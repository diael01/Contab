using Contracts.Models;
using FluentValidation;
using Repository.Models;

namespace Contracts.Validation
{
    public class EmpDTOValidator : CascadingAbstractValidator<EmpDTO>
    {
        public EmpDTOValidator() : base()
        {
            RuleFor(emp => emp).NotNull();
            //TBD: created custom rule for ManagerNodeAsText
            ////=>to check not null ONLY if NOT level 0 or CEO
            //RuleFor(emp => emp.ManagerNodeAsText).NotNull();
            RuleFor(emp => emp.Name).NotNull();
            //TBD: to add more not nulls for other contracts after the UTs working

            //RuleFor(org => org.OrgNodeText).NotNull();
            //validate not null only if is not the root
        }
    }

    public class EmpValidator : CascadingAbstractValidator<Employee>
    {
        public EmpValidator() : base()
        {
            RuleFor(emp => emp).NotNull();
            RuleFor(emp => emp.ManagerNode).NotNull();
            RuleFor(emp => emp.Name).NotNull();
            RuleFor(emp => emp.UpdatedAt).NotNull();
            RuleFor(emp => emp.UpdatedBy).NotNull();
            //TBD: to add more not nulls for other contracts after the UTs working

            //RuleFor(org => org.OrgNodeText).NotNull();
            //validate not null only if is not the root
        }
    }
}
