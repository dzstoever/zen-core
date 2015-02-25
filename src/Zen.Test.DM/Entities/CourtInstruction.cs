using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class CourtInstruction : DomainEntity<int>
    {
        public virtual string Note { get; set; }        
        public virtual string UpdateBy { get; set; }
        public virtual string UpdateComment { get; set; }
        public virtual DateTime? UpdateDate { get; set; }

        //associations
        public virtual Court Court { get; set; }
        public virtual CourtInstructionType Type { get; set; }
        
    }
}