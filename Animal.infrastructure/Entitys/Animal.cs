using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Animal.infrastructure.Entitys{
    [Table("tbl_animals")]
    public class Animais{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = null!;

        [ForeignKey("Specie")]
        public int SpecieId { get; set; }
        public Specie Specie { get; set; } = default!;

        public int Age { get; set; }

        [StringLength(40000)]
        public string Description { get; set; } = string.Empty;
    }
}
