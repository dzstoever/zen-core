using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public abstract class CostCode : DomainEntity<string>
    {        
        public virtual bool IsBillable { get; set; }
        public virtual bool IsInvoiceable { get; set; }
        public virtual bool IsGLPostable { get; set; }
        public virtual decimal CurrentCost { get; set; }              
        public virtual string Description { get; set; }
        public virtual string ClientMasterShortName { get; set; }                 
    }
}