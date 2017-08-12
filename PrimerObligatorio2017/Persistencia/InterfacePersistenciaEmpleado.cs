using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaEmpleado
    {
        Empleado Buscar(string nombre);

        Empleado BuscarHabilitado(string nombre);

        void Agregar(Empleado empleado);

        void Modificar(Empleado empleado);

        void Eliminar(Empleado empleado);
    }
}
