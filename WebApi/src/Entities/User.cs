using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApi.src.Entities
{   
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ID",TypeName = "numeric(9,0)")]
        public decimal? Id { get; set; }

        [Column("Username",TypeName = "nvarchar(25)")]
        public string? Username { get; set; }

    }
}