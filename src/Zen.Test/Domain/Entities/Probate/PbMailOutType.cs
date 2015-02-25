namespace Zen.Test.Domain.Entities.Probate
{
    public class PbMailOutType : MailOutType
    {
        #region Properties

        public virtual short PocAmtRequired { get; set; }
        public virtual short RelAmtRequired { get; set; }
        public virtual short ReqBalRequired { get; set; }
        public virtual short ReqSifRequired { get; set; }
        public virtual string ClaimCounty { get; set; }
        public virtual string ClaimState { get; set; } 

        #endregion
    }
}