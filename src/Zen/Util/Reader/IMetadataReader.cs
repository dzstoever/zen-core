using System.Collections.Generic;
using Zen.Util.Domain;

namespace Zen.Util.Reader
{
    public interface IMetadataReader
    {
        IList<Column> GetTableDetails(Table table, string owner);
        List<Table> GetTables(string owner);
        IList<string> GetOwners();
        List<string> GetSequences(string owner);
        PrimaryKey DeterminePrimaryKeys(Table table);
        IList<ForeignKey> DetermineForeignKeyReferences(Table table);
        //List<string> GetSequences(List<Table> table);
        //List<string> GetForeignKeyTables(string columnName);
    }
}