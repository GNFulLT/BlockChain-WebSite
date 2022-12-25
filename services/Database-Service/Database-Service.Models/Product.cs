using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Database_Service.Models
{
    [Table("product_table")]
    [DataContract]
    [Index(nameof(Name), IsUnique = true)]
    public class Product : IDatabaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [Column("name")]
        [DataMember(Order = 2)]
        public string Name { get; set; }

        [Column("dsc")]
        [DataMember(Order = 3)]
        public string Description { get; set; }

        [Column("carbon_value")]
        [DataMember(Order = 4)]
        public int CarbonValue { get; set; }

        [Column("created_at")]
        [DataMember(Order = 5)]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        [DataMember(Order = 6)]
        public DateTime UpdatedAt { get; set; }
    }
}
