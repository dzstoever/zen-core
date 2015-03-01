using Zen.Util.Domain;
using Zen.Util.Reader;

namespace Zen.Util
{
    public class MetadataFactory
    {
        public static IMetadataReader GetReader(ServerType serverType, string connectionStr)
        {
            switch (serverType)
            {
                //case ServerType.Oracle:
                //    return new OracleMetadataReader(connectionStr);
                //case ServerType.SqlServer:
                //    return new SqlServerMetadataReader(connectionStr);
                //case ServerType.MySQL:
                //    return new MysqlMetadataReader(connectionStr);
                //case ServerType.SQLite:
                //    return new SqliteMetadataReader(connectionStr);
                //case ServerType.Sybase:
                //    return new SybaseMetadataReader(connectionStr);
                //case ServerType.Ingres:
                //    return new IngresMetadataReader(connectionStr);
                //case ServerType.CUBRID:
                //    return new CUBRIDMetadataReader(connectionStr);
                //default:
                //    return new NpgsqlMetadataReader(connectionStr);

                //dzs
                default:
                    return new SqlServerMetadataReader(connectionStr);
            }
        }
    }
}