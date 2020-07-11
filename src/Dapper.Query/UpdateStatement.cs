using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class UpdateStatement : StatementBase
    {
        public UpdateStatement Update(Table table) { return this; }
        public UpdateStatement Set(params Column[] columns) { return this; }
        public UpdateStatement Where(Predicate predicate) { return this; }

    }
}
