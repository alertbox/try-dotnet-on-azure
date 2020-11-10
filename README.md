# Try out C# (.NET)

Develop in .NET 5.0+, includes minimal required set up to get started. In case you were wondering, this `.devcontainer` is:

- Based on `dotnetcore` development container found in [@microsoft/vscode-dev-containers][devcontainers-repo]
- Ideal for [.NET 5.0+][dotnet-sdk-docker-image] with .NET Core, .NET Core CLI, and ASP.NET Core, and
- Includes [Azure CLI][azure-cli-docs] and [Node][node-js-docs]

## Configuration Options

```bash
# Create new projects
dotnet new webapi -n Weather.Rest -o src/Rest
# Update .vscode/tasks.json > watch > command > Path to starter project.
dotnet new classlib -n Weather.Application -o src/Application
dotnet new classlib -n Weather.Infrastructure -o src/Infrastructure
```

```bash
# Add project-to-project (P2P) references
dotnet add src/Rest reference src/Application src/Infrastructure
dotnet add src/Infrastructure reference src/Application
```

```bash
# Create a solution file and add projects
dotnet new sln Weather
dotnet sln add src/Rest src/Application src/Infrastructure
```

- [The VS Code Remote - Containers docs][vscode-remote-docs] is a good source to learn more about `.devcontainer.json` configuration options and its usage.
- [See .NET Core CLI page][dotnet-core-cli-docs] to learn the full-blown `dotnet` options.

[devcontainers-repo]: https://github.com/microsoft/vscode-dev-containers
[dotnet-sdk-docker-image]: https://hub.docker.com/_/microsoft-dotnet-sdk/
[azure-cli-docs]: https://docs.microsoft.com/en-us/cli/azure/get-started-with-azure-cli
[node-js-docs]: https://nodejs.dev/learn
[vscode-remote-docs]: https://code.visualstudio.com/docs/remote/containers
[dotnet-core-cli-docs]: https://docs.microsoft.com/en-us/dotnet/core/tools/
