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
            RuleFor(emp => emp.Name).NotNull();
            RuleFor(emp => emp.IdCardSerieNo).NotNull();
            RuleFor(emp => emp.IdCardCnp).NotNull();
            RuleFor(emp => emp.MainSalary).NotNull();
            RuleFor(emp => emp.CountyCode).NotNull();
            RuleFor(emp => emp.Email).NotNull();
            RuleFor(emp => emp.Birthday).NotNull();
            //RuleFor(emp => emp.ManagerNodeAsName).NotNull();
            RuleFor(emp => emp.EmpDeptNodeAsText).NotNull();
            RuleFor(emp => emp.EmpActivityNodeAsText).NotNull();
            RuleFor(emp => emp.EmpWorkTypeNodeAsText).NotNull();
            RuleFor(emp => emp.EmpFunctionNodeAsText).NotNull();
        }
    }

    public class EmpValidator : CascadingAbstractValidator<Employee>
    {
        public EmpValidator() : base()
        {
            RuleFor(emp => emp).NotNull();
            RuleFor(emp => emp.EmpNode).NotNull();
            RuleFor(emp => emp.ManagerNode).NotNull();
            RuleFor(emp => emp.Name).NotNull();
            RuleFor(emp => emp.IdCardSerieNo).NotNull();
            RuleFor(emp => emp.IdCardCnp).NotNull();
            RuleFor(emp => emp.MainSalary).NotNull();
            RuleFor(emp => emp.ManagerNode).NotNull();

            //RuleFor(emp => emp.HiringDate).NotNull();
            //RuleFor(emp => emp.EmpShift).NotNull();
            //RuleFor(emp => emp.WorkGroup).NotNull();
            //RuleFor(emp => emp.HoursToWork).NotNull();
            //RuleFor(emp => emp.TypeWorkContract).NotNull();

            RuleFor(emp => emp.CountyCode).NotNull();
            RuleFor(emp => emp.Email).NotNull();
            RuleFor(emp => emp.Birthday).NotNull();
            RuleFor(emp => emp.EmpDeptNode).NotNull();
            RuleFor(emp => emp.EmpActivityNode).NotNull();
            RuleFor(emp => emp.EmpWorkTypeNode).NotNull();
            RuleFor(emp => emp.EmpFunctionNode).NotNull();
            RuleFor(emp => emp.UpdatedAt).NotNull();
            RuleFor(emp => emp.UpdatedBy).NotNull();
        }
    }
}
