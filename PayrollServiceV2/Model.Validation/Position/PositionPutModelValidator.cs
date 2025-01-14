using Command.Request.Position.Put.Model;
using FluentValidation;

namespace Model.Validation.Position
{
    public sealed class PositionPutModelValidator : AbstractValidator<PositionPutCommandModel>
    {
        public PositionPutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(5);
            RuleFor(model => model.UserId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
