# dotnet-practice

This repository contains a minimal .NET backend project created with the
ASP.NET Core Web API template. It's intended to help beginners get
started with building and running a .NET backend inside the workspace.

## Getting Started

### Prerequisites

* [.NET SDK 10.0](https://dotnet.microsoft.com/download) (you already
  verified `dotnet --version` prints `10.0.x`)
* Optional: an editor such as Visual Studio Code with the C# extension
  for IntelliSense and debugging.

### Building and Running

Open a terminal in the workspace root and run the following commands:

```bash
# change into the project directory
cd backend

# download any NuGet dependencies (run once or after adding new ones)
dotnet restore

# compile the code
dotnet build

# run the app. by default it will listen on https://localhost:7229
# (ports may vary)
dotnet run
```

You can test the sample endpoint by browsing to
`https://localhost:7229/weatherforecast` or using `curl`.

### Learning Resources

* https://docs.microsoft.com/aspnet/core/getting-started
* https://docs.microsoft.com/dotnet/core/tutorials/  

Feel free to poke around `backend/Program.cs` to see how the minimal API
is wired up – comments have been added to help explain each section.
