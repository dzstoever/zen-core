using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public abstract class StatusCode : DomainEntity<string>
    {
        public virtual bool IsActiveInventory { get; set; } 
        public virtual string Description { get; set; }
    }
}