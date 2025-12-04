using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Entrega
    {
        public int IdEntrega { get; set; }
        public int IdPedido { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string EstadoEntrega { get; set; }
        public int Estado { get; set; } = 1;
    }
}