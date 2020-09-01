using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Facade.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.felipe.Controllers
{
    [Authorize("Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoFacade _pedidoFacade;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IClienteRepository _clienteRepository;

        public PedidosController(IPedidoRepository pedidoRepository, IPedidoFacade pedidoFacade, IClienteRepository clienteRepository)
        {
            _pedidoFacade = pedidoFacade;
            _pedidoRepository = pedidoRepository;
            _clienteRepository = clienteRepository;
        }

        [HttpPost("assign-drone")]
        public async Task<ActionResult> AssignDrone()
        {
            await _pedidoFacade.AssignDrone(_pedidoRepository);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {
            var clientePedido = _clienteRepository.GetCliente(pedido.Cliente.Id);

            pedido.Cliente = clientePedido;
            pedido.DataHoraInclusao = DateTime.Now;
            pedido.Situacao = (int)StatusPedido.AGUARDANDO;
            await _pedidoRepository.SavePedidoAsync(pedido);

            return pedido;
        }

    }
}
