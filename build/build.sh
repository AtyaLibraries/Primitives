#!/usr/bin/env bash
set -euo pipefail

CONFIGURATION="${CONFIGURATION:-Release}"
SKIP_TESTS="${SKIP_TESTS:-false}"
SCRIPT_DIR="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
ROOT_DIR="$(cd "${SCRIPT_DIR}/.." && pwd)"

cd "$ROOT_DIR"

dotnet restore "./Primitives.sln"
dotnet build "./Primitives.sln" --configuration "$CONFIGURATION" --no-restore

if [ "$SKIP_TESTS" != "true" ]; then
  dotnet test "./Primitives.sln" --configuration "$CONFIGURATION" --no-build --logger "trx;LogFileName=test-results.trx"
fi
