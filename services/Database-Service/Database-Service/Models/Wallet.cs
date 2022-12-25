using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database_Service.Models
{
    public class Wallet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("carbon_point")]
        public int CarbonPoint { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now();

        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.Now();

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
