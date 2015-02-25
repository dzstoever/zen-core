using System;

namespace Zen.Test.Domain.Entities.Probate
{
    //mapped to [P2_MasterRecord]
    //- query criteria can only be applied to IMasterAccount members
    //- will issue 1 select (with outer joins to all subclasses)
    public interface IPbAccount : IMasterAccount, IAccount
    {
        #region Properties

        decimal? AdditionalFee { get; set; }
        decimal? PocAmt { get; set; }
        decimal? RelAmt { get; set; }
        decimal? SearchFee { get; set; }
        string Id { get; set; } //Note: implemented in base class (DomainEntity)
        string CaseNumber { get; set; }
        string ClaimFiledSource { get; set; }
        string ClientName { get; } //redundant value from MasterRecord
        string ContingencyRate { get; set; }
        string RmsCode { get; set; }
        DateTime? ActionDate { get; set; }
        DateTime? HearingDate { get; set; }        
        DateTime? InsSplSentDate { get; set; }
        DateTime? OpenDate { get; set; }                
        DateTime? SearchSentDate { get; set; }
        DateTime? SplSentDate { get; set; }        
        
        //associations
        PbAcctMgmt AcctMgmtAddl { get; set; }
        
        //aggregates
        int? DaysSinceSearchSent { get; }        

        #endregion
    }
}