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
        }
    }

    public class ParamValidator : CascadingAbstractValidator<Param>
    {
        public ParamValidator() : base()
        {
            RuleFor(p => p).NotNull();
            
            RuleFor(p => p.ProcessingDate).NotNull();
            RuleFor(p => p.UpdatedBy).NotNull();
            RuleFor(p => p.UpdatedAt).NotNull();
            
        }
    }
}
