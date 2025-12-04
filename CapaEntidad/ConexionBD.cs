using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace CapaDatos
{
    public static class ConexionBD
    {
        public static string CadenaConexion =
            ConfigurationManager.ConnectionStrings["cnBDDelice"].ConnectionString;
    }
}
