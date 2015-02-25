namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx]
    /// Table = bkcol.dbo.[wrk_plx]
    /// </summary>    
    public class BkWorkPlacement : WorkPlacement
    {
        
        #region Properties

        public virtual int RefNum { get; set; }
        
        #region using components...
        //public virtual string AttyAddr1 { get; set; }
        //public virtual string AttyAddr2 { get; set; }
        //public virtual string CosignorEmail { get; set; }
        //public virtual string CosignorFax { get; set; }
        //public virtual string OtherUserEmail { get; set; }
        //public virtual string OtherUserFax { get; set; }
        #endregion


        #endregion

    }
}