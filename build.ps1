# Build script for S1ySt34lthSPTTrainer Installer
Set-StrictMode -Version Latest
dotnet restore Installer/Installer.csproj
dotnet publish Installer/Installer.csproj -c Release -r win-x64 /p:PublishSingleFile=true -p:PublishTrimmed=false -o ./out
Write-Host "Build complete. Output in ./out"
