using System;
using Zen.Core;
using Zen.Core.Components;

namespace Zen.Test.Domain.Entities
{   
    public abstract class User : DomainEntity<string> //, IUser
    {        
        public virtual bool AllowAdmin { get; set; }
        public virtual bool AllowCourtEdit { get; set; }
        public virtual bool AllowFinance { get; set; }
        public virtual bool AllowMail { get; set; }
        public virtual bool AllowOperator { get; set; }
        public virtual bool AllowPaymentEntry { get; set; }
        public virtual bool BypassIsolationGroups { get; set; }
        public virtual bool ShowSSN { get; set; }
        public virtual int SecurityLevel { get; set; }
        public virtual string Department { get; set; }
        public virtual string PhoneExt { get; set; }
        public virtual string DefaultScreen { get; set; }
        public virtual DateTime? DateCreated { get; set; }    
    
        //components
        public virtual NameInfo Name { get; set; }
        
    }
}