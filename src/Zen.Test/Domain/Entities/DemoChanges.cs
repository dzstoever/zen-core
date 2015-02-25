using System;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    public abstract class DemoChanges : DomainEntity<int>
    {        
        public virtual bool BypassScrub { get; set; }
        public virtual bool ReturnToSender { get; set; }
        public virtual bool UspsDeliverable { get; set; }
        public virtual string RecType { get; set; }
        public virtual string SSN { get; set; }
        public virtual DateTime LastUpdated { get; set; }
        public virtual DateTime NcoaVerifyDate { get; set; }
        public virtual DateTime UspsCertifyDate { get; set; }

        //components
        public virtual NameInfo Name { get; set; }
        public virtual AddressInfo Address { get; set; }

        //associations
        //Note: Probate - FK - MatterNum - linked thru Account.Debtor             
        //Note: Collections - FK - DebtorNum - linked directly to Debtor          
        public virtual Debtor Debtor { get; set; }
        public virtual DebtorRelation Relationship { get; set; }
        
    }
}