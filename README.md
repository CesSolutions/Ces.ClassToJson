# Ces.ClassToJson + UI

<p>This packge with UI help to create JSON file to use in report designers as **ObjectModel** (For example in StimulReport).</p>

<a href="https://www.nuget.org/packages/Ces.ClassToJson/">Nuget Package</a>

***

> Updates v1.5.1

- UI chaged and added a check box to add dada type to json proeprty
- Nuget package create more accurate json string

***

## Ces.ClassToJson.UI
  - **TreeView:** Show classes inassembly base on namespaces.
  - **OutputWindow:** Shows created JSON string.
  - **ExpandAll:** Expands all nodes in tree view.
  - **Clear Selection:** Uncheck all selected nodes in tree view.
  - **Cancel:** Cancel async operation while application start to convert models to JSON string as stream.
  - **Select Assembly:** Open dialog to select assembly file. Selected file path is show in blue text and if user click on it, application open directory.
  - **Output Path:** Open save dialog to set path and name for JSON string. This button is disable by default because application use assembly path to save JSON file. Selected file path is show in green text and if user click on it, application open output directory.
  - **Use same path:** By default application use assembly pathto save created  JSON file otherwise uncheck thisoption then choose desire path and file name.
  - **Convert To Json:** Convert selected objects in tree view ot entire assembly to JSON string and save to file.
  - **All Objects:** If user check this, application convert all objects inassembly to jsonstring and save to output file and ignore selected objects in tree view.
  - **Overwrite if file exist:** Because of default naming of out JSON file consist of a fixed string and current date with time (ClassToJSon _ 2025-10-25 _ 23-20-65), it is possible that user click on convert button twice in a minute. If file exist already, application throw an exception otherwise user check this option to overwrite on existig file.
  - **Remove Namespace Delimiter:** If check this option and do not define any delimiter in text box, (.) will remove from namespace
  - **AddDataType:** Add value in front of property of json model randomly (StimulDesinger detect data type by value)

<div align="center">
<img src="https://github.com/user-attachments/assets/3fe2ee86-7949-4f96-91da-ed0edb46474a">
</div>

***

## Ces.ClassToJson

```csharp
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
        public bool AddDataType { get; set; }
    }

    public enum OutputTypeEnum
    {
        Json
    }
}

```

## How to Use
Create an instance of `ClassToJson` and pass `ClassToJsonOption` then use methods

```csharp
var option = new Ces.ClassToJson.ClassToJsonOption
{
    AssemblyPath = _assembplyPath,
    OutpuPath = _outputPath,
    UseAssemblyPath = chkUseSamePath.Checked,
    OverWrite = chkOverwrite.Checked,
    RemoveNamespaceDelimiter = chkRemoveNamespaceDelimiter.Checked,
    NamespaceDelimiter = string.IsNullOrEmpty(txtNamespaceDelimiter.Text) ? null : char.Parse(txtNamespaceDelimiter.Text),
    AddDataType = chkAddDataType.Checked,
};

_cls = new Ces.ClassToJson.ClassToJson(option);
```

## Methods
- **GetObjectsAsync:** Return all classes in assembly then return a `List<Type>`.
- **GetPropertiesAsync:** Return `List<string>` that consist of all properties of an object.
- **ConvertToJsonAsync:** This method hae two overloads. If user dose not pass paramter, this method converts entire asembly to json otherwise only selected objects will convert to json. This method save result to file as stream.
