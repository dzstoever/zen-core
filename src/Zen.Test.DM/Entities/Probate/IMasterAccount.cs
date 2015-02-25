using System;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// interface representing a MasterAccount record
    /// </summary>
    /// <remarks>not mapped (use IPbAccount)</remarks>
    public interface IMasterAccount
    {
        #region Properties

        bool IsPurged { get; set; }
        string DatabaseName { get; set; }        
        string MasterAcctNum { get; set; }        
        string MasterLastName { get; set; }
        string MasterSSN { get; set; }
        DateTime? MasterCreateDate { get; set; }

        #endregion
    }
}