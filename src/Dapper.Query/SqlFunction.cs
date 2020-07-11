using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class SqlFunction : Column
    {
        public string Format { get; set; }
        public List<Column> Parameters { get; set; }

        private SqlFunction(string functionFormat, params Column[] parameters)
        {
            this.ColumnType = ColumnType.SqlFunction;
            this.Name = functionFormat;
        }

        public static SqlFunction GetDate()
        {
            return new SqlFunction("getDate()");
        }

        public static SqlFunction Between(Column source, Column start, Column end)
        {
            return new SqlFunction("{0} between {1} and {2}", source, start, end);
        }

        //public static SqlFunction In(Column source, params object[] values)
        //{
        //    return new SqlFunction("{0} between {1} and {2}", source, values);
        //}

        public static SqlFunction In(Column source, SelectStatement selectStatement)
        {
            return new SqlFunction("{0} between {1} and {2}", source, selectStatement);
        }
    }
}
