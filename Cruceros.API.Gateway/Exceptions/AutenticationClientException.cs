namespace Cruceros.API.Gateway.Exceptions
{
    [Serializable]
    internal class AutenticationClientException : Exception
    {
        public AutenticationClientException()
        {
        }

        public AutenticationClientException(string? message) : base(message)
        {
        }

        public AutenticationClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}