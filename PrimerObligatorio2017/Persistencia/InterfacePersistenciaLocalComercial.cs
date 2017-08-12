using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaLocalComercial
    {
        LocalComercial Buscar(int padron);

        void Agregar(LocalComercial Local);

        void Modificar(LocalComercial Local);

        void Eliminar(LocalComercial Local);

        List<LocalComercial> Listar();
    }
}
