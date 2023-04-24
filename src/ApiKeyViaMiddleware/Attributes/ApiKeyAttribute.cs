namespace ApiKeyViaMiddleware.Attributes
{
    namespace Portalum.Sales.UdoApi.Attributes
    {
        /// <summary>
        /// ApiKey Attribute
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public class ApiKeyAttribute : Attribute
        {
        }
    }
}
