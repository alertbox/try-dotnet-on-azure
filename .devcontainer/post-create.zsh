#!/bin/zsh
echo "Trust the cert on the current platform"
dotnet dev-certs https --clean
dotnet dev-certs https -t

# If there's a Solution file, then run `dotnet restore`
# It's assumed that the Solution file has all the projects added.
if [ -f ./*.sln ]; 
then
    echo '.NET solution file found.'
    dotnet restore --no-cache --force
fi
