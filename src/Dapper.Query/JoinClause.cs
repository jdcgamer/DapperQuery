namespace Dapper.Query
{
    public class JoinClause
    {
        internal JoinType JoinType { get; set; }
        internal SelectStatement ParentStatement { get; set; }
        internal Table JoinedTable { get; set; }
        internal Predicate OnPredicate { get; set; }

        internal JoinClause(SelectStatement parentStatement, Table joinedTable, JoinType joinType)
        {
            this.ParentStatement = parentStatement;
            this.JoinedTable = joinedTable;
            this.JoinType = joinType;
        }

        public IFromClause On(Predicate predicate)
        {
            this.OnPredicate = predicate;
            return this.ParentStatement;
        }

        public override string ToString()
        {
            string s = string.Empty;
            if (this.JoinType == JoinType.Inner)
            {
                s = "inner join ";
            }
            else if(this.JoinType == JoinType.Left)
            {
                s = "left outer join ";
            }
            else
            {
                s = "right outer join ";
            }
            s += this.JoinedTable.ToString();
            s += " on ";
            s += this.OnPredicate.ToString();
            return s;
        }
    }
}