#!/usr/bin/env bash
set -euo pipefail

CONFIGURATION="${CONFIGURATION:-Release}"
VERSION_SUFFIX="${VERSION_SUFFIX:-}"
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_DIR="$(cd "${SCRIPT_DIR}/.." && pwd)"

cd "$ROOT_DIR"

dotnet restore "./Primitives.sln"
dotnet test "./Primitives.sln" --configuration "$CONFIGURATION" --no-restore

pack_args=(
  pack
  "./src/Primitives.NuGet/Primitives.NuGet.csproj"
  --configuration "$CONFIGURATION"
  --no-build
  --output "./artifacts/packages"
)

if [ -n "$VERSION_SUFFIX" ]; then
  pack_args+=("/p:VersionSuffix=$VERSION_SUFFIX")
fi

dotnet "${pack_args[@]}"
