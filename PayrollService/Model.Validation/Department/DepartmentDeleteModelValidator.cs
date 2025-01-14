using Command.Request.Handler.Department.Delete;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentDeleteModelValidator : AbstractValidator<DepartmentDeleteModel>
    {
        public DepartmentDeleteModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
