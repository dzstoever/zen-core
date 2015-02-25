namespace Zen.Test.Domain.Entities
{
}

namespace Zen.Test.Domain.Entities.Collections
{
}

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [idx]
    /// Table = probe.dbo.[p2_wrk_mnt]
    /// </summary>
    public class PbWorkMaintenance : WorkMaintenance
    {
        
        #region Properties

        //public virtual int SeqNum { get; set; }
        public virtual string MatterNum { get; set; }        

        #endregion

    }
}