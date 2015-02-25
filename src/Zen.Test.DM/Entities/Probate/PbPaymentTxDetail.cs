using System;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Entity mapped as component...see PbDebtor
    /// </summary>
    public class PbPaymentTxDetail : PaymentTxDetail
    {
        
        #region Properties

        public virtual bool? Flip { get; set; } //[flip]        
        public virtual bool LateInvoice { get; set; }//[lateinvoiceflag]
        protected virtual string Rate { get; set; }
        public override decimal? CommissionRate
        {
            get { return Convert.ToDecimal(Rate); }
            set { if (Rate != null) Rate = value.Value.ToString(); }
        }        
        public virtual decimal? BalanceTotals { get; set; } //[balance totals]  
        public virtual decimal? DeathCertMailFee { get; set; } //[cert mail fee]        
        public virtual decimal? CommissionPaid { get; set; } //[commissionpaid]
        public virtual decimal? FilingFee { get; set; }//[filing fee]
        public virtual decimal? OtherFee { get; set; } //[other fee] 
        public virtual decimal? SearchFee { get; set; }
        public virtual string Copay { get; set; }//[copay]                
        public virtual string SicCode { get; set; } //[sic_code]
        public virtual string TxCode { get; set; }
        public virtual string CreatedBy { get; set; } 
        public virtual DateTime? ACHDetailDate { get; set; } //[dt_achdetail]
        public virtual DateTime? BalanceDate { get; set; }        
        public virtual DateTime? CapOne2085Date { get; set; }
        public virtual DateTime? CapOnePostDate { get; set; }
        public virtual DateTime? EisPmtDateRcvd { get; set; }//[eis_pmt_dt_recd]
        public virtual DateTime? EstateNoticeDate { get; set; }
        public virtual DateTime? MERDate { get; set; }
         
        #endregion

    }
}