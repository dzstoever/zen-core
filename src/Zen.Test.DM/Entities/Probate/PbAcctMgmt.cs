using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = MatterNum
    /// Table = [P2_AcctMgmt]
    /// </summary>
    public class PbAcctMgmt : DomainEntity<string>
    {
        public virtual decimal? RegZBal { get; set; }
        public virtual string AttyAddr2 { get; set; }
        public virtual string ExecAddr2 { get; set; }
        public virtual string ContactAddr2 { get; set; }
        public virtual string ClientStatus { get; set; }                        
        public virtual string PaymentTerms { get; set; }        
        public virtual DateTime? ClientStatusUpdated { get; set; }
        public virtual DateTime? PaymentDueDate { get; set; }
        public virtual DateTime? RegZExpireDate { get; set; }

        //one-to-one *not needed
        //public virtual IPbAccount Account { get; set; }

    }
}