namespace RoomMicroservices.Application.Exceptions
{
    public class ConflictException : Exception
    {
        public ConflictException(string text) : base(text) { }

    }
}
