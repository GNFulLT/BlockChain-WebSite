using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database_Service.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("dsc")]
        public string Description { get; set; }

        [Column("carbon_value")]
        public int CarbonValue { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now();

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now();
    }
}
