using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace GSqlQuery.Sqlite.Benchmark.Query
{
    [SimpleJob(RuntimeMoniker.Net70, baseline: true)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public abstract class BenchmarkBase
    {
        protected readonly SqliteConnectionOptions _connectionOptions;

        public BenchmarkBase()
        {
            _connectionOptions = CreateTable.GetConnectionOptions();
        }

        [Params(true, false)]
        public bool Async { get; set; }
    }
}