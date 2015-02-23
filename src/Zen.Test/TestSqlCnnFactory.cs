using System;
using Zen.Data;
using Zen.Test.Maps;

namespace Zen.Test
{
    public class TestSqlCnnFactory : SqlCnnFactory
    {
        //protected override string CnnString() { return base.CnnString(); }
        //protected override string SqlDialect() { return base.SqlDialect(); }
        public override Type MappingAssemblyType()
        {
            return typeof(PersonMap);
        }
    }
}