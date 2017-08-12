using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    internal class LogicaPropiedad : InterfaceLogicaPropiedad
    {
        public Propiedad Buscar(int padron)
        {
            Propiedad propiedad = null;

            InterfacePersistenciaCasa interCasa = FabricaPersistencia.GetPersistenciaCasa();

            propiedad = interCasa.Buscar(padron);

            if (propiedad == null)
            {
                InterfacePersistenciaApartamento interApartamento = FabricaPersistencia.GetPersistenciaApartamento();

                propiedad = interApartamento.Buscar(padron);
            }

            if (propiedad == null)
            {
                InterfacePersistenciaLocalComercial interLocal = FabricaPersistencia.GetPersistenciaLocal();

                propiedad = interLocal.Buscar(padron);
            }

            return propiedad;
        }

        public void Agregar(Propiedad propiedad)
        {
            if (propiedad == null)
            {
                throw new ExcepcionPersonalizada("La propiedad es nula.");
            }

            if (propiedad is Casa)
            {
                InterfacePersistenciaCasa interCasa = FabricaPersistencia.GetPersistenciaCasa();

                interCasa.Agregar((Casa)propiedad);
            }
            else if (propiedad is Apartamento)
            {
                InterfacePersistenciaApartamento interApartamento = FabricaPersistencia.GetPersistenciaApartamento();

                interApartamento.Agregar((Apartamento)propiedad);
            }
            else if (propiedad is LocalComercial)
            {
                InterfacePersistenciaLocalComercial interLocal = FabricaPersistencia.GetPersistenciaLocal();

                interLocal.Agregar((LocalComercial)propiedad);
            }
            else
            {
                throw new ExcepcionPersonalizada("El tipo de propiedad no es valido");
            }

        }

        public void Modificar(Propiedad propiedad)
        {
            if (propiedad == null)
            {
                throw new ExcepcionPersonalizada("La propiedad es nula.");
            }

            if (propiedad is Casa)
            {
                InterfacePersistenciaCasa interCasa = FabricaPersistencia.GetPersistenciaCasa();

                interCasa.Modificar((Casa)propiedad);
            }
            else if (propiedad is Apartamento)
            {
                InterfacePersistenciaApartamento interApartamento = FabricaPersistencia.GetPersistenciaApartamento();

                interApartamento.Modificar((Apartamento)propiedad);
            }
            else if (propiedad is LocalComercial)
            {
                InterfacePersistenciaLocalComercial interLocal = FabricaPersistencia.GetPersistenciaLocal();

                interLocal.Modificar((LocalComercial)propiedad);
            }
            else
            {
                throw new ExcepcionPersonalizada("El tipo de propiedad no es valido");
            }
        }

        public void Eliminar(Propiedad propiedad)
        {
            if (propiedad == null)
            {
                throw new ExcepcionPersonalizada("La propiedad es nula.");
            }

            if (propiedad is Casa)
            {
                InterfacePersistenciaCasa interCasa = FabricaPersistencia.GetPersistenciaCasa();

                interCasa.Eliminar((Casa)propiedad);
            }
            else if (propiedad is Apartamento)
            {
                InterfacePersistenciaApartamento interApartamento = FabricaPersistencia.GetPersistenciaApartamento();

                interApartamento.Eliminar((Apartamento)propiedad);
            }
            else if (propiedad is LocalComercial)
            {
                InterfacePersistenciaLocalComercial interLocal = FabricaPersistencia.GetPersistenciaLocal();

                interLocal.Eliminar((LocalComercial)propiedad);
            }
            else
            {
                throw new ExcepcionPersonalizada("El tipo de propiedad no es valido");
            }
        }

        public List<Propiedad> Listar()
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            InterfacePersistenciaCasa interCasa = FabricaPersistencia.GetPersistenciaCasa();

            foreach (Propiedad p in interCasa.Listar())
            {
                propiedades.Add(p);
            }

            InterfacePersistenciaLocalComercial interLocal = FabricaPersistencia.GetPersistenciaLocal();

            foreach (Propiedad p in interLocal.Listar())
            {
                propiedades.Add(p);
            }

            InterfacePersistenciaApartamento interApartamento = FabricaPersistencia.GetPersistenciaApartamento();

            foreach (Propiedad p in interApartamento.Listar())
            {
                propiedades.Add(p);
            }

            return propiedades;
        }

        //Singleton puro
        private static LogicaPropiedad _instancia = null;

        private LogicaPropiedad()
        { }

        public static LogicaPropiedad GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new LogicaPropiedad();
            }

            return _instancia;
        }
    }
}
