namespace Domain.ValueObjects.Exceptions
{
    [Serializable]
    internal class InvalidLongitudeException : Exception
    {
        public InvalidLongitudeException()
        {
        }

        public InvalidLongitudeException(string? message) : base(message)
        {
        }

        public InvalidLongitudeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

    }
}