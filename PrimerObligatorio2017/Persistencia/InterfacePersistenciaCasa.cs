using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaCasa
    {
        Casa Buscar(int padron);

        void Agregar(Casa unaCasa);

        void Modificar(Casa unaCasa);

        void Eliminar(Casa unaCasa);

        List<Casa> Listar();
    }
}
