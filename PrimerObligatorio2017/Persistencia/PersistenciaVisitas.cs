using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaVisitas : InterfacePersistenciaVisita
    {
        public void Agregar(Visita visita)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarVisita = new SqlCommand("AgregarVisita", conexion);
                cmdAgregarVisita.CommandType = CommandType.StoredProcedure;

                cmdAgregarVisita.Parameters.AddWithValue("@fecha", visita.Fecha);
                cmdAgregarVisita.Parameters.AddWithValue("@telefono", visita.Telefono);
                cmdAgregarVisita.Parameters.AddWithValue("@visitante", visita.Nombre);
                cmdAgregarVisita.Parameters.AddWithValue("@padron", visita.Propiedad.Padron);


                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarVisita.Parameters.Add(valorRetorno);

                conexion.Open();

                int oAfectados = cmdAgregarVisita.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("La propiedad con el rut " + visita.Propiedad.Padron + " no existe.");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("La fecha de la visita no puede ser menor a la fecha actual.");
                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar la visita.");
                        break;
                }

                visita.Codigo = (int)valorRetorno.Value;

            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public List<Visita> Listar(int padron)
        {
            SqlConnection conexion = null;
            SqlDataReader drVisita = null;
            List<Visita> visitas = new List<Visita>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarVisitas = new SqlCommand("ListarVisitas", conexion);
                cmdListarVisitas.CommandType = CommandType.StoredProcedure;

                cmdListarVisitas.Parameters.AddWithValue("@padron", padron);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdListarVisitas.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdListarVisitas.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("La propiedad con el padron " + padron + " no existe.");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un error al listar las visitas.");
                        break;
                }

                drVisita = cmdListarVisitas.ExecuteReader();

                Visita visita = null;

                if (drVisita.HasRows)
                {
                    while (drVisita.Read())
                    {
                        InterfacePersistenciaEmpleado interEmpleado = PersistenciaEmpleado.GetInstancia();
                        Empleado empleado = interEmpleado.Buscar((string)drVisita["Empleado"]);

                        InterfacePersistenciaZona interZona = PersistenciaZona.GetInstancia();
                        Zonas zona = interZona.Buscar((string)drVisita["Departamento"], (string)drVisita["Localidad"]);

                        Propiedad propiedad = new Propiedad((int)drVisita["Padron"], (string)drVisita["Direccion"], (int)drVisita["Precio"], (string)drVisita["Accion"], (int)drVisita["Baños"], (int)drVisita["Habitaciones"], (double)drVisita["Area"], empleado, zona);

                        visita = new Visita((int)drVisita["Id"], (DateTime)drVisita["Fecha"], (string)drVisita["Visitante"], (string)drVisita["Telefono"], propiedad);
                        visitas.Add(visita);
                    }
                }
                return visitas;
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch
            {
                throw new ExcepcionPersonalizada("Ocurrio un problema al acceder a la base de datos.");
            }
            finally
            {
                if (drVisita != null)
                {
                    drVisita.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        //Singleton puro
        private static PersistenciaVisitas _instancia = null;

        private PersistenciaVisitas()
        { }

        public static PersistenciaVisitas GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaVisitas();
            }

            return _instancia;
        }
    }
}
