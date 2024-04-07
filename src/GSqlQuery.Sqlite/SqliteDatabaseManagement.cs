using GSqlQuery.Runner;
using Microsoft.Data.Sqlite;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GSqlQuery.Sqlite
{
    public sealed class SqliteDatabaseManagement : DatabaseManagement<SqliteDatabaseConnection, SqliteDatabaseTransaction, SqliteCommand, SqliteTransaction, SqliteDataReader>, IDatabaseManagement<SqliteDatabaseConnection>
    {
        public SqliteDatabaseManagement(string connectionString) : base(connectionString, new SqliteDatabaseManagementEvents())
        { }

        public SqliteDatabaseManagement(string connectionString, DatabaseManagementEvents events) : base(connectionString, events)
        { }

        public override SqliteDatabaseConnection GetConnection()
        {
            SqliteDatabaseConnection databaseConnection = new SqliteDatabaseConnection(_connectionString);

            if (databaseConnection.State != ConnectionState.Open)
            {
                databaseConnection.Open();
            }

            return databaseConnection;
        }

        public override async Task<SqliteDatabaseConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            SqliteDatabaseConnection databaseConnection = new SqliteDatabaseConnection(_connectionString);

            if (databaseConnection.State != ConnectionState.Open)
            {
                await databaseConnection.OpenAsync(cancellationToken);
            }

            return databaseConnection;
        }
    }
}