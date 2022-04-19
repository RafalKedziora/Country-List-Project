namespace CountryListProjectAPI.Validators
{
    public class CreateGraphRouteDtoValidator : AbstractValidator<CreateGraphRouteDto>
    {
        public CreateGraphRouteDtoValidator(CountryContext dbContext)
        {
            RuleFor(x => x.OriginId)
                .NotEmpty()
                .Must(x => dbContext.Countries.Any(c => c.Id == x))
                .WithMessage("Country with this id doesn't exist!");

            RuleFor(x => x.DestinationId)
                .NotEmpty()
                .Must(x => dbContext.Countries.Any(c => c.Id == x))
                .WithMessage("Country with this id doesn't exist!");
        }
    }
}
