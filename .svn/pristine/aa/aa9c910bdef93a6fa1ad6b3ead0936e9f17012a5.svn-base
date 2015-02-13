using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Zen.Data
{    
    public class SqlClientCnnFactory : IDbCnnFactory
    {
        protected SqlClientCnnFactory()
        {
            CnnBuilder = new System.Data.SqlClient.SqlConnectionStringBuilder(ConnectionString);
        }
        private readonly System.Data.SqlClient.SqlConnectionStringBuilder CnnBuilder;

        /// <summary>
        /// Override this in any derived class to get a connection string FROM WHEREVER YOU LIKE...
        /// One option could be to read it from app.config or web.config with ConfigurationManager
        /// .ConnectionStrings[ConfigurationManager.AppSettings["ConnectionStringName"]].ConnectionString; 
        /// </summary>
        /// <remarks>
        /// Provides a reasonable default = @"Server=localhost; Database=TestDB; Trusted_Connection=True;"
        /// Azure example:
        /// @"Server=tcp:[serverName].database.windows.net;Database=myDataBase;
        /// User ID=[LoginForDb]@[serverName];Password=myPassword;Trusted_Connection=False;
        /// Encrypt=True;
        /// MultipleActiveResultSets=True;"
        /// </remarks>
        /// <see cref="http://www.connectionstrings.com/"/>
        protected virtual string ConnectionString 
        {
            get { return @"Server=.\SQLExpress; Database=TestDB; Trusted_Connection=True;"; }            
        }
        
        public string GetConnectionString()
        {
            return CnnBuilder.ConnectionString;
        }
        public string GetDataProvider()
        {
            return "System.Data.SqlClient";
        }
        public string GetDbName()
        {
            return CnnBuilder.InitialCatalog;
        }
        public string GetDbServer()
        {
            return CnnBuilder.DataSource;
        }
        public string GetDbUserId()
        {
            return CnnBuilder.UserID;
        }
        public string GetDbPassword()
        {
            return CnnBuilder.Password;
        }

        /// <summary>
        /// Only needs to be overridden if using MappedEntity(s)
        /// See the IDbCnnFactory for further descriptions.
        /// </summary>
        public virtual string GetMappingAssemblyFQN()
        {
            return default(String);
        }
        /// <summary>
        /// Only needs to be overridden if using MappedEntity(s)
        /// See the IDbCnnFactory for further descriptions.
        /// </summary>
        public virtual string GetMappingAssemblyTypeName()
        {
            return default(String);
        }
    }

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
    
    public interface IDbCnnFactory
    {
        string GetConnectionString();
        string GetDataProvider();
        string GetDbName();
        string GetDbServer();
        string GetDbUserId();
        string GetDbPassword();
        
        /// <summary>
        /// Supply the fully qualified name of the assembly containing your IDbMapping classes 
        /// or .hbm.xml embedded resource files.
        /// </summary>
        /// <remarks>
        /// This only needs to be implemented if using MappedEntity(s).
        /// The MappedEntityConfigurator will try to load from the Type before the AssemblyFQN.
        /// </remarks>
        /// <example>"My.Sample.Assembly, Version=1.0.2004.0, Culture=neutral, PublicKeyToken=8744b20f8da049e3"</example>
        string GetMappingAssemblyFQN();
        /// <summary>
        /// Supply any type from the assembly containing your IDbMapping classes
        /// or .hbm.xml embedded resource files.
        /// </summary>
        /// <remarks>
        /// This only needs to be implemented if using MappedEntity(s).
        /// The MappedEntityConfigurator will try to load from the Type before the AssemblyFQN.
        /// </remarks>
        /// <example>"My.Sample.Assembly.MyMap, My.Sample.Assembly"</example>
        string GetMappingAssemblyTypeName();
    }

}
