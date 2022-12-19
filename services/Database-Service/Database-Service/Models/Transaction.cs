using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database_Service.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("earning")]
        public int Earning { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }


        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Product")]
        [Column("product_id")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
