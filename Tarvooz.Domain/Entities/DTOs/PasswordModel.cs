namespace Tarvooz.Domain.Entities.DTOs
{
    public class PasswordModel
    {
        public string PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
