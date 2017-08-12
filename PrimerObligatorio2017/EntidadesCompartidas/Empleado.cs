using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Empleado
    {
       
        private string _nombrelogueo;
        private string _contraseña;
        
        public string NombreLogueo
        {
            get { return _nombrelogueo; }
            set
            {
                if (value.Trim().Length < 0)
                {
                    throw new ExcepcionPersonalizada("Ingrese un nombre de logueo.");
                }
                if (value.Trim().Length > 30)
                {
                    throw new ExcepcionPersonalizada("El nombre de logueo no puede tener mas de 30 caracteres.");
                }
                _nombrelogueo = value;
                    
            }
        }
        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                if (value.Trim().Length != 10)
                {
                    throw new ExcepcionPersonalizada("La contraseña debe tener 10 caracteres.");
                }
                _contraseña = value;
                
            }
        }
       
        public Empleado(string nombrelogueo, string contraseña)
        {
            NombreLogueo = nombrelogueo;
            Contraseña = contraseña;
        }
     
        public override string ToString()
        {
            return ("Nombre de Logueo: " + NombreLogueo + "; Contraseña: " + Contraseña);
        }
    }
}
