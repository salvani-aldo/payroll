using Command.Request.Handler.Employee.Post;
using FluentValidation;

namespace Model.Validation.Employee
{
    public sealed class EmployeePostModelValidator : AbstractValidator<EmployeePostModel>
    {
        public EmployeePostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.FirstName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.MiddleName).MaximumLength(50);
            RuleFor(model => model.LastName).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.BirthDate).NotEmpty().NotNull();
        }
    }
}
