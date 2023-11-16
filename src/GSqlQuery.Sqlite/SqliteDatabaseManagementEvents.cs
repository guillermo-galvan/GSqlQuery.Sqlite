using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GSqlQuery.Sqlite
{
    public class SqliteDatabaseManagementEvents : DatabaseManagementEvents
    {
        public override IEnumerable<IDataParameter> GetParameter<T>(IEnumerable<ParameterDetail> parameters)
        {
            return parameters.Select(x => new SqliteParameter(x.Name, x.Value));
        }
    }
}