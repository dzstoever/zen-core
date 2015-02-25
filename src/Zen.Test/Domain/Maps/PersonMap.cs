using System;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zen.Data;
using Zen.Test.Domain;

namespace Zen.Test.Maps
{
    public class PersonMap : ClassMapping<Person>, IDbMap
    {
        public PersonMap()
        {
            Schema("dbo"); Table("Person");

            //Id(x => x.Id, map => { map.Column("MRN"); map.Generator(Generators.Assigned); map.Length(15); });
            Id(x => x.Id, map=> map.Generator(Generators.GuidComb));

            Property(x => x.SSN, map => map.Length(9));
            Property(x => x.DOB);
            Property(x => x.DOD);

            Component(c => c.Name, comp =>
            {
                comp.Property(p => p.First, map => { map.Length(100); });
                comp.Property(p => p.Middle, map => { map.Length(100); });
                comp.Property(p => p.Last, map => { map.Length(100); });
            });
            

        }
    }
}
