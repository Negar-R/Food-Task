using FluentNHibernate.Automapping;
using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Food.Entities;

namespace Food.Data
{
    public class NhibernateHelper : DefaultAutomappingConfiguration
    {
        private static ISessionFactory _factory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_factory == null)
                {
                    var connectionString = String.Empty;

                    var cfgi = new StoreConfiguration();

                    var fluentConfiguration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2012
                            .ConnectionString(@"Data Source=DESKTOP-I30IACT;Initial Catalog=Food;Integrated Security=True")
                            .ShowSql()
                        );

                    var configuration =
                        fluentConfiguration.Mappings(m =>
                            m.AutoMappings.Add(AutoMap.AssemblyOf<Foodd>(cfgi)
                                .UseOverridesFromAssemblyOf<FoodMap>())
                        );
                    var buildSessionFactory = configuration.ExposeConfiguration(cfg =>
                        {
                            new SchemaUpdate(cfg).Execute(false, false);
                            new SchemaExport(cfg)
                                .Create(true, true);
                        })
                        .BuildSessionFactory();



                    _factory = buildSessionFactory;
                }

                return _factory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
