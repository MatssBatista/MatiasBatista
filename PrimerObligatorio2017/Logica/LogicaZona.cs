using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaZona : InterfaceLogicaZona
    {
        public Zonas Buscar(string departamento, string localidad)
        {
            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            return interZona.Buscar(departamento, localidad);
        }

        public Zonas BuscarHabilitada(string departamento, string localidad)
        {
            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            return interZona.BuscarHabilitada(departamento, localidad);
        }

        public void Agregar(Zonas zona)
        {
            if (zona == null)
            {
                throw new ExcepcionPersonalizada("La zona es nula.");
            }

            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            interZona.Agregar(zona);
        }

        public void Modificar(Zonas zona)
        {
            if (zona == null)
            {
                throw new ExcepcionPersonalizada("La zona es nula.");
            }

            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            interZona.Modificar(zona);
        }

        public void Eliminar(Zonas zona)
        {
            if (zona == null)
            {
                throw new ExcepcionPersonalizada("La zona es nula.");
            }

            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            interZona.Eliminar(zona);
        }

        public List<Zonas> Listar()
        {
            InterfacePersistenciaZona interZona = FabricaPersistencia.GetPersistenciaZona();

            return interZona.Listar();
        }

        //Singleton puro
        private static LogicaZona _instancia = null;

        private LogicaZona()
        { }

        public static LogicaZona GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaZona();
            }

            return _instancia;
        }
    }
}
