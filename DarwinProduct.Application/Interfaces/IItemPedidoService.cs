using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Application.Interfaces
{
    public interface IItemPedidoService<T> where T : ItemPedido
    {
        IEnumerable<T> ObterItensPorPedido(int idPedido);
    }
}
