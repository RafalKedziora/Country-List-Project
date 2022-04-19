namespace CountryListProjectAPI.Validators
{
    public class UpdateGraphRouteDtoValidator : AbstractValidator<UpdateGraphRouteDto>
    {
        public UpdateGraphRouteDtoValidator(CountryContext dbContext)
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
