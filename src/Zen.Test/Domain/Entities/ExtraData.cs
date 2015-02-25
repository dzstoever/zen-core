using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public abstract class ExtraData : DomainEntity<int>
    {
        public virtual char FieldType { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string FieldValue { get; set; }
        public virtual string InputFile { get; set; }
        //public virtual DateTime? CreateDate { get; set; }

        //associations
        public virtual IAccount Account { get; set; }
        
    }
}