
dotnet --version

# clean build
git -C "$PSScriptRoot/src" clean -xdf
dotnet build src

Read-Host