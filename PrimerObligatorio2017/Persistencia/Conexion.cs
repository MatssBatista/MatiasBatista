﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class Conexion
    {
        private static string _cadenaConexion = "data source = .; initial catalog = Obligatorio2017; integrated security = true;";

        public static string CadenaConexion
        {
            get
            {
                return _cadenaConexion;
            }
        }
    }
}
