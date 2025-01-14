using Command.Request.Emplooyee.Delete;
using FluentValidation;

namespace Model.Validation.Employee
{
    public sealed class EmployeeDeleteModelValidator : AbstractValidator<EmployeeDeleteModel>
    {
        public EmployeeDeleteModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
