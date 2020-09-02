using devboost.dronedelivery.felipe.DTO.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace devboost.dronedelivery.felipe.DTO.Extensions
{
    public static class ClienteExtensions
    {
        public static bool HasClient(this Cliente cliente)
        {
            return cliente != null && !string.IsNullOrWhiteSpace(cliente.UserId);
        }
    }
}
