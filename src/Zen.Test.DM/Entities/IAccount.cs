using System;
using System.Collections.Generic;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    public interface IAccount : IDomainObject
    {
        /// <summary>
        /// use this as the universal identifier,(EntityId implemented in DomainEntity)
        /// when working with accounts from different domains together
        /// </summary>
        Guid Uid { get; }

        decimal? AcctBal { get; set; }
        decimal? AdjBal { get; set; }
        decimal? CommissionRate { get; set; }
        string AcctId { get; set; }
        string AcctNum { get; set; }
        string AcctNumRedacted { get; }
        string AcctType { get; set; }
        string ActionCode { get; set; }        
        DateTime? ChargeOffDate { get; set; }                
        DateTime? CreateDate { get; set; }        
        DateTime? PlaceDate { get; set; }                
        
        //components
        PayArrangement PayArrangement { get; set; }        
        
        //associations
        Client Client { get; set; }
        Debtor Debtor { get; set; }
        StatusCode StatusCode { get; set; }
        CaseHandler CaseHandler { get; set; }

        //sets
        ISet<HistoryNote> HistoryNotes { get; set; }
        ISet<PaymentTx> PaymentTxs { get; set; }        
        ISet<ExtraData> ExtraDataItems { get; set; }        
        ISet<Response> ResponseEntrys { get; set; }                              
        
        //aggregates
        int? DaysSincePlacement { get; }

        
        #region Methods

        /// <remarks>
        /// If the payment 'item' has .PaymentTxDetail it should be persisted by reachability.
        /// </remarks>
        void AddPaymentTx(PaymentTx item);
        void AddHistoryNote(HistoryNote item);
        void AddExtraData(ExtraData item);
        void AddResponse(Response item);
        void RemovePaymentTx(PaymentTx item);
        void RemoveHistoryNote(HistoryNote item);
        void RemoveExtraData(ExtraData item);
        void RemoveResponse(Response item);
        
        #endregion
    }
}