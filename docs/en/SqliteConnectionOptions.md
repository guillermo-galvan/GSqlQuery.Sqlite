# SqliteConnectionOptions

Class to configure the connection to the database.

### Constructors

|                                                                                            |                                                                                        |
|--------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------|
| SqliteConnectionOptions(string connectionString)                                            | Initialize an instance with the connection string passed as a parameter         |
| SqliteConnectionOptions(string connectionString, DatabaseManagementEvents events)           | Initialize an instance with the connection string passed as a parameter and a class derived from [DatabaseManagementEvents](DatabaseManagementEvents.md) |
| SqliteConnectionOptions(IFormats formats, SqliteDatabaseManagement sqliteDatabaseManagement)  | Initialize an instance with the format to use and an instance of [SqliteDatabaseManagement](SqliteDatabaseManagement.md)   |

### Properties

|                               |                                                                                            |
|-------------------------------|--------------------------------------------------------------------------------------------|
| Format                        | Formats the column and table name                                                          |
| DatabaseManagement            | Database Connection Manager                                                                |

```csharp
using GSqlQuery.Sqlite;

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>");

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions("<connectionString>", new SqliteDatabaseManagementEvents());

SqliteConnectionOptions connectionOptions = new SqliteConnectionOptions(new SqliteFormats(), new SqliteDatabaseManagement("<connectionString>"));

```