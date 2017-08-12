using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;

namespace Persistencia
{
    public interface InterfacePersistenciaApartamento
    {
        Apartamento Buscar(int padron);

        void Agregar(Apartamento unApto);

        void Modificar(Apartamento unApto);

        void Eliminar(Apartamento unApto);

        List<Apartamento> Listar();
    }
}
