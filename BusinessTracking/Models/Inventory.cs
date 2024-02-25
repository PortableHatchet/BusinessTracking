using Postgrest;
using Postgrest.Attributes;
using Postgrest.Models;
using Supabase;


// Matches the supabase table for Inventory
namespace BusinessTracking.Models
{
    [Table("inventory")]
    public class InventoryItem : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Quantity")]
        public int Quantity { get; set; }

        [Column("Price")]
        public decimal Price { get; set; }
    }
}
