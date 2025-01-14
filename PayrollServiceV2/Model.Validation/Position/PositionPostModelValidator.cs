using Command.Request.Position.Post.Model;
using FluentValidation;

namespace Model.Validation.Position
{
    public sealed class PositionPostModelValidator : AbstractValidator<PositionPostCommandModel>
    {
        public PositionPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(5);
            RuleFor(model => model.UserId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
