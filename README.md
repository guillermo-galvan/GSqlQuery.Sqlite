# GSqlQuery.Sqlite [![es](https://img.shields.io/badge/lang-es-red.svg)](./README.es.md) [![NuGet](https://img.shields.io/nuget/v/GSqlQuery.Sqlite.svg)](https://www.nuget.org/packages/GSqlQuery.Sqlite)

A library to run queries generated by [GSqlQuery](https://github.com/guillermo-galvan/GSqlQuery) on the Sqlite database for .NET.

## Get Started

GSqlQuery.Sqlite can be installed using the [Nuget packages](https://www.nuget.org/packages/GSqlQuery.Sqlite) or the `dotnet` CLI

```shell
dotnet add package GSqlQuery.Sqlite --version 1.0.0-alpha
```
[See our documentation](./docs/en/Config.md) for instructions on how to use the package.


## Example

```csharp
using GSqlQuery.Sqlite;

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>");

IEnumerable<Actor> rows = EntityExecute<Actor>.Select(connectionOptions).Build().Execute();
```

## Contributors

GSqlQuery is actively maintained by [Guillermo Galván](https://github.com/guillermo-galvan). Contributions are welcome and can be submitted using pull request.

## License
Copyright (c) Guillermo Galván. All rights reserved.

Licensed under the [Apache-2.0 license](./LICENSE).