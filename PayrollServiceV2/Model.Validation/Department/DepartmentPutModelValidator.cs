using Command.Request.Department.Put.Model;
using FluentValidation;

namespace Model.Validation.Department
{
    public sealed class DepartmentPutModelValidator : AbstractValidator<DepartmentPutCommandModel>
    {
        public DepartmentPutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotNull().NotEmpty().GreaterThanOrEqualTo(1);
            RuleFor(model => model.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(model => model.Code).NotNull().NotEmpty().MaximumLength(5);
            RuleFor(model => model.UserId).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
