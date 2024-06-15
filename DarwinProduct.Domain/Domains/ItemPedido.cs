using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.Domains
{
    public class ItemPedido
    {
        /// <summary>
        /// Identificador do Item
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Identificador do Pedido
        /// </summary>
        public int PedidoId { get; set;}
        /// <summary>
        /// Nome do produto
        /// </summary>
        public string Produto { get; set; }
        /// <summary>
        /// Quantidade desse produto
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int QuantidadeDeProduto { get; set; }
        /// <summary>
        /// Produto
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "O preço do produto deve ser maior do que 0.")]
        public decimal Preco { get; set; }
        /// <summary>
        /// Navegação para o Pedido
        /// </summary>
        public Pedido Pedido { get; set; }
    }
}
