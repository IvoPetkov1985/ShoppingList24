using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ShoppingList24.Data.DataConstants.ProductNote;

namespace ShoppingList24.Data.Models
{
    public class ProductNote
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NoteContentMaxLength)]
        public string Content { get; set; } = null!;

        [Required]
        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
    }
}
