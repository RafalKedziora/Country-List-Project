namespace CountryListProjectAPI.Validators
{
    public class CreateCountryDtoValidator : AbstractValidator<CreateCountryDto>
    {
        public CreateCountryDtoValidator(CountryContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(50)
                .Must(x => !dbContext.Countries.Any(c => c.Name == x))
                .WithMessage("Country with this name already exists");
            
            RuleFor(x => x.Code)
                .NotEmpty()
                .MaximumLength(3)
                .MinimumLength(3)
                .Must(x => !dbContext.Countries.Any(c => c.Code == x))
                .WithMessage("Country with this code already exists");
        }
    }
}
