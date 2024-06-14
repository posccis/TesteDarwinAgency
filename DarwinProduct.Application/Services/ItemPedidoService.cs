using DarwinProduct.Application.Interfaces;
using DarwinProduct.Domain.Domains;
using DarwinProduct.Domain.Exceptions;
using DarwinProduct.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Application.Services
{
    public class ItemPedidoService : IItemPedidoService<ItemPedido>
    {
        private readonly DarwinProductContext _darwinContext;
        public ItemPedidoService(DarwinProductContext darwinContext)
        {
            _darwinContext = darwinContext;
        }
        public IEnumerable<ItemPedido> ObterItensPorPedido(int idPedido)
        {
            try
            {
                return _darwinContext.Itens.Where(i => i.PedidoId == idPedido).AsEnumerable();
                
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar retornar os itens do pedido:" + ex.Message);
            }
        }
    }
}
