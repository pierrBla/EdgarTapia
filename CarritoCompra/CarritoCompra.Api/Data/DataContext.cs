
using CarritoCompra.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarritoCompra.Api.Data
{
    public class DataContext : DbContext
    {
        //ctor para poner constructor
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }

        
        public DbSet<Country> Countries { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //para que no se repita los paises
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>().HasIndex(x => x.Name).IsUnique();

        }
    }
}
