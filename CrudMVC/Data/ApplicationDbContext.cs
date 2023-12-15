using CrudMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
        }

        // Agregar los modelos
        public DbSet<Contacto> Contactos { get; set; }
    }
}
