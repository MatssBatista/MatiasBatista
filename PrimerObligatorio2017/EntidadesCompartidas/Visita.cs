using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Visita
    {
        private int _codigo;
        private Propiedad _propiedad;
        private string _nombre;
        private DateTime _fecha;
        private string _telefono;

        public int Codigo
        {
            get
            {
                return _codigo;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ExcepcionPersonalizada("El codigo de la visita no puede ser menor a cero.");
                }
                _codigo = value;
            }
        }

        public Propiedad Propiedad
        {
            get
            {
                return _propiedad;
            }
            set
            {
                if (value == null)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar la propiedad.");
                }
                _propiedad = value;
            }
        }

        public string Nombre
        {
            get 
            { 
                return _nombre; 
            }
            set
            {
                if (value.Trim().Length < 0)
                {
                    throw new ExcepcionPersonalizada("Ingrese el nombre del visitante");
                }
                if (value.Trim().Length > 30)
                {
                    throw new ExcepcionPersonalizada("El nombre del visitante no puede tener mas de 20 caracteres.");
                }
                _nombre = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
            }
        }

        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                if (value.Trim().Length <= 0)
                {
                    throw new ExcepcionPersonalizada("Debe ingresar un numero de telefono.");
                }

                try
                {
                    int n = Convert.ToInt32(value.Trim());
                }
                catch (FormatException)
                {
                    throw new ExcepcionPersonalizada("El numero de telefono solo puede contener numeros enteros.");
                }

                _telefono = value;
            }
        }

        public Visita(int codigo, DateTime fecha, string nombre, string telefono,Propiedad propiedad)
        {
            Codigo = codigo;
            Propiedad = propiedad;
            Nombre = nombre;
            Fecha = fecha;
            Telefono = telefono;
        }
    }
}
