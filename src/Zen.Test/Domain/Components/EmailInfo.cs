//using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
using Zen.Core;

namespace Zen.Test.Domain.Components
{
    public class EmailInfo : DomainObject
    {
        //[StringLengthValidator(5, 100)]
        //[NotNullValidator]
        public virtual string To { get; set; }
    }
}