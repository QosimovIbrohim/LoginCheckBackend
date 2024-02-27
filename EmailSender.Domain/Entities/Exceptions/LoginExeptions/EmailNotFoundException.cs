namespace EmailSender.Domain.Entities.Exceptions.LoginExeption
{
    public class EmailNotFoundException : Exception
    {
        public EmailNotFoundException()
            : base("Email is not found!") { }
    }
}
