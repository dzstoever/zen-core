using System.Reflection;

namespace Zen.Data
{
    public interface IDbContext
    {        
        string ConnectionString { get; }                
        string DbDialect { get; }
        string DbName { get; }
        string DbServer { get; }
        string DbUserId { get; }
        string DbPassword { get; }

        /// <summary>
        /// The assembly containing your ClassMapping<T> (IDbMap) classes.
        /// Used during configuration by the NHConfigurator.
        /// </summary>        
        Assembly ByCodeMappingAssembly { get; set; }
        /// <summary>
        /// The assembly containing your hbm.xml embedded resource files.
        /// Used during configuration by the NHConfigurator.
        /// </summary>        
        Assembly HbmXmlMappingAssembly { get; set; }
    }

}
