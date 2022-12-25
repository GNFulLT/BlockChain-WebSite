using System.ComponentModel.DataAnnotations.Schema;

namespace Database_Service.Models
{
    [Table("qr_table")]
    public class Qr
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("qr_image_path", TypeName = "text")]
        public string QrImagePath { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.Now();

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
