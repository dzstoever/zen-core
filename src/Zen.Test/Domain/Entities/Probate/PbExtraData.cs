namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = IDX
    /// </summary>
    public class PbExtraData : ExtraData
    {
        #region Properties

        public virtual char InputFileType { get; set; }
        //public virtual string MatterNum { get; set; }

        #endregion
    }
}