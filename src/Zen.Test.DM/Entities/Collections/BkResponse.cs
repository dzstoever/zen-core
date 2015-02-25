namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx]
    /// Table = bkcol.dbo.[apl_response]
    /// </summary>
    /// <remarks>use for accounts only, payments hooked to debtor</remarks>
    public class BkResponse : Response
    {        
        #region Properties

        //Note: Key1 = fk into account
        public virtual int Key2 { get; set; }
        public virtual int Key3 { get; set; }

        public virtual BkPaymentTxDetail PaymentTxDetail { get; set; }

        #endregion
    }
}