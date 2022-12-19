using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

#pragma warning disable CS8618

namespace Database_Service.Models
{
    [Table("user_table")]
    [DataContract]
    public class User : IDatabaseModel
    {
        [Column("id")]
        [DataMember(Order = 1)]
        [Required]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(255)]
        [DataMember(Order = 2)]
        [Required]
        public string Name { get; set; }

        [Column("surname")]
        [MaxLength(255)]
        [DataMember(Order = 3)]
        [Required]
        public string Surname { get ; set; }

        [Column("username")]
        [MaxLength(255)]
        [DataMember(Order = 4)]
        public string Username { get; set; }

        [Column("email")]
        [MaxLength(255)]
        [DataMember(Order = 5)]
        public string Email { get; set; }

        [Column("password")]
        [MaxLength(255)]
        [DataMember(Order = 6)]
        public string Password { get; set; }

        [Column("created_at")]
        [DataMember(Order = 7)]
        public DateTime CreatedAt { get; set; }

    }
}
#pragma warning restore CS8618 
