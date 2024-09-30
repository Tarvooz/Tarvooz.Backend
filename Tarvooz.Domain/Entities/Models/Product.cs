using System.Text.Json.Serialization;

namespace Tarvooz.Domain.Entities.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
}
