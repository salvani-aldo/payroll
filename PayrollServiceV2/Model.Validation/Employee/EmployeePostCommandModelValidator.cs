using Command.Request.Emplooyee.Post.Model;
using FluentValidation;

namespace Model.Validation.Employee
{
    public class EmployeePostCommandModelValidator : AbstractValidator<EmployeePostCommandModel>
    {
        public EmployeePostCommandModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.BirthDate).NotEmpty().NotNull();
            RuleFor(model => model.UserId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.Email).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.Phone).NotEmpty().NotNull().MaximumLength(15);
            RuleFor(model => model.StatusId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.GenderId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
