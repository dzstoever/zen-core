using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class PaymentTx : DomainEntity<int>
    {
        public virtual string CheckIssuer { get; set; }     // [checkissuer]        [chk issuer]
        public virtual string CheckNumber { get; set; }     // [checknum]           [chk nbr]        
        public virtual string TxHistory { get; set; }       // [tranhistory]        [payment history]
        public virtual DateTime? TxDate { get; set; }       // [trandate]           [pmt date recd1]        
        
        //associations        
        public virtual PaymentTxDetail Detail { get; set; } // fk [tranidx]         *map as component
        public virtual PaymentTxSource Source { get; set; } // on [transource]      on [pmt source] 
        public virtual IAccount Account { get; set; }       // *use Detail.Account  on [eisi matter #]
        public virtual Debtor Debtor { get; set; }          // on [debtornum]       *use Detail.Account.Debtor                
        
    }
}