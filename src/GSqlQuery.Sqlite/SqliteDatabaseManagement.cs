using GSqlQuery.Runner;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace GSqlQuery.Sqlite
{
    public sealed class SqliteDatabaseManagement : DatabaseManagement, IDatabaseManagement<SqliteDatabaseConnection>
    {
        public SqliteDatabaseManagement(string connectionString) : base(connectionString, new SqliteDatabaseManagementEvents())
        { }

        public SqliteDatabaseManagement(string connectionString, DatabaseManagementEvents events) : base(connectionString, events)
        { }

        public int ExecuteNonQuery(SqliteDatabaseConnection connection, IQuery query, IEnumerable<IDataParameter> parameters)
        {
            return base.ExecuteNonQuery(connection, query, parameters);
        }

        public Task<int> ExecuteNonQueryAsync(SqliteDatabaseConnection connection, IQuery query, IEnumerable<IDataParameter> parameters, CancellationToken cancellationToken = default)
        {
            return base.ExecuteNonQueryAsync(connection, query, parameters, cancellationToken);
        }

        public IEnumerable<T> ExecuteReader<T>(SqliteDatabaseConnection connection, IQuery<T> query, IEnumerable<PropertyOptions> propertyOptions, IEnumerable<IDataParameter> parameters)
            where T : class
        {
            return base.ExecuteReader<T>(connection, query, propertyOptions, parameters);
        }

        public Task<IEnumerable<T>> ExecuteReaderAsync<T>(SqliteDatabaseConnection connection, IQuery<T> query, IEnumerable<PropertyOptions> propertyOptions, IEnumerable<IDataParameter> parameters, CancellationToken cancellationToken = default) 
            where T : class
        {
            return base.ExecuteReaderAsync<T>(connection, query, propertyOptions, parameters, cancellationToken);
        }

        public T ExecuteScalar<T>(SqliteDatabaseConnection connection, IQuery query, IEnumerable<IDataParameter> parameters)
        {
            return base.ExecuteScalar<T>(connection, query, parameters);
        }

        public Task<T> ExecuteScalarAsync<T>(SqliteDatabaseConnection connection, IQuery query, IEnumerable<IDataParameter> parameters, CancellationToken cancellationToken = default)
        {
            return base.ExecuteScalarAsync<T>(connection, query, parameters, cancellationToken);
        }

        public override IConnection GetConnection()
        {
            SqliteDatabaseConnection databaseConnection = new SqliteDatabaseConnection(_connectionString);

            if (databaseConnection.State != ConnectionState.Open)
            {
                databaseConnection.Open();
            }

            return databaseConnection;
        }

        public async override Task<IConnection> GetConnectionAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            SqliteDatabaseConnection databaseConnection = new SqliteDatabaseConnection(_connectionString);

            if (databaseConnection.State != ConnectionState.Open)
            {
                await databaseConnection.OpenAsync(cancellationToken);
            }

            return databaseConnection;
        }

        SqliteDatabaseConnection IDatabaseManagement<SqliteDatabaseConnection>.GetConnection()
        {
            return (SqliteDatabaseConnection)GetConnection();
        }

        async Task<SqliteDatabaseConnection> IDatabaseManagement<SqliteDatabaseConnection>.GetConnectionAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return (SqliteDatabaseConnection)await GetConnectionAsync(cancellationToken);
        }
    }
}