using System;
using Zen.Data;
using Zen.Test.Maps;

namespace Zen.Test
{
    public class TestSqlCnnFactory : SqlCnnFactory
    {
        //protected override string CnnString() { return ""; }
        //protected override string SqlDialect() { return ""; }

        public override Type MappingAssemblyType()
        {
            return typeof(PersonMap);
        }
        //public override string MappingAssemblyFQN() { }
    }
}