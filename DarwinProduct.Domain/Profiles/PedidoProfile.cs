using AutoMapper;
using DarwinProduct.Domain.Domains;
using DarwinProduct.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarwinProduct.Domain.Profiles
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoDTORequest, Pedido>();
            CreateMap<Pedido, PedidoDTOResponse>();

            CreateMap<ItemPedidoDTORequest, ItemPedido>();
        }
    }
}
