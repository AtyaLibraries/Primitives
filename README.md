# Primitives

Low-level reusable primitives for Atya foundation packages.

| | |
| --- | --- |
| Repository | [https://github.com/AtyaLibraries/Primitives](https://github.com/AtyaLibraries/Primitives) |
| NuGet | `Atya.Foundation.Primitives` |
| License | MIT |

> This README is the repository landing page. A minimal, consumer-facing copy
> is packed into the NuGet package from `src/Primitives.NuGet/README.md`.

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

- `src/Primitives.NuGet/` for the shipped package
- `tests/Primitives.UnitTests/` for behavioral coverage
- `samples/Primitives.Samples.Console/` for runnable usage examples
- `benchmarks/Primitives.Benchmarks/` for BenchmarkDotNet coverage

## Build, Test, Pack

```bash
./build/build.ps1 -Configuration Release
./build/pack.ps1 -Configuration Release
```

Artifacts land in `artifacts/packages/`.
