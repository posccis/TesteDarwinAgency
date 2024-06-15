using DarwinProduct.Application.Interfaces;
using DarwinProduct.Domain.Domains;
using DarwinProduct.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DarwinProduct.API.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService<Pedido> _pedidoService;
        private readonly IItemPedidoService<ItemPedido> _itemPedidoService;

        public PedidoController(IPedidoService<Pedido> pedidoService, IItemPedidoService<ItemPedido> itemPedidoService)
        {
            _itemPedidoService = itemPedidoService;
            _pedidoService = pedidoService;
        }

        /// <summary>
        /// Endpoint para adicioanr um novo pedido.
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>Retorna um código http informando se foi inserido junto do objeto.</returns>
        [HttpPost]
        public async Task<IActionResult> AdicionaPedido(Pedido pedido) 
        {
            try
            {
                await _pedidoService.InserirPedido(pedido);
                return CreatedAtAction(nameof(ObtemPedidoPorId), new { id = pedido.Id }, pedido);
            }
            catch (ServiceException sExc)
            {

                return BadRequest(sExc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }
        
        /// <summary>
        /// Endpoint para atualizar um pedido.
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns>Retorna um código http informando se foi atualizado junto do objeto atualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> AtualizaPedido(Pedido pedido) 
        {
            try
            {
                await _pedidoService.AtualizarPedido(pedido);
                return CreatedAtAction(nameof(ObtemPedidoPorId), new { id = pedido.Id }, pedido);
            }
            catch (ServiceException sExc)
            {

                return BadRequest(sExc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }



        /// <summary>
        /// Endpoint para obter todos os pedidos com seus itens.
        /// </summary>
        /// <returns>Lista com todos os pedidos</returns>
        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> ObtemTodosOsPedidos()
        {
            try
            {
                var pedidos = await _pedidoService.ObterTodosPedidos();
                return Ok(pedidos);
            }
            catch (ServiceException sExc)
            {

                return NotFound(sExc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }

        /// <summary>
        /// Endpoint para obter o pedido através do seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto do tipo pedido com todos os atributos incluido a lista de itens.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObtemPedidoPorId(int id) 
        {
            try
            {
                var pedido = await _pedidoService.ObterPedidoPorId(id);
                if (pedido is null) throw new ServiceException($"Não foi possivel encontrar nenhum pedido com o id {id}.");
                return Ok(pedido);
            }
            catch (ServiceException sExc)
            {

                return NotFound(sExc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }
        /// <summary>
        /// Endpoint para remover o pedido através do seu Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um código http informando se a operação foi realizada com sucesso.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> RemovePedido(int id) 
        {
            try
            {
                await _pedidoService.RemoverPedido(id);
                return Ok();
            }
            catch (ServiceException sExc)
            {

                return NotFound(sExc.Message);
            }
            catch (Exception exc)
            {

                return BadRequest(exc.Message);
            }
        }
    }
}
