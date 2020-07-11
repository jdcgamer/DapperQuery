using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class OrderByColumn
    {
        public Column ParentColumn { get; set; }
        public OrderByDirection Direction { get; set; }

        public OrderByColumn(Column parentColumn, OrderByDirection direction)
        {
            this.ParentColumn = parentColumn;
            this.Direction = direction;
        }

        public static implicit operator OrderByColumn(Column parentColumn)
        {
            return new OrderByColumn(parentColumn, OrderByDirection.Ascending);
        }

        public override string ToString()
        {
            return this.ParentColumn.ToString() + " " + (this.Direction == OrderByDirection.Descending ? "desc" : "");
        }
    }

    public enum OrderByDirection
    {
        Ascending = 0,
        Descending
    }
}
