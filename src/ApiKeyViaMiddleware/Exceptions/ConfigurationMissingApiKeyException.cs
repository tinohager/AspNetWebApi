namespace ApiKeyViaMiddleware.Exceptions
{
    public class ConfigurationMissingApiKeyException : Exception
    {
        public ConfigurationMissingApiKeyException() { }
        public ConfigurationMissingApiKeyException(string message) : base(message) { }
    }
}
