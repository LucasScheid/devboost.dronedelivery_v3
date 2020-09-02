using devboost.dronedelivery.felipe.DTO;
using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.test
{
    public static class SetupTests
    {
        public static PedidoDrone GetPedidoDrone(StatusEnvio statusEnvio)
        {
            return new PedidoDrone()
            {
                DataHoraFinalizacao = new DateTime(2020, 8, 20, 22, 00, 00),
                Distancia = 5,
                StatusEnvio = (int)statusEnvio,
                Pedido = GetPedido(),
                Drone = GetDrone(),
                DroneId = GetDrone().Id,
                PedidoId = GetPedido().Id
            };
        }

        public static List<PedidoDrone> GetPedidoDrones(StatusEnvio statusEnvio)
        {
            return new List<PedidoDrone>()
            {
                GetPedidoDrone(statusEnvio)
            };
        }

        public static Pedido GetPedido()
        {
            return new Pedido()
            {
                Cliente = new Cliente()
                {
                    Nome = "Felipe",
                    Id = 1,
                    Latitude = -19.9539424,
                    Longitude = -43.9750544,
                    Password = "",
                    UserId = ""
                },
                ClienteId = 1,
                Peso = 50,
                Situacao = (int)StatusPedido.AGUARDANDO

            };

        }
        public static List<Pedido> GetPedidosList()
        {
            return new List<Pedido>() { 
                GetPedido() 
            };
        }

        public static Cliente GetCliente()
        {
            return new Cliente()
            {
                Nome = "Felipe",
                Id = 1,
                Latitude = -19.9539424,
                Longitude = -43.9750544,
                Password = "",
                UserId = ""

            };
        }

        public static Drone GetDrone()
        {
            return new Drone()
            {
                Id = 1,
                Autonomia = 100,
                Capacidade = 100,
                Carga = 100,
                Perfomance = (100 / 60.0f) *100,
                Velocidade = 100
            };
        }

        public static DroneDto GetDroneDto()
        {
            return new DroneDto(new DroneStatusDto(GetDrone()), 100);
        }
    }
}
