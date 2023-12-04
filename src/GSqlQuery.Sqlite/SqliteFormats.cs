namespace GSqlQuery.Sqlite
{
    public sealed class SqliteFormats : DefaultFormats
    {
        public override string Format => "\"{0}\"";

        public override string ValueAutoIncrementingQuery => "SELECT last_insert_rowid();";

        public override string GetColumnName(string tableName, ColumnAttribute column, QueryType queryType)
        {
            return queryType == QueryType.Read || queryType == QueryType.Join ? $"{tableName}.{string.Format(Format, column.Name)}" : $"{string.Format(Format, column.Name)}";
        }
    }
}