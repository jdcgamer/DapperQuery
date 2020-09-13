using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper.Query
{
    public class Column
    {
        #region Properties

        public ColumnType ColumnType { get; protected set; }
        public string Name { get; protected set; }
        public IColumnOwner Parent { get; protected set; }
        public SelectStatement SelectStatement { get; protected set; }
        public object Value { get; protected set; }

        #endregion

        #region Constructors

        protected Column()
        { }

        public Column(IColumnOwner parent, string name)
        {
            this.ColumnType = ColumnType.TableColumn;
            this.Name = name;
            this.Parent = parent;
            this.Parent.AddColumn(this);
        }

        public Column(object value)
        {
            this.ColumnType = ColumnType.Value;
            this.Value = value;
        }

        #endregion

        #region Comparison operators

        public static Predicate operator ==(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.EqualTo, right);
        }

        public static Predicate operator !=(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.NotEqualTo, right);
        }

        public static Predicate operator <(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.LessThan, right);
        }

        public static Predicate operator <=(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.LessThanOrEqualTo, right);
        }

        public static Predicate operator >(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.GreaterThan, right);
        }

        public static Predicate operator >=(Column left, Column right)
        {
            return new Predicate(left, ComparisonOperator.GreaterThanOrEqualTo, right);
        }

        #endregion

        #region Comparison Methods

        // todo: implement between method with SqlFunction.Between
        public Predicate Between(Column start, Column end)
        {
            return start <= this && this <= end;
        }

        // todo: implement other functions e.g.: In(), NotIn()

        //public Predicate In(params Column[] values)
        //{

        //}

        #endregion

        #region Implicit Conversions

        public static implicit operator Column(SelectStatement selectStatement)
        {
            return new Column(selectStatement);
        }

        public static implicit operator Column(string value)
        {
            return new Column(value);
        }

        public static implicit operator Column(bool value)
        {
            return new Column(value);
        }

        public static implicit operator Column(byte value)
        {
            return new Column(value);
        }

        public static implicit operator Column(short value)
        {
            return new Column(value);
        }

        public static implicit operator Column(int value)
        {
            return new Column(value);
        }

        public static implicit operator Column(long value)
        {
            return new Column(value);
        }

        public static implicit operator Column(float value)
        {
            return new Column(value);
        }

        public static implicit operator Column(double value)
        {
            return new Column(value);
        }

        public static implicit operator Column(decimal value)
        {
            return new Column(value);
        }

        public static implicit operator Column(DateTime value)
        {
            return new Column(value);
        }

        public static implicit operator Column(byte[] value)
        {
            return new Column(value);
        }

        public static implicit operator Column(Guid value)
        {
            return new Column(value);
        }

        public static implicit operator Column(Enum value)
        {
            return new Column(value);
        }

        #endregion

        #region Order Bys

        public OrderByColumn Ascending()
        {
            return new OrderByColumn(this, OrderByDirection.Ascending);
        }

        public OrderByColumn Descending()
        {
            return new OrderByColumn(this, OrderByDirection.Descending);
        }

        #endregion

        #region object overrides

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is Column)
            {
                Column columnToCompare = (Column)obj;
                return this.Parent == columnToCompare.Parent && this.Name == columnToCompare.Name;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (this.ParentTable?.TableName + "." + this.Name).GetHashCode();
        }

        public override string ToString()
        {
            switch (this.ColumnType)
            {
                case ColumnType.TableColumn:
                    return this.ParentTable?.TableName + "." + this.Name;
                case ColumnType.SelectStatement:
                    return "inner query";
                case ColumnType.SqlFunction:
                    return this.Name;
                case ColumnType.Value:
                    if (this.Value is Enum)
                    {
                        return Convert.ToInt32(this.Value).ToString();
                    }
                    return Value?.ToString();
                default:
                    return string.Empty;
            }

        }

        #endregion
    }
}
