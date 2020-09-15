using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class SelectStatement : StatementBase, IClause, ISelectClause, IFromClause, IWhereClause, IGroupByClause, IColumnOwner
    {
        public bool IsDistinct { get; private set; }
        public int TopCount { get; private set; }
        public List<Column> SelectedColumns { get; private set; }
        public IColumnOwner FromSource { get; private set; }
        public List<JoinClause> Joins { get; private set; }
        public Predicate WherePredicate { get; private set; }
        public List<Column> GroupByColumns { get; private set; }
        public Predicate HavingPredicate { get; private set; }
        public List<OrderByColumn> OrderByColumns { get; private set; }

        public SelectStatement()
        {
            this.SelectedColumns = new List<Column>();
            this.Joins = new List<JoinClause>();
            this.GroupByColumns = new List<Column>();
            this.OrderByColumns = new List<OrderByColumn>();
        }

        #region IColumnOwner members

        string IColumnOwner.Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        string IColumnOwner.Alias => throw new NotImplementedException();
        IList<Column> IColumnOwner.Columns => throw new NotImplementedException();
        Column IColumnOwner.Star => throw new NotImplementedException();
        void IColumnOwner.AddColumn(Column column)
        {
            throw new NotImplementedException();
        }
        IColumnOwner IColumnOwner.As(string alias)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ISelectClause Select(params Column[] columns)
        {
            this.SelectedColumns.AddRange(columns);
            return this;
        }

        public ISelectClause SelectTop(int count, params Column[] columns)
        {
            this.TopCount = count;
            return this.Select(columns);
        }

        public ISelectClause SelectDistinct(params Column[] columns)
        {
            this.IsDistinct = true;
            return this.Select(columns);
        }

        public ISelectClause SelectDistinctTop(int count, params Column[] columns)
        {
            this.IsDistinct = true;
            this.TopCount = count;
            return this.Select(columns);
        }

        public IFromClause From(Table table)
        {
            this.FromSource = table;
            return this;
        }

        public JoinClause InnerJoin(Table table)
        {
            return this.Join(table, JoinType.Inner);
        }

        public JoinClause LeftJoin(Table table)
        {
            return this.Join(table, JoinType.Left);
        }

        public JoinClause RightJoin(Table table)
        {
            return this.Join(table, JoinType.Right);
        }

        private JoinClause Join(Table table, JoinType joinType)
        {
            var joinClause = new JoinClause(this, table, joinType);
            this.Joins.Add(joinClause);
            return joinClause;
        }

        public IWhereClause Where(Predicate predicate)
        {
            if (this.WherePredicate == null)
            {
                this.WherePredicate = predicate;
            }
            else
            {
                this.WherePredicate = this.WherePredicate && predicate;
            }
            return this;
        }

        public IGroupByClause GroupBy(params Column[] columns)
        {
            this.GroupByColumns.AddRange(columns);
            return this;
        }

        public IClause Having(Predicate predicate)
        {
            if (this.HavingPredicate == null)
            {
                this.HavingPredicate = predicate;
            }
            else
            {
                this.HavingPredicate = this.HavingPredicate && predicate;
            }
            return this;
        }

        public SelectStatement OrderBy(params OrderByColumn[] orderByColumns)
        {
            this.OrderByColumns.AddRange(orderByColumns);
            return this;
        }

    }
}
