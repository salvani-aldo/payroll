using Command.Request.Handler.Department.Post;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentPostModelValidator : AbstractValidator<DepartmentPostModel>
    {
        public DepartmentPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(4);
        }
    }
}
