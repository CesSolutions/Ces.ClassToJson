# Ces.ClassToJson + Ces.ClassToJson.UI

<p>This packge with UI help to create JSON file to use in report designers as **ObjectModel** (For example in StimulReport).</p>

<a href="https://www.nuget.org/packages/Ces.ClassToJson/">Nuget Package</a>

***

> UI Features
> 
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
<img src="">
</div>
