using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class DeleteStatement : StatementBase
    {
        public DeleteStatement DeleteFrom(Table table) { return this; }
        public DeleteStatement Where(Predicate predicate) { return this; }
    }
}
