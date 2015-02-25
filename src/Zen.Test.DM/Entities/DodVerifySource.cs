using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class DodVerifySource : DomainEntity<string>
    {        
        public virtual string Description { get; set; }
    }
}