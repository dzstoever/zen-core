using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    public class MailOutTemplateOverride : DomainEntity<int>
    {        
        public virtual string ClientMasterShortName { get; set; }
        public virtual string ClientShortName { get; set; }

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
        
        //associations
        public virtual MailOutTemplate MailOutTemplate { get; set; }
        public virtual MailOutType MailOutType { get; set; }

    }
}