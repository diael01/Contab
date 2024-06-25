using Contracts.Models;
using Contracts.Validation;
using FluentValidation;

namespace Contracts.Validatidation
{
    public class OrgValidator : CascadingAbstractValidator<OrgDTO>
    {
        public OrgValidator() : base()
        {
            RuleFor(org => org).NotNull();
            RuleFor(org => org.Name).NotNull();
            RuleFor(org => org.Type).NotNull();

        }
    }
}
