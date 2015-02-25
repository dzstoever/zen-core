using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class PaymentTxDetail : DomainEntity<int>
    {
        public virtual bool ChargedOff { get; set; }        // [chargedoff]         [c/o]
        public virtual decimal? TxAmount { get; set; }      // [tranamt]            [pmt amt recd1]        
        public virtual decimal? CommissionRate { get; set; }// [commissionrate]     [rate]*varchar
        public virtual decimal? Commission { get; set; }    // [commission]         [commission]                                      
        public virtual decimal? AcctBalAdj { get; set; }    // [adjbal]             [acctbaladj]
        public virtual decimal? Cost { get; set; }          // [cost]               [cost]  
        public virtual string CostCode { get; set; }        // [costcode]           [costcode]        
        public virtual string InvoiceNumber { get; set; }   // [invoicenum]         [invoice nbr]
        //public virtual DateTime? CreateDate { get; set; }   // [createdate]         [createdate]
        public virtual DateTime? InvoiceDate { get; set; }  // [invoicedate]        [invoice date]            
        public virtual DateTime? PostDate { get; set; }     // [postdate]           [post date]
        public virtual Guid? CostLink { get; set; }
        
        //associations
        public virtual IAccount Account { get; set; }       // on [refnum] int      on [eisi matter #] string        
        
    }
}