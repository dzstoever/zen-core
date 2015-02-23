using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zen.Core;

namespace Zen.Test.Domain
{
    public class Person : DomainEntity<Guid>
    {
        public virtual string SSN { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual DateTime? DOD { get; set; }

        public virtual NameInfo Name { get; set; }
        public virtual AddressInfo HomeAddress { get; set; }
        public virtual AddressInfo WorkAddress { get; set; }
        public virtual PhoneInfo CellPhone { get; set; }
        public virtual PhoneInfo HomePhone { get; set; }
        public virtual PhoneInfo WorkPhone { get; set; }        
        public virtual Demographics Demographics { get; set; }

        public virtual IDictionary<ContactType, ContactInfo> Contacts { get; set; }        
    }

    public class Demographics : DomainObject
    {
        public virtual string Sex { get; set; }
        public virtual string Race { get; set; }
        public virtual string Country { get; set; }
        public virtual string Citizenship { get; set; }
        public virtual string MaritalStatus { get; set; }
        public virtual float Height { get; set; }
        public virtual float Weight { get; set; }        
        //public virtual ISet<string> Ethnicities { get; set; }
    }

    public class ContactType : DomainEntity<int>
    {
        public virtual string Description { get; set; }        
    }

    //public enum ContactTypes
    //{
    //    Spouse,
    //    Relative,
    //    Attorney,
    //    Physician //...
    //}
}
