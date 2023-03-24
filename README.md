# Tryout .NET & Azure Stuff

[<img align="right" alt=".NET C-sharp" width="128rem" src="https://raw.githubusercontent.com/github/explore/93d8a67084f94b2a444e510199a6e7622e5b09a3/topics/dotnet/dotnet.png" />][dotnet-quick-start]

This template repo serves as a flavor of ready-to-go .NET and Azure development container.

> Originally, this dev container was created to tryout [.NET preview versions][dotnet-download-latest] without having to install them locally.

[dotnet-quick-start]: https://learn.microsoft.com/en-us/dotnet/standard/get-started
[dotnet-download-latest]: https://dotnet.microsoft.com/en-us/download/dotnet

### What's included:

Technically, this includes nothing but:

- .NET 6.0 LTS SDK and Azure CLI with Bicep
- Docker and Kubernetes with Helm Charts, and
- Configured to build and run from VS Code



## Requirements

See [dev containers][devcontainers-use] to get started at the most basic level, and:

- A GitHub account, and
- [VS Code][vscode-download] with [recommended](./vscode/extensions.json) extensions

[devcontainers-use]: https://containers.dev/supporting
[vscode-download]: https://code.visualstudio.com/



## Quick Start

If you are completely new to .NET and C#, the [.NET Learning Center][ms-docs-dotnet-learning-center] is a good source of information. Or follow this generic pattern:

First you want a copy of this repo. It is marked as a `Template` so you will only have to [Use this template][use-this-template] and follow the instructions. Read more about this in the [GitHub's Template Repositories][github-template-repos] document.

With [Dev Container CLI][devcontainers-cli]:

Just run `devcontainer up devcontainers-try-dotnet-stuff/` in the repo. And that's it! 

With VS Code:

First. run `code devcontainers-try-dotnet-stuff/` in the repo to open in VS Code, and then it'll propmpt to `Reopen in Container`. Do that and we're all set!

[ms-docs-dotnet-learning-center]: https://dotnet.microsoft.com/en-us/learn
[use-this-template]: /generate
[github-template-repos]: https://docs.github.com/en/repositories/creating-and-managing-repositories/creating-a-repository-from-a-template
[devcontainers-cli]: https://github.com/devcontainers/cli/#readme



## Things to Tryout

First, you want to ensure the repo is `Reopened in Container`. Then you'll be able to work on .NET and Azure stuff like you would locally.

With VS Code:

1. In a Terminal, run `dotnet --info` to see required versions are installed.
2. Run `az --version` to verify Azure CLI is installed.

### Create a rest-api

Next, you would want to create a .NET project, say, a [Minimal API][dotnet-minimal-apis-tutorial] `test-project` that ships with .NET Template projects.

[dotnet-minimal-apis-tutorial]: https://learn.microsoft.com/en-us/aspnet/core/tutorials/min-web-api?view=aspnetcore-6.0&tabs=visual-studio-code

With VS Code:

1. Run `dotnet new` to create a new web api with specific template.

   ```bash
   dotnet new webapi -o test-project \
                     --use-minimal-apis \
                     --language "C#"
   ```

2. Open the [launchSettings.json](./test-project/properties/launchSettings.json) file, then change the `test_project` profile to run on port `5000` for HTTP and `5001` for HTTPS.

   ```json
   "profiles": {
     "test_project": {
       // ...
       "applicationUrl": "https://localhost:5001;http://localhost:5000",
       // ...
   }
   ```

### Build and run from source

VS Code is integrated with Omnisharp Tools to run the web api on the dev container.

With VS Code:

1. Press `F5` to launch the web api project. Terminal shows the output from the Debug Console.
2. When the web api executes, visit [localhost:5001/swagger](https://localhost:5001/swagger) on your favorite browser.
3. Press `Ctrl`+`C` to stop and disconnect the debugger.



## Useful Resources

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

Copyright (c) Alertbox Inc. All rights reserved.

The source code is license under the [MIT license](LICENSE).

