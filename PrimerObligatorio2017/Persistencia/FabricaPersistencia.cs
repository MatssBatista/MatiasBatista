using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    public class FabricaPersistencia
    {
        public static InterfacePersistenciaZona GetPersistenciaZona()
        {
            return (PersistenciaZona.GetInstancia());
        }

        public static InterfacePersistenciaEmpleado GetPersistenciaEmpleado()
        {
            return (PersistenciaEmpleado.GetInstancia());
        }

        public static InterfacePersistenciaVisita GetPersistenciaVisita()
        {
            return (PersistenciaVisitas.GetInstancia());
        }

        public static InterfacePersistenciaLocalComercial GetPersistenciaLocal()
        {
            return (PersistenciaLocalComercial.GetInstancia());
        }

        public static InterfacePersistenciaCasa GetPersistenciaCasa()
        {
            return (PersistenciaCasa.GetInstancia());
        }

        public static InterfacePersistenciaApartamento GetPersistenciaApartamento()
        {
            return (PersistenciaApartamento.GetInstancia());
        }
    }
}
