using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
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
    public static class NHConfigurator
    {        
        public static Configuration Cfg { get; private set; }
        public static ISessionFactory SessionFactory { get; private set; }
        public static ISessionFactoryImplementor SessionFactoryImpl 
        {
            get { return SessionFactory as ISessionFactoryImplementor; }
        }

        /// <summary>
        /// Builds a SessionFactory for use with the NHibernateDao using the supplied configuration file.
        /// LOADS ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLY
        /// </summary>
        /// <param name="xmlFileName">If set to an empty string Configure() will use app/web.config or hibernate.cfg.xml</param>        
        public static void Configure(string xmlFileName)
        {
            Aspects.GetLogger().DebugFormat("Configuring database from {0}...", xmlFileName);
            try
            {
                Cfg = new Configuration();
                if (string.IsNullOrWhiteSpace(xmlFileName))
                    Cfg.Configure();
                else
                    Cfg.Configure(xmlFileName);
                SessionFactory = Cfg.BuildSessionFactory();                
            }
            catch (Exception ex)
            { throw new ConfigException("Unable to configure session factory from xml/config file.", ex); }
        }

        /// <summary>
        /// Builds a SessionFactory for use with the NHibernateDao. Tries to resolve IDbCnnFactory using IocDI.
        /// LOADS ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLY
        /// </summary>        
        public static void Configure()
        {
            Aspects.GetLogger().Debug("Configuring database...");
            var cnnFactory = Aspects.GetIocDI().Resolve<IDbCnnFactory>();
            
            Assembly mappingAssembly = null;
            try
            {
                var mappingAssemblyType = cnnFactory.MappingAssemblyType();
                var mappinbAssemblyFQN = cnnFactory.MappingAssemblyFQN();                
                if (mappingAssemblyType != null)
                    mappingAssembly = mappingAssemblyType.Assembly;                
                if (mappingAssembly == null && !string.IsNullOrWhiteSpace(mappinbAssemblyFQN))
                    mappingAssembly = Assembly.Load(mappinbAssemblyFQN);
                //if (mappingAssembly == null) throw new ConfigException("Unable to load mapping assembly.");
                // OK we may be using embedded .hbms

                var cnnString = cnnFactory.ConnectionString;
                var sqlDialect = (SqlDialects)Enum.Parse(typeof(SqlDialects), cnnFactory.DatabaseDialect);
                switch (sqlDialect)
                {// subset of NHibernate.Dialect.
                    case SqlDialects.MsSql2000Dialect:      ConfigureDbAccess<MsSql2000Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSql2005Dialect:      ConfigureDbAccess<MsSql2005Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSql2008Dialect:      ConfigureDbAccess<MsSql2008Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSql2012Dialect:      ConfigureDbAccess<MsSql2012Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSqlAzure2008Dialect: ConfigureDbAccess<MsSqlAzure2008Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSqlCe40Dialect:      ConfigureDbAccess<MsSqlCe40Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.MsSqlCeDialect:        ConfigureDbAccess<MsSqlCe40Dialect>(cnnString, mappingAssembly); break;
                    case SqlDialects.SQLiteDialect:         ConfigureDbAccess<SQLiteDialect>(cnnString, mappingAssembly); break;
                    default: ConfigureDbAccess<MsSql2008Dialect>(cnnString, mappingAssembly); break;
                }                                                
            }
            catch (Exception ex)
            { throw new ConfigException("Unable to configure session factory from IDbCnnFactory.", ex); }            
        }
        
        // Configure NHibernate ByCode
        static void ConfigureDbAccess<T>(string cnnString, Assembly mappingAssembly) 
            where T : NHibernate.Dialect.Dialect
        {
            Cfg = new Configuration();
            Cfg.DataBaseIntegration(c =>
            {
                c.ConnectionString = cnnString; //@"Data Source=.\SQLEXPRESS;Initial Catalog=ZenTestDb;Integrated Security=True;Pooling=False";
                c.Dialect<T>();                
#if DEBUG
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
#endif
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

        //private static NHibernate.Dialect.Dialect ToDialect(this SqlDialects sqlDialect)
        //{
        //    switch (sqlDialect)
        //    {// subset of NHibernate.Dialect.
        //        case SqlDialects.MsSql2000Dialect: return new MsSql2000Dialect();
        //        case SqlDialects.MsSql2005Dialect: return new MsSql2005Dialect();
        //        case SqlDialects.MsSql2008Dialect: return new MsSql2008Dialect();
        //        case SqlDialects.MsSql2012Dialect: return new MsSql2012Dialect();
        //        case SqlDialects.MsSqlAzure2008Dialect: return new MsSqlAzure2008Dialect();
        //        case SqlDialects.MsSqlCe40Dialect: return new MsSqlCe40Dialect();
        //        case SqlDialects.MsSqlCeDialect: return new MsSqlCe40Dialect();
        //        case SqlDialects.SQLiteDialect: return new SQLiteDialect();
        //        default: return new MsSql2008Dialect();
        //    }    
        //}

        /// <summary>
        /// Use the NHProfiler to watch sql in realtime or create an offline file for later review
        /// note: don't forget to TurnOffNHProfiler(usually on App_Exit)
        /// </summary>
        /// <param name="offline">
        /// set offline to true if you want a file instead of live sql
        /// The filename will be SqlyyyyMMddhhmmss.nhprof
        /// </param>
        public static void TurnOnNHProfiler(bool offline)
        {
            // only initialize if the dll exists
            var exists = new ImplChecker().CheckForDll("HibernatingRhinos.Profiler.Appender.dll");
            if (!exists) return;

            var offlineFileName = string.Format("Sql{0}.nhprof", DateTime.Now.ToString("yyyyMMddhhmmss"));
            if (offline) NHibernateProfiler.InitializeOfflineProfiling(offlineFileName);
            else NHibernateProfiler.Initialize();            
        }
        public static void TurnOffNHProfiler()
        {
            NHibernateProfiler.Shutdown();
        }


        //note: Db must exist prior to calling this method
        public static void CreateDbSchema()
        {
            var export = new SchemaExport(Cfg);
            export.Create(true, true);
            
            //export.Execute(new Action<string>(), );

            //cfg.SetDefaultAssembly(""); // to use for the mappings added to the cfg afterwords
            //cfg.SetDefaultNamespace("");// to use for the mappings added to the cfg afterwords            
            //string[] ddl = cfg.GenerateSchemaCreationScript(new MsSql2008Dialect());
            //cfg.ValidateSchema();

        }

        public static void DropDbSchema()
        {
            var export = new SchemaExport(Cfg);
            export.Drop(true, true);
        }
        
        public static void UpdateDbSchema() { }
        
        public static void ValidateDbSchema() { }
        

        public static void PopulateDbWithTestData() { }

    }
}