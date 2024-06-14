using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.Domains
{
    public class Pedido
    {
        /// <summary>
        /// Indentificador do pedido
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Nome do cliente
        /// </summary>
        [Required]
        [MinLength(2, ErrorMessage = "O nome do cliente deve possuir pelo menos 2 caracteres.")]
        [MaxLength(2, ErrorMessage = "O nome do cliente deve possuir no máximo 100 caracteres.")]
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
        public IEnumerable<ItemPedido> Items { get; set; }
    }
}
