using GSqlQuery.Runner;

namespace GSqlQuery.Sqlite
{
    public class SqliteConnectionOptions : ConnectionOptions<SqliteDatabaseConnection>
    {
        public SqliteConnectionOptions(string connectionString) :
            base(new SqliteStatements(), new SqliteDatabaseManagement(connectionString))
        { }

        public SqliteConnectionOptions(string connectionString, DatabaseManagementEvents events) :
            base(new SqliteStatements(), new SqliteDatabaseManagement(connectionString, events))
        { }

        public SqliteConnectionOptions(IStatements statements, SqliteDatabaseManagement sqlServerDatabaseManagement) :
            base(statements, sqlServerDatabaseManagement)
        {

        }


    }
}