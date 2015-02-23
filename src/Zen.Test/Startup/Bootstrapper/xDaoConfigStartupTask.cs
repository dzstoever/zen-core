using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bootstrap.Extensions.StartupTasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using Zen.Data;
using Zen.Log;
using Zen.Test.Domain;

namespace Zen.Test.Startup.Bootstrapper
{
    public class DaoConfigStartupTask : IStartupTask
    {
        /// <summary>
        /// Configure test database every time we startup...
        /// </summary>
        private static void ConfigureDbAccess()
        {            
            //DaoConfigurator.Configure();
            //Aspects.GetLogger().DebugFormat("{0} complete.", "DaoConfigStartupTask");
        }

        public void Run()
        {
            ConfigureDbAccess();
        }

        public void Reset()
        {
            ConfigureDbAccess(); // reconfigure to undo anything that changed...
        }

    }
}