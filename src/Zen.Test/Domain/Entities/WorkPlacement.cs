using System;
using Zen.Core;
using Zen.Test.Domain.Components;

namespace Zen.Test.Domain.Entities
{
    public class WorkPlacement : DomainEntity<int>
    {
        public virtual bool InsertFlag { get; set; } //true for records we want pushed into account tables
        public virtual bool IsOnFile { get; set; }
        public virtual int? CourtId { get; set; }
        public virtual decimal? AcctBal { get; set; }
        public virtual decimal? CommissionRate { get; set; }
        public virtual string AcctId { get; set; }
        public virtual string AcctNum { get; set; }
        public virtual string AcctType { get; set; }                
        public virtual string CaseHandler { get; set; }        
        public virtual string ClientMaster { get; set; }
        public virtual string ClientNumChargeOff { get; set; }
        public virtual string ClientNumOpen { get; set; }
        public virtual string ClientShort { get; set; }
        public virtual string DebtorSSN { get; set; }
        public virtual string DebtorSSNOriginal { get; set; }               
        public virtual string ErrorMessage { get; set; }
        public virtual string HistoryNote { get; set; }
        public virtual string InputFile { get; set; }                            
        public virtual string ProcessStatus { get; set; }
        public virtual string RMSCode { get; set; }
        public virtual string StatusCode { get; set; }
        public virtual string UD01 { get; set; }
        public virtual string UD02 { get; set; }
        public virtual string UD03 { get; set; }
        public virtual string UD04 { get; set; }
        public virtual string UD05 { get; set; }
        public virtual string UD06 { get; set; }
        public virtual string UD07 { get; set; }
        public virtual string UD08 { get; set; }
        public virtual string UD09 { get; set; }
        public virtual string UD10 { get; set; }
        public virtual DateTime? AcctOpenDate { get; set; }
        public virtual DateTime? ChargeOffDate { get; set; }
        //public virtual DateTime? CreateDate { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual DateTime? PlaceDate { get; set; }
        public virtual ContactInfo Attorney { get; set; }
        public virtual ContactInfo Cosignor { get; set; }
        public virtual ContactInfo Debtor { get; set; }
        public virtual ContactInfo OtherUser { get; set; }
        #region using components...
        /*public virtual string AttorneyCity { get; set; } //[]
        public virtual string AttorneyEmail { get; set; }//[]
        public virtual string AttorneyFax { get; set; }  //[]
        public virtual string AttorneyName { get; set; } //[]
        public virtual string AttorneyPhone { get; set; }//[]
        public virtual string AttorneyState { get; set; }//[]
        public virtual string AttorneyZip { get; set; }  //[]*/
        /*public virtual string CosignorAddr1 { get; set; }
        public virtual string CosignorAddr2 { get; set; }
        public virtual string CosignorCity { get; set; }
        public virtual string CosignorName { get; set; }
        public virtual string CosignorPhone { get; set; }
        public virtual string CosignorState { get; set; }
        public virtual string CosignorZip { get; set; }*/
        /*public virtual string DebtorAddr1 { get; set; } //*Pb-[Deceased...]
        public virtual string DebtorAddr2 { get; set; }
        public virtual string DebtorCity { get; set; }
        public virtual string DebtorFirstName { get; set; }
        public virtual string DebtorLastName { get; set; }
        public virtual string DebtorMiddleName { get; set; }
        public virtual string DebtorPhone1 { get; set; }
        public virtual string DebtorPhone2 { get; set; }        
        public virtual string DebtorState { get; set; }
        public virtual string DebtorZip { get; set; }*/
        /*public virtual string OtherUserAddress { get; set; }
        public virtual string OtherUserCity { get; set; }
        public virtual string OtherUserName { get; set; }
        public virtual string OtherUserPhone { get; set; }
        public virtual string OtherUserState { get; set; }
        public virtual string OtherUserZip { get; set; }*/
        #endregion
        public virtual WorkBatch Batch { get; set; }

    }
}