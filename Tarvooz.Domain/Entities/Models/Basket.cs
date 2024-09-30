namespace Tarvooz.Domain.Entities.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
    }
}
