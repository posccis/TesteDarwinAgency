using DarwinProduct.Domain.Domains;
using DarwinProduct.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Persistence
{
    public static class Seed
    {
        public static async Task SeedData(DarwinProductContext context)
        {
            if(context.ItemPedidos.Any() || context.Pedidos.Any())
            {
                return;
            }
            var pedidos = GetPedidoSeed();
            context.Pedidos.AddRange(pedidos);
            
            await context.SaveChangesAsync();

            foreach(Pedido pedido in pedidos)
            {
                context.ItemPedidos.AddRange(pedido.Items);
                await context.SaveChangesAsync();
            }

        }
        public static List<Pedido> GetPedidoSeed()
        {
            var pedidos = new List<Pedido>
        {
            new Pedido
            {
                Cliente = "Cliente A",
                Data = DateTime.Now.AddDays(-7),
                Total = 1000,
                Items = new List<ItemPedido>
                {
                    new ItemPedido
                    {
                        Produto = "Produto X",
                        QuantidadeDeProduto = 2,
                        Preco = 250
                    },
                    new ItemPedido
                    {
                        Produto = "Produto Y",
                        QuantidadeDeProduto = 1,
                        Preco = 500
                    }
                }
            },
            new Pedido
            {
                Cliente = "Cliente B",
                Data = DateTime.Now.AddDays(-5),
                Total = 1500,
                Items = new List<ItemPedido>
                {
                    new ItemPedido
                    {
                        Produto = "Produto Z",
                        QuantidadeDeProduto = 3,
                        Preco = 500
                    }
                }
            }
        };

            return pedidos;
        }
    }
}
