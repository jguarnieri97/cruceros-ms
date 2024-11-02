namespace Cruceros.API.Gateway.Exceptions
{
    [Serializable]
    internal class ReservasClientException : Exception
    {
        public ReservasClientException()
        {
        }

        public ReservasClientException(string? message) : base(message)
        {
        }

        public ReservasClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}