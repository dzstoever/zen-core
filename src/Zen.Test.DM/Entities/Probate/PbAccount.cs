using System;
using System.Collections.Generic;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities.Probate
{    
    /// <summary>
    /// interface for all probate accounts
    /// </summary>
    /// <remarks>use for polymorphic queries 
    /// - will issue multiple selects (1 for each subclass)
    /// - result set is combined in one collection of PbAccount, typeof() each object in the list is a specific subclass</remarks>
    public abstract class PbAccount : DomainEntity<string>, IPbAccount
    {
        private decimal? _commissionRate;
        
        public virtual string MasterSSNRedacted
        {
            get
            {
                var last4Index = MasterSSN.Length - 4;
                return "xxx-xx-" + MasterSSN.Substring(last4Index, 4);
            }
        }


        #region IAccount Members
        
        public virtual decimal? AcctBal { get; set; }
        public virtual decimal? AdjBal { get; set; }
        /// <summary>
        /// convert ContingencyRate from string to decimal
        /// </summary>
        public virtual decimal? CommissionRate
        {
            get
            {
                _commissionRate = string.IsNullOrEmpty(ContingencyRate)
                                      ? (decimal?)null
                                      : Convert.ToDecimal(ContingencyRate);
                return _commissionRate;
            }
            set
            {
                _commissionRate = value;
                ContingencyRate = value.ToString();
            }
        }
        public virtual string AcctId { get; set; }
        public virtual string AcctNum { get; set; }
        public virtual string AcctType { get; set; }        
        public virtual string ActionCode { get; set; }
        public virtual DateTime? ChargeOffDate { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? PlaceDate { get; set; }        
        
        //components
        public virtual PayArrangement PayArrangement { get; set; }
        
        //associations        
        public virtual Client Client { get; set; }
        public virtual Debtor Debtor { get; set; }        
        public virtual StatusCode StatusCode { get; set; }
        public virtual CaseHandler CaseHandler { get; set; }           
        
        //sets                                                          
        public virtual ISet<PaymentTx> PaymentTxs { get; set; }
        public virtual void AddPaymentTx(PaymentTx item)
        {
            if (PaymentTxs == null) PaymentTxs = new HashSet<PaymentTx>();
            item.Account = this;
            PaymentTxs.Add(item);
        }
        public virtual void RemovePaymentTx(PaymentTx item)
        {
            if (PaymentTxs == null || !PaymentTxs.Contains(item)) return;
            item.Account = null;
            PaymentTxs.Remove(item);
        }        


        public virtual ISet<HistoryNote> HistoryNotes { get; set; }
        public virtual void AddHistoryNote(HistoryNote item)
        {
            if (HistoryNotes == null) HistoryNotes = new HashSet<HistoryNote>();
            item.Account = this;
            HistoryNotes.Add(item);
        }
        public virtual void RemoveHistoryNote(HistoryNote item)
        {
            if (HistoryNotes == null || !HistoryNotes.Contains(item)) return;
            item.Account = null;
            HistoryNotes.Remove(item);
        }
        
        public virtual ISet<ExtraData> ExtraDataItems { get; set; }
        public virtual void AddExtraData(ExtraData item)
        {
            if (ExtraDataItems == null) ExtraDataItems = new HashSet<ExtraData>();
            item.Account = this;
            ExtraDataItems.Add(item);
        }
        public virtual void RemoveExtraData(ExtraData item)
        {
            if (ExtraDataItems == null || !ExtraDataItems.Contains(item)) return;
            item.Account = null;
            ExtraDataItems.Remove(item);
        }                

        public virtual ISet<Response> ResponseEntrys { get; set; }
        public virtual void AddResponse(Response item)
        {
            if (ResponseEntrys == null) ResponseEntrys = new HashSet<Response>();
            item.Account = this;
            ResponseEntrys.Add(item);
        }
        public virtual void RemoveResponse(Response item)
        {
            if (ResponseEntrys == null || !ResponseEntrys.Contains(item)) return;
            item.Account = null;
            ResponseEntrys.Remove(item);
        }
        
        //aggregates
        public virtual int? DaysSincePlacement
        {
            get
            {
                if (PlaceDate.HasValue)
                {
                    var timespan = DateTime.Now.Subtract(PlaceDate.Value);
                    return timespan.Days;
                }
                return null;
            }
        }
        public virtual string AcctNumRedacted
        {
            get
            {
                if (AcctNum != null)
                {
                    if (AcctNum.Length < 5) return "xxxx";
                    var last4Index = AcctNum.Length - 4;
                    return new string('x', last4Index) + AcctNum.Substring(last4Index, 4);
                }
                return null;
            }
        }        

        #endregion
        
        #region IMasterAccount Members

        public virtual bool IsPurged { get; set; }
        public virtual string MasterAcctNum { get; set; }
        public virtual string MasterLastName { get; set; }
        public virtual string MasterSSN { get; set; }        
        public virtual string DatabaseName { get; set; }
        public virtual DateTime? MasterCreateDate { get; set; }

        #endregion

        #region IPbAccount Members
       
        public virtual decimal? AdditionalFee { get; set; }
        public virtual decimal? PocAmt { get; set; }
        public virtual decimal? RelAmt { get; set; }
        public virtual decimal? SearchFee { get; set; }        
        public virtual string CaseNumber { get; set; }
        public virtual string ClaimFiledSource { get; set; }
        public virtual string ClientName { get; set; } //Note: redundant member (available thru other entities)        
        public virtual string ContingencyRate { get; set; } //Note: member requires type conversion(nvarchar in the database)        
        public virtual string RmsCode { get; set; }
        public virtual DateTime? OpenDate { get; set; }
        public virtual DateTime? SplSentDate { get; set; }
        public virtual DateTime? InsSplSentDate { get; set; }
        public virtual DateTime? SearchSentDate { get; set; }
        public virtual DateTime? ActionDate { get; set; }
        public virtual DateTime? HearingDate { get; set; }
        
        //associations
        public virtual PbAcctMgmt AcctMgmtAddl { get; set; } //Note: additional info from P2_AcctMgmt...
        
        //aggregates
        public virtual int? DaysSinceSearchSent
        {
            get
            {
                if (SearchSentDate.HasValue)
                {
                    var timespan = DateTime.Now.Subtract(SearchSentDate.Value);
                    return timespan.Days;
                }
                return null;
            }
        }

        #endregion
       
    }    
}