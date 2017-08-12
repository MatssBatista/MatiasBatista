using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Propiedad
    {
        private int _padron;
        private string _direccion;
        private int _precio;
        private string _accion;
        private int _baños;
        private int _habitaciones;
        private double _tamaño;
        private Empleado _unEmpleado;
        private Zonas _unaZona;

        public int Padron
        {
            get
            {
                return _padron;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El padron debe ser mayor a cero.");
                }
                _padron = value;
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                if (value.Trim().Length == 0)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar la direccion.");
                }
                if (value.Trim().Length > 30)
                {
                    throw new ExcepcionPersonalizada("La direccion no puede tener mas de 30 caracteres.");
                }
                _direccion = value;
            }
        }

        public int Precio
        {
            get
            {
                return _precio;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El precio debe ser mayor a cero.");
                }
                _precio = value;
            }
        }

        public string Accion
        {
            get
            {
                return _accion;
            }
            set
            {
                if (value != "venta" && value != "alquiler" && value != "permuta")
                {
                    throw new ExcepcionPersonalizada("El tipo de accion no es valido.");
                }
                _accion = value;
            }
        }

        public int Baños
        {
            get
            {
                return _baños;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El numero de baños no puede ser menor a cero.");
                }

                _baños = value;
            }
        }

        public int Habitaciones
        {
            get
            {
                return _habitaciones;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El numero de habitaciones no puede ser menor a cero.");
                }

                _habitaciones = value;
            }
        }

        public double Tamaño
        {
            get
            {
                return _tamaño;
            }
            set
            {
                if (value <= 1)
                {
                    throw new ExcepcionPersonalizada("El tamaño debe ser mayor a 10 metros cuadrados.");
                }
                _tamaño = value;
            }
        }

        public Empleado UnEmpleado
        {
            get { return _unEmpleado; }
            set
            {
                if (value == null)
                    throw new ExcepcionPersonalizada("Ingrese un empleado.");
                else
                    _unEmpleado = value;
            }
        }

        public Zonas UnaZona
        {
            get { return _unaZona; }
            set
            {
                if (value == null)
                    throw new ExcepcionPersonalizada("Ingrese una zona.");
                else
                    _unaZona = value;
            }
        }

        public Propiedad(int padron, string direccion, int precio, string accion, int baños, int habitaciones, double tamaño, Empleado e, Zonas z)
        {
            Padron = padron;
            Direccion = direccion;
            Precio = precio;
            Accion = accion;
            Baños = baños;
            Habitaciones = habitaciones;
            Tamaño = tamaño;
            UnEmpleado = e;
            UnaZona = z;
        }
    }
}
