using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public abstract class HistoryNote : DomainEntity<int>
    {        
        public virtual string Note { get; set; }
        public virtual string NoteType { get; set; }
        public virtual string CreatedBy { get; set; }
        //public virtual DateTime? CreateDate { get; set; }

        //associations
        public virtual IAccount Account { get; set; }        
    }
}