using System.Reflection;

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

        private void Initialize()
        {
            if (string.IsNullOrEmpty(_option.AssemblyPath))
                throw new ArgumentNullException(nameof(_option.AssemblyPath));

            if (!_option.UseAssemblyPath && string.IsNullOrEmpty(_option.OutpuPath))
                throw new ArgumentNullException(_option.OutpuPath);

            _assembly = Assembly.LoadFrom(_option.AssemblyPath);
        }

        public async Task<int> CovertAsync(CancellationToken cancellationToken)
        {
            if (_option.OutputType == OutputTypeEnum.Json)
                await ConvertToJsonAsync(cancellationToken);

            return 0;
        }

        public async Task<List<Type>> GetTypeListAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var result = _assembly.GetTypes();
            return await Task.FromResult(result.ToList());
        }

        public async Task<List<PropertyInfo>> GetPropertyListAsync(string typeFullName, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var type = _assembly
                .GetTypes()
                .FirstOrDefault(x => x.FullName == typeFullName);

            if (type == null)
                return await Task.FromResult(new List<PropertyInfo>());

            var result = type
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);

            return await Task.FromResult(result.ToList());
        }

        private async Task<int> ConvertToJsonAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var classes = _assembly.GetTypes();

            return await Task.FromResult(0);
        }
    }
}
