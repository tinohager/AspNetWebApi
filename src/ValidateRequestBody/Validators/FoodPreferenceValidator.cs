using FluentValidation;
using ValidateRequestBody.Services;

namespace ValidateRequestBody.Validators
{
    public class FoodPreferenceValidator : AbstractValidator<string>
    {
        public FoodPreferenceValidator(IFoodService foodService)
        {
            RuleFor(food => food).Must((food) =>
            {
                var foods = foodService.QueryAsync().GetAwaiter().GetResult();

                return foods.Contains(food, StringComparer.OrdinalIgnoreCase);
            }).WithMessage("Food not supported");
        }
    }
}
