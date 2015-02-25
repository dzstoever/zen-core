using System;
using Zen.Data;
using Zen.Test.Maps;

namespace Zen.Test
{
    public class TestSqlCnnFactory : SqlCnnFactory
    {
        protected override string CnnString() { return @"Server=.\SQLEXPRESS; Initial Catalog=ZenTestDb; Integrated Security=true;"; }
        protected override SqlDialects SqlDialect() { return SqlDialects.MsSql2012Dialect; }

        public override Type MappingAssemblyType()
        {
            return typeof(PersonMap);
        }
        //public override string MappingAssemblyFQN() { }
    }
}