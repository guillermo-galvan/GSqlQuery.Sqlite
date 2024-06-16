using GSqlQuery.Runner;
using Microsoft.Data.Sqlite;
using System.Threading;
using System.Threading.Tasks;

namespace GSqlQuery.Sqlite
{
    public sealed class SqliteDatabaseTransaction(SqliteDatabaseConnection connection, SqliteTransaction transaction) : Transaction<SqliteDatabaseConnection, SqliteCommand,  SqliteTransaction, SqliteConnection>(connection, transaction)
    {
        ~SqliteDatabaseTransaction()
        {
            Dispose(disposing: false);
        }

        public override void Rollback()
        {
            base.Rollback();
            Dispose();
        }

        public override async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            await base.RollbackAsync(cancellationToken);
            Dispose();
        }

        public override void Commit()
        {
            base.Commit();
            Dispose();
        }

        public override async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await base.CommitAsync(cancellationToken);
            Dispose();
        }
    }
}