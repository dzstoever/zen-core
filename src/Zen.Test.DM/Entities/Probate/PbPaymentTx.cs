using System;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [id] (*[gid] is actual key) 
    /// Table = probe.dbo.[payments]
    /// </summary>
    public class PbPaymentTx : PaymentTx
    {             
        #region Properties
        
        public virtual Guid UniqueId { get; set; }              //[gid]

        public virtual PbPaymentTxSource Source2 { get; set; }  // on [pmt source2]

        public virtual PbResponse Response { get; set; }        // on [gid] int            

        //Note: not mapped
        public override Debtor Debtor
        {
            get { return Detail.Account.Debtor; }
            set
            {
                throw new Exception("Set the account/debtor using PbPaymentTx.Detail.Account");
                //Detail.Account.Debtor = value;
            }
        }

        #endregion
    }
}