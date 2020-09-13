using System;
using System.Collections.Generic;
using System.IO.Pipes;
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

    public interface IColumnOwner
    {
        string Name { get; set; }
        string Alias { get; }
        IList<Column> Columns { get; }
        Column Star { get; }
        void AddColumn(Column column);
        IColumnOwner As(string alias);
    }
}
