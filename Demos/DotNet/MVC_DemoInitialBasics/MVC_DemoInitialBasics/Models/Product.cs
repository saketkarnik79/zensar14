using System.ComponentModel.DataAnnotations;

namespace MVC_DemoInitialBasics.Models
{

    public class Product
    {
        [Display(Name = "Product Identifier")]
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string? Name { get; set; }
        
        [Display(Name = "Product Description")]
        [MaxLength(200)]
        public string? Description { get; set; }

        [Display(Name = "Product Price")]
        [DataType(DataType.Currency)]
        public long Price { get; set; }
    }
}
