# TM File Parser

This repo contains code for the parser to extract data from .tm7 and .tb7 files. 

The repo contains two projects

- TMFileParser
- TMFileConverter

## TMFileParser

TMFileParser is .NET core(Currently .NET core 5.0) class library published as a nuget package.
The NuGet package can be consumed from NuGet.org . 

### Features

* Class Library Built on . NET 5.0.
* Support to parse all the data in .tm7 and .tb7 files or get specific data like Data Flows.

## TMFileConverter

TMFileParser is cross-platform .NET core console application that can be used to extract data from .tm7 and .tb7 files.

### Features

* Cross - Platform CLI Built on .NET 5.0.
* Self contained .NET Core Application.
* Support to convert to JSON.
* Support to convert all the data in .tm7 and .tb7 files or get specific data like Data Flows.

### Instructions

Download the OS specific binaries (Windows, Mac OS, Linus). Extract TMFileConverter.zip. Navigate TMFileConverter from the command prompt or terminal and invoke 'TMFileConverter.exe' or 'TMFileConverter'.

## Contributing

This project welcomes contributions and suggestions.  Most contributions require you to agree to a
Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us
the rights to use your contribution. For details, visit https://cla.opensource.microsoft.com.

When you submit a pull request, a CLA bot will automatically determine whether you need to provide
a CLA and decorate the PR appropriately (e.g., status check, comment). Simply follow the instructions
provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/).
For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or
contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.

## Trademarks

This project may contain trademarks or logos for projects, products, or services. Authorized use of Microsoft 
trademarks or logos is subject to and must follow 
[Microsoft's Trademark & Brand Guidelines](https://www.microsoft.com/en-us/legal/intellectualproperty/trademarks/usage/general).
Use of Microsoft trademarks or logos in modified versions of this project must not cause confusion or imply Microsoft sponsorship.
Any use of third-party trademarks or logos are subject to those third-party's policies.
