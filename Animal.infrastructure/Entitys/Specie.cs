using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Animal.infrastructure.Entitys{
    [Table("tbl_Species")]
    public class Specie{
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; } = null;
    }
}