using Command.Request.Handler.Position.Put;
using FluentValidation;

namespace Model.Validation.Position
{
    public sealed class PositionPutModelValidator : AbstractValidator<PositionPutModel>
    {
        public PositionPutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(4);
        }
    }
}
