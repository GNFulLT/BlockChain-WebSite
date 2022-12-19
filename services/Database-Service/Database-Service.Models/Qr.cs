using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Database_Service.Models
{
    [Table("qr_table")]
    [DataContract]
    public class Qr : IDatabaseModel
    {
        [Column("id")]
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [Column("qr_image_path", TypeName = "text")]
        [DataMember(Order = 2)]
        public string QrImagePath { get; set; }

        [Column("created_at")]
        [DataMember(Order = 3)]
        public DateTime CreatedAt { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [DataMember(Order = 4)]
        public int UserId { get; set; }

        public User User { get; set; }

    }
}
