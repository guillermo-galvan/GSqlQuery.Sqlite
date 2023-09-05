using Microsoft.Data.Sqlite;
using System.Threading;

namespace GSqlQuery.Sqlite.Test
{
    internal class Helper
    {
        internal const string ConnectionString = "Data Source=test;Mode=Memory;Cache=Shared";

        private static SqliteConnection connection;
        private readonly static Mutex mut = new Mutex();

        internal static void CreateDatatable()
        {
            mut.WaitOne();

            if (connection == null)
            {
                connection = new SqliteConnection(ConnectionString);
                connection.Open();
                var createCommand = connection.CreateCommand();
                createCommand.CommandText =
                    @"
                       CREATE TABLE ""test1"" (
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
                       CREATE TABLE ""test2"" (
	                        ""Id""	INTEGER NOT NULL,
	                        ""Money""	TEXT,
	                        ""IsBool""	INTEGER,
	                        ""Time""	TEXT,
	                        PRIMARY KEY(""Id"" AUTOINCREMENT)
                        );
                    ";
                createCommand.ExecuteNonQuery();

                createCommand.CommandText =
                    @"
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL) 
                                        VALUES (1,'120.32','Test desde la app','sdsadsa','test');
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL) 
                                        VALUES (2,'120.32','Test desde la app','sdsadsa','test');
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL) 
                                        VALUES (3,'120.32','Test desde la app','sdsadsa','test');
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL) 
                                        VALUES (4,'120.32','Test desde la app','sdsadsa','test');
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL) 
                                        VALUES (5,'120.32','Test desde la app','sdsadsa','test');
                       INSERT INTO test1 (idTest1,Money,Nombre,GUID,URL)
                                        VALUES (6,'120.32','Test desde la app','sdsadsa','test');
                    ";
                createCommand.ExecuteNonQuery();

                createCommand.CommandText =
                   @"
                       INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                       INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                       INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                       INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                        INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                       INSERT INTO test2 (Money,IsBool,Time ) 
                                    VALUES ('1235.23',1,null);
                    ";
                createCommand.ExecuteNonQuery();

            }

            mut.ReleaseMutex();
        }
    }
}