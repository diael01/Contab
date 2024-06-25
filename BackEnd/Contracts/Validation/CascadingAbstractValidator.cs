using FluentValidation;

namespace Contracts.Validation
{
    public abstract class CascadingAbstractValidator<T> : AbstractValidator<T>
    {
        public CascadingAbstractValidator() : base()
        {
            RuleLevelCascadeMode = CascadeMode.Continue;
        }
    }
}
