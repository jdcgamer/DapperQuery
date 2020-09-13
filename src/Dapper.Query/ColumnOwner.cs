using System;
using System.Collections.Generic;
using System.Text;

namespace Dapper.Query
{
    public class ColumnOwner : IColumnOwner
    {
        private string _alias;
        protected IList<Column> Columns = new List<Column>();
        string IColumnOwner.Name { get; set; }
        string IColumnOwner.Alias => _alias;
        IList<Column> IColumnOwner.Columns => this.Columns;
        public Column Star { get; private set; }

        public ColumnOwner() : this(null) { }

        public ColumnOwner(string name)
        {
            ((IColumnOwner)this).Name = name;
            this.Star = new Column(this, "*");
        }

        void IColumnOwner.AddColumn(Column column)
        {
            this.Columns.Add(column);
        }

        public IColumnOwner As(string alias)
        {
            _alias = alias;
            return this;
        }
    }
}
