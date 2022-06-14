namespace ApiKeyViaActionFilter.Services
{
    public interface IFoodService
    {
        Task<string[]> QueryAsync(CancellationToken cancellationToken = default);
    }
}
