using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class TriggerLog : DomainEntity<long>
    {        
        public virtual string FieldName { get; set; }
        public virtual string NewVal { get; set; }
        public virtual string OldVal { get; set; }
        public virtual string ProcessName { get; set; }
        public virtual string ServerName { get; set; }
        public virtual string TableName { get; set; }
        public virtual string UserId { get; set; }
        public virtual string Workstation { get; set; }
        //public virtual DateTime? CreateDate { get; set; }

    }
}