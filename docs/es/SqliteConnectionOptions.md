# SqliteConnectionOptions

Clase para poder configurar la conexión a base de datos

### Constructores

|                                                                                            |                                                                                        |
|--------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| SqliteConnectionOptions(string connectionString)                                            | Inicializar una instancia con la cadena de conexion que se pasa como parametro         |
| SqliteConnectionOptions(string connectionString, SqliteDatabaseManagement events)           | Inicializar una instancia con la cadena de conexion que se pasa como parametro y una clase derivada de [DatabaseManagementEvents](DatabaseManagementEvents.md) |
| SqliteConnectionOptions(IFormats formats, SqliteDatabaseManagement sqliteDatabaseManagement)  | Inicializar una instancia con el formato a utlizar y una intancia de [SqliteDatabaseManagement](SqliteDatabaseManagement.md)   |

### Propiedades

|                               |                                                                                            |
|-------------------------------|--------------------------------------------------------------------------------------------|
| Format                        | Da el formato al nombre de la columna y tabla                                              |
| DatabaseManagement            | Administrador de la conexión a base de datos                                               |

```csharp

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>");

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>", new SqliteDatabaseManagementEvents());

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions(new SqliteFormats(), new SqliteDatabaseManagement("<connectionString>"));

```