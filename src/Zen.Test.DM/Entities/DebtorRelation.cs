using Zen.Core;

namespace Zen.Test.Domain.Entities
{
    /// <remarks>
    /// For Pb/Es:
    /// *contacts are stored in [AccountManagement] tables
    /// set/built in code
    /// </remarks> 
    /// <remarks>
    /// For Bk:
    /// Table = [LU_Relationship]
    /// Id = Relationship 
    /// </remarks>
    public class DebtorRelation : DomainEntity<string> 
    {
        public virtual char MailToCode { get; set; }
    }
}