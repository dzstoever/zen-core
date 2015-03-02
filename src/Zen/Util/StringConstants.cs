namespace Zen.Util
{
    public class StringConstants
    {
        public static string OracleConnStrTemplate = 
            "Data Source=XE;User Id=Sample; Password=password;";

        public static string SQLConnStrTemplate =
            "Data Source=localhost;Initial Catalog=Sample;Integrated Security=SSPI;";

        public static string PostgreSQLConnStrTemplate =
            "Server=localhost;Port=5432;Database=postgres;User Id=postgres;Password=password;";

        public static string MySqlConnStrTemplate =
            "Server=localhost;Port=3306;Database=letrunghieu;Uid=root;Pwd=a;";

        public static string SqliteConnStrTemplate =
            "Data Source=local.db;Version=3;New=False;Compress=True;";

        public static string SybaseConnStrTemplate =
            "Provider=ASAProv;UID=uidname;PWD=password;DatabaseName=databasename;EngineName=enginename;CommLinks=TCPIP{host=servername}";

        public static string IngresConnStrTemplate = 
            "Host=localhost;Port=II7;Database=myDb;User ID=myUser;Password=myPassword;";

        public static string CUBRIDConnStrTemplate =
            "server=localhost;port=33000;database=demodb;user=dba;password=";
    }
}