using Contracts.Models;
using FluentValidation;

namespace Contracts.Validation
{
    public class NodeValidator : CascadingAbstractValidator<OrgDTO>
    {
        public NodeValidator() : base()
        {
            RuleFor(org => org).NotNull();
            RuleFor(org => org.Name).NotNull();
            //RuleFor(org => org.NodeAsText).NotNull();
            //validate not null only if is not the root
        }
    }

    public class OrgValidator : CascadingAbstractValidator<Organisation>
    {
        public OrgValidator() : base()
        {
            RuleFor(org => org).NotNull();
            RuleFor(org => org.Name).NotNull();
            RuleFor(org => org.Node).NotNull();
            RuleFor(org => org.NodeAsText).NotNull();
            RuleFor(org => org.UpdatedBy).NotNull();
            RuleFor(org => org.UpdatedAt).NotNull();
            //RuleFor(org => org.OrgLevel).GreaterThan(0);
            //TBD: fix validate not null only if is not the root
        }
    }
}
