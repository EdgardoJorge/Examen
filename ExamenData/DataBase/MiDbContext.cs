using ExamenData.DataBase.Seeds;
using ExamenData.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase
{
    public class MiDbContext : DbContext
    {
        public MiDbContext(DbContextOptions opts): base(opts)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBulder)
        {
            modelBulder.Entity<Cliente>()
                .HasMany<Pedido>()
                .WithOne()
                .HasForeignKey(p => p.id_cliente)
                .IsRequired();

            modelBulder.Entity<DetallePedido>()
                .HasOne<Producto>()
                .WithMany()
                .HasForeignKey(d => d.id_producto);

            modelBulder.Entity<Pedido>()
                .HasMany<DetallePedido>()
                .WithOne()
                .HasForeignKey(p => p.id_pedido);
            modelBulder.seed();


        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos {  get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
    }
}
