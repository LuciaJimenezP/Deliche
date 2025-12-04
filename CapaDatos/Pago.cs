using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdPedido { get; set; }
        public string TipoPago { get; set; }
        public decimal MontoPagado { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string EstadoPago { get; set; }
        public int Estado { get; set; } = 1;
    }
}