using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogService.Models
{
    public class Product
    {
        [Key]
        [Display(AutoGenerateField = true)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        [Column(TypeName ="decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
