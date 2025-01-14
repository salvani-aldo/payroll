using Command.Request.Department.Post.Model;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentPostModelValidator : AbstractValidator<DepartmentPostCommandModel>
    {
        public DepartmentPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).NotEmpty().NotNull().MaximumLength(5);
            RuleFor(model => model.UserId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
