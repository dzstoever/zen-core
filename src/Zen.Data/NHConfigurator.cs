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
        public static IDbContext DbContext { get; private set; }
        public static Configuration Cfg { get; private set; }
        public static ISessionFactory SessionFactory { get; private set; }
        public static ISessionFactoryImplementor SessionFactoryImpl 
        {
            get { return SessionFactory as ISessionFactoryImplementor; }
        }

        /// <summary>
        /// Builds a SessionFactory for use with the NHibernateDao, using the supplied configuration file.
        /// LOADS EMBEDDED MAPPINGS FROM THE CONFIGURED ASSEMBLYS (hbmxml mapping assembly can also be set in the cfg file)
        /// </summary>
        /// <param name="xmlFileName">If set to an empty string Configure() will use app/web.config/hibernate.cfg.xml</param>
        /// <param name="bycodeAssembly">optional assembly with ByCode mappings</param>
        /// <param name="hbmxmlAssembly">optional assembly with embedded hbm.xml mappings</param>        
        public static void Configure(string xmlFileName, Assembly bycodeAssembly, Assembly hbmxmlAssembly)
        {
            Aspects.GetLogger().DebugFormat("Configuring database from {0}...", string.IsNullOrWhiteSpace(xmlFileName) ? "app/web.config or hibernate.cfg.xml" : xmlFileName);
            try
            {
                Cfg = new Configuration();
                if (string.IsNullOrWhiteSpace(xmlFileName))
                    Cfg.Configure();
                else
                    Cfg.Configure(xmlFileName);

                if (bycodeAssembly != null)
                    AddByCodeMappings(Cfg, bycodeAssembly);
                if (hbmxmlAssembly != null)
                    AddHbmXmlMappings(Cfg, hbmxmlAssembly);
                
                SessionFactory = Cfg.BuildSessionFactory();
                "{0} mappings in domain model.".LogMe(Log.LogLevel.Debug, SessionFactoryImpl.GetAllClassMetadata().Count());

                //set the DbContext
                SqlDialects sqlDialect;
                var nhDialect = SessionFactoryImpl.Dialect;                 
                switch (nhDialect.ToString())
                {// subset of 
                    case "NHibernate.Dialect.MsSql2005Dialect":      sqlDialect = SqlDialects.MsSql2005; break;
                    case "NHibernate.Dialect.MsSql2008Dialect":      sqlDialect = SqlDialects.MsSql2008; break;
                    case "NHibernate.Dialect.MsSql2012Dialect":      sqlDialect = SqlDialects.MsSql2012; break;
                    case "NHibernate.Dialect.MsSqlAzure2008Dialect": sqlDialect = SqlDialects.MsSqlAzure; break;
                    case "NHibernate.Dialect.MsSqlCe40Dialect":      sqlDialect = SqlDialects.MsSqlCe40; break;
                    case "NHibernate.Dialect.MsSqlCeDialect":        sqlDialect = SqlDialects.MsSqlCe; break;
                    case "NHibernate.Dialect.SQLiteDialect":         sqlDialect = SqlDialects.SQLite; break;
                    default: sqlDialect = SqlDialects.Other; break;
                }
                
                DbContext = new SqlContext
                {
                    CnnString = Cfg.GetProperty("connection.connection_string") ?? Cfg.GetProperty("connection.connection_string_name") ?? "",
                    SqlDialect = sqlDialect
                    //, HbmXmlMappingAssembly = //todo: check for mapping assembly in config file...
                };                
            }
            catch (Exception ex)
            { throw new ConfigException("Unable to configure session factory from xml/config file.", ex); }
        }

        /// <summary>
        /// Builds a SessionFactory for use with the NHibernateDao, using the supplied database context.
        /// LOADS ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLYS
        /// </summary>        
        public static void Configure(IDbContext dbContext)
        {
            Aspects.GetLogger().Debug("Configuring database from IDbContext...");
            try
            {
                var sqlDialect = (SqlDialects)Enum.Parse(typeof(SqlDialects), dbContext.DbDialect);
                ConfigureDbAccess(dbContext.ConnectionString, sqlDialect, dbContext.ByCodeMappingAssembly, dbContext.HbmXmlMappingAssembly);                                                               
            }
            catch (Exception ex)
            { throw new ConfigException("Unable to configure session factory from IDbCnnFactory.", ex); }
            DbContext = dbContext;
        }

        /// <summary>
        /// Builds a SessionFactory for use with the NHibernateDao, using the supplied database connection.
        /// LOADS ALL THE MAPPINGS FROM THE CONFIGURED ASSEMBLYS
        /// </summary>
        private static void ConfigureDbAccess(string cnnString, SqlDialects sqlDialect, Assembly bycodeAssembly, Assembly hbmxmlAssembly) //where T : Dialect
        {
            Cfg = new Configuration();
            Cfg.DataBaseIntegration(c =>
            {
                c.ConnectionString = cnnString; 
                switch (sqlDialect)
                {
                    case SqlDialects.MsSql2005: c.Dialect<MsSql2005Dialect>(); break;
                    case SqlDialects.MsSql2008: c.Dialect<MsSql2008Dialect>(); break;
                    case SqlDialects.MsSql2012: c.Dialect<MsSql2012Dialect>(); break;
                    case SqlDialects.MsSqlAzure: c.Dialect<MsSqlAzure2008Dialect>(); break;
                    case SqlDialects.MsSqlCe40: c.Dialect<MsSqlCe40Dialect>(); break;
                    case SqlDialects.MsSqlCe: c.Dialect<MsSqlCeDialect>(); break;
                    case SqlDialects.SQLite: c.Dialect<SQLiteDialect>(); break;
                    default: c.Dialect<MsSql2012Dialect>(); break;
                }            
                #if DEBUG
                c.LogSqlInConsole = true;
                c.LogFormattedSql = true;
                #endif
                // !!!
                //c.SchemaAction = SchemaAutoAction.Create;//.Create, .Recreate, .Update, .Validate
            });
            

            if(bycodeAssembly != null) 
                AddByCodeMappings(Cfg, bycodeAssembly);
            if(hbmxmlAssembly != null) 
                AddHbmXmlMappings(Cfg, hbmxmlAssembly);

            SessionFactory = Cfg.BuildSessionFactory();
            "{0} mappings in domain model.".LogMe(Log.LogLevel.Debug, SessionFactoryImpl.GetAllClassMetadata().Count());
        }

        /// <summary>
        /// load all class mappings from the assembly (marked with IDbMap)  
        /// </summary>
        private static void AddByCodeMappings(Configuration cfg, Assembly bycodeAssembly)
        {
            var byCodeMappings = (
                    from t in bycodeAssembly.GetTypes()
                    where t.GetInterfaces().Contains(typeof(IDbMap))
                    select t);// as Type[];
            var modelMapper = new ModelMapper();
            modelMapper.AddMappings(byCodeMappings);
            cfg.AddMapping(modelMapper.CompileMappingForAllExplicitlyAddedEntities());
            
        }

        /// <summary>
        /// load all embedded resources from the assembly (whose names end in .hbm.xml) 
        /// </summary>
        private static void AddHbmXmlMappings(Configuration cfg, Assembly hbmxmlAssembly)
        {
            cfg.AddAssembly(hbmxmlAssembly);
        }


        /// <summary>
        /// Use the NHProfiler to watch sql in realtime or create an offline file for later review
        /// note: don't forget to TurnOffNHProfiler(usually on App_Exit)
        /// </summary>
        /// <param name="offline">
        /// set offline to true if you want a file instead of live sql
        /// The filename will be named 'SqlyyyyMMddhhmmss.nhprof'
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