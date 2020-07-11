using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class Predicate
    {
        public PredicateType PredicateType { get; set; }

        public Predicate LeftPredicate { get; set; }
        public Predicate RightPredicate { get; set; }
        public LogicalOperator LogicalOperator { get; set; }

        public Column LeftColumn { get; set; }
        public Column RightColumn { get; set; }
        public ComparisonOperator ComparisonOperator { get; set; }

        public Predicate()
        {
        }

        public Predicate(Predicate left, LogicalOperator logicalOperator, Predicate right)
        {
            this.LeftPredicate = left;
            this.LogicalOperator = logicalOperator;
            this.RightPredicate = right;
            this.PredicateType = PredicateType.Node;
        }

        public Predicate(Column left, ComparisonOperator comparisonOperator, Column right)
        {
            this.LeftColumn = left;
            this.ComparisonOperator = comparisonOperator;
            this.RightColumn = right;
            this.PredicateType = PredicateType.Leaf;
        }

        public static Predicate operator |(Predicate left, Predicate right)
        {
            return new Predicate(left, LogicalOperator.Or, right);
        }

        public static Predicate operator &(Predicate left, Predicate right)
        {
            return new Predicate(left, LogicalOperator.And, right);
        }

        public static bool operator true(Predicate c)
        {
            return true;
        }

        public static bool operator false(Predicate c)
        {
            return true;
        }

        public override string ToString()
        {
            if (this.PredicateType == PredicateType.Node)
            {
                return this.LeftPredicate.ToString() + (this.LogicalOperator == LogicalOperator.And ? "And" : "Or") + this.RightPredicate.ToString();
            }
            return this.LeftColumn.ToString() + this.ComparisonOperator.ToSqlString() + this.RightColumn.ToString();
        }
    }
}
