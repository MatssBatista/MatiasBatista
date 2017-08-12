using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Casa : Propiedad
    {
        private double _terreno;
        private bool _jardin;

        public double Terreno
        {
            get
            {
                return _terreno;
            }
            set
            {
                if (value < Tamaño)
                {
                    throw new ExcepcionPersonalizada("El tamaño del terreno no puede ser menor al tamaño de la propiedad.");
                }

                if (value <= 1)
                {
                    throw new ExcepcionPersonalizada("El tamaño del terreno no puede ser menor a 100 metros cudrados.");
                }
                _terreno = value;
            }
        }

        public bool Jardin
        {
            get
            {
                return _jardin;
            }
            set
            {
                
                _jardin = value;
            }
        }

        public Casa(int padron, string direccion, int precio, string accion, int baños, int habitaciones, double tamaño, double terreno, bool jardin, Empleado empleado, Zonas zona)
            : base (padron, direccion, precio, accion, baños, habitaciones, tamaño, empleado, zona)
        {
            Terreno = terreno;
            Jardin = jardin;
        }

    }
}
