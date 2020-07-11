using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Dapper.Query
{
    public class Script
    {
        public List<StatementBase> Statements { get; set; }
        public string Sql { get; set; }
        public List<object> Parameters { get; set; }

        public void Add(StatementBase selectStatement)
        {
            this.Parameters = new List<object>();
            this.Statements = new List<StatementBase>();
            this.Statements.Add(selectStatement);
        }

        public void CreateScript()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var statement in Statements)
            {
                SqlTranslator translator = new SqlTranslator(statement);
                var sql = translator.GenerateSql();
                sb.AppendLine(sql);
                this.Parameters.Add(translator.Parameters);
            }
            this.Sql = sb.ToString();
        }

        public IEnumerable<dynamic> Run(IDbConnection con)
        {
            return con.Query(this.Sql, this.Parameters);
        }
    }
}
