using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface InterfaceLogicaPropiedad
    {
        Propiedad Buscar(int padron);

        void Agregar(Propiedad propiedad);

        void Modificar(Propiedad propiedad);

        void Eliminar(Propiedad propiedad);

        List<Propiedad> Listar();
    }
}
