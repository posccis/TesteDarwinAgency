using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.Interfaces
{
    internal interface IItemPedido
    {
        /// <summary>
        /// Identificador do Item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador do Pedido
        /// </summary>
        public int PedidoId { get; set; }
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Produto { get; set; }
        /// <summary>
        /// Quantidade desse produto
        /// </summary>
        public int QuantidadeDeProduto { get; set; }
        /// <summary>
        /// Produto
        /// </summary>
        public decimal Preco { get; set; }
        /// <summary>
        /// Navegação para o Pedido
        /// </summary>
        public Pedido Pedido { get; set; }
    }
}
