namespace ContactManager.Domain.Contacts.Exceptions
{
    public class InvalidContactException : Exception
    {
        public InvalidContactException(string message) : base(message)
        {
        }
    }
}
