using GSqlQuery.Runner;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GSqlQuery.Sqlite
{
    public class SqliteDatabaseManagementEvents : DatabaseManagementEvents
    {
        public override Func<Type, IEnumerable<ParameterDetail>, IEnumerable<IDataParameter>> OnGetParameter { get; set; } = (type, parametersDetail) =>
        {
            return parametersDetail.Select(x => new SqliteParameter(x.Name, x.Value));
        };
    }
}