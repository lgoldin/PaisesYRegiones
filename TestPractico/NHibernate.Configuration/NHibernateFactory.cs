namespace NHibernate.Configuration
{
    using System.Configuration;
    using Cfg;
    using Connection;
    using Dialect;
    using Mapping.ByCode;
    using Mappings;

    public class NHibernateFactory
    {
        private static ISessionFactory sessionFactory;

        public static ISessionFactory Get()
        {
            if (sessionFactory != null)
            {
                return sessionFactory;
            }

            return CreateSessionFactory();
        }

        private static ISessionFactory CreateSessionFactory()
        {
            var configuration = new Cfg.Configuration();
            configuration.DataBaseIntegration(db =>
            {
                db.ConnectionProvider<DriverConnectionProvider>();
                db.Dialect<MsSql2005Dialect>();
                db.ConnectionString = ConfigurationManager.ConnectionStrings["TestPractico"].ConnectionString;
                db.BatchSize = 30;
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.Timeout = 255;
                db.LogFormattedSql = false;
                db.LogSqlInConsole = false;
                db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
            });

            var mapper = new ConventionModelMapper();
            var mappings = new[]
                                   {
                                       typeof(PaisMap),
                                       typeof(RegionMap)
                                   };

            mapper.AddMappings(mappings);
            configuration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
            sessionFactory = configuration.BuildSessionFactory();

            return sessionFactory;
        }
    }
}
