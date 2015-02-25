using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Id = GUID
    /// </remarks>
    public class MailOutImage : DomainEntity<Guid> 
    {
        public virtual byte[] Archive { get; set; }

        //associations
        public virtual MailOutRequest Request { get; set; }
        
    }
}