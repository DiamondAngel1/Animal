using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PostgreSQLBD.Data.Entitis{
    [Table("tbl_Users")]
    public class UserEntity{
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string FName { get; set; } = string.Empty;

        [Required, StringLength(50)]
        public string LName { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; } = string.Empty;

        [Required, StringLength(255)]
        public string? Phone { get; set; } = string.Empty;

        [Required]
        public DateOnly? Birthday { get; set; }
    }
}