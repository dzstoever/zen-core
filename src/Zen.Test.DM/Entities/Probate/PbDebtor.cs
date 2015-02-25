using System;
using System.Collections.Generic;
using Zen.Core.Components;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = there is no database table. (everything is in the Account table) 
    /// </summary>
    public class PbDebtor : Debtor
    {
        private ContactInfo _attorney;        
        private ContactInfo _executor;
        private ContactInfo _family;
        private IDictionary<DebtorRelation, DebtorContact> _contactDictionary;

        public virtual string DODVerifyInitials { get; set; }
        public virtual string DODVerifySource { get; set; }
        public virtual DateTime? DOD { get; set; }
        public virtual DateTime? DODVerifyDate { get; set; }
        //components   
        public virtual ContactInfo Attorney
        {
            get { return _attorney ?? (_attorney = new ContactInfo()); }
            set { _attorney = value; }
        }
        public virtual ContactInfo Executor
        {
            get { return _executor ?? (_executor = new ContactInfo()); }
            set { _executor = value; }
        }
        public virtual ContactInfo Family
        {
            get { return _family ?? (_family = new ContactInfo()); }
            set { _family = value; }
        }
                      
        public override IDictionary<DebtorRelation, DebtorContact> ContactDictionary
        {
            get
            {
                if (_contactDictionary == null)
                {
                    _contactDictionary = new Dictionary<DebtorRelation, DebtorContact>();
                    if (Attorney != null)
                    {
                        var relation = new DebtorRelation {Id = "Attorney", MailToCode = 'A'};
                        _contactDictionary.Add(relation, new DebtorContact
                                                             {
                                                                 Info = Attorney,
                                                                 Relation = relation,
                                                                 Debtor = this,
                                                                 IsActive = true,
                                                                 IsVerifiedAtty = true
                                                             });
                    }
                    if (Executor != null)
                    {
                        var relation = new DebtorRelation {Id = "Executor", MailToCode = 'E'};
                        _contactDictionary.Add(relation, new DebtorContact
                                                             {
                                                                 Info = Executor,
                                                                 Relation = relation,
                                                                 Debtor = this,
                                                                 IsActive = true,
                                                             });
                    }
                    if (Family != null)
                    {
                        var relation = new DebtorRelation {Id = "Family", MailToCode = 'F'};
                        _contactDictionary.Add(relation, new DebtorContact
                                                             {
                                                                 Info = Family,
                                                                 Relation = relation,
                                                                 Debtor = this,
                                                                 IsActive = true,
                                                             });
                    }
                }
                return _contactDictionary;
            }
            set
            {
                throw new InvalidOperationException(
                    "Can not set probate ContactDictionary directly! Use PbAccount.(Attorney, Executor, Family) properties.");
            }
        }
        //aggregates
        public virtual int? DaysSinceDOD
        {
            get
            {
                if (DOD.HasValue)
                {
                    var ts = DateTime.Now.Subtract(DOD.Value);
                    return ts.Days;
                }
                return null;
            }
        }
        public virtual int? DeceasedAge
        {
            get
            {
                if (DOB.HasValue && DOD.HasValue)
                {
                    var yearDiff = DOD.Value.Year - DOB.Value.Year;
                    if (DOB.Value.DayOfYear > DOD.Value.DayOfYear)
                    {
                        yearDiff = yearDiff - 1;
                    } //Died before birthday in the year of death                    
                    return yearDiff;
                }
                return null;
            }
        }
        
    }
}