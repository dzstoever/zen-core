namespace Zen.Test.Domain.Entities.Probate
{
    public class PbLetterType : LetterType
    {
        #region Properties

        public virtual bool? IsPost { get; set; }
        public virtual bool? IsPre { get; set; }

        #endregion
    }
}