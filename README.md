# Ces.ClassToJson + Ces.ClassToJson.UI

<p>This packge with UI help to create JSON file to use in report designers as **ObjectModel** (For example in StimulReport).</p>

<a href="https://www.nuget.org/packages/Ces.ClassToJson/">Nuget Package</a>

***

## Ces.ClassToJson.UI
> Feature
  - **TreeView:** Show classes inassembly base on namespaces.
  - **OutputWindow:** Shows created JSON string.
  - **ExpandAll:** Expands all nodes in tree view.
  - **Clear Selection:** Uncheck all selected nodes in tree view.
  - **Cancel:** Cancel async operation while application start to convert models to JSON string as stream.
  - **Select Assembly:** Open dialog to select assembly file. Selected file path is show in blue text and if user click on it, application open directory.
  - **Output Path:** Open save dialog to set path and name for JSON string. This button is disable by default because application use assembly path to save JSON file. Selected file path is show in green text and if user click on it, application open output directory.
  - **Use same path:** By default application use assembly pathto save created  JSON file otherwise uncheck thisoption then choose desire path and file name.
  - **Read Obhects:** Read entire assembly then show objects in tree view based on their namespace.
  - **Convert To Json:** Convert selected objects in tree view ot entire assembly to JSON string and save to file.
  - **All Objects:** If user check this, application convert all objects inassembly to jsonstring and save to output file and ignore selected objects in tree view.
  - **Overwrite if file exist:** Because of default naming of out JSON file consist of a fixed string and current date with time (ClassToJSon _ 2025-10-25 _ 23-20-65), it is possible that user click on convert button twice in a minute. If file exist already, application throw an exception otherwise user check this option to overwrite on existig file.

<div align="center">
<img src="https://github.com/user-attachments/assets/9137a748-f2d6-491f-a476-bbd692bb363d">
</div>

***

## Ces.ClassToJson
> ClassToJsonOption

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
    }

    public enum OutputTypeEnum
    {
        Json
    }
}

```

## Methods
- **GetObjectsAsync:** Return all classes in assembly then return a `List<Type>`.
- **GetPropertiesAsync:** Return `List<string>` that consist of all properties of an object.
- **ConvertToJsonAsync:** This method hae two overloads. If user dose not pass paramter, this method converts entire asembly to json otherwise only selected objects will convert to json. This method save result to file as stream.

## How to Use
Create an instance of `ClassToJson` and pass `ClassToJsonOption` then use methods

```csharp
var option = new Ces.ClassToJson.ClassToJsonOption
{
    AssemblyPath = _assembplyPath,
    OutpuPath = _outputPath,
    UseAssemblyPath = chkUseSamePath.Checked,
    OverWrite = chkOverwrite.Checked
};

_cls = new Ces.ClassToJson.ClassToJson(option);
```
