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
    public class PedidoService : IPedidoService<Pedido>
    {
        private readonly DarwinProductContext _darwinContext;
        public PedidoService(DarwinProductContext darwinContext)
        {
            _darwinContext = darwinContext;
        }
        public async Task AtualizaPeido(Pedido pedido)
        {
            try
            {
                if (pedido is not null)
                {
                    if(ObtemPedidoPorId(pedido.Id) is not null)
                    {
                        _darwinContext.Pedidos.Update(pedido);
                        await _darwinContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new ServiceException($"Não foi localizado nenhum pedido com o id {pedido.Id}.");
                    }
                }
                else
                {
                    throw new ServiceException("O objeto enviado está vazio ou nulo.");
                }
            }
            catch (ServiceException sExc)
            {

                throw new ServiceException("Erro ao tentar atualizar o pedido:" + sExc.Message);
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar atualizar o pedido:" + ex.Message);
            }
        }

        public IEnumerable<Pedido> ObtemTodosPedidos()
        {
            try
            {
                return _darwinContext.Pedidos;
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar obter todos os pedidos: " + ex.Message);
            }
        }

        public async Task InserirPedido(Pedido pedido)
        {
            try
            {
                if(pedido != null)
                {
                    if(ObtemPedidoPorId(pedido.Id) == null)
                    {
                        _darwinContext.Pedidos.Add(pedido);
                        await _darwinContext.SaveChangesAsync();
                    }
                    else
                    {
                        throw new ServiceException("Já existe um pedido cadastrado com esse id.");
                    }
                }
                else
                {
                    throw new ServiceException("O objeto enviado está vazio ou nulo.");
                }
            }
            catch (ServiceException sExc)
            {

                throw new ServiceException("Erro ao tentar inserir o pedido:" + sExc.Message);
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar inserir o pedido:" + ex.Message);
            }
        }

        public Pedido ObtemPedidoPorId(int id)
        {
            try
            {
                var pedido = _darwinContext.Pedidos.FirstOrDefault(p => p.Id == id);
                
                return pedido;
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar obter o pedido:" + ex.Message);
            }
        }

        public async Task RemoverPedido(int id)
        {
            try
            {
                var pedido = ObtemPedidoPorId(id);
                if(pedido is not null)
                {
                    _darwinContext.Remove(pedido);
                    await _darwinContext.SaveChangesAsync();
                }
                else
                {
                    throw new ServiceException($"Não foi localizado nenhum pedido com o id {id}.");
                }
            }
            catch (ServiceException sExc)
            {

                throw new ServiceException("Erro ao tentar remover o pedido:" + sExc.Message);
            }
            catch (Exception ex)
            {

                throw new ServiceException("Erro ao tentar remover pedido:" + ex.Message);
            }
        }
    }
}
