using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaZona
    {
        Zonas Buscar(string departamento, string localidad);

        Zonas BuscarHabilitada(string departamento, string localidad);

        void Agregar(Zonas zona);

        void Modificar(Zonas zona);

        void Eliminar(Zonas zona);

        List<Zonas> Listar();
    }
}
