using System;
using Zen.Core;
using Zen.Core.Components;

namespace Zen.Test.Domain.Entities
{
    /// <summary>
    /// Id = ClientShortName
    /// </summary>
    public abstract class Client : DomainEntity<string>
    {
        private ContactInfo _contactInfo;

        public virtual bool? IsActive { get; set; }
        public virtual int? IsolationGroup { get; set; }
        public virtual string Name { get; set; }
        public virtual string MasterName { get; set; }
        public virtual string MasterShortName { get; set; }        
        //public virtual DateTime CreateDate { get; set; }

        //components
        public virtual ContactInfo Contact
        {
            get { return _contactInfo ?? (_contactInfo = new ContactInfo()); }
            set { _contactInfo = value; }
        }
    
    }
}