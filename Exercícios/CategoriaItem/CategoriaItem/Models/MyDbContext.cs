using Microsoft.EntityFrameworkCore;

namespace CategoriaItem.Models
{
    public class MyDbContext : DbContext
    {

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Item> Itens { get; set; }
    }
}
