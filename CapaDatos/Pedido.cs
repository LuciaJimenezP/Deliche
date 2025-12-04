using System;
using System.Collections.Generic;
using System.Linq;

namespace CapaEntidad
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string EstadoPedido { get; set; }
        public decimal Total { get; set; }
        public int IdCliente { get; set; }
        public int Estado { get; set; } = 1;

        public List<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();
    }
}