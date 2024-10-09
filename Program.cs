using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernateExample.Models;

namespace FluentNHibernateExample
{
    class Program
    {

        public static void Main(string[] args)
        {
            using (var session = NHibernateHelper.GetSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var product = new Product()
                    {
                        Id = 10,
                        Name = "Hi",
                        Units = 2,
                        Price = 3,
                    };
                    session.Save(product);
                    transaction.Commit(); // Commit transaction
                }
            }

        }

    }
}
