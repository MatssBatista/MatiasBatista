using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class FabricaLogica
    {
        public static InterfaceLogicaZona GetLogicaZona()
        {
            return LogicaZona.GetInstancia();
        }

        public static InterfaceLogicaEmpleado GetLogicaEmpleado()
        {
            return LogicaEmpleado.GetInstancia();
        }

        public static InterfaceLogicaVisita GetLogicaVisita()
        {
            return LogicaVisita.GetInstancia();
        }

        public static InterfaceLogicaPropiedad GetLogicaPropiedad()
        {
            return LogicaPropiedad.GetInstancia();
        }
    }
}
