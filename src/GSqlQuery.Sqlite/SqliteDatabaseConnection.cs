using GSqlQuery.Runner;
using Microsoft.Data.Sqlite;
using SQLitePCL;
using System.Data;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace GSqlQuery.Sqlite
{
    public sealed class SqliteDatabaseConnection(string connectionString) : Connection<SqliteDatabaseTransaction, SqliteConnection, SqliteTransaction, SqliteCommand>(new SqliteConnection(connectionString)), IConnection<SqliteDatabaseTransaction, SqliteCommand>
    {
        public override Task CloseAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
#if NET5_0_OR_GREATER
            return _connection.CloseAsync();
#else
            return base.CloseAsync(cancellationToken);
#endif
        }

        public override SqliteDatabaseTransaction BeginTransaction()
        {
            return SetTransaction(new SqliteDatabaseTransaction(this, _connection.BeginTransaction()));
        }

        public override SqliteDatabaseTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return SetTransaction(new SqliteDatabaseTransaction(this, _connection.BeginTransaction(isolationLevel)));
        }

        public override Task<SqliteDatabaseTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            SqliteTransaction mySqlTransaction = _connection.BeginTransaction();
            return Task.FromResult(SetTransaction(new SqliteDatabaseTransaction(this, mySqlTransaction)));

        }

        public override Task<SqliteDatabaseTransaction> BeginTransactionAsync(IsolationLevel isolationLevel, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            SqliteTransaction mySqlTransaction = _connection.BeginTransaction(isolationLevel);
            return Task.FromResult(SetTransaction(new SqliteDatabaseTransaction(this, mySqlTransaction)));
        }

        //public override SqliteCommand GetDbCommand()
        //{
        //    SqliteCommand result = _connection.CreateCommand();

        //    if (_transaction != null)
        //    {
        //        result.Transaction = this._transaction.
        //    }

        //    return result;
        //}

        ~SqliteDatabaseConnection()
        {
            Dispose(disposing: false);
        }
    }
}