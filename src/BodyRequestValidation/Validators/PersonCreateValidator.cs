using BodyRequestValidation.Dtos.Person;
using BodyRequestValidation.Services;
using FluentValidation;
using FluentValidation.Validators;

namespace BodyRequestValidation.Validators
{
    public class PersonCreateValidator : AbstractValidator<PersonCreateRequestDto>
    {
        public PersonCreateValidator(IFoodService foodService)
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.EmailAddress).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
            RuleForEach(x => x.FoodPreferences).SetValidator(new FoodPreferenceValidator(foodService));
        }
    }
}
