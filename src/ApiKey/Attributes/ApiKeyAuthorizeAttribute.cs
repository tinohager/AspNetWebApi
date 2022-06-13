using Microsoft.AspNetCore.Mvc;

namespace Nager.AspNetCoreApiKey
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class ApiKeyAuthorizeAttribute : TypeFilterAttribute
	{
		public ApiKeyAuthorizeAttribute() : base(typeof(ApiKeyAuthorizeAsyncFilter))
		{
		}
	}
}
