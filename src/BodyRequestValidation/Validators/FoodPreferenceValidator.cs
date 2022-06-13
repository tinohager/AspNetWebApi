using BodyRequestValidation.Services;
using FluentValidation;

namespace BodyRequestValidation.Validators
{
    public class FoodPreferenceValidator : AbstractValidator<string>
    {
        public FoodPreferenceValidator(IFoodService foodService)
        {
            RuleFor(food => food).Must((food) =>
            {
                var foods = foodService.QueryAsync().GetAwaiter().GetResult();

                return foods.Contains(food, StringComparer.OrdinalIgnoreCase);
            }).WithMessage("Not allowed food");
        }
    }
}
