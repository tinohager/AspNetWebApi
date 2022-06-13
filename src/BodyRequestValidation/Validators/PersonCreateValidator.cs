using BodyRequestValidation.Dtos.Person;
using FluentValidation;
using FluentValidation.Validators;

namespace BodyRequestValidation.Validators
{
    public class PersonCreateValidator : AbstractValidator<PersonCreateRequestDto>
    {
        public PersonCreateValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.EmailAddress).EmailAddress(EmailValidationMode.AspNetCoreCompatible);
        }
    }
}
