using Microsoft.EntityFrameworkCore;
using proyectoCRUD.Models;

namespace proyectoCRUD.Data
{
    public class AplicationDbContext : DbContext
    {

        //Crearemos un constructor

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) 
        { 
            
        
        }

        //Instanciar el modelo

        public DbSet<Libro> Libro { get; set; }
    }
}
