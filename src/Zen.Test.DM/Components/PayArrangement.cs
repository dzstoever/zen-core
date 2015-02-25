using System;

namespace Zen.Test.Domain.Components
{
    public class PayArrangement //: ValidObject Todo: create subclasses to verify for different situations
    {
        public virtual short PmtCycle { get; set; }//Monthly Payment         
        public virtual decimal? LastPmtAmt { get; set; }
        public virtual decimal? PmtAmt { get; set; }        
        public virtual decimal? PifAmt { get; set; }//Paid in Full
        public virtual decimal? SifAmt { get; set; }//Settlement Offer                
        public virtual string SifType { get; set; }
        public virtual string SifApprovedBy { get; set; }
        public virtual DateTime? LastPmtDate { get; set; }
        public virtual DateTime? PmtDueDate { get; set; }
        public virtual DateTime? SifDueDate { get; set; }
    }
}