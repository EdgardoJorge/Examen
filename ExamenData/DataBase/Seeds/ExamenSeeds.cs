using ExamenData.DataBase.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenData.DataBase.Seeds
{
    internal static class ExamenSeeds
    {
        public static void seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().HasData(
                new Cliente
                {
                    id = 1,
                    Nombre = "Leonardo",
                    ApellidoPaterno = "Rosas",
                    ApellidoMaterno = "Rosas",
                    EMail = "ideideijde@deidhe.com",
                    DNI = "17273363",
                },
                new Cliente
                {
                    id = 2,
                    Nombre = "Juan",
                    ApellidoPaterno = "Pablo",
                    ApellidoMaterno = "Rosas",
                    EMail="dheui@hduehde.com",
                    DNI="12134564",
                }
                );
            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    id = 1,
                    Nombre = "Pan integral",
                    stock= 12,
                    precio=12.30
                },
                new Producto
                {
                    id=2,
                    Nombre="Pan Frances",
                    stock=20,
                    precio=10,
                }
                );
            modelBuilder.Entity<Pedido>().HasData(
                new Pedido
                {
                    Id = 1,
                    fechaPedido = DateTime.Now,
                    total=13,
                    id_cliente=1,

                },
                new Pedido
                {
                    Id= 2,
                    fechaPedido= DateTime.Now,
                    total=12,
                    id_cliente=2,
                }
                );
            modelBuilder.Entity<DetallePedido>().HasData(
                new DetallePedido
                {
                    id = 1,
                    cantidad = 12,
                    id_pedido = 1,
                    id_producto = 2,
                },
                new DetallePedido
                {
                    id = 2,
                    cantidad = 3,
                    id_pedido = 2,
                    id_producto = 1,
                }
                );

        }
    }
}
