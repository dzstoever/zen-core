using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    public class DebtorContact : DomainEntity<int>
    {
        private ContactInfo _info;

        public virtual bool DoNotCall { get; set; }
        public virtual bool DoNotMail { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual bool IsVerifiedAtty { get; set; }
        
        //components
        public virtual ContactInfo Info
        {
            get { return _info ?? (_info = new ContactInfo()); }
            set { _info = value; }
        }
        
        //associations
        public virtual Debtor Debtor { get; set; }
        
        //note: map as non-lazy
        public virtual DebtorRelation Relation { get; set; }

    }
}