using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class CourtInstructionType : DomainEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual ISet<CourtInstruction> Instructions { get; set; }


        #region Methods

        public virtual void AddNewInstruction(Court court, string note)
        {
            if (Instructions == null) Instructions = new HashSet<CourtInstruction>();
            var instruction = new CourtInstruction
            {
                Type = this,
                Court = court,
                Note = note
            };
            Instructions.Add(instruction);
        }

        public virtual void AddInstruction(CourtInstruction item)
        {
            if (Instructions == null) Instructions = new HashSet<CourtInstruction>();
            item.Type = this;
            Instructions.Add(item);
        }        
        public virtual void RemoveInstruction(CourtInstruction item)
        {
            if (Instructions == null || !Instructions.Contains(item)) return;
            item.Type = null;
            Instructions.Remove(item);
        }

        #endregion
    }
}