using Command.Request.Department.Delete.ByEmployee;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentDeleteModelValidator : AbstractValidator<DepartmentDeleteModel>
    {
        public DepartmentDeleteModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(1);
        }
    }
}
