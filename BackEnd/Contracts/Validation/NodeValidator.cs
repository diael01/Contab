using Contracts.Models;
using FluentValidation;
using Repository.Models;

namespace Contracts.Validation
{
    public class NodeValidator : CascadingAbstractValidator<OrgDTO>
    {
        public NodeValidator() : base()
        {
            RuleFor(org => org).NotNull();
            RuleFor(org => org.Name).NotNull();
            RuleFor(org => org.Level).NotNull();
            RuleFor(org => org.OrgNodeText).NotNull();
        }
    }

    public class OrgValidator : CascadingAbstractValidator<Organisation>
    {
        public OrgValidator() : base()
        {
            RuleFor(org => org).NotNull();
            RuleFor(org => org.Name).NotNull();
            RuleFor(org => org.Level).NotNull();
            RuleFor(org => org.OrgNode).NotNull();
            RuleFor(org => org.UpdatedBy).NotNull();
            RuleFor(org => org.UpdatedAt).NotNull();
            //RuleFor(org => org.OrgLevel).GreaterThan(0);//TBD: fix
        }
    }
}
