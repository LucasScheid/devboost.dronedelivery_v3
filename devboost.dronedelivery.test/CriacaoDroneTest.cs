using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Models;
using devboost.dronedelivery.felipe.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

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
    }
}
