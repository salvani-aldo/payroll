using Command.Request.Emplooyee.Put;
using FluentValidation;

namespace Model.Validation.Employee
{
    public sealed class EmployeePutModeValidator : AbstractValidator<EmployeePutModel>
    {
        public EmployeePutModeValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.BirthDate).NotEmpty().NotNull();
            RuleFor(model => model.DepartmentId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.PositionId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.UserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.Email).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Phone).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(model => model.StatusId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.GenderId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
