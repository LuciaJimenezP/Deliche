using System.Net;
using System.Net.Mail;
using System.Text;
using CapaEntidad;

namespace CapaNegocio
{
    public static class CorreoHelper
    {

        private const string CorreoOrigen = "oficialdeliche@gmail.com";
        private const string ClaveCorreoOrigen = "zhmvavqrdgobnrfd";

        public static void EnviarCorreoPedido(Pedido pedido, Cliente cliente)
        {
            if (cliente == null || string.IsNullOrWhiteSpace(cliente.Correo))
                return;

            string asunto = "Resumen de tu pedido - Deliche";
            string cuerpo = ConstruirCuerpoCorreo(pedido, cliente);

            MailMessage mensaje = new MailMessage();
            mensaje.From = new MailAddress(CorreoOrigen, "Deliche");
            mensaje.To.Add(cliente.Correo);
            mensaje.Subject = asunto;
            mensaje.Body = cuerpo;
            mensaje.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;

            
            smtp.Credentials = new NetworkCredential(CorreoOrigen, ClaveCorreoOrigen);

            smtp.Send(mensaje);
        }

        private static string ConstruirCuerpoCorreo(Pedido pedido, Cliente cliente)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hola {cliente.Nombre},");
            sb.AppendLine();
            sb.AppendLine("¡Gracias por tu compra en Deliche! 🧁");
            sb.AppendLine();
            sb.AppendLine("Este es el detalle de tu pedido:");
            sb.AppendLine("--------------------------------------------------");

            foreach (var det in pedido.Detalles)
            {
                string nombre = string.IsNullOrWhiteSpace(det.NombreProducto)
                                ? $"Producto #{det.IdProducto}"
                                : det.NombreProducto;

                sb.AppendLine($"{det.Cantidad} x {nombre} - S/ {det.Subtotal:F2}");
            }

            sb.AppendLine("--------------------------------------------------");
            sb.AppendLine($"Total: S/ {pedido.Total:F2}");
            sb.AppendLine();
            sb.AppendLine($"Fecha del pedido: {pedido.FechaPedido:dd/MM/yyyy}");
            sb.AppendLine($"Fecha de entrega: {pedido.FechaEntrega:dd/MM/yyyy}");
            sb.AppendLine();
            sb.AppendLine("¡Gracias por tu compra!");
            sb.AppendLine("Equipo Deliche");

            return sb.ToString();
        }
    }
}

