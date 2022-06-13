namespace BodyRequestValidation.Services
{
    public class FoodService : IFoodService
    {
        public Task<string[]> QueryAsync(CancellationToken cancellationToken = default)
        {
            var items = new[]
            { 
                "Pizza",
                "Pasta",
                "Burger"
            };

            return Task.FromResult(items);
        }
    }
}
