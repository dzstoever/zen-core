using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public abstract class CaseHandler : DomainEntity<string>
    {
        public virtual string Description { get; set; }
        public virtual string Name { get; set; }        
    }
}