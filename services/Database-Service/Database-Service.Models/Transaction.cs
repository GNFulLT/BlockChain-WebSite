using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Database_Service.Models
{
    [Table("transaction_table")]
    [DataContract]
    public class Transaction : IDatabaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [Column("earning")]
        [DataMember(Order = 2)]
        public int Earning { get; set; }

        [Column("created_at")]
        [DataMember(Order = 3)]
        public DateTime CreatedAt { get; set; }


        [ForeignKey("User")]
        [Column("user_id")]
        [DataMember(Order = 4)]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("Product")]
        [Column("product_id")]
        [DataMember(Order = 5)]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
