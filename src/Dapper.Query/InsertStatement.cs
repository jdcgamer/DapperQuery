using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class InsertStatement : SelectStatement
    {
        public InsertStatement InsertInto(Table table, params Column[] columns) { return this; }
        public InsertStatement Values(params Column[] columns) { return this; }
    }
}
