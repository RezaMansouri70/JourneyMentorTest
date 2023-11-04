namespace Domain.ValueObjects.Exceptions
{
    [Serializable]
    internal class InvalidLatitudeException : Exception
    {
        public InvalidLatitudeException()
        {
        }

        public InvalidLatitudeException(string? message) : base(message)
        {
        }

        public InvalidLatitudeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}