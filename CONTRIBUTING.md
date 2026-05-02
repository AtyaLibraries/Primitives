# Contributing to Primitives

Thanks for contributing. This repository follows the standard conventions of
all `atya-base-nuget-package`-generated packages - if you've worked on one, you've worked
on all of them.

## Prerequisites

- .NET SDK - version floor in [global.json](global.json)
- git
- PowerShell 7+ (Windows) or bash (Linux / macOS)

## Loop

```bash
dotnet restore
./build/build.ps1          # or ./build/build.sh
./build/pack.ps1           # or ./build/pack.sh
```

## Code style

- All rules live in [`.editorconfig`](.editorconfig). `EnforceCodeStyleInBuild=true`
  means violations become build warnings/errors - fix them, don't suppress them.
- `Nullable` is enabled. New public API must be null-annotated.
- `TreatWarningsAsErrors=true` on packable projects.

## Tests

- Framework: xUnit + FluentAssertions + NSubstitute (global-using'd via
  [`tests/Directory.Build.props`](tests/Directory.Build.props)).
- Every bug fix needs a failing-before / passing-after test.
- No mocking of types you do not own - wrap them first.

## Commits + PRs

- Conventional commit subject line preferred: `feat:`, `fix:`, `chore:`, `docs:`, `test:`.
- Update [`CHANGELOG.md`](CHANGELOG.md) under `[Unreleased]` in the same PR.
- Small, reviewable PRs. Split mechanical refactors from behaviour changes.

## Releasing

1. Merge the release PR into master.
2. The publish-nuget GitHub workflow builds, packs, publishes the stable NuGet and symbol packages, creates the vX.Y.Z tag, and creates the GitHub Release.
3. Ensure the repository has the NUGET_API_KEY secret configured before release.
