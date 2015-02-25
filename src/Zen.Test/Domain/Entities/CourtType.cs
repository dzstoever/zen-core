using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class CourtType : DomainEntity<int>
    {
        public virtual string Description { get; set; }
        public virtual ISet<Court> Courts { get; set; }
        
        #region Methods

        public virtual void AddCourt(Court item)
        {
            if (Courts == null) Courts = new HashSet<Court>();
            item.CourtType = this;
            Courts.Add(item);
        }
        public virtual void RemoveCourt(Court item)
        {
            if (Courts == null || !Courts.Contains(item)) return;
            item.CourtType = null;
            Courts.Remove(item);
        }

        #endregion
    }
}