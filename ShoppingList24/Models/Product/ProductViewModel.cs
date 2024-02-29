using System.ComponentModel.DataAnnotations;
using static ShoppingList24.Data.DataConstants.Product;

namespace ShoppingList24.Models.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
