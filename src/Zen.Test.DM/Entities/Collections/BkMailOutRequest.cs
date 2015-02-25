using System;

namespace Zen.Test.Domain.Entities.Collections
{
    public class BkMailOutRequest : MailOutRequest
    {
        #region Properties

        public virtual bool IsApproved { get; set; }        
        public virtual string ApprovalManager { get; set; } //[approvemgr]
        public virtual DateTime? ApprovalDate { get; set; } //[approvedate]
        public virtual BkPaymentTx PaymentTx { get; set; } //on [TranIDX]

        #endregion
    }
}