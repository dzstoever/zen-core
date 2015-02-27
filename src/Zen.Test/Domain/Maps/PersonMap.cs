using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Zen.Data;

namespace Zen.Test.Domain.Maps
{
    public class PersonMap : ClassMapping<Person>, IDbMap
    {
        public PersonMap()
        {
            Schema("ZenTestDB.dbo"); Table("Person");

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

            Component(c => c.CellPhone, comp =>
            {
                comp.Property(p => p.Number, map => { map.Length(20); });
                
            });
            //public virtual PhoneInfo    CellPhone { get; set; }
            

        }
    }
}
