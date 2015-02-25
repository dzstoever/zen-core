using System;

namespace Zen.Test.Domain.Entities.Probate
{
    /// <summary>
    /// Id = [responseid] (*[idfr] is actual key) 
    /// Table = probe.dbo.[p2_response]
    /// </summary>
    /// <remarks>use for accounts and payments</remarks>
    public class PbResponse : Response
    {
        
        #region Properties

        public virtual Guid UniqueId { get; set; } //[idfr]
        
        public virtual long? CustomBigInt1 { get; set; }
        public virtual string CustomString1 { get; set; }           //[CustomVarchar1] 
        public virtual string CustomString2 { get; set; }           //[CustomVarchar2]  
        public virtual DateTime? CustomDate { get; set; }           //[CustomSmallDateTime1]   
        public virtual DateTime? PhoneOrLetterDate { get; set; }    //[PhoneOrLetterDate]                

        public virtual PbPaymentTx PaymentTx { get; set; } //on [pmtidfr]        

        #endregion

    }
}