#!/usr/bin/env bash
set -euo pipefail
dotnet restore Installer/Installer.csproj
dotnet publish Installer/Installer.csproj -c Release -r win-x64 /p:PublishSingleFile=true -p:PublishTrimmed=false -o ./out
echo "Build complete. Output in ./out"
