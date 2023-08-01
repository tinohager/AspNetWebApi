namespace ApiKeyViaMiddleware.Attributes
{
    /// <summary>
    /// ApiKey Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute
    {
    }
}
