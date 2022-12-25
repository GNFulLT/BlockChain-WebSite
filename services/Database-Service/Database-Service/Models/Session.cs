using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database_Service.Models
{
    [Table("session_table")]
    public class Session
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("session_key")]
        [MaxLength(255)]
        public string SessionKey { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now();

        [ForeignKey("User")]
        [Column("user_id")]
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
