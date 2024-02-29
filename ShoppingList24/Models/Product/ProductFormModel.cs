using System.ComponentModel.DataAnnotations;
using static ShoppingList24.Data.DataConstants.Product;

namespace ShoppingList24.Models.Product
{
    public class ProductFormModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string Name { get; set; } = null!;
    }
}
