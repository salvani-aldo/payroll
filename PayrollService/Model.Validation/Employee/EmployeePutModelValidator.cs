using Command.Request.Handler.Employee.Put;
using FluentValidation;

namespace Model.Validation.Employee
{
    public sealed class EmployeePutModelValidator : AbstractValidator<EmployeePutModel>
    {
        public EmployeePutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.MiddleName).MaximumLength(50);
            RuleFor(model => model.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.BirthDate).NotEmpty().NotNull();
        }
    }
}
