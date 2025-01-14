using Command.Request.Handler.Position.Delete;
using FluentValidation;

namespace Model.Validation.Position
{
    public sealed class PositionDeleteModelValidator : AbstractValidator<PositionDeleteModel>
    {
        public PositionDeleteModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
