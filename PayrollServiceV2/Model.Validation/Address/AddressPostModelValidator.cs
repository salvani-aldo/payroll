using Command.Request.Address.Post.Model;
using FluentValidation;

namespace Model.Validation.Address
{
    public class AddressPostModelValidator : AbstractValidator<AddressPostCommandModel>
    {
        public AddressPostModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.ZipCode).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.StateId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.CountryId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.City).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(model => model.EmployeeId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.Street).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
