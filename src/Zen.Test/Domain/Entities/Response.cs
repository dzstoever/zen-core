using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class Response : DomainEntity<int>
    {
                                                                    // -Bk(Id=[idx])    -Pb(Id=[idfr] *also [responseid])
        public virtual bool IsDeleted { get; set; }
        public virtual string RespType { get; set; }
        public virtual string ClientMasterShortName { get; set; }
        public virtual DateTime? RespDate { get; set; }             // [CreateDate]     [RespDate]
        
        //associations
        public virtual IAccount Account { get; set; }               // on [Key1]        on [MatterNum]
                
    }
}