using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class Table : ColumnOwner
    {

        protected Table(string tableName) : base(tableName)
        { }

    }
}
