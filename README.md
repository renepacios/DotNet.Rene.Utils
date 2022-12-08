# DotNet Rene.Utils
Rene.Utils is a set of useful utilities and extensions of recurrent usage


## Builds
[![Build Status](https://rene.visualstudio.com/Github.DotNet.Rene.Utils/_apis/build/status/rene15009.DotNet.Rene.Utils?branchName=main)](https://rene.visualstudio.com/Github.DotNet.Rene.Utils/_build/latest?definitionId=3&branchName=main)
![GitHub Workflow Status](https://img.shields.io/github/workflow/status/rene15009/DotNet.Rene.Utils/.NET%20Core?label=build&logo=github)
[![Build status](https://ci.appveyor.com/api/projects/status/h7hn4uo4t3qif9pt?svg=true)](https://ci.appveyor.com/project/rene15009/dotnet-rene-utils)
[![Build status](https://ci.appveyor.com/api/projects/status/h7hn4uo4t3qif9pt/branch/main?svg=true)](https://ci.appveyor.com/project/rene15009/dotnet-rene-utils/branch/main)
[![Build Status](https://ci.appveyor.com/api/projects/status/github/rene15009/DotNet.Rene.Utils?branch=main&svg=true&passingText=passing%20-%20OK)](https://ci.appveyor.com/api/projects/status/github/rene15009/DotNet.Rene.Utils?branch=main&svg=true&passingText=master%20-%20OK)

![CodeQL](https://github.com/rene15009/DotNet.Rene.Utils/workflows/CodeQL/badge.svg)
![AppVeyor tests](https://img.shields.io/appveyor/tests/rene15009/dotnet-rene-utils)
[![GitHub issues](https://img.shields.io/github/issues/rene15009/DotNet.Rene.Utils)](https://github.com/rene15009/DotNet.Rene.Utils/issues)
[![GitHub forks](https://img.shields.io/github/forks/rene15009/DotNet.Rene.Utils)](https://github.com/rene15009/DotNet.Rene.Utils/network)
[![GitHub stars](https://img.shields.io/github/stars/rene15009/DotNet.Rene.Utils)](https://github.com/rene15009/DotNet.Rene.Utils/stargazers)

[![GitHub license](https://img.shields.io/github/license/rene15009/DotNet.Rene.Utils)](https://github.com/rene15009/DotNet.Rene.Utils/blob/master/LICENSE)

[![NuGet](https://img.shields.io/nuget/v/Rene.Utils.Core.svg?style=plastic&logo=NuGet&label=Rene.Utils&color=green)](https://www.nuget.org/packages/Rene.Utils.Core/) 
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Rene.Utils.Core?color=red&label=Preview%20Version&logo=NuGet&style=plastic)
[![NuGet](https://img.shields.io/nuget/dt/Rene.Utils.Core.svg?style=plastic&logo=NuGet)](https://www.nuget.org/packages/Rene.Utils.Core/)

# What is Rene.Utils?
Is a small library that complements .NET with useful helpers clases. I wrote  a version of Rene.Utils with VB.NET (follies of youth) for .NET 2, 3.5,.. and mantein this version over the years. <b>This is a new project build from scratch and maintained in my freetime</b>

#### Important:
I use this project to practice, techniques of testing, CI/CD, manage a open source project and so on. 
For this reason new features in library could take time to be avaliable in main branch. I have while write test, docs ... You can get pre-relase version from nuget or alpha branch.

## .NET Framework suport
DotNet Rene Utils is built using .net Standard 2.1 and supports the `4.0+ .NET Framework` as well as `.NET Core`


## .NET Core CLI Installation
1. Open a command line and switch to the directory that contains your project file.
2. Use the following command to install a Rene.Utils from Nuget repository:
    ```dotnetcli
    dotnet add package Rene.Utils.Core [-pre]
    ```  
3. After the command completes, look at the project file to make sure the package was installed.
   You can open the `.csproj` file to see the added reference:
    ```xml
   <ItemGroup>
        <PackageReference Include="Rene.Utils.Core" Version="0.3.1" />
   </ItemGroup>
    ```
####  -> Install a specific version of a package
If the version is not specified, NuGet installs the latest version of the package. You can also use the [dotnet add package](/dotnet/core/tools/dotnet-add-package?tabs=netcore2x) command to install a specific version of a Nuget package:
```dotnetcli
dotnet add package Rene.Utils.Core --version 0.3.1-preview-16
```

`  ` 
## .NET Full Framework Installation
1. Ensure Nuget is avaliable or install it. [Instructions to install NuGet](http://docs.nuget.org/docs/start-here/installing-nuget). 
2. Install [Rene.Utils](https://www.nuget.org/packages/Rene.Utils.Core/) from the package manager console:
```
PM> Install-Package Rene.Utils.Core 
```

#### Release Notes
 Coming soon

##### License
`   `DotNet Rene Utils is licensed under The MIT License (MIT), check the [LICENSE](https://github.com/rene15009/DotNet.Rene.Utils/blob/master/LICENSE) file for details.

##### Version
![Nuget](https://img.shields.io/nuget/v/Rene.Utils.Core?color=white&label=&style=for-the-badge)

##### Development
`   `C# 


