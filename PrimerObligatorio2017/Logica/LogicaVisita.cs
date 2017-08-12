using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaVisita :InterfaceLogicaVisita
    {
        public void Agregar(Visita visita)
        {
            if (visita == null)
            {
                throw new ExcepcionPersonalizada("La visita es nula.");
            }
            if (visita.Fecha < DateTime.Now)
            {
                throw new ExcepcionPersonalizada("La fecha de la visita no puede ser anterior a la fecha actual.");
            }

            InterfacePersistenciaVisita interVisita = FabricaPersistencia.GetPersistenciaVisita();

            interVisita.Agregar(visita);
        }

        public List<Visita> Listar(int padron)
        {
            InterfacePersistenciaVisita interVisita = FabricaPersistencia.GetPersistenciaVisita();

            return interVisita.Listar(padron);
        }

        //Singleton puro
        private static LogicaVisita _instancia = null;

        private LogicaVisita()
        { }

        public static LogicaVisita GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaVisita();
            }

            return _instancia;
        }
    }
}
