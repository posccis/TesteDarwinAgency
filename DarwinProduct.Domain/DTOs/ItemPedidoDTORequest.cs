using DarwinProduct.Domain.Domains;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.DTOs
{
    public class ItemPedidoDTORequest
    {
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
    }
}
