# FlaxCLI

FlaxCLI provides a command-line interface and tries to fill in the gap of a missing flax launcher for other platforms besides windows.

---

## Installation guide

Requires atleast .NET 5.

### Windows

* Download the source.
* Run `build.bat`
* Run `install.bat`
* Use the command `flax` to invoke the program.

### Linux

* Download the source and run `dotnet pack src` followed by `dotnet tool install --global --add-source ./nupkg FlaxCLI`
