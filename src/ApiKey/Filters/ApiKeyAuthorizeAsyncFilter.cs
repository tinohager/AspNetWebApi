using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Nager.AspNetCoreApiKey
{
    public class ApiKeyAuthorizeAsyncFilter : IAsyncAuthorizationFilter
    {
        public static string ApiKeyHeaderName = "X-Api-Key";

        private readonly ILogger<ApiKeyAuthorizeAsyncFilter> _logger;

        public ApiKeyAuthorizeAsyncFilter(ILogger<ApiKeyAuthorizeAsyncFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var request = context.HttpContext.Request;
            var hasApiKeyHeader = request.Headers.TryGetValue(ApiKeyHeaderName, out var apiKeyValue);

            if (hasApiKeyHeader)
            {
                _logger.LogDebug("Found the header {ApiKeyHeader}. Starting API Key validation", ApiKeyHeaderName);

                if (apiKeyValue.Count != 0 && !string.IsNullOrWhiteSpace(apiKeyValue))
                {
                    var potentialApiKey = apiKeyValue.First();

                    var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
                    var apiKey = configuration.GetValue<string>("ApiKey");

                    if (!apiKey.Equals(potentialApiKey))
                    {
                        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                        return;
                    }
                }
                else
                {
                    _logger.LogWarning("{HeaderName} header found, but api key was null or empty", ApiKeyHeaderName);
                }
            }
            else
            {
                _logger.LogWarning("No ApiKey header found.");
            }

            context.Result = new UnauthorizedResult();
        }
    }
}
