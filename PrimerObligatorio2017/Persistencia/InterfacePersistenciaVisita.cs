using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaVisita
    {
        void Agregar(Visita visita);

        List<Visita> Listar(int padron);
    }
}
