using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Models
{
    [Table("wallet_table")]
    [DataContract]
    [Index(nameof(UserId),IsUnique = true)]
    public class Wallet : IDatabaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DataMember(Order =1)]
        public int Id { get; set; }

        [Column("carbon_point")]
        [DataMember(Order = 2)]
        public int CarbonPoint { get; set; }

        [Column("created_at")]
        [DataMember(Order = 3)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [DataMember(Order = 4)]
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("User")]
        [Column("user_id")]
        [DataMember(Order = 5)]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
