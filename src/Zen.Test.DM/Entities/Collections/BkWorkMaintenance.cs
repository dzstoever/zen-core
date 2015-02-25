namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [idx]
    /// Table = bkcol.dbo.[wrk_mnt]
    /// </summary>    
    public class BkWorkMaintenance : WorkMaintenance
    {        

        #region Properties

        public virtual int DebtorNum { get; set; }
        public virtual int RefNum { get; set; }
        public virtual string ClientShort { get; set; } //[ClientShortname]                
        public virtual string ErrorMessage { get; set; }
        public virtual string RecordImage { get; set; }        
        public virtual string StatusCode { get; set; }

        #endregion

    }
}