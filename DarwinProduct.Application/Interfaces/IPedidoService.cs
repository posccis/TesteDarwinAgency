using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Application.Interfaces
{
    public interface IPedidoService<T> where T : Pedido
    {
        Task InserirPedido(T pedido);
        Task AtualizaPeido(T pedido);
        Task RemoverPedido(T pedido);
        Pedido ObtemPedidoPorId(int id);
        IEnumerable<Pedido> GetPedidos();
    }
}
