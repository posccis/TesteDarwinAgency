using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.DTOs
{
    public class PedidoDTORequest
    {
        /// <summary>
        /// Nome do cliente
        /// </summary>
        public string Cliente { get; set; }
        /// <summary>
        /// DAta do pedido
        /// </summary>
        public DateTime Data { get; set; }
        /// <summary>
        /// Lista de Itens do Pedido
        /// </summary>
        public List<ItemPedidoDTORequest> Items { get; set; }
    }
}
