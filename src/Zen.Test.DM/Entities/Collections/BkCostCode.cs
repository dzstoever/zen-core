
namespace Zen.Test.Domain.Entities.Collections
{
    /// <summary>
    /// Id = [CostCode] *actual key = IDX
    /// Table = bkcol.dbo.[lu_costcode]
    /// </summary>    
    public class BkCostCode : CostCode
    {
        public virtual int Idx { get; set; }  
    }
}