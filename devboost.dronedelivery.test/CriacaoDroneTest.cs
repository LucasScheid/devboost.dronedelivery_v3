using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.EF.Repositories.Interfaces;
using devboost.dronedelivery.felipe.Services;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;

namespace devboost.dronedelivery.test
{
    public class CriacaoDroneTest
    {



        [Theory]
        [InlineData(50, 30, 10, true, "O drone deveria aceitar esta carga")]
        [InlineData(50, 30, 20, true,  "O drone deveria aceitar esta carga")]
        [InlineData(50, 30, 30,false,  "O drone NÃO deveria aceitar esta carga")]
        public void ValidarPeso(int capacidadeDrone, int droneSomaPeso, int pedidoPeso, bool resultadoEsperado, string mensagemErro)
        {
            var drone = new Drone { Id = 1, Capacidade = capacidadeDrone, Velocidade = 40, Autonomia = 50, Carga = 80, Perfomance = 33.3F };

            DroneStatusDto dtoDroneStatus = new DroneStatusDto { Drone = drone, SomaDistancia = 50, SomaPeso = droneSomaPeso};

            Pedido pedido = new Pedido {ClienteId = 1, Peso = pedidoPeso };

            Assert.True(resultadoEsperado == DroneService.ValidaPeso(dtoDroneStatus, pedido), mensagemErro);
        }


        [Theory]
        [InlineData(8, 2, 5, 20, true, "O drone deveria aceitar esta distancia")]
        [InlineData(8, 2, 5, 15, true, "O drone deveria aceitar esta distancia")]
        [InlineData(8, 2, 5, 10, false, "O drone NÃO deveria aceitar esta distancia")]
        public void ValidarDistancia(int somaDistancia,   double distanciaRetorno, double pedidoDroneDistancia, float performanceDrone, bool resultadoEsperado,  string mensagemErro)
        {
            var drone = new Drone { Id = 1, Capacidade = 500, Velocidade = 40, Autonomia = 50, Carga = 80, Perfomance = performanceDrone };

            DroneStatusDto dtoDroneStatus = new DroneStatusDto { Drone = drone, SomaDistancia = somaDistancia, SomaPeso = 300};

            Assert.True(resultadoEsperado == DroneService.ValidaDistancia(dtoDroneStatus, distanciaRetorno, pedidoDroneDistancia), mensagemErro);
        }

        [Fact]
        public void finalizaPedido()
        {
            PedidoDrone pedidoUm = new PedidoDrone() {Id=1, StatusEnvio = (int)StatusEnvio.EM_TRANSITO}; 
            PedidoDrone pedidoDois = new PedidoDrone() {Id=2, StatusEnvio = (int)StatusEnvio.EM_TRANSITO};

            List<PedidoDrone> listPedidoDrones = new List<PedidoDrone> { pedidoUm, pedidoDois };

            var _pedidoDroneRepository = new Mock<IPedidoDroneRepository>();
            _pedidoDroneRepository.Setup(_ => _.RetornaPedidosParaFecharAsync()).Returns(listPedidoDrones);

            //Assert.Contains(false, listPedidoDrones.Any(p => p.StatusEnvio != (int)StatusEnvio.FINALIZADO)); 

        }
    }
}
