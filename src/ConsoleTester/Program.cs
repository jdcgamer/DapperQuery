using Dapper.Query;
using System;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new Customer();
            var p = new Product();
            var o = new Order();
            var s = new SelectStatement();
            s
                .Select(c.Id, c.Name, p.Id, p.Name, o.OrderDate, o.Count)
                .From(o)
                .InnerJoin(c).On(o.CustomerId == c.Id)
                .InnerJoin(p).On(o.ProductId == p.Id)
                .Where(o.OrderDate > "2019-02-02")
                .GroupBy(c.Id, c.Name, p.Id, p.Name, o.OrderDate)
                .Having(o.Count > 5)
                .OrderBy(c.Name, p.Name);
        }
    }


}
