using System;

namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx] 
    /// Table = bkcol.dbo.[apl_tran]
    /// </summary>
    public class BkPaymentTx : PaymentTx
    {
        #region Properties

        public virtual decimal? CheckAmount { get; set; }// [checkamt]  
        public virtual string AddedByProcess { get; set; }
        public virtual string AddedByUserId { get; set; }
        public virtual string Origin { get; set; }
        public virtual DateTime? PdcDate { get; set; }

        /// <summary>
        /// The corresponding Non-sufficient funds Tx
        /// </summary>
        public virtual PaymentTx NsfPaymentTx { get; set; }

        #endregion
        
    }
}