namespace ValidateRequestBody.Services
{
    public interface IFoodService
    {
        Task<string[]> QueryAsync(CancellationToken cancellationToken = default);
    }
}
