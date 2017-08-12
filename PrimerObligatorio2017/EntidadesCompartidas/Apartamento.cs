using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Apartamento : Propiedad
    {
        private int _piso;
        private bool _ascensor;

        public int Piso
        {
            get
            {
                return _piso;
            }
            set
            {
                if (value < 0)
                {
                    throw new ExcepcionPersonalizada("El numero del piso debe ser un numero positivo o 0.");
                }
                _piso = value;
            }
        }

        public bool Ascensor
        {
            get
            {
                return _ascensor;
            }
            set
            {
                
                _ascensor = value;
            }
        }


        public Apartamento(int padron, string direccion, int precio, string accion, int baños, int habitaciones, double tamaño, int piso, bool ascensor, Empleado empleado, Zonas zona)
            : base (padron, direccion, precio, accion, baños, habitaciones, tamaño, empleado, zona)
        {
            Piso = piso;
            Ascensor = ascensor;
        }
    }
}
