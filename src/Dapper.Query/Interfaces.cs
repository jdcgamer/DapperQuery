using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public interface IClause
    {
        SelectStatement OrderBy(params OrderByColumn[] orderByColumns);
    }

    public interface ISelectClause : IClause
    {
        IFromClause From(Table table);
    }

    public interface IFromClause : IClause
    {
        JoinClause InnerJoin(Table table);
        JoinClause LeftJoin(Table table);
        JoinClause RightJoin(Table table);
        IWhereClause Where(Predicate predicate);
        IGroupByClause GroupBy(params Column[] columns);
    }

    public interface IWhereClause : IClause
    {
        IGroupByClause GroupBy(params Column[] columns);
    }

    public interface IGroupByClause : IClause
    {
        IClause Having(Predicate predicate);
    }
}
