```
Copyright (c) 2019-2020 Yoann MOUGNIBAS

This file is part of LazyCook.

LazyCook is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

LazyCook is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LazyCook.  If not, see <https://www.gnu.org/licenses/>.
```
# General

The aim to this project is to make the use of a "KitchenAid© Cook Processor" easier.

# For developers

## Requirements (Microsoft provided)

* .NET Core 3.1 SDK (https://dotnet.microsoft.com/download)
* Any text editor with UTF-8 and "CR LF" capabilities.

If Visual Studio 2019 is used, select `Build only` hint source on "Error list" tab.

Gecko driver (for selenium webdriver) required.
Add it to your PATH.
https://www.selenium.dev/documentation/en/getting_started_with_webdriver/third_party_drivers_and_plugins/

## Build instructions

```
dotnet clean
dotnet build
```

## Test instructions

```
dotnet clean
dotnet test
```

## Run instructions

```
dotnet clean
dotnet run --project webassembly
```

Then navigate to `http://localhost:5000/`

## Misc

### Source file encoding and end of line convention

* UTF-8 (without BOM)
* "CR LF" (windows)

### FxCop (Microsoft provided, enabled by default)

Run `dotnet add package Microsoft.CodeAnalysis.FxCopAnalyzers` on each project.

### StyleCop (Third-party provided, enabled by default)

Run `dotnet add package StyleCop.Analyzers` on each project.
Add the following lines to `<ItemGroup>...</ItemGroup>` section :

```
<None Remove="stylecop.json" />
<AdditionalFiles Include="../../stylecop.json" />
```

### Code Coverage (Third-party provided, enabled by default)

Run `dotnet add package coverlet.msbuild` on each test project.
Add the following line to `<ItemGroup>...</ItemGroup>` section : `<CollectCoverage>true</CollectCoverage>`
