using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class WorkMaintenance : DomainEntity<int>
    {                                                  
        public virtual bool IsOnFile { get; set; }
        public virtual decimal? CommissionRate { get; set; }
        public virtual decimal? GrossAmount { get; set; }
        public virtual decimal? NetAmount { get; set; }
        public virtual string AcctId { get; set; }
        public virtual string AcctNum { get; set; }        
        public virtual string ClientMaster { get; set; }                
        public virtual string FieldCode { get; set; }        
        public virtual string InputFile { get; set; }        
        public virtual string MaintData { get; set; } //[MntData]        
        public virtual string RMSCode { get; set; }
        public virtual string RecordType { get; set; }
        public virtual string TranCode { get; set; }        
        public virtual string UD01 { get; set; }
        public virtual string UD02 { get; set; }
        public virtual string UD03 { get; set; }
        public virtual string UD04 { get; set; }
        public virtual string UD05 { get; set; }
        public virtual string UD06 { get; set; }
        public virtual string UD07 { get; set; }
        public virtual string UD08 { get; set; }
        public virtual string UD09 { get; set; }
        public virtual string UD10 { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime TranDate { get; set; }

        //associations
        public virtual WorkBatch Batch { get; set; } //on BatchID
        
    }
}