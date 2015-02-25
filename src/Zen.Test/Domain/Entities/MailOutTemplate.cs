using System;
using System.Collections.Generic;
using System.Text;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Table = dbo.APL_MailOutTemplates
    /// Id = IDX
    /// </remarks>
    public class MailOutTemplate : DomainEntity<int>
    {
        public virtual bool IsDefault { get; set; }
        public virtual bool IsDuplex { get; set; }
        public virtual bool SigIsDynamic { get; set; }
        public virtual bool SigIsLegal { get; set; }
        public virtual int? FlatPageCount { get; set; }
        public virtual int? PrintPageCount { get; set; }
        public virtual string AuditBy { get; set; }                
        public virtual string EnvelopeName { get; set; }
        public virtual string FileName { get; set; }        
        public virtual string FooterSubtitle { get; set; }
        public virtual string HeaderFax { get; set; }
        public virtual string HeaderHours { get; set; }
        public virtual string HeaderPhone { get; set; }
        public virtual string HeaderSubtitle { get; set; }
        public virtual string HeaderTollfree { get; set; }
        public virtual string HeaderWebsite { get; set; }                
        public virtual string PayAddress { get; set; }
        public virtual string PayCityStateZip { get; set; }
        public virtual string PayName { get; set; }        
        public virtual string PrinterDatName { get; set; }
        public virtual string PrinterName { get; set; }        
        public virtual string Status { get; set; }
        public virtual DateTime? AuditDate { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        
        //associations
        public virtual MailOutType MailOutType { get; set; }
        
        //sets
        public virtual ISet<MailOutTemplateOverride> TemplateOverrides { get; set; }

        
        #region Methods

        public virtual string GetTypeDescription()
        {
            return (MailOutType == null) ? "null" : MailOutType.Description;
        }
        public virtual string GetClientOverrideString()
        {
            if (IsDefault)
                return "[default]";
            
            if (TemplateOverrides == null || TemplateOverrides.Count == 0)
                return "[none]";

            var sb = new StringBuilder("Clients: ");
            var i = 1;
            foreach (var lookup in TemplateOverrides)
            {
                sb.Append(lookup.ClientMasterShortName ?? lookup.ClientShortName);
                if (i < TemplateOverrides.Count) sb.Append(", ");
                i++;
            }
            return sb.ToString();
        }

        public virtual void AddTemplateOverride(MailOutTemplateOverride item)
        {
            if (TemplateOverrides == null) TemplateOverrides = new HashSet<MailOutTemplateOverride>();
            item.MailOutTemplate = this;
            TemplateOverrides.Add(item);
        }
        public virtual void RemoveTemplateOverride(MailOutTemplateOverride item)
        {
            if (TemplateOverrides == null || !TemplateOverrides.Contains(item)) return;
            item.MailOutTemplate = null;
            TemplateOverrides.Remove(item);
        }
                
        #endregion
    }
}