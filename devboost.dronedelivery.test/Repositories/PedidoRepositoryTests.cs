﻿using devboost.dronedelivery.felipe.DTO.Enums;
using devboost.dronedelivery.felipe.EF.Data;
using devboost.dronedelivery.felipe.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace devboost.dronedelivery.test.Repositories
{
    public class PedidoRepositoryTests
    {
        private PedidoRepository GetRepository()
        {
            var data = SetupTests.GetPedidosList();
            var context = ContextProvider<felipe.DTO.Models.Pedido>.GetContext(data);
            return new PedidoRepository(context);

        }

        [Fact]
        public void GetPedidoTest()
        {

            var pedido = GetRepository().GetPedido(1);
            Assert.True(pedido != null);
        }
        [Fact]
        public void ObterPedidosTest()
        {
            var pedido = GetRepository().ObterPedidos((int)StatusPedido.AGUARDANDO);
            Assert.True(pedido != null);
        }
    }
}