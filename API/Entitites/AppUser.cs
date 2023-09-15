namespace API.Entitites // keep the name oragnized by keeping it the folders name
{
    public class AppUser
    {
        public int Id { get; set; }
        public string UserName { get; set; } // ? means nullible
        public byte[] PasswordHash  { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}