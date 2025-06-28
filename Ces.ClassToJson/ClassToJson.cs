using System.Reflection;
using System.Text;

namespace Ces.ClassToJson
{
    public class ClassToJson
    {
        private ClassToJsonOption _option;
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
        public async Task<List<Type>> GetObjectsAsync(CancellationToken cancellationToken = default)
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
            string classFullName,
            CancellationToken cancellationToken = default)
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
        /// Create json string
        /// </summary>
        /// <param name="typesFulleName">List of typs' fullname</param>
        /// <returns></returns>
        public async Task ConvertToJsonAsync(
            List<string> typesFulleName,
            CancellationToken cancellationToken = default)
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

                        sb.Append($"\"{typesFulleName[n]}\":");
                        sb.Append("{");

                        for (int i = 0; i < result.Count; i++)
                        {
                            if (cancellationToken.IsCancellationRequested)
                                throw new OperationCanceledException();

                            //In JSON format, Last item shall not have (,)
                            if (i == result.Count - 1)
                                sb.Append($"\"{result[i].Name}\" : \"\"");
                            else
                                sb.Append($"\"{result[i].Name}\" : \"\",");
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

        /// <summary>
        /// Create json string
        /// </summary>
        /// <param name="typesFulleName">List of typs' fullname</param>
        /// <returns></returns>
        public async Task ConvertToJsonAsync(
            CancellationToken cancellationToken = default)
        {
            if (System.IO.File.Exists(_option.OutpuPath) && !_option.OverWrite)
                throw new Exception("Overwrite is not allowes");

            var sb = new StringBuilder();
            var classList = await GetObjectsAsync(cancellationToken);
            var typesFulleName = classList.DistinctBy(x => x.FullName).Select(x => x.FullName).ToList();

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

                        sb.Append($"\"{typesFulleName[n]}\":");
                        sb.Append("{");

                        for (int i = 0; i < result.Count; i++)
                        {
                            if (cancellationToken.IsCancellationRequested)
                                throw new OperationCanceledException();

                            //In JSON format, Last item shall not have (,)
                            if (i == result.Count - 1)
                                sb.Append($"\"{result[i].Name}\" : \"\"");
                            else
                                sb.Append($"\"{result[i].Name}\" : \"\",");
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
    }
}
