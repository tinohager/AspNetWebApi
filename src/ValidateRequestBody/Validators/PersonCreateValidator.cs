using FluentValidation;
using FluentValidation.Validators;
using ValidateRequestBody.Dtos.Person;
using ValidateRequestBody.Services;

namespace ValidateRequestBody.Validators
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
