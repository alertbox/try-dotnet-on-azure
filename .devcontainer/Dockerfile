# [Choice] .NET version: 6.0, 5.0, 3.1
# https://mcr.microsoft.com/v2/dotnet/sdk/tags/list
ARG VARIANT="5.0"
FROM mcr.microsoft.com/dotnet/sdk:${VARIANT}-focal

# [Option] Install zsh
ARG INSTALL_ZSH="true"
# [Option] Upgrade OS packages to their latest versions
ARG UPGRADE_PACKAGES="true"
# Install needed packages and setup non-root user. Use a separate RUN statement to add your own dependencies.
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=${USER_UID}
RUN apt-get update && curl -ssL https://raw.githubusercontent.com/microsoft/vscode-dev-containers/master/script-library/common-debian.sh -o /tmp/common-debian.sh \
    && /bin/bash /tmp/common-debian.sh "${INSTALL_ZSH}" "${USERNAME}" "${USER_UID}" "${USER_GID}" "${UPGRADE_PACKAGES}" "true" "true" \
    && apt-get clean -y && rm -rf /tmp/common-debian.sh

# [Option] Install Node.js
ARG INSTALL_NODE="true"
ARG NODE_VERSION="lts/*"
ENV NVM_DIR=/usr/local/share/nvm
ENV NVM_SYMLINK_CURRENT=true \
    PATH=${NVM_DIR}/current/bin:${PATH}
RUN if [ "$INSTALL_NODE" = "true" ]; then apt-get update && curl -ssL https://raw.githubusercontent.com/microsoft/vscode-dev-containers/master/script-library/node-debian.sh -o /tmp/node-debian.sh \
    && /bin/bash /tmp/node-debian.sh "${NVM_DIR}" "${NODE_VERSION}" "${USERNAME}"; \
    fi \
    && apt-get clean -y && rm -rf /tmp/node-debian.sh

# [Option] Install Azure CLI
ARG INSTALL_AZURE_CLI="true"
RUN if [ "$INSTALL_AZURE_CLI" = "true" ]; then apt-get update && curl -ssL https://raw.githubusercontent.com/microsoft/vscode-dev-containers/master/script-library/azcli-debian.sh -o /tmp/azcli-debian.sh \
    && /bin/bash /tmp/azcli-debian.sh; \
    fi \
    && apt-get clean -y && rm -rf /tmp/azcli-debian.sh

# Install SQL Tools: SQLPackage and sqlcmd
COPY mssql/installSQLtools.sh installSQLtools.sh
RUN bash ./installSQLtools.sh \
    && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/library-scripts

# Update args in docker-compose.yaml to set the UID/GID of the "vscode" user.
RUN if [ "$USER_GID" != "1000" ] || [ "$USER_UID" != "1000" ]; then groupmod --gid $USER_GID vscode && usermod --uid $USER_UID --gid $USER_GID vscode; fi

# [Optional] Uncomment this section to install additional OS packages.
# RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
#     && apt-get -y install --no-install-recommends <your-package-list-here>

# [Optional] Uncomment this line to install global node packages.
# RUN su vscode -c "source /usr/local/share/nvm/nvm.sh && npm install -g <your-package-here>" 2>&1