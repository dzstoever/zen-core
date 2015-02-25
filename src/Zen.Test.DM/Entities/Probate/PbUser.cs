using System;

namespace Zen.Test.Domain.Entities.Probate
{
    public class PbUser : User
    {

        #region Properties
        
        public virtual bool AllowCap1BKFraud { get; set; }        
        public virtual bool AllowDeceasedEdit { get; set; }
        public virtual bool AllowDiscoverClosure { get; set; }                
        public virtual bool AllowNA { get; set; }        
        public virtual bool AllowPostEstate { get; set; }
        public virtual bool AllowPreEstate { get; set; }
        public virtual bool AllowQA { get; set; }                
        public virtual string ComputerName { get; set; }        
                
        #endregion

    }
}