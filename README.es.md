# GSqlQuery.Sqlite [![en](https://img.shields.io/badge/lang-en-red.svg)](./README.md) [![NuGet](https://img.shields.io/nuget/v/GSqlQuery.Sqlite.svg)](https://www.nuget.org/packages/GSqlQuery.Sqlite)

Una biblioteca para ejecutar las consultas generadas por [GSqlQuery](https://github.com/guillermo-galvan/GSqlQuery) en la base de datos Sqlite para .NET

## Empezar

GSqlQuery.Sqlite se puede instalar utilizando el administrador de [paquetes Nuget](https://www.nuget.org/packages/GSqlQuery.Sqlite) o la `dotnet` CLI

```shell
dotnet add package GSqlQuery.Sqlite --version 2.0.1
```

[Revise nuestra documentación](./docs/es/Config.md) para obtener instrucciones sobre cómo utilizar el paquete.

## Ejemplo

```csharp
using GSqlQuery.Sqlite;

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>");

IEnumerable<Actor> rows = EntityExecute<Actor>.Select(connectionOptions).Build().Execute();
```

## Colaborar

GSqlQuery es mantenido activamente por [Guillermo Galván](https://github.com/guillermo-galvan). Las contribuciones son bienvenidas y se pueden enviar mediante pull request.

## Licencia
Copyright (c) Guillermo Galván. All rights reserved.

Licensed under the [Apache-2.0 license](./LICENSE).