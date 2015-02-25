using System;
using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Id = GUID
    /// </remarks>
    public class MailOutBatch : DomainEntity<Guid> //, MailOutBatch
    {
        public virtual int? PrintCount { get; set; }
        public virtual decimal? TotalCost { get; set; }
        public virtual decimal? TotalPostage { get; set; }
        public virtual string PrintJobName { get; set; }
        public virtual string PrinterName { get; set; }
        public virtual DateTime? PrintDate { get; set; }
        public virtual byte[] ReportArchive { get; set; }
        
        //sets
        public virtual ISet<MailOutRequest> Requests { get; set; }
        

        #region Methods

        public virtual void AddRequest(MailOutRequest item)
        {
            if (Requests == null) Requests = new HashSet<MailOutRequest>();
            item.MailOutBatch = this;
            Requests.Add(item);
        }
        public virtual void RemoveRequest(MailOutRequest item)
        {
            if (Requests == null || !Requests.Contains(item)) return;
            item.MailOutBatch = null;
            Requests.Remove(item);
        }

        #endregion

    }
}