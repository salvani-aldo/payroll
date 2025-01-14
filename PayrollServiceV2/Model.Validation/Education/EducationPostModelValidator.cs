using Command.Request.Education.Post;
using FluentValidation;

namespace Model.Validation.Education
{
    public sealed class EducationPostModelValidator : AbstractValidator<EducationPostCommandModel>
    {
        public EducationPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.School).NotEmpty().NotNull().MaximumLength(50);
            RuleFor(model => model.DegreeId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.Year).NotEmpty().NotNull().GreaterThan(1950);
            RuleFor(model => model.EmployeeId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.Course).NotEmpty().NotNull().MaximumLength(50);
        }
    }
}
