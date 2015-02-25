using System;
using System.Collections.Generic;
using System.Linq;

namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = DebtorNum
    /// </summary>
    public class BkDebtor : Debtor
    {

        public virtual string BKCaseNum { get; set; }
        public virtual string BKChapter { get; set; }
        public virtual string BKVerifyInitials { get; set; }
        public virtual string BKVerifySource { get; set; }
        public virtual string CustomerType { get; set; }
        public virtual string LastDialerCRC { get; set; }
        public virtual DateTime? BKFileDate { get; set; }
        public virtual DateTime? BKLastChecked { get; set; }
        public virtual DateTime? BKVerifyDate { get; set; }        
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? LastDialerDate { get; set; }
        
        //aggregates
        public virtual int? CurrentAge
        {
            get
            {
                if (DOB.HasValue)
                {
                    var years = DateTime.Now.Year - DOB.Value.Year;
                    if (DOB.Value.DayOfYear > DateTime.Now.DayOfYear)
                        years = years - 1; //birthday hasn't occured this year                                        
                    return years;
                }
                return null;
            }
        }


        public virtual ISet<DebtorContact> VerifiedAttorneys { get; set; }

        public virtual DebtorContact VerifiedAttorney
        {
            get
            {

                if (VerifiedAttorneys == null || VerifiedAttorneys.Count == 0)
                    return null;

                return VerifiedAttorneys.First();                        
            }
        }

        public override DebtorContact GetDebtorContact(char mailToCode)
        {
            if (ContactDictionary == null) return null;

            if (mailToCode == 'A' && VerifiedAttorney != null)
            {
                return VerifiedAttorney;
                /*
                var verifiedAttys =
                    from c in VerifiedAttorneys
                    where c.IsVerifiedAtty == true
                    select c;

                if (verifiedAttys.Count() > 0)
                    return verifiedAttys.FirstOrDefault();
                */
            }


            return (from c in ContactDictionary
                    where c.Key.MailToCode == mailToCode
                    select c.Value).FirstOrDefault();
        }

        public override DebtorContact GetDebtorContact(DebtorRelation debtorRelation)
        {
            if (ContactDictionary == null) return null;

            if (debtorRelation.MailToCode == 'A' && VerifiedAttorney != null)
            {
                return VerifiedAttorney;
                /*
                var verifiedAttys =
                     from c in VerifiedAttorneys
                     where c.IsVerifiedAtty == true
                     select c;

                if (verifiedAttys.Count() > 0)
                    return verifiedAttys.FirstOrDefault();
                */
            }

            return (from c in ContactDictionary
                    where c.Key == debtorRelation
                    select c.Value).FirstOrDefault();
        }


        
    }
}