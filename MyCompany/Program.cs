using System;
using System.Linq;
using Infrastructure.DataBase;
namespace MyCompany
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var data = new DataBaseContext())
            {
                var e = data.Customers.AsEnumerable();
                foreach (var s in e)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
}
