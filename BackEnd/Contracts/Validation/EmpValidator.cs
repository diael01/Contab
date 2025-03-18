using Contracts.Models;
using FluentValidation;

namespace Contracts.Validation
{
    public class EmpDTOValidator : CascadingAbstractValidator<EmpDTO>
    {
        public EmpDTOValidator() : base()
        {
            RuleFor(emp => emp).NotNull();
            //RuleFor(emp => emp.EmpNodeAsText).NotNull();
            RuleFor(emp => emp.FirstName).NotNull();
            RuleFor(emp => emp.LastName).NotEmpty();
            //RuleFor(emp => emp.FullName).NotWhiteSpace(); todo
            RuleFor(emp => emp.IdCardSerieNo).NotNull();
            RuleFor(emp => emp.IdCardCnp).NotNull();
            RuleFor(emp => emp.MainSalary).NotNull();
            RuleFor(emp => emp.CountyCode).NotNull();
            RuleFor(emp => emp.PersonalEmail).NotNull();
            RuleFor(emp => emp.Birthday).NotNull();

            //RuleFor(emp => emp.EmpDeptNodeText).NotNull();
            //RuleFor(emp => emp.EmpActivityNodeText).NotNull();
            //RuleFor(emp => emp.EmpWorkTypeNodeText).NotNull();
            //RuleFor(emp => emp.EmpFunctionNodeText).NotNull();
        }
    }

    public class EmpValidator : CascadingAbstractValidator<Employee>
    {
        public EmpValidator() : base()
        {
            RuleFor(emp => emp).NotNull();
            RuleFor(emp => emp.EmpNode).NotNull();
            RuleFor(emp => emp.ManagerNode).NotNull();
            RuleFor(emp => emp.LastName).NotNull();
            RuleFor(emp => emp.FirstName).NotNull();
            RuleFor(emp => emp.IdCardSerieNo).NotNull();
            RuleFor(emp => emp.IdCardCnp).NotNull();
            RuleFor(emp => emp.MainSalary).NotNull();

            //RuleFor(emp => emp.HiringDate).NotNull();
            //RuleFor(emp => emp.EmpShift).NotNull();
            //RuleFor(emp => emp.WorkGroup).NotNull();
            //RuleFor(emp => emp.HoursToWork).NotNull();
            //RuleFor(emp => emp.TypeWorkContract).NotNull();

            RuleFor(emp => emp.CountyCode).NotNull();
            RuleFor(emp => emp.PersonalEmail).NotNull();
            RuleFor(emp => emp.Birthday).NotNull();
            //RuleFor(emp => emp.EmpDeptNode).NotNull();
            //RuleFor(emp => emp.EmpActivityNode).NotNull();
            //RuleFor(emp => emp.EmpWorkTypeNode).NotNull();
            //RuleFor(emp => emp.EmpFunctionNode).NotNull();
            RuleFor(emp => emp.UpdatedAt).NotNull();
            RuleFor(emp => emp.UpdatedBy).NotNull();
        }
    }
}
