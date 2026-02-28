namespace LearnManagerAPI.Services.Exceptions
{
    // simple marker exception so callers can distinguish
    public class EmailAlreadyRegisteredException : Exception
    {
        public EmailAlreadyRegisteredException(string email)
            : base($"Email '{email}' is already registered.")
        {
        }
    }
}