using Command.Request.Handler.Department.Put;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentPutModelValidator : AbstractValidator<DepartmentPutModel>
    {
        public DepartmentPutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Name).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Code).MaximumLength(4);
        }
    }
}
