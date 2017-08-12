using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaEmpleado : InterfaceLogicaEmpleado
    {
        public Empleado Buscar(string nombre)
        {
            InterfacePersistenciaEmpleado interEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();

            return interEmpleado.Buscar(nombre);
        }

        public Empleado BuscarHabilitado(string nombre)
        {
            InterfacePersistenciaEmpleado interEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();

            return interEmpleado.BuscarHabilitado(nombre);
        }

        public void Agregar(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ExcepcionPersonalizada("El empleado es nulo.");
            }

            InterfacePersistenciaEmpleado interEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();

            interEmpleado.Agregar(empleado);
        }

        public void Modificar(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ExcepcionPersonalizada("El empleado es nulo.");
            }

            InterfacePersistenciaEmpleado interEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();

            interEmpleado.Modificar(empleado);
        }

        public void Eliminar(Empleado empleado)
        {
            if (empleado == null)
            {
                throw new ExcepcionPersonalizada("El empleado es nulo.");
            }

            InterfacePersistenciaEmpleado interEmpleado = FabricaPersistencia.GetPersistenciaEmpleado();

            interEmpleado.Eliminar(empleado);
        }

        //Singleton puro
        private static LogicaEmpleado _instancia = null;

        private LogicaEmpleado()
        { }

        public static LogicaEmpleado GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaEmpleado();
            }

            return _instancia;
        }
    }
}
