namespace Tarvooz.Domain.Entities.Models
{
    public class SearchPattern
    {
        public Guid Id { get; set; }
        public string SearchWord { get; set; }
        public int SearchCount { get; set; }
    }
}
