using System;
using System.Collections.Generic;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities.Estates
{
    /// <summary>
    /// Id = AccessId
    /// Table = probe.dbo.AcctMgmt_Manual
    /// </summary>
    public class EsAccount : DomainEntity<long>, IAccount
    {
        public virtual decimal? SearchFee { get; set; }
        public virtual string ClientName { get; set; }
        public virtual DateTime? ActionDate { get; set; }        
        public virtual DateTime? OpenDate { get; set; }        
        public virtual DateTime? SearchSentDate { get; set; }
        
        
        #region IAccount Members
        
        public virtual decimal? AcctBal { get; set; }
        public virtual decimal? AdjBal { get; set; }
        public virtual decimal? CommissionRate { get; set; }
        public virtual string AcctId { get; set; }
        public virtual string AcctType { get; set; }
        public virtual string AcctNum { get; set; }        
        public virtual string ActionCode { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? PlaceDate { get; set; }
        public virtual DateTime? ChargeOffDate { get; set; }
        
        //components
        public virtual PayArrangement PayArrangement { get; set; }        
        
        //associations
        public virtual Client Client { get; set; }
        public virtual Debtor Debtor { get; set; }
        public virtual StatusCode StatusCode { get; set; }
        public virtual CaseHandler CaseHandler { get; set; }
        
        //sets
        public virtual ISet<ExtraData> ExtraDataItems { get; set; }
        public virtual ISet<HistoryNote> HistoryNotes { get; set; }
        public virtual ISet<PaymentTx> PaymentTxs { get; set; }
        public virtual ISet<Response> ResponseEntrys { get; set; }
        public virtual void AddExtraData(ExtraData item)
        {
            if (ExtraDataItems == null) ExtraDataItems = new HashSet<ExtraData>();
            item.Account = this;
            ExtraDataItems.Add(item);
        }
        public virtual void AddHistoryNote(HistoryNote item)
        {
            if (HistoryNotes == null) HistoryNotes = new HashSet<HistoryNote>();
            item.Account = this;
            HistoryNotes.Add(item);
        }
        public virtual void AddPaymentTx(PaymentTx item)
        {
            if (PaymentTxs == null) PaymentTxs = new HashSet<PaymentTx>();
            item.Account = this;
            PaymentTxs.Add(item);
        }
        public virtual void AddResponse(Response item)
        {
            if (ResponseEntrys == null) ResponseEntrys = new HashSet<Response>();
            item.Account = this;
            ResponseEntrys.Add(item);
        }
        public virtual void RemoveExtraData(ExtraData item)
        {
            if (ExtraDataItems == null || !ExtraDataItems.Contains(item)) return;
            item.Account = null;
            ExtraDataItems.Remove(item);
        }
        public virtual void RemoveHistoryNote(HistoryNote item)
        {
            if (HistoryNotes == null || !HistoryNotes.Contains(item)) return;
            item.Account = null;
            HistoryNotes.Remove(item);
        }
        public virtual void RemovePaymentTx(PaymentTx item)
        {
            if (PaymentTxs == null || !PaymentTxs.Contains(item)) return;
            item.Account = null;
            PaymentTxs.Remove(item);
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
                if (AcctNum == null)
                    return null;
                if (AcctNum.Length < 5)
                    return "xxxx";

                var last4Index = AcctNum.Length - 4;
                return new string('x', last4Index) + AcctNum.Substring(last4Index, 4);
            }
        }

        #endregion
    }
}