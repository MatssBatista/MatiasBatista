using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class LocalComercial : Propiedad
    {
        private bool _habilitacion;

        public bool Habilitacion
        {
            get
            {
                return _habilitacion;
            }
            set
            {
                
                _habilitacion = value;
            }
        }

        public LocalComercial(int padron, string direccion, int precio, string accion, int baños, int habitaciones, double tamaño, bool habilitacion, Empleado empleado, Zonas zona)
            : base (padron, direccion, precio, accion, baños, habitaciones, tamaño, empleado, zona)
        {
            Habilitacion = habilitacion;
        }
    }
}
