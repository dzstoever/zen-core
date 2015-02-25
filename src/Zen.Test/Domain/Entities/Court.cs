using System;
using System.Collections.Generic;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    public class Court : DomainEntity<int>
    {
        private AddressInfo _address = new AddressInfo();
        private PhoneInfo _phone = new PhoneInfo();

        public virtual int? ScoreRank { get; set; }
        public virtual decimal? ScoreTier1 { get; set; }
        public virtual decimal? ScoreTier2 { get; set; }
        public virtual decimal? ScoreTier3 { get; set; }        
        public virtual decimal? ClaimFilingFee { get; set; }
        public virtual decimal? DeathCertificateFee { get; set; }
        public virtual decimal? SearchFee { get; set; }
        public virtual decimal? VendorSearchFee { get; set; }
        public virtual string AuditBy { get; set; }
        public virtual string AuditComment { get; set; }        
        public virtual string CSRInstructions { get; set; }        
        public virtual string County { get; set; }        
        public virtual string Name { get; set; }
        public virtual string PayeeName { get; set; }
        public virtual string State { get; set; }
        public virtual string UpdateBy { get; set; }
        public virtual string UpdateComment { get; set; }
        public virtual string WebSite1 { get; set; }
        public virtual string WebSite2 { get; set; }
        public virtual DateTime? AuditReviewDate { get; set; }
        public virtual DateTime? UpdateDate { get; set; }

        //components
        public virtual AddressInfo Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public virtual PhoneInfo Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }        
        
        //associations
        public virtual CourtClaimSource ClaimSource { get; set; }
        public virtual CourtType CourtType { get; set; }
        
        //sets
        public virtual ISet<CourtInstruction> Instructions { get; set; }
                        

        #region Methods

        public virtual void AddNewInstruction(CourtInstructionType type, string note)
        {
            if (Instructions == null) Instructions = new HashSet<CourtInstruction>();
            var instruction = new CourtInstruction
            {
                Court = this,
                Type = type,
                Note = note
            };
            Instructions.Add(instruction);
        }

        public virtual void AddInstruction(CourtInstruction item)
        {
            if (Instructions == null) Instructions = new HashSet<CourtInstruction>();
            item.Court = this;
            Instructions.Add(item);
        }
        public virtual void RemoveInstruction(CourtInstruction item)
        {
            if (Instructions == null || !Instructions.Contains(item)) return;
            item.Court = null;
            Instructions.Remove(item);
        }

        #endregion
    }
}