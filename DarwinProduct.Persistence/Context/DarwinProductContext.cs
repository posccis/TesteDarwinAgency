using DarwinProduct.Domain.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Persistence.Context
{
    public class DarwinProductContext : DbContext
    {
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItemPedidos { get; set; }

        public DarwinProductContext(DbContextOptions op) : base(op) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pedido>(entity =>
            {
                //Definição do index da tabela
                entity.HasIndex(p => p.Id).IsUnique();
                //Definição da relação
                entity.HasMany(p => p.Items)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.PedidoId)
                .OnDelete(DeleteBehavior.Cascade);
            });
                
                
                
            modelBuilder.Entity<ItemPedido>(entity =>
            {
                //Definição do index da tabela
                entity.HasIndex(i => i.Id).IsUnique();
                //Definição da relação
                entity.HasOne(i => i.Pedido)
                .WithMany(p => p.Items)
                .HasForeignKey(i => i.PedidoId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
