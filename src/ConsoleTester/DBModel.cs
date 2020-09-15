using Dapper.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTester
{
    public class Product : Table
    {
        private Column _Id { get; set; }
        public Column Id
        {
            get => _Id;
            set => _Id.Value = value;
        }

        private Column _Name { get; set; }
        public Column Name
        {
            get => _Name;
            set => _Name.Value = value;
        }

        private Column _Category { get; set; }
        public Column Category
        {
            get => _Category;
            set => _Category.Value = value;
        }

        public Product() : base("Product")
        {
            _Id = new Column(this, "id");
            _Name = new Column(this, "name");
            _Category = new Column(this, "category");
        }
    }

    class Customer : Table
    {
        private Column _Id { get; set; }
        public Column Id
        {
            get => _Id;
            set => _Id.Value = value;
        }

        private Column _Name { get; set; }
        public Column Name
        {
            get => _Name;
            set => _Name.Value = value;
        }

        private Column _BirthDate { get; set; }
        public Column BirthDate
        {
            get => _BirthDate;
            set => _BirthDate.Value = value;
        }


        public Customer() : base("Product")
        {
            _Id = new Column(this, "id");
            _Name = new Column(this, "name");
            _BirthDate = new Column(this, "birthdate");
        }
    }

    class Order : Table
    {
        private Column _Id { get; set; }
        public Column Id
        {
            get => _Id;
            set => _Id.Value = value;
        }

        private Column _CustomerId { get; set; }
        public Column CustomerId
        {
            get => _CustomerId;
            set => _CustomerId.Value = value;
        }

        private Column _ProductId { get; set; }
        public Column ProductId
        {
            get => _ProductId;
            set => _ProductId.Value = value;
        }

        private Column _OrderDate { get; set; }
        public Column OrderDate
        {
            get => _OrderDate;
            set => _OrderDate.Value = value;
        }

        private Column _Count { get; set; }
        public Column Count
        {
            get => _Count;
            set => _Count.Value = value;
        }
        

        public Order() : base("Product")
        {
            _Id = new Column(this, "id");
            _CustomerId = new Column(this, "customerid");
            _ProductId = new Column(this, "productid");
            _Count = new Column(this, "count");
            _OrderDate = new Column(this, "orderdate");
        }
    }

}
