using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public enum ColumnType
    {
        TableColumn,
        SelectStatement,
        SqlFunction,
        Value
    }

    public enum LogicalOperator
    {
        And,
        Or
    }

    public enum ComparisonOperator
    {
        EqualTo,
        NotEqualTo,
        GreaterThan,
        GreaterThanOrEqualTo,
        LessThan,
        LessThanOrEqualTo
    }

    public enum PredicateType
    {
        Node,
        Leaf
    }

    public enum JoinType
    {
        Inner,
        Left,
        Right
    }

    public static class ComparisonOperatorExtension
    {
        public static string ToSqlString(this ComparisonOperator comparisonOperator)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.EqualTo:
                    return "=";
                case ComparisonOperator.NotEqualTo:
                    return "<>";
                case ComparisonOperator.GreaterThan:
                    return ">";
                case ComparisonOperator.GreaterThanOrEqualTo:
                    return ">=";
                case ComparisonOperator.LessThan:
                    return "<";
                case ComparisonOperator.LessThanOrEqualTo:
                    return "<=";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
