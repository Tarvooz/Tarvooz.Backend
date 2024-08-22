namespace Tarvooz.Domain.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public Category Category { get; set; }
        public User User { get; set; }
    }
}
