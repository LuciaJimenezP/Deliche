using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class ProductoBL
    {
        private ProductoDAO dao = new ProductoDAO();

        public DataTable Listar()
        {
            return dao.Listar();
        }

        public void Insertar(Producto prod)
        {
            if (prod.Precio < 0)
                throw new Exception("El precio no puede ser negativo.");

            dao.Insertar(prod);
        }

        public void Eliminar(int id)
        {
            dao.Eliminar(id);
        }

        public DataTable ReporteBajoStock()
        {
            return dao.ObtenerBajoStock();
        }
    }
}