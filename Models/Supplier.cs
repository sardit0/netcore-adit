namespace Inventaris.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string ContactInfo { get; set; } = string.Empty;
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
