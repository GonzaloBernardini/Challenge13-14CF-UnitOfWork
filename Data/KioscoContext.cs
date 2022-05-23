using Challenge13Kiosco.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge13Kiosco.Data
{
    public class KioscoContext : DbContext
    {
        public KioscoContext(DbContextOptions<KioscoContext>options) :base(options)
        {

        }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Caracteristica> Caracteristicas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Sobrecarga del metodo que arma la tabla para especificar configuracion propia
            modelBuilder.Entity<Producto>()
                .HasOne<Caracteristica>(s => s.Caracteristica)
                .WithOne(ad => ad.Producto)
                .HasForeignKey<Caracteristica>(ad => ad.IdProducto);

            modelBuilder.Entity<Caracteristica>().Property(x => x.Precio).HasPrecision(18, 2);
            modelBuilder.Entity<Caracteristica>().Property(x => x.Ancho).HasPrecision(18, 2);
            modelBuilder.Entity<Caracteristica>().Property(x => x.Largo).HasPrecision(18, 2);
            modelBuilder.Entity<Caracteristica>().Property(x => x.Peso).HasPrecision(18, 2);
        }
    }
}
