# How To Create a Project From This Template

This template appears in:

- Visual Studio as `Atya package`
- .NET CLI as `abnp-package`

## Install the template

If you have the template source folder locally:

```powershell
dotnet new install "C:\path\to\atya-base-nuget-package"
```

If you already installed an older version and want to refresh it:

```powershell
dotnet new install "C:\path\to\atya-base-nuget-package" --force
```

If you have a packed template `.nupkg`, install that instead:

```powershell
dotnet new install "C:\path\to\your-template-package.nupkg"
```

## Create a project in Visual Studio

1. Close all Visual Studio instances after installing or updating the template.
2. Open Visual Studio again.
3. Go to `File -> New -> Project`.
4. Search for `Atya package`.
5. Select the template.
6. Enter the project name and location.
7. Fill in the additional fields such as:
   - package description
   - authors
   - company
   - tags
   - repository URL
8. Choose optional settings such as:
   - include benchmarks project
   - include `.github` folder
   - skip post-generation restore
9. Click `Create`.

## Create a project from the command line

Minimal example:

```powershell
dotnet new abnp-package -n MyCompany.MyPackage -o .\MyCompany.MyPackage
```

Example with options:

```powershell
dotnet new abnp-package `
  -n MyCompany.MyPackage `
  -o .\MyCompany.MyPackage `
  --description "Reusable building blocks for MyCompany" `
  --authors "MyCompany" `
  --company "MyCompany" `
  --repository "https://github.com/myorg/MyCompany.MyPackage"
```

Optional flags:

```powershell
--include-benchmarks false
--include-github false
--skip-restore
```

## Troubleshooting

If the template does not appear in Visual Studio, or Visual Studio still uses an older version:

```powershell
dotnet new install "C:\path\to\atya-base-nuget-package" --force
```

Then fully restart Visual Studio and try again.

## Notes

- The generated project is a package-oriented repository template.
- It can include source, tests, samples, benchmarks, build scripts, and GitHub workflow files.
- The generated solution name follows the project name you provide during creation.
