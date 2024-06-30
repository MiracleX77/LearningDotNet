using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Roller.Domain.Entities
{
    [Table("Rolls")]
    public class Roll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("value")]
        public int Value { get; set; }
        [Column("created")]
        public DateTime Created { get; set; }
    }
}