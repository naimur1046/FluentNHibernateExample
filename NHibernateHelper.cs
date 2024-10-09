using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateExample;
using FluentNHibernateExample.Mappings;

namespace FluentNHibernateExample
{
    internal class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    string connectionString = "Data Source=NAIMURRAHMAN;Initial Catalog = productDetails;TrustServerCertificate=True; Trusted_Connection=True;";
                    _sessionFactory = Fluently.Configure()
    .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString)
    .ShowSql())  // Enables SQL logging
    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductMap>())
    .BuildSessionFactory();

                }
                

                return _sessionFactory;
            }
        }
        public static ISession GetSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
