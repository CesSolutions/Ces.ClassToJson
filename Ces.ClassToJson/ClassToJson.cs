using System.Reflection;
using System.Text;

namespace Ces.ClassToJson
{
    public class ClassToJson
    {
        /// <summary>
        /// option must be accessible after initianlization because initialze method
        /// configure parameters and may be used by developer
        /// </summary>
        public ClassToJsonOption _option;
        private Assembly _assembly;

        public ClassToJson(ClassToJsonOption option)
        {
            _option = option;
            Initialize();
        }

        /// <summary>
        /// Load assembly
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        private void Initialize()
        {
            if (string.IsNullOrEmpty(_option.AssemblyPath))
                throw new Exception("Assembly path is not defined");

            if (!_option.UseAssemblyPath && string.IsNullOrEmpty(_option.OutpuPath))
                throw new Exception("Output path is not defined");

            if (_option.UseAssemblyPath)
                _option.OutpuPath = System.IO.Path.Combine(
                    System.IO.Path.GetDirectoryName(_option.AssemblyPath),
                    "ConvertToJson" + DateTime.Now.ToString(" _ yyyy-MM-dd _ HH-mm-ss") + ".json");

            _assembly = Assembly.LoadFrom(_option.AssemblyPath);
        }

        /// <summary>
        /// Return all public classes
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public async Task<List<Type>> GetObjectsAsync(
            CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var result = _assembly.GetTypes().Where(x => x.IsClass && x.IsPublic).ToList();
            return await Task.FromResult(result);
        }

        /// <summary>
        /// Return propery list of a class
        /// </summary>
        /// <param name="classFullName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="OperationCanceledException"></exception>
        public async Task<List<PropertyInfo>> GetPropertiesAsync(
            string classFullName, CancellationToken cancellationToken = default)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var type = _assembly
                .GetTypes()
                .FirstOrDefault(x => x.IsClass && x.IsPublic && x.FullName == classFullName);

            if (type == null)
                return await Task.FromResult(new List<PropertyInfo>());

            var result = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return await Task.FromResult(result.ToList());
        }

        /// <summary>
        /// Convert list of types to json file
        /// </summary>
        /// <param name="typesFulleName">List of typs' fullname</param>
        /// <returns></returns>
        public async Task ConvertToJsonAsync(
            List<string> typesFulleName, CancellationToken cancellationToken = default)
        {
            await CreateJsonFileAsync(typesFulleName, cancellationToken);
        }

        /// <summary>
        /// Convert entire assembly to json file 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task ConvertToJsonAsync(
            CancellationToken cancellationToken = default)
        {
            var classList = await GetObjectsAsync(cancellationToken);
            var typesFulleName = classList.DistinctBy(x => x.FullName).Select(x => x.FullName).ToList();

            await CreateJsonFileAsync(typesFulleName, cancellationToken);
            await Task.CompletedTask;
        }

        private async Task CreateJsonFileAsync(
            List<string> typesFulleName, CancellationToken cancellationToken = default)
        {
            if (System.IO.File.Exists(_option.OutpuPath) && !_option.OverWrite)
                throw new Exception("Overwrite is not allowes");

            var sb = new StringBuilder();

            using (FileStream fs = new FileStream(_option.OutpuPath, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(stream: fs))
                {
                    sb.Append("{");

                    for (int n = 0; n < typesFulleName.Count; n++)
                    {
                        if (cancellationToken.IsCancellationRequested)
                            throw new OperationCanceledException();

                        var result = await GetPropertiesAsync(typesFulleName[n]);

                        if (_option.RemoveNamespaceDelimiter)
                            sb.Append($"\"{typesFulleName[n].Replace(".", _option.NamespaceDelimiter.ToString().Trim())}\":");
                        else
                            sb.Append($"\"{typesFulleName[n]}\":");

                        sb.Append("{");

                        for (int i = 0; i < result.Count; i++)
                        {
                            if (cancellationToken.IsCancellationRequested)
                                throw new OperationCanceledException();

                            //In JSON format, Last item shall not have (,)
                            if (_option.AddDataType)
                                sb.Append(SetDataType(result[i]) + (i == result.Count - 1 ? string.Empty : ","));
                            else
                                sb.Append($"\"{result[i].Name}\":\"\"{(i == result.Count - 1 ? string.Empty : ",")}");
                        }

                        //In JSON format, Last item shall not have (,)
                        if (n == typesFulleName.Count - 1)
                            sb.Append("}");
                        else
                            sb.Append("},");

                        await sw.WriteAsync(sb.ToString());
                        sb.Clear();
                    }

                    sb.Append("}");
                    await sw.WriteAsync(sb.ToString());
                    sb.Clear();
                }
            }

            await Task.CompletedTask;
        }

        private string GetDataType(PropertyInfo propertyInfo)
        {
            var dataType = propertyInfo.GetType();

            if (dataType == typeof(string))
                return "string";
            else if (dataType == typeof(float))
                return "float";
            else if (dataType == typeof(double))
                return "double";
            else if (dataType == typeof(decimal))
                return "decimal";
            else if (dataType == typeof(DateTime))
                return "datetime";
            else if (dataType == typeof(TimeSpan))
                return "timespan";
            else if (dataType == typeof(DateTimeOffset))
                return "datetime offset";
            else if (dataType == typeof(sbyte))
                return "sbyte";
            else if (dataType == typeof(byte))
                return "byte";
            else if (dataType == typeof(byte[]))
                return "byte[]";
            else if (dataType == typeof(short))
                return "ushort";
            else if (dataType == typeof(int))
                return "int";
            else if (dataType == typeof(uint))
                return "uint";
            else if (dataType == typeof(long))
                return "long";
            else if (dataType == typeof(ulong))
                return "ulong";
            else if (dataType == typeof(bool))
                return "bool";
            else if (dataType == typeof(char))
                return "char";
            else if (dataType == typeof(Guid))
                return "guid";
            else
                return "object";
        }

        /// <summary>
        /// When using json, third part application can diagnose data type by 
        /// each value. So, this method based on option class can assign a value
        /// to each type of property
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        private object SetDataType(PropertyInfo propertyInfo)
        {
            var dataType = propertyInfo.PropertyType;

            if (dataType == typeof(string))
                return $"\"{propertyInfo.Name}\":\"acb\"";
            else if (dataType == typeof(float) || dataType == typeof(float?))
                return 3.14;
            else if (dataType == typeof(double) || dataType == typeof(double?))
                return 12345.6789;
            else if (dataType == typeof(decimal) || dataType == typeof(decimal?))
                return 99999.99;
            else if (dataType == typeof(DateTime) || dataType == typeof(DateTime?))
                return $"\"{propertyInfo.Name}\":\"2025-06-29T15:30:00\"";
            else if (dataType == typeof(TimeSpan) || dataType == typeof(TimeSpan?))
                return $"\"{propertyInfo.Name}\":\"12:34:56\"";
            else if (dataType == typeof(DateTimeOffset) || dataType == typeof(DateTimeOffset?))
                return $"\"{propertyInfo.Name}\":\"2025-06-29T23:45:00+03:30\"";
            else if (dataType == typeof(sbyte) || dataType == typeof(sbyte?))
                return -128;
            else if (dataType == typeof(byte) || dataType == typeof(byte?))
                return 255;
            else if (dataType == typeof(byte[]) || dataType == typeof(byte?[]))
                return $"\"{propertyInfo.Name}\":\"AAECAwQFBgc\"";
            else if (dataType == typeof(short) || dataType == typeof(short?))
                return 32767;
            else if (dataType == typeof(ushort) || dataType == typeof(ushort?))
                return 65535;
            else if (dataType == typeof(int) || dataType == typeof(int?))
                return 123;
            else if (dataType == typeof(uint) || dataType == typeof(uint?))
                return 4294967295;
            else if (dataType == typeof(long) || dataType == typeof(long?))
                return 9223372036854775807;
            else if (dataType == typeof(ulong) || dataType == typeof(ulong?))
                return 18446744073709551615;
            else if (dataType == typeof(bool) || dataType == typeof(bool?))
                return $"\"{propertyInfo.Name}\":{true.ToString().ToLower()}";
            else if (dataType == typeof(char) || dataType == typeof(char?))
                return $"\"{propertyInfo.Name}\":\"A\"";
            else if (dataType == typeof(Guid) || dataType == typeof(Guid?))
                return $"\"{propertyInfo.Name}\":\"3fa85f64-5717-4562-b3fc-2c963f66afa6\"";
            else
                return null;
        }
    }
}
