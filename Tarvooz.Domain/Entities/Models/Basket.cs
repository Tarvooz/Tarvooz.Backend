using System.Text.Json.Serialization;

namespace Tarvooz.Domain.Entities.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public Product Product { get; set; }
    }
}
