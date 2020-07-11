using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class Table
    {
        public string TableName { get; private set; }
        public Column Star { get; private set; }

        protected Table(string tableName)
        {
            this.TableName = tableName;
            this.Star = new Column(this, "*");
        }

        public override string ToString()
        {
            return this.TableName;
        }
    }
}
