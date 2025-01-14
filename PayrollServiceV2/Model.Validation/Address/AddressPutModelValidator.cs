using Command.Request.Address.Put;
using FluentValidation;

namespace Model.Validation.Address
{
    public class AddressPutModelValidator : AbstractValidator<AddressPutModel>
    {
        public AddressPutModelValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            RuleFor(model => model.Id).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(model => model.ZipCode).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.StateId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.CountryId).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(model => model.City).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(model => model.Street).NotNull().NotEmpty().MaximumLength(50);
        }
    }
}
