using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Logica
{
    public interface InterfaceLogicaVisita
    {
        void Agregar(Visita visita);

        List<Visita> Listar(int padron);
    }
}
