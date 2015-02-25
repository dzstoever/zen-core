namespace Zen.Test.Domain.Entities.Collections
{
    public class BkUser : User
    {

        #region Properties
        
        public virtual bool AllowDebtorEdit { get; set; }
        public virtual bool AllowMailOutApproval { get; set; }

        #endregion

    }
}