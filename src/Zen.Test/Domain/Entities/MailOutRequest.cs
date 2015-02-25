using System;
using System.Collections.Generic;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Id = IDX
    /// </remarks>
    public class MailOutRequest : DomainEntity<int>
    {                      
        public virtual bool CeaseProcessing { get; set; }
        public virtual bool Mailed { get; set; }
        public virtual bool PrintAsap { get; set; }
        public virtual bool Processed { get; set; }        
        public virtual int? CourtId { get; set; }
        public virtual decimal? AdjBal { get; set; }        
        public virtual decimal? Cost1 { get; set; }
        public virtual decimal? Cost2 { get; set; }
        public virtual decimal? PmtAmt { get; set; }
        public virtual decimal? ReqBal { get; set; }
        public virtual decimal? ReqSif { get; set; }
        public virtual decimal? SifAmt { get; set; }
        public virtual string RequestedBy { get; set; }
        public virtual string ClientAcct { get; set; }
        public virtual string ClientCode { get; set; }
        public virtual string NoMailReason { get; set; }
        public virtual string AdditionalInfo { get; set; }                             
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? DueDate { get; set; }
        public virtual DateTime? ProcessedDate { get; set; }        
        public virtual DateTime? RequestedPrintDate { get; set; }
        public virtual DateTime? ReturnToSenderDate { get; set; }

        //components
        public virtual NameInfo MailToName { get; set; }
        public virtual AddressInfo MailToAddress { get; set; }
        
        //associations   
        public virtual IAccount Account { get; set; }
        public virtual LetterType LetterType { get; set; }                
        public virtual MailOutType MailOutType { get; set; }        
        public virtual MailOutBatch MailOutBatch { get; set; }
        //public virtual User Requestor { get; set; }

        //sets
        public virtual ISet<MailOutImage> MailOutImages { get; set; }                
        //public virtual ISet<MailOutPrintQ> PrintQEntrys { get; set; }
        
        
        #region Methods

        public virtual void AddImage(MailOutImage item)
        {
            if (MailOutImages == null) MailOutImages = new HashSet<MailOutImage>();
            item.Request = this;
            MailOutImages.Add(item);
        }
        public virtual void RemoveImage(MailOutImage item)
        {
            if (MailOutImages == null || !MailOutImages.Contains(item)) return;
            item.Request = null;
            MailOutImages.Remove(item);
        }        

        #endregion

    }
}