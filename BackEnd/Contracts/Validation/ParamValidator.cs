using Contracts.Models;
using FluentValidation;

namespace Contracts.Validation
{
    public class ParamDTOValidator : CascadingAbstractValidator<ParamDTO>
    {
        public ParamDTOValidator() : base()
        {
            RuleFor(p => p).NotNull();
              RuleFor(p => p.ProcessingDate).NotNull();
            RuleFor(p => p.AdvanceDay).NotNull();
            RuleFor(p => p.NormatedRegime).NotNull();
            RuleFor(p => p.NoDaysForWhichAdvanceisPaid).NotNull();
            RuleFor(p => p.FiscalCode).NotNull();
            RuleFor(p => p.CaenCode).NotNull();
            RuleFor(p => p.AdvancePercentRate).NotNull();
            RuleFor(p => p.WorkRegime8Hours).NotNull();
        }
    }

    public class ParamValidator : CascadingAbstractValidator<Param>
    {
        public ParamValidator() : base()
        {
            RuleFor(p => p).NotNull();
            RuleFor(p => p.AdvanceDay).NotNull();
            RuleFor(p => p.NormatedRegime).NotNull();
            RuleFor(p => p.NoDaysForWhichAdvanceisPaid).NotNull();
            RuleFor(p => p.FiscalCode).NotNull();
            RuleFor(p => p.CaenCode).NotNull();
            RuleFor(p => p.AdvancePercentRate).NotNull();
            RuleFor(p => p.WorkRegime8Hours).NotNull();

            RuleFor(p => p.ProcessingDate).NotNull();
            RuleFor(p => p.UpdatedBy).NotNull();
            RuleFor(p => p.UpdatedAt).NotNull();
            
        }
    }
}
