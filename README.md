# Tryout Azure & .NET Stuff

[<img align="right" alt=".NET C-sharp" width="128rem" src="https://raw.githubusercontent.com/github/explore/93d8a67084f94b2a444e510199a6e7622e5b09a3/topics/dotnet/dotnet.png" />][dotnet-quick-start]

This template repo serves as a flavor of ready-to-go .NET and Azure development container.

> Originally, this dev container was created to tryout [.NET preview versions][dotnet-versions] without having to install them locally.

[dotnet-quick-start]: https://learn.microsoft.com/en-us/dotnet/standard/get-started
[dotnet-versions]: https://versionsof.net/core/

### What's included:

Technically, this includes nothing but:

- .NET 8.0 SDK and Azure CLI to build, run, and publish to cloud
- Docker and Kubernetes with Helm Charts for containers and for orchestrations
- Bicep and Terraform to manage infrastructure code (or IaaC)
- Node and Yarn for JavaScript-based apps and services

## Requirements

See [dev containers][devcontainers-use] to get started at the most basic level, and:

- A GitHub account, and
- [VS Code][vscode-download] with [recommended](./vscode/extensions.json) extensions

[devcontainers-use]: https://containers.dev/supporting
[vscode-download]: https://code.visualstudio.com/



## Quick start

[![Open in Dev Container](https://img.shields.io/static/v1?style=for-the-badge&label=Dev+Container&message=Open&color=blue&logo=visualstudiocode)](https://vscode.dev/redirect?url=vscode://ms-vscode-remote.remote-containers/cloneInVolume?url=https://github.com/alertbox/devcontainers-azure-dotnet)

If you are completely new to .NET and C#, the [@dotnet YouTube Channel][yt-dotnet-playlists] is a good source of information.

[yt-dotnet-playlists]: https://www.youtube.com/@dotnet/playlists



First, you want to ensure the repo is `Reopened in Container`. Then you'll be able to work on .NET and Azure stuff like you would locally.

With VS Code:

1. In a Terminal, run `dotnet --info` to see required versions are installed.
2. Run `az --version` to verify Azure CLI is installed.



## Build and run from source

VS Code is integrated with Omnisharp Tools to run the web api on the dev container.

With VS Code:

1. Press `F5` to launch the project. Terminal shows the output from the Debug Console.
2. When the web api executes, visit [localhost:8081/swagger](https://localhost:8081/swagger) on your favorite browser.
3. Press `Ctrl`+`C` to stop and disconnect the debugger.



## Known issues

- https://github.com/devcontainers/features/issues/440
- https://github.com/azure/azure-functions-core-tools/issues/3112
- https://github.com/omnisharp/omnisharp-vscode/issues/4348



## Useful resources

- [Dev Containers specification][devcontainers-json-spec] is a good source to learn more about `.devcontainer.json` configuration options and its usage.
- [See .NET CLI page][ms-docs-dotnet-cli] to learn the full-blown `dotnet` options.
- [See Azure CLI page][ms-docs-azure-cli] to learn what can be done with `az` and `az pipelines`.
- [See Azure DevOps CLI page][ms-docs-azure-devops-cli] to learn what can be done with `az devops` .
- [See .NET Docker Images][dotnet-docker-images] for alternative versions as you wish.

[devcontainers-json-spec]: https://containers.dev/implementors/json_reference/
[ms-docs-dotnet-cli]: https://docs.microsoft.com/en-us/dotnet/core/tools/
[ms-docs-azure-cli]: https://learn.microsoft.com/en-us/cli/azure/reference-index?view=azure-cli-latest
[ms-docs-azure-devops-cli]: https://learn.microsoft.com/en-us/azure/devops/cli/?view=azure-devops
[dotnet-docker-images]: https://hub.docker.com/_/microsoft-dotnet-sdk/



## Feedback

If you have any technical problems with dev containers, you are better off asking [Dev Containers Support][devcontainers-support] directly, since you'll end up getting a much faster response back that way.

[devcontainers-support]: https://github.com/devcontainers/community/discussions/3



## Contributing

The official repo to contribute would be [@devcontainers][devcontainers-repo].

Have a suggestion or a bug fix? Just open a pull request or an issue. Include clear and simple instructions possible.

[devcontainers-repo]: https://github.com/devcontainers



## License

Copyright :copyright: 2020 Alertbox, Inc. (@alertbox). All rights reserved.

The source code is license under the [MIT license](#MIT-1-ov-file).

