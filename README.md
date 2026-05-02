# Primitives

Low-level reusable primitives for Atya foundation packages.

| | |
| --- | --- |
| Repository | [https://github.com/AtyaLibraries/Primitives](https://github.com/AtyaLibraries/Primitives) |
| NuGet | `Atya.Foundation.Primitives` |
| License | MIT |

> This README is the repository landing page. A minimal, consumer-facing copy
> is packed into the NuGet package from `src/Primitives/README.md`.

## Purpose

`Atya.Foundation.Primitives` provides low-level reusable primitives that build on
`Atya.Foundation.Abstractions` without pulling in framework-specific behavior.

## Included Types

- `Error`
- `Result`
- `Result<TValue>`
- `ValueObject`
- `StronglyTypedId<TValue>`
- `PagedRequest`
- `PagedResult<T>`

## Layout

- `src/Primitives/` for the shipped package
- `tests/Primitives.UnitTests/` for behavioral coverage
- `samples/Primitives.Samples.Console/` for runnable usage examples
- `benchmarks/Primitives.Benchmarks/` for BenchmarkDotNet coverage

## Build, Test, Pack

```bash
dotnet restore ./Primitives.sln
dotnet build ./Primitives.sln --configuration Release --no-restore
dotnet test ./tests/Primitives.UnitTests/Primitives.UnitTests.csproj --configuration Release --no-build
dotnet pack ./src/Primitives/Primitives.csproj --configuration Release --no-build
```

Artifacts land in `artifacts/packages/`.
