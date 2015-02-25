namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [statuscode]
    /// Table = bkcol.dbo.[lu_statuscode]
    /// </summary>    
    public class BkStatusCode : StatusCode
    {        
        #region Properties

        public virtual bool HideSkip { get; set; }
        public virtual bool HideUI { get; set; }
        public virtual bool IsAction { get; set; }               
        public virtual string NextAction { get; set; }
        public virtual string SpecialInstructions { get; set; }
        public virtual string StatusUse { get; set; }

        #endregion
    }
}