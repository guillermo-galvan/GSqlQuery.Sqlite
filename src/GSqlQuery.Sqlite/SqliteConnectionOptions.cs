using GSqlQuery.Runner;

namespace GSqlQuery.Sqlite
{
    public class SqliteConnectionOptions : ConnectionOptions<SqliteDatabaseConnection>
    {
        public SqliteConnectionOptions(string connectionString) :
            base(new SqliteFormats(), new SqliteDatabaseManagement(connectionString))
        { }

        public SqliteConnectionOptions(string connectionString, DatabaseManagementEvents events) :
            base(new SqliteFormats(), new SqliteDatabaseManagement(connectionString, events))
        { }

        public SqliteConnectionOptions(IFormats formats, SqliteDatabaseManagement sqlServerDatabaseManagement) :
            base(formats, sqlServerDatabaseManagement)
        {

        }


    }
}