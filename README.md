# Try out the minimal API with .NET 6.0 (preview)

This [Cocktails][cocktails-list] :cocktail: ordering backend API code demonstrates developing a minimal API with CQRS pattern for ASP.NET Web API on .NET 6.0 preview using VS Code and Development Containers.

> Originally, **Skol** is the Swedish way of saying :beers: Cheers! 

### What's included:
- Uses .NET 6.0 development container found in @kosalanuwan/devcontainers
- Uses Top-level Class, Minimal Hosting, Record types, et al.
- Uses ASP.NET Core for the RESTful Web API
- Uses API Versioning, REST Convensions, et al.
- Uses Seed Data for EF Core InMemory database
- Uses DbContext for the Unit of Work and repository pattern
- Uses Mediatr package for Publisher/Subscriber pattern
- Uses Onion Architecture for solution structure and layers
- Uses REST Client extension for trying out the rest-endpoints from VS Code
- Configured to build and run from the VS Code tasks

## Todo

- [X] Use of Mediatr Behavior for post process
- [ ] Use of Global imports
- [ ] Use of Web Application hosting for API.NET Web API
- [ ] Use of Minimal API routes with versioning

## Quick Start
If you want to fork or clone the repo locally, then open up the source code in a remote container.

```zsh
#!/bin/zsh
# Clone with GitHub CLI
gh repo clone kosalanuwan/vscode-remote-try-skol-minimal-api
cd vscode-remote-try-skol-minimal-api
```

With VS Code:
```zsh
#!/bin/zsh
# Run in watch mode
dotnet restore
dotnet build
dotnet watch --project Services/Skol.Services.csproj run
```

### Troubleshooting
Unable to configure HTTPS endpoint. No server certificate was specified, and the default developer certificate could not be found.
```zsh
#!/bin/zsh
# Clean all HTTP developer certs
dotnet dev-certs https --clean
# Trust the cert on the current platform
dotnet dev-certs https -t
```

## Useful Commands


```zsh
#!/bin/zsh
# Create new projects
dotnet new classlib -n Skol.Domain -o Domain
dotnet new classlib -n Skol.Application -o Application
dotnet new classlib -n Skol.Infrastructure -o Infrastructure
dotnet new webapi -n Skol.Services -o Services
# Update .vscode/tasks.json > watch > command > Path to starter project.
```

```zsh
#!/bin/zsh
# Add project-to-project (P2P) references
dotnet add Services/ reference Application/ Infrastructure/
dotnet add Application/ reference Domain/
dotnet add Infrastructure/ reference Application/
```

```zsh
#!/bin/zsh
# Create a solution file and add projects
dotnet new sln -n Skol
dotnet sln add Domain/ Infrastructure/ Application/ Services/
```

```zsh
#!/bin/zsh
# Add NuGet packages for Application
cd Application/
dotnet add package MediatR.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.Extensions.Configuration 
```

```bash
#!/bin/zsh
# Add NuGet packages for Infrastructure
cd Infrastructure/
dotnet add package Microsoft.EntityFrameworkCore.InMemory
```

```bash
#!/bin/zsh
# Add NuGet packages for Versioning the API
cd Services/
dotnet add package Microsoft.AspnetCore.Mvc.Versioning --prerelease
```

- [The VS Code Remote - Containers docs][vscode-remote-docs] is a good source to learn more about `.devcontainer.json` configuration options and its usage.
- [See .NET Core CLI page][dotnet-core-cli-docs] to learn the full-blown `dotnet` options.

[cocktails-list]: https://www.thespruceeats.com/a-to-z-cocktail-recipes-3962886
[devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers
[dotnet-sdk-docker-image]: https://hub.docker.com/_/microsoft-dotnet-sdk/
[azure-cli-docs]: https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli
[node-js-docs]: https://nodejs.dev/learn
[vscode-remote-docs]: https://code.visualstudio.com/docs/remote/containers
[dotnet-core-cli-docs]: https://docs.microsoft.com/en-us/dotnet/core/tools/
