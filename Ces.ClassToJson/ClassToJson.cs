using System.Reflection;

namespace Ces.ClassToJson
{
    public class ClassToJson
    {
        private ClassToJsonOption _option;
        private Assembly? _assembly;

        public ClassToJson(ClassToJsonOption option)
        {
            _option = option;
        }

        public async Task CovertAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            if (string.IsNullOrEmpty(_option.AssemblyPath))
                throw new ArgumentNullException(nameof(_option.AssemblyPath));

            if(!_option.UseAssemblyPath && string.IsNullOrEmpty(_option.OutpuPath))
                throw new ArgumentNullException(_option.OutpuPath);

            _assembly = Assembly.LoadFrom(_option.AssemblyPath);

            if (_option.OutputType == OutputTypeEnum.Json)
                await ConvertToJsonAsync(cancellationToken);
        }

        private async Task ConvertToJsonAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                throw new OperationCanceledException();

            var classes = _assembly.GetTypes();
        }
    }
}
