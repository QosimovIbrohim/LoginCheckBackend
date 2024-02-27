namespace EmailSender.Domain.Entities.Exceptions.LoginExeption
{
    public class WrongPasswordException : Exception
    {
        public WrongPasswordException()
             : base("Wrong Password!") { }
    }
}
