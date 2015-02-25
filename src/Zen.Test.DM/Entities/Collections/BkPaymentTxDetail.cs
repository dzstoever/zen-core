using System;

namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx] 
    /// Table = bkcol.dbo.[apl_trandetail]
    /// </summary>
    public class BkPaymentTxDetail : PaymentTxDetail
    {
        #region Properties

        public virtual bool ClientAck { get; set; }
        public virtual bool Presented { get; set; }
        public virtual bool Reported { get; set; }
        public virtual string RmsCode { get; set; }
        public virtual DateTime? ClientAckDate { get; set; }        
        public virtual DateTime? PresentedDate { get; set; }        
        public virtual DateTime? ReportedDate { get; set; }        

        #endregion
    }
}