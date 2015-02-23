using System;
using System.Data.SqlClient;
using System.Text;

namespace Zen.Data
{
    public class SqlCnnFactory : IDbCnnFactory
    {
        private SqlConnectionStringBuilder _cnnBuilder;

        /// <summary>
        /// Override this in any derived class to get a connection string FROM WHEREVER YOU LIKE...
        /// One option could be to read it from app.config or web.config with ConfigurationManager
        /// .ConnectionStrings[ConfigurationManager.AppSettings["ConnectionStringName"]].ConnectionString; 
        /// </summary>
        /// <remarks>
        /// Provides a reasonable default = @"Server=localhost; Database=ZenTestDB; Trusted_Connection=True;"
        /// Azure example:
        /// @"Server=tcp:[serverName].database.windows.net;Database=myDataBase;
        /// User ID=[LoginForDb]@[serverName];Password=myPassword;Trusted_Connection=False;
        /// Encrypt=True;
        /// MultipleActiveResultSets=True;"
        /// </remarks>
        /// <see cref="http://www.connectionstrings.com/"/>
        protected virtual string CnnString()
        {
            return @"Server=.\SQLExpress; Database=ZenTestDB; Trusted_Connection=True;";
        }

        /// <summary>
        /// Override this in any derived class to use a different Sql Dialect
        /// </summary>
        /// <remarks> 
        /// Acceptable values are a subset of NHibernate.Dialect:
        /// MsSql2000Dialect
        /// MsSql2005Dialect
        /// MsSql2008Dialect
        /// MsSql2012Dialect
        /// MsSqlAzure2008Dialect
        /// MsSqlCe40Dialect
        /// MsSqlCeDialect
        /// SQLiteDialect
        /// </remarks>
        protected virtual string SqlDialect()
        {
            return "MsSql2012Dialect";
        }

        /// <summary>
        /// Override this in any derived class to use a different Sql Data Provider
        /// </summary>
        protected virtual string SqlProvider()
        {
            return "System.Data.SqlClient";
        }

        /// <summary>
        /// Only needs to be overridden if using MappedEntity(s)
        /// See the IDbCnnFactory for further descriptions.
        /// </summary>
        public virtual Type MappingAssemblyType()
        {
            return null;
        }

        /// <summary>
        /// Only needs to be overridden if using MappedEntity(s)
        /// See the IDbCnnFactory for further descriptions.
        /// </summary>
        public virtual string MappingAssemblyFQN()
        {
            return default(String);
        }


        public string ConnectionString
        {
            get
            {
                _cnnBuilder = new SqlConnectionStringBuilder(CnnString());
                return _cnnBuilder.ConnectionString;
            }
        }

        public string DatabaseDialect
        {
            get { return SqlDialect(); }
        }

        public string DataProvider
        {
            get { return SqlProvider(); }
        }

        public string DbName
        {
            get { return _cnnBuilder.InitialCatalog; }
        }

        public string DbServer
        {
            get { return _cnnBuilder.DataSource; }
        }

        public string DbUserId
        {
            get { return _cnnBuilder.IntegratedSecurity ? "IntegratedSecurity" : _cnnBuilder.UserID; }
        }

        public string DbPassword
        {
            get { return _cnnBuilder.IntegratedSecurity ? "IntegratedSecurity" : _cnnBuilder.Password; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Connection String: {0}", ConnectionString));
            sb.AppendLine(string.Format("Database Dialect: {0}", DatabaseDialect));
            sb.AppendLine(string.Format("Data Provider: {0}", DataProvider));
            var mType = MappingAssemblyType();
            sb.AppendLine(string.Format("Mapping Type: {0}", mType));
            sb.AppendLine(string.Format("Mapping FQN: {0}", mType!=null ? mType.AssemblyQualifiedName : MappingAssemblyFQN()));
            return sb.ToString();
        }
    }
    
}

