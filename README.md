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

## Project links

* Project repository : https://github.com/mougnibas/LazyCook
* Project DevOps : https://mougnibas.visualstudio.com/LazyCook

## Sources convention

* "CR LF" line ending
* UTF-8 (without BOM)
* Default StyleCop and FxCop rules

## Requirements

* .NET Core 3.1 SDK (https://dotnet.microsoft.com/download)
* Visual Studio Code (https://code.visualstudio.com/Download)
* Gecko driver added to PATH (https://www.selenium.dev/documentation/en/getting_started_with_webdriver/third_party_drivers_and_plugins/)
* Google Chrome (https://www.google.com/chrome/)

## Project import

* From Visual Studio Code, open Workspace file `LazyCook.code-workspace`
* Install recommended extensions

## Application lifecycle instructions

### Clean

`Terminal / Run Task / clean`

### Build

`Terminal / Run Build Task`

### Test

`Terminal / Run Task / test`

Then wait a couple of minutes.

### Run

`Run / Run Without Debuging (Ctrl+F5)`

### Debug

`Run / Start Debuging (F5)`
