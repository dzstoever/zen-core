namespace Zen.Test.Domain.Entities.Probate
{
    public class PurgedAccount : PbAccount
    {
        //members with not-null constraint

        #region Properties

        public virtual bool Attorney { get; set; }
        public virtual bool Child { get; set; }
        public virtual bool ReleaseMailed { get; set; }
        public virtual bool Spouse { get; set; }

        #endregion
    }
}