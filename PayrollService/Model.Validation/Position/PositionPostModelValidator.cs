using Command.Request.Handler.Position.Post;
using FluentValidation;

namespace Model.Validation.Position
{
    public sealed class PositionPostModelValidator : AbstractValidator<PositionPostModel>
    {
        public PositionPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(4);
        }
    }
}
