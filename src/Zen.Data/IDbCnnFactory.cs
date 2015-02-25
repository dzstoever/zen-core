using System;
using System.Reflection;
using NHibernate.Dialect;

namespace Zen.Data
{
    public interface IDbCnnFactory
    {
        //Assembly ByCodeMappingAssembly { get; set; }
        //Assembly HbmXmlMappingAssembly { get; set; }

        /// <summary>
        /// Supply any type from the assembly containing your IDbMap classes
        /// or .hbm.xml embedded resource files.
        /// </summary>
        /// <remarks>
        /// This only needs to be implemented if using MappedEntity(s).
        /// The DaoConfigurator will try to load from the Type before the AssemblyFQN.
        /// </remarks>        
        Type MappingAssemblyType();
        /// <summary>
        /// Supply the fully qualified name of the assembly containing your IDbMapping classes 
        /// or .hbm.xml embedded resource files.
        /// </summary>
        /// <remarks>
        /// This only needs to be implemented if using MappedEntity(s).
        /// The DaoConfigurator will try to load from the Type before the AssemblyFQN.
        /// </remarks>
        /// <example>"My.Sample.Assembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3"</example>
        string MappingAssemblyFQN();

        string ConnectionString { get; }
        string DatabaseDialect { get; }
        string DataProvider { get; }        
        string DbName { get; }
        string DbServer { get; }
        string DbUserId { get; }
        string DbPassword { get; }      
    }

    /*
    public class NoDbCnnFactory : IDbCnnFactory
    {
        public string GetConnectionString()
        {
            return default(String);
        }
        public string GetDataProvider()
        {
            return default(String);
        }
        public string GetDbDialect()
        {
            return default(String);
        }

        public string GetDbName()
        {
            return default(String);
        }
        public string GetDbServer()
        {
            return default(String);
        }
        public string GetDbUserId()
        {
            return default(String);
        }
        public string GetDbPassword()
        {
            return default(String);
        }

        public string GetMappingAssemblyFQN()
        {
            return default(String);
        }
        public string GetMappingAssemblyTypeName()
        {
            return default(String);
        }

    }
    */
}
