using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class NocProcess : DomainEntity<int>
    {       
        public virtual short Type { get; set; }
        public virtual short Criticality { get; set; }
        public virtual string Description { get; set; }
        public virtual string Executable { get; set; }
        public virtual string Name { get; set; }    
    
        //associations
        public virtual NocApplication Application { get; set; }
    }
}