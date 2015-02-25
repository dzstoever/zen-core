namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [statuscode]
    /// Table = probe.dbo.[p2_lu_statuscode]
    /// </summary>
    public class PbStatusCode : StatusCode
    {

        #region Properties

        public virtual bool IsAuto { get; set; }
        public virtual bool IsChristus { get; set; }
        public virtual bool IsClosable { get; set; }
        public virtual bool IsEL2 { get; set; }
        public virtual bool IsHearingType { get; set; }
        public virtual bool IsLegal { get; set; }
        public virtual bool IsNA { get; set; }
        public virtual bool IsPTP { get; set; }
        public virtual bool IsPost { get; set; }
        public virtual bool IsPre { get; set; }
        public virtual bool IsRetired { get; set; }
        public virtual bool IsScorable { get; set; }
        public virtual bool IsStatus1 { get; set; }
        public virtual bool IsStatusA { get; set; }
        public virtual bool IsUncollectible { get; set; }

        #endregion

    }
}