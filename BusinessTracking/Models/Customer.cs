using Postgrest;
using Postgrest.Attributes;
using Postgrest.Models;
using Supabase;


// Matches the supabase table for Customers
namespace BusinessTracking.Models
{
    [Table("customers")]
    public class Customer : BaseModel
    {
        [PrimaryKey("id")]
        public int Id { get; set; }

        [Column("Name")]
        public string? Name { get; set; }

        [Column("Address")]
        public string? Address { get; set; }

        [Column("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [Column("Email")]
        public string? Email { get; set; }

        [Column("Notes")]
        public string? Notes { get; set; }
    }
}
