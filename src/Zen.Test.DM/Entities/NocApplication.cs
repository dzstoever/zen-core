using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class NocApplication : DomainEntity<int>
    {
        public virtual string Name { get; set; }
        
        //sets
        public virtual ISet<NocProcess> Processes { get; set; }


        #region Methods

        public virtual void AddProcess(NocProcess item)
        {
            if (Processes == null) Processes = new HashSet<NocProcess>();
            item.Application = this;
            Processes.Add(item);
        }
        public virtual void RemoveProcess(NocProcess item)
        {
            if (Processes == null || !Processes.Contains(item)) return;
            item.Application = null;
            Processes.Remove(item);
        }

        #endregion
    }
}