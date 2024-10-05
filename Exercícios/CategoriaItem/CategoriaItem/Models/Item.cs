using System.ComponentModel.DataAnnotations.Schema;

namespace CategoriaItem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Nome { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria? Categoria { get; set; }
    }
}
