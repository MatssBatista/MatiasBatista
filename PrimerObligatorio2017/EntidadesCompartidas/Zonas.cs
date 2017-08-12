using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Zonas
    {

        private string _departamento;
        private string _localidad;
        private string _nombre;
        private int _habitantes;
        private List<string> _lista;       

        public string Departamento
        {
            get { return _departamento; }
            set
            {
                if (value.Length != 1)
                {
                    throw new ExcepcionPersonalizada("El departamento se representa con una letra.");
                }
                _departamento = value;
            }
        }

        public string Localidad
        {
            get { return _localidad; }
            set
            {
                if (value.Trim().Length != 3)
                {
                    throw new ExcepcionPersonalizada("La localidad se representa con tres letra.");
                }
                _localidad = value;      
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (value.Trim().Length < 0)
                {
                    throw new ExcepcionPersonalizada("Ingrese un nombre para la zona.");
                }
                if (value.Trim().Length > 20)
                {
                    throw new ExcepcionPersonalizada("El nombre de la Zona no puede tener mas de 20 caracteres.");
                }
                _nombre = value;    
            }
        }

        public int Habitantes
        {
            get { return _habitantes; }
            set
            {
                if (value > 0)
                    _habitantes = value;
                else
                    throw new ExcepcionPersonalizada("Ingrese la cantidad de habitantes");
            }
        }

        public List<string> Servicios
        {
            get { return _lista; }
            set
            {
                if (value == null)
                {
                    value = new List<string>();
                }

                _lista = value;
            }
        }

        public Zonas(string departamento, string localidad, string nombre, int habitantes, List<string> servicios)
        {
            Departamento = departamento;
            Localidad = localidad;
            Nombre = nombre;
            Habitantes = habitantes;
            Servicios= servicios;
        }

        public override string ToString()
        {
            return ("Departamento: " + Departamento + "; Localidad: " + Localidad + "; Nombre: " + Nombre + "; Habitantes: " + Habitantes + "; Lista de Servicios: " + Servicios);
        }
    }
}
