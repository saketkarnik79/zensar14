using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web_DemoMVCBasics.Models
{
    [Table("Products")]
    public class Product
    {
        [Key]
        [Display(Name= "Product Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Product Name")]
        public string? Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}
