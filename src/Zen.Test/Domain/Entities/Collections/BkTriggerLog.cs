namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx] *int
    /// Table = bkcol.dbo.[sys_triggerlog]
    /// </summary>    
    public class BkTriggerLog : TriggerLog
    {
        
        #region Properties

        public virtual bool IsDeleted { get; set; } //[IsDel]
        public virtual BkAccount Account { get; set; }                  //on [RefNum]
        public virtual BkDebtor Debtor { get; set; }                    //on [DebtorNum]
        public virtual BkDebtorContact DebtorContact { get; set; }      //on [DebtorRelIDX]        
        public virtual BkPaymentTx PaymentTx { get; set; }              //on [TranIDX]
        public virtual BkPaymentTxDetail PaymentTxDetail { get; set; }  //on [TranDetailIDX]        

        #endregion

    }
}