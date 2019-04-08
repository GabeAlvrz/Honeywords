namespace Honeywords.API.Models
{
    public class Password
    {
        public int Id { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }
    }
}