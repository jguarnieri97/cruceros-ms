namespace Cruceros.API.Gateway.Exceptions
{
    [Serializable]
    internal class RoomClientException : Exception
    {
        public RoomClientException()
        {
        }

        public RoomClientException(string? message) : base(message)
        {
        }

        public RoomClientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}