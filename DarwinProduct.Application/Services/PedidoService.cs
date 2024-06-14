using DarwinProduct.Application.Interfaces;
using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Application.Services
{
    public class PedidoService : IPedidoService<Pedido>
    {
        public Task AtualizaPeido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pedido> GetPedidos()
        {
            throw new NotImplementedException();
        }

        public Task InserirPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public Pedido ObtemPedidoPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoverPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }
    }
}
