using System;

namespace Zen.Test.Domain.Entities.Probate
{
    public class PbMailOutRequest : MailOutRequest
    {
        public virtual bool EstateFound { get; set; }
        public virtual string CheckNumber { get; set; }
        public virtual DateTime? SearchResponseDate { get; set; }
    }
}