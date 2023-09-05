using GSqlQuery.SqliteTest.Data;
using Microsoft.Data.Sqlite;
using System;

namespace GSqlQuery.Sqlite.Benchmark
{
    internal static class CreateTable
    {
        internal const string ConnectionString = "Data Source=benchmark.db";

        internal static SqliteConnectionOptions GetConnectionOptions()
        {
            return new SqliteConnectionOptions(ConnectionString);
        }

        internal static void Create()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                using (var createCommand = connection.CreateCommand())
                {
                    createCommand.CommandText =
                        @"
                               CREATE TABLE IF NOT EXISTS ""test1"" (
	                                ""idTest1""	NUMERIC NOT NULL,
	                                ""Money""	TEXT,
	                                ""Nombre""	TEXT,
	                                ""GUID""	TEXT,
	                                ""URL""	TEXT
                                );
                            ";
                    createCommand.ExecuteNonQuery();

                    createCommand.CommandText =
                        @"
                               CREATE TABLE IF NOT EXISTS ""test2"" (
	                                ""Id""	INTEGER NOT NULL,
	                                ""Money""	TEXT,
	                                ""IsBool""	INTEGER,
	                                ""Time""	TEXT,
	                                PRIMARY KEY(""Id"" AUTOINCREMENT)
                                );
                            ";
                    createCommand.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        internal static void CreateData()
        {
            var connectionOptions = GetConnectionOptions();
            using (var connection = connectionOptions.DatabaseManagement.GetConnection())
            {
                using (var transaction = connection.BeginTransaction())
                {
                    var batch = Execute.BatchExecuteFactory(connectionOptions);
                    Test2 test = new Test2() { IsBool = false, Money = 200m, Time = DateTime.Now };
                    for (int i = 0; i < 1000; i++)
                    {
                        test.IsBool = (i % 2) == 0;
                        batch.Add(sb => test.Insert(sb).Build());
                    }

                    int result = batch.Execute(transaction.Connection);

                    transaction.Commit();
                }

                connection.Close();
            }
        }
    }
}