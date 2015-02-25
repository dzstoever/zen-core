using System;
using System.Collections.Generic;
using System.Linq;
using Zen.Core;
using Zen.Core.Components;

namespace Zen.Test.Domain.Entities
{
    public abstract class Debtor : DomainEntity<int>
    {
        private NameInfo _name;
        private AddressInfo _address;
        private PhoneInfo _phone1;
        private PhoneInfo _phone2;
        private PhoneInfo _fax;
        
        
        //Note: DoNotCall/DoNotMail not used in Pb, for now
        public virtual bool? DoNotCall { get; set; }
        public virtual bool? DoNotMail { get; set; }
        public virtual string SSN { get; set; }
        public virtual DateTime? DOB { get; set; }
        
        //components        
        public virtual NameInfo Name
        {
            get { return _name ?? (_name = new NameInfo()); }
            set { _name = value; }
        }
        public virtual AddressInfo Address
        {
            get { return _address ?? (_address = new AddressInfo()); }
            set { _address = value; }
        }
        public virtual PhoneInfo Phone1
        {
            get { return _phone1 ?? (_phone1 = new PhoneInfo()); }
            set { _phone1 = value; }
        }
        public virtual PhoneInfo Phone2
        {
            get { return _phone2 ?? (_phone2 = new PhoneInfo()); }
            set { _phone2 = value; }
        }
        public virtual PhoneInfo Fax
        {
            get { return _fax ?? (_fax = new PhoneInfo()); }
            set { _fax = value; }
        }
        
        //associations
        public virtual Court Court { get; set; }        
                
        //Note: where ([isactive]=1) and ([addr1] is not null) and ([lastname] is not null or [firstname] is not null)
        public virtual IDictionary<DebtorRelation, DebtorContact> ContactDictionary { get; set; }        
        
        //aggregates
        public virtual string SSNRedacted
        {
            get
            {
                if (SSN == null) return "xxx-xx-xxxx";
                return "xxx-xx-" + SSN.Substring(SSN.Length - 4, 4);
            }
        }        
        /// <summary>
        /// read-only combination of all contact info 
        /// </summary>
        public virtual ContactInfo Info
        {
            get
            {
                return new ContactInfo
                           {
                               Name = Name,
                               Address = Address,
                               Phone1 = Phone1,
                               Phone2 = Phone2,
                               Fax = Fax
                           };
            }
        }


        #region Methods

        public virtual DebtorContact GetDebtorContact(char mailToCode)
        {
            if (ContactDictionary == null) return null;

            if (mailToCode == 'A')
            {
                var verifiedAttys =
                    from c in ContactDictionary
                    where c.Key.MailToCode == mailToCode
                        && c.Value.IsVerifiedAtty == true
                    select c.Value; 
                
                if (verifiedAttys.Count() > 0)
                    return verifiedAttys.FirstOrDefault();
            }


            return (from c in ContactDictionary
                    where c.Key.MailToCode == mailToCode
                    select c.Value).FirstOrDefault();
        }

        public virtual DebtorContact GetDebtorContact(DebtorRelation debtorRelation)
        {
            if (ContactDictionary == null) return null;

            if (debtorRelation.MailToCode == 'A')
            {
                var verifiedAttys =
                    from c in ContactDictionary
                    where c.Key.MailToCode == debtorRelation.MailToCode
                        && c.Value.IsVerifiedAtty == true
                    select c.Value;

                if (verifiedAttys.Count() > 0)
                    return verifiedAttys.FirstOrDefault();
            }

            return (from c in ContactDictionary
                    where c.Key == debtorRelation
                    select c.Value).FirstOrDefault();
        }

        #endregion
    }
}