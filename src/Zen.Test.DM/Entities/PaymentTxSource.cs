using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class PaymentTxSource : DomainEntity<string>
    {
        public virtual bool? AffectsAdjBal { get; set; } // -all same...
        public virtual bool? AllowFinance { get; set; }
        public virtual bool? AllowMailRoom { get; set; }        
        public virtual bool? IsActive { get; set; }
        public virtual bool? IsCommissionable { get; set; }
        public virtual bool? IsFee { get; set; }
        public virtual bool? IsGLPostable { get; set; }
        public virtual bool? IsHidden { get; set; }
        public virtual bool? IsInHouse { get; set; }
        public virtual bool? IsInvoiceable { get; set; }
        public virtual bool? IsOnHold { get; set; }
        public virtual bool? IsReversal { get; set; }
        public virtual string Description { get; set; }
        
    }
}