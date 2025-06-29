namespace Ces.ClassToJson
{
    public class ClassToJsonOption
    {
        public string AssemblyPath { get; set; } = default!;
        public string OutpuPath { get; set; } = default!;
        /// <summary>
        /// if true: Use [AssemblyPath] as [OutpuPath] to save result.
        /// In this case [OutpuPath] can be null or empty
        /// </summary>
        public bool UseAssemblyPath { get; set; } = true;
        public bool OverWrite { get; set; } = false;
        public OutputTypeEnum OutputType { get; set; } = OutputTypeEnum.Json;
        /// <summary>
        /// A namespace delimited by dot (.) and user can replace with another character
        /// </summary>
        public bool RemoveNamespaceDelimiter { get; set; }        
        public char? NamespaceDelimiter { get; set; }
    }

    public enum OutputTypeEnum
    {
        Json
    }
}
