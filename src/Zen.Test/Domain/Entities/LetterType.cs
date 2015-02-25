using System.Collections.Generic;
using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// Id = LetterType
    /// </remarks>
    public class LetterType : DomainEntity<string>
    {
        public virtual bool? IsMailOut { get; set; }
        public virtual string Description { get; set; }
        
        //sets
        public virtual ISet<MailOutType> MailOutTypes { get; set; }


        #region Methods

        public virtual void AddMailOutType(MailOutType item)
        {
            if (MailOutTypes == null) MailOutTypes = new HashSet<MailOutType>();
            item.LetterType = this;
            MailOutTypes.Add(item);
        }
        public virtual void RemoveMailOutType(MailOutType item)
        {
            if (MailOutTypes == null || !MailOutTypes.Contains(item)) return;
            item.LetterType = null;
            MailOutTypes.Remove(item);
        }

        #endregion
    }
}