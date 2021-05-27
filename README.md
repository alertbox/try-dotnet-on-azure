# Try out Skol ASP.NET Web API with CQRS pattern (C#)

This repository demonstrates developing CQRS pattern for ASP.NET Web API with .NET 6.0 using VS Code and  Development Containers.

### What's included:
- Uses .NET 6.0 development container found in @kosalanuwan/devcontainers
- Uses Top-level Class, Minimal Hosting, Record types, et al
- Uses ASP.NET Core for the RESTful Web API
- Uses EF Core InMemory for persisting data
- Uses DbContext for the unit of work and repository pattern
- Uses Mediatr package for Publisher/Subscriber pattern
- Uses Onion Architecture for solution structure and layers
- Uses REST Client extension for trying out the rest-endpoints from VS Code
- Configured to build and run from the VS Code tasks

## Quick Start
If you want to fork or clone the repo locally, then open up the source code in a remote container.

```zsh
#!/bin/zsh
gh repo clone kosalanuwan/vscode-remote-try-skol-webapi
cd vscode-remote-try-skol-webapi
```

With VS Code:
```zsh
dotnet restore
dotnet build
dotnet watch --project Rest/Skol.Rest.Services.csproj run
```

## Useful Commands

```bash
# Create new projects
dotnet new classlib -n Skol.Domain -o Domain
dotnet new classlib -n Skol.Application -o Application
dotnet new classlib -n Skol.Infrastructure -o Infrastructure
dotnet new webapi -n Skol.Rest -o Rest
# Update .vscode/tasks.json > watch > command > Path to starter project.
```

```bash
# Add project-to-project (P2P) references
dotnet add Rest/ reference Application/ Infrastructure/
dotnet add Application/ reference Domain/
dotnet add Infrastructure/ reference Application/
```

```bash
# Create a solution file and add projects
dotnet new sln -n Skol
dotnet sln add Domain/ Infrastructure/ Application/ Rest/
```

```zsh
cd Application/
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.Extensions.Configuration 
```

```bash
cd Infrastructure/
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

```bash
cd Rest/
dotnet add package Microsoft.AspnetCore.Mvc.Versioning --prerelease
```

- [The VS Code Remote - Containers docs][vscode-remote-docs] is a good source to learn more about `.devcontainer.json` configuration options and its usage.
- [See .NET Core CLI page][dotnet-core-cli-docs] to learn the full-blown `dotnet` options.

[devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers
[dotnet-sdk-docker-image]: https://hub.docker.com/_/microsoft-dotnet-sdk/
[azure-cli-docs]: https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli
[node-js-docs]: https://nodejs.dev/learn
[vscode-remote-docs]: https://code.visualstudio.com/docs/remote/containers
[dotnet-core-cli-docs]: https://docs.microsoft.com/en-us/dotnet/core/tools/
