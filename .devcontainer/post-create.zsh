#!/bin/zsh

echo 'Prepare SQL database.'
# parameters: $1=SA password, $2=dacpac path, $3=sql script(s) path
/bin/bash .devcontainer/mssql/postCreateCommand.sh 'P@ssw0rd' './bin/Debug/' './.devcontainer/mssql/'

# If there's a Solution file, then run `dotnet restore`
# It's assumed that the Solution file has all the projects added.
if [ -f ./*.sln ]; 
then
    echo '.NET solution file found.'
    dotnet restore
fi
