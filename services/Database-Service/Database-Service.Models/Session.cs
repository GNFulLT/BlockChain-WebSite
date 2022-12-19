using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Database_Service.Models
{
    [Table("session_table")]
    [DataContract]
    public class Session : IDatabaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [Column("session_key")]
        [MaxLength(255)]
        [DataMember(Order = 2)]
        public string SessionKey { get; set; }

        [DataMember(Order = 3)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [DataMember(Order = 4)]
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
