using ApiKeyViaMiddleware.Attributes;
using ApiKeyViaMiddleware.Exceptions;
using Microsoft.AspNetCore.Http.Features;

namespace ApiKeyViaMiddleware.Middlewares
{
    public class ApiKeyMiddleware
    {
        public const string ApiKeyHeaderName = "X-Api-Key";
        private const string ConfigurationKeyForApiKey = "ApiKey";

        private readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var hasAuthorizeAttribute = context.Features.Get<IEndpointFeature>()?.Endpoint?.Metadata
                .Any(m => m is ApiKeyAttribute);

            if (!hasAuthorizeAttribute.HasValue || !hasAuthorizeAttribute.Value)
            {
                await this._next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var receivedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            var configuration = context.RequestServices.GetRequiredService<IConfiguration>();
            var expectedApiKey = configuration.GetValue<string>(ConfigurationKeyForApiKey);
            if (expectedApiKey == null)
            {
                throw new ConfigurationMissingApiKeyException($"No config found for {ConfigurationKeyForApiKey}");
            }

            if (!expectedApiKey.Equals(receivedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                return;
            }

            await this._next(context);
        }
    }

    public static class ApiKeyMiddlewareExtensions
    {
        /// <summary>
        /// Register ApiKey Middleware
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseApiKey(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ApiKeyMiddleware>();
        }
    }
}
