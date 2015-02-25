namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [status codes]
    /// Table = probe.dbo.[payment source]
    /// </summary>
    public class PbPaymentTxSource : PaymentTxSource
    {
        #region Properties

        public virtual bool? IsDPC { get; set; }
        public virtual bool? IsEST { get; set; }
        public virtual bool? IsFEL { get; set; }
        public virtual bool? IsRemittable { get; set; }

        #endregion
    }
}