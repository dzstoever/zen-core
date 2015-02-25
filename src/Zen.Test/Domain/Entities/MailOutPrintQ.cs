using System;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Id = IDX
    /// </remarks>
    public class MailOutPrintQ : DomainEntity<int> 
    {
        //Todo: use these to group documents prior to printing
        public virtual bool IsDuplex { get; set; }
        public virtual int SortId { get; set; }
        public virtual int TrayNumber { get; set; }

        //associations
        //Note: use the Request to get Type, Batch, & Image(s) info
        public virtual MailOutRequest Request { get; set; }
        public virtual MailOutTemplate Template { get; set; }
        
    }
}