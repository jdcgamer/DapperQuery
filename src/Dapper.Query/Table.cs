using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class Table : ColumnOwner, ITable
    {
        string ITable.Name { get; set; }
        protected Table(string name)
        {
            ((ITable)this).Name = name;
        }

    }
}
