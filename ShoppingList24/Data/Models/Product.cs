using System.ComponentModel.DataAnnotations;
using static ShoppingList24.Data.DataConstants.Product;

namespace ShoppingList24.Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; } = null!;

        public IList<ProductNote> ProductNotes { get; set; } = new List<ProductNote>();
    }
}
