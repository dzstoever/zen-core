namespace Zen.Test.Domain.Components
{
    public class AddressInfo : Zen.Core.Components.AddressInfo
    {
        /// <summary>
        /// store floating point zip codes from the database here
        /// </summary>
        public virtual float? Zip { get; set; }
        
    }
}