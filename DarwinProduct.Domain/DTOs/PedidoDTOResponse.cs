using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.DTOs
{
    public class PedidoDTOResponse
    {
        /// <summary>
        /// Indentificador do pedido
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// DAta do pedido
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// Valor Total do pedido
        /// </summary>
        public decimal Total { get; set; }
        /// <summary>
        /// Lista de Itens do Pedido
        /// </summary>
        public List<ItemPedido> Items { get; set; }
    }
}
