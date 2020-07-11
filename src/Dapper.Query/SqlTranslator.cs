using System;
using System.Collections.Generic;

namespace Dapper.Query
{
    public class SqlTranslator
    {
        public List<object> Parameters { get; set; }

        public SqlTranslator(StatementBase statement)
        { }

        /// <summary>
        /// Visits select clause
        /// </summary>
        /// <param name="distinct">True if distinct defined</param>
        /// <param name="topCount">If top rows defined, an integer number which is more than zero, otherwise zero or a negative integer</param>
        /// <param name="columns">Selected columns</param>
        protected virtual void VisitSelectClause(bool distinct, int topCount, List<Column> columns) { }

        protected virtual void VisitFromClause(Table table) { }
        protected virtual void VisitJoinClause(JoinClause joinClause) { }
        protected virtual void VisitWhereClause(Predicate predicate) { }
        protected virtual void VisitGroupByClause(List<Column> columns) { }
        protected virtual void VisitHavingClause(Predicate predicate) { }
        protected virtual void VisitOrderByClause(List<Column> columns) { }
        public virtual string GenerateSql() { throw new NotImplementedException(); }
    }
}