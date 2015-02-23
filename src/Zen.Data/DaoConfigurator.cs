using System;
using System.Linq;
using System.Reflection;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Zen.Data
{
    public static class DaoConfigurator
    {
        public static bool UseXmlConfig { get; set; }
        public static Configuration Cfg { get; private set; }
        public static ISessionFactory SessionFactory { get; private set; }
        public static ISessionFactoryImplementor SessionFactoryImpl 
        {
            get { return SessionFactory as ISessionFactoryImplementor; }
        }

        /// <summary>
        /// Set UseXmlConfig = true to configure from app/web.config/hibernate.cfg.xml
        /// - or -
        /// IDbCnnFactory must be registered with Ioc prior to calling this constructor
        /// </summary>
        /// <remarks>LOADS ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLY</remarks>
        public static void Configure()
        {
            Aspects.GetLogger().Debug("Configuring database...");

            if (UseXmlConfig)
            {
                try
                {
                    Cfg = new Configuration();
                    Cfg.Configure();
                    SessionFactory = Cfg.BuildSessionFactory();
                    return;
                }
                catch (Exception ex)
                { throw new ConfigException("Unable to configure session factory from xml/config file.", ex); }
                
            }

            var cnnFactory = Aspects.GetIocDI().Resolve<IDbCnnFactory>();// ?? new NoDbCnnFactory();
            Assembly mappingAssembly = null;
            try
            {
                var mappingAssemblyType = cnnFactory.MappingAssemblyType();
                var mappinbAssemblyFQN = cnnFactory.MappingAssemblyFQN();                
                if (mappingAssemblyType != null)
                    mappingAssembly = mappingAssemblyType.Assembly;                
                if (mappingAssembly == null && !string.IsNullOrWhiteSpace(mappinbAssemblyFQN))
                    mappingAssembly = Assembly.Load(mappinbAssemblyFQN);
                if (mappingAssembly == null) throw new ConfigException("Unable to load mapping assembly.");
                //
                // we have a mapping assembly
                //
                var cnnString = cnnFactory.ConnectionString;                
                switch (cnnFactory.DatabaseDialect)
                {// subset of NHibernate.Dialect.
                    case "MsSql2000Dialect":
                        ConfigureDbAccess<MsSql2000Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSql2005Dialect":
                        ConfigureDbAccess<MsSql2005Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSql2008Dialect":
                        ConfigureDbAccess<MsSql2008Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSql2012Dialect":
                        ConfigureDbAccess<MsSql2012Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSqlAzure2008Dialect":
                        ConfigureDbAccess<MsSqlAzure2008Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSqlCe40Dialect":
                        ConfigureDbAccess<MsSqlCe40Dialect>(cnnString, mappingAssembly);
                        break;
                    case "MsSqlCeDialect":
                        ConfigureDbAccess<MsSqlCeDialect>(cnnString, mappingAssembly);
                        break;
                    case "SQLiteDialect":
                        ConfigureDbAccess<SQLiteDialect>(cnnString, mappingAssembly);
                        break;
                    default:
                        ConfigureDbAccess<MsSql2012Dialect>(cnnString, mappingAssembly);
                        break;        
                }                                
            }
            catch (Exception ex)
            { throw new ConfigException("Check your IDbCnnFactory implementation.", ex); }
            
            /*
            #region another possible way
            // - or -
            //Cfg.SetProperty("connection.connection_string", sqlCnnString);
            //Cfg.SetProperty("dialect", "NHibernate.Dialect.MsSql2008Dialect");
            //Cfg.SetProperty("connection.provider", "NHibernate.Connection.DriverConnectionProvider");
            //Cfg.SetProperty("connection.driver_class", "NHibernate.Driver.SqlClientDriver");                        
            #endregion
            */
        }

        static void ConfigureDbAccess<TDialect>(string cnnString, Assembly mappingAssembly) 
            where TDialect : NHibernate.Dialect.Dialect
        {
            Cfg = new Configuration();
            Cfg.DataBaseIntegration(c =>
            {
                c.ConnectionString = cnnString; //@"Data Source=.\SQLEXPRESS;Initial Catalog=ZenTestDb;Integrated Security=True;Pooling=False";
                c.Dialect<TDialect>();
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;

                // !!!
                // be very careful with this or you could wipe out an entire database!!!
                // !!!
                //c.SchemaAction = SchemaAutoAction.Create;//.Create, .Recreate, .Update, .Validate
            });

            //Assembly mappingAssembly = typeof (Person).Assembly; //Assembly.GetEntryAssembly();            
            var dbMaps = from t in mappingAssembly.GetTypes()
                         where t.GetInterfaces().Contains(typeof(IDbMap))
                         select t;
            var dbMappings = dbMaps as Type[] ?? dbMaps.ToArray();            
            var mapper = new ModelMapper();
            mapper.AddMappings(dbMappings);
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            // load all ByCode class mappings from the assembly
            Cfg.AddMapping(domainMapping);
            // load all Embedded Resources from the assembly (whose names end in .hbm.xml)
            Cfg.AddAssembly(mappingAssembly);// this could probably be omitted unless we ever want to embed .hbm.xml?
            "{0} mappings in domain model. (not including embedded .hbm.xml files)".LogMe(Log.LogLevel.Debug, dbMappings.Count());
            
            SessionFactory = Cfg.BuildSessionFactory();                        
        }


        /// <summary>
        /// Use the NHProfiler to watch sql in realtime or create an offline file for later review
        /// </summary>
        /// <param name="offline">set offline to true if you want a file instead of live sql</param>
        public static void TurnOnNHProfiler(bool offline)
        {
            // only initialize if the dll exists
            var exists = new ImplChecker().CheckForDll("HibernatingRhinos.Profiler.Appender.dll");
            if (!exists) return;

            var offlineFileName = string.Format("Sql{0}.nhprof", DateTime.Now.ToString("yyyyMMddhhmmss"));
            if (offline) NHibernateProfiler.InitializeOfflineProfiling(offlineFileName);
            else NHibernateProfiler.Initialize();
        }


        public static void CreateDb(bool dropIfExists)
        {
            
        }

        public static void DropDb()
        {
            
        }

        public static void CreateDbSchema()
        {
            SchemaExport export = new SchemaExport(Cfg);
            export.Drop(true, true);
            export.Create(true, true);
            //export.Execute(new Action<string>(), );

            //cfg.SetDefaultAssembly(""); // to use for the mappings added to the cfg afterwords
            //cfg.SetDefaultNamespace("");// to use for the mappings added to the cfg afterwords            
            //string[] ddl = cfg.GenerateSchemaCreationScript(new MsSql2008Dialect());
            //cfg.ValidateSchema();

        }
        
        public static void DropDbSchema() { }
        
        public static void UpdateDbSchema() { }
        
        public static void ValidateDbSchema() { }
        

        public static void PopulateDbWithTestData() { }

        //SchemaExport export = new SchemaExport(cfg);
        //export.Drop(true, true);
        //export.Create(true, true);

        //export.Execute(new Action<string>(), );

        //cfg.SetDefaultAssembly(""); // to use for the mappings added to the cfg afterwords
        //cfg.SetDefaultNamespace("");// to use for the mappings added to the cfg afterwords            
        //string[] ddl = cfg.GenerateSchemaCreationScript(new MsSql2008Dialect());
        //cfg.ValidateSchema();

        //Configuration config = cfg.Configure();// read cfg from hibernate.cfg.xml file
    }
}