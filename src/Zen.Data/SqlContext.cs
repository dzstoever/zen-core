using System.Data.SqlClient;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace Zen.Data
{
    public class SqlContext : IDbContext
    {
        private SqlConnectionStringBuilder _cnnBuilder;
        
        public string ConnectionString
        {
            get
            {
                if(_cnnBuilder == null) _cnnBuilder = new SqlConnectionStringBuilder(CnnString);
                return _cnnBuilder.ConnectionString;
            }
        }
        public string DbDialect
        {
            get { return SqlDialect.ToString(); }
        }
        public string DbName
        {
            get
            {
                if (_cnnBuilder == null) _cnnBuilder = new SqlConnectionStringBuilder(CnnString);
                return _cnnBuilder.InitialCatalog;
            }
        }
        public string DbServer
        {
            get
            {
                if (_cnnBuilder == null) _cnnBuilder = new SqlConnectionStringBuilder(CnnString);
                return _cnnBuilder.DataSource;
            }
        }
        public string DbUserId
        {
            get
            {
                if (_cnnBuilder == null) _cnnBuilder = new SqlConnectionStringBuilder(CnnString);
                var winIdentity = WindowsIdentity.GetCurrent();
                var winUserId = winIdentity == null ? "" : winIdentity.Name ?? "";
                return _cnnBuilder.IntegratedSecurity ? winUserId : _cnnBuilder.UserID;
            }
        }
        public string DbPassword
        {
            get
            {
                if (_cnnBuilder == null) _cnnBuilder = new SqlConnectionStringBuilder(CnnString);
                return _cnnBuilder.IntegratedSecurity ? "IntegratedSecurity" : _cnnBuilder.Password;
            }
        }

        /// <summary>
        /// Override this in any derived class to get a connection string FROM WHEREVER YOU LIKE...
        ///     One option could be to read it from app.config or web.config with ConfigurationManager
        ///     .ConnectionStrings[ConfigurationManager.AppSettings["ConnectionStringName"]].ConnectionString; 
        /// </summary>
        /// <see cref="http://www.connectionstrings.net/"/>
        public virtual string CnnString { get; set; }
        /// <summary>
        /// Override this in any derived class to use a different Sql Dialect
        /// </summary>
        public virtual SqlDialects SqlDialect { get; set; }
        /// <summary>
        /// The assembly containing your ClassMapping<T> (IDbMap) classes.
        /// Used during configuration by the NHConfigurator.
        /// </summary>
        public virtual Assembly ByCodeMappingAssembly { get; set; }
        /// <summary>
        /// The assembly containing your hbm.xml embedded resource files.
        /// Used during configuration by the NHConfigurator.
        /// </summary>
        public virtual Assembly HbmXmlMappingAssembly { get; set; }
        

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Format("Connection String: {0}", ConnectionString));
            sb.AppendLine(string.Format("Database Dialect: {0}", DbDialect));
            sb.AppendLine(string.Format("ByCodeMapping Assembly: {0}", ByCodeMappingAssembly.ShowNullorEmptyString()));
            sb.AppendLine(string.Format("HbmXmlMapping Assembly: {0}", ByCodeMappingAssembly.ShowNullorEmptyString()));
            return sb.ToString();
        }

    }
    
}

