using System;
using System.Collections.Generic;
using System.Linq;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Table = dbo.APL_MailOutTypes
    /// Id = IDX
    /// </remarks>
    public class MailOutType : DomainEntity<int>
    {
        public virtual bool OnHold { get; set; }
        public virtual short AdjBalRequired { get; set; }
        public virtual short PifAmtRequired { get; set; }
        public virtual short PmtAmtRequired { get; set; }
        public virtual short SifAmtRequired { get; set; }
        public virtual string Description { get; set; }        
        public virtual string MailToCode { get; set; }
        public virtual string OnHoldReason { get; set; }
        public virtual string StatusExclusions { get; set; }
        //public virtual DateTime? CreateDate { get; set; } 
       
        //associations
        public virtual LetterType LetterType { get; set; }
        public virtual MailOutTemplate DefaultTemplate { get; private set; }        
        
        //sets
        public virtual ISet<MailOutTemplate> Templates { get; set; }
        public virtual ISet<MailOutTemplateOverride> TemplateOverrides { get; set; }
                
        
        #region Methods

        public virtual void PutOnHold(string reason)
        {
            OnHold = true;
            OnHoldReason = reason;
        }

        public virtual void TakeOffHold()
        {
            OnHold = false;
            OnHoldReason = null;
        }

        public virtual void SetDefaultTemplate(MailOutTemplate template)
        {
            DefaultTemplate = template;
            template.MailOutType = this;
            template.IsDefault = true;
        }        
        
        /// <summary>
        /// Checks for any template overrides present for this client
        /// </summary>
        /// <remarks>
        /// Multiple overrides for the same ClientShortName or ClientMasterShortName are invalid,
        /// the first one found will be returned
        /// </remarks>
        /// <remarks>
        /// The template Override may contain dynamic data even if it is the same physical file
        /// </remarks>
        /// <returns>
        /// ClientShortName override, if any
        /// ClientMasterShortName override, if any
        /// else DefaultTemplate
        /// </returns>
        public virtual MailOutTemplate GetClientTemplate(Client client)
        {
            if (TemplateOverrides != null)
            {
                //Note: Id = ShortName
                var templateOverride = CheckForClientShortOverride(client.Id);
                if (templateOverride != null)
                    return templateOverride;

                templateOverride = CheckForClientMasterOverride(client.MasterShortName);
                if (templateOverride != null)
                    return templateOverride;

            }            
            return DefaultTemplate;
        }
        private MailOutTemplate CheckForClientShortOverride(string shortName)
        {
            //get the override
            var templateOverride = TemplateOverrides.Where(shortLookup => shortLookup.ClientShortName == shortName)
                .FirstOrDefault();
            
            //return the template
            if (templateOverride == null) return null;
            return templateOverride.MailOutTemplate; 
                
        }
        private MailOutTemplate CheckForClientMasterOverride(string masterShortName)
        {
            //get the override
            var templateOverride = TemplateOverrides.Where(masterLookup => 
                masterLookup.ClientMasterShortName == masterShortName)
                .FirstOrDefault();
            
            //return the template
            if (templateOverride == null) return null;
            return templateOverride.MailOutTemplate; 
        }

        public virtual void AddTemplate(MailOutTemplate item)
        {
            if (Templates == null) Templates = new HashSet<MailOutTemplate>();
            item.MailOutType = this;
            Templates.Add(item);
        }
        public virtual void RemoveTemplate(MailOutTemplate item)
        {
            if (Templates == null || !Templates.Contains(item)) return;
            item.MailOutType = null;
            Templates.Remove(item);
        }

        #endregion

    }
}