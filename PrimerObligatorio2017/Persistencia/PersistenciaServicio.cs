using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaServicio
    {
        internal static List<string> Listar(string departamento, string localidad)
        {
            SqlConnection conexion = null;
            SqlDataReader drServicio = null;
            List<string> servicios = new List<string>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarServicios = new SqlCommand("ListarServicio", conexion);
                cmdListarServicios.CommandType = CommandType.StoredProcedure;

                cmdListarServicios.Parameters.AddWithValue("@departamento", departamento);
                cmdListarServicios.Parameters.AddWithValue("@localidad", localidad);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdListarServicios.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdListarServicios.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("La propiedad no existe.");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un error al listar los servicios.");
                        break;
                }

                drServicio = cmdListarServicios.ExecuteReader();

                string servicio = null;

                if (drServicio.HasRows)
                {
                    while (drServicio.Read())
                    {
                        servicio = (string)drServicio["Servicio"];
                        servicios.Add(servicio);
                    }
                }
                return servicios;
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
                if (drServicio != null)
                {
                    drServicio.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        internal static void Agregar(string departamento, string localidad, string servicio, SqlTransaction transaccion)
        {
            try
            {

                SqlCommand cmdAgregarServicio = new SqlCommand("AgregarServicio", transaccion.Connection);
                cmdAgregarServicio.CommandType = CommandType.StoredProcedure;

                cmdAgregarServicio.Parameters.AddWithValue("@departamento", departamento);
                cmdAgregarServicio.Parameters.AddWithValue("@localidad", localidad);
                cmdAgregarServicio.Parameters.AddWithValue("@servicio", servicio);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarServicio.Parameters.Add(valorRetorno);

                cmdAgregarServicio.Transaction = transaccion;

                cmdAgregarServicio.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Esta zona ya tiene este servicio.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("La zona con el departamento " + departamento + " y la localidad " + localidad + "no existe.");

                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("La zona con el departamento " + departamento + " y la localidad " + localidad + "fue dada de baja.");

                        break;

                    case -4:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el servicio.");

                        break;
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
        }

        internal static void Eliminar(string departamento, string localidad, SqlTransaction transaccion)
        {
            try
            {
                SqlCommand cmdEliminarServicio = new SqlCommand("EliminarServicio", transaccion.Connection);
                cmdEliminarServicio.CommandType = CommandType.StoredProcedure;

                cmdEliminarServicio.Parameters.AddWithValue("@departamento", departamento);
                cmdEliminarServicio.Parameters.AddWithValue("@localidad", localidad);                

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarServicio.Parameters.Add(valorRetorno);

                cmdEliminarServicio.Transaction = transaccion;

                cmdEliminarServicio.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar los servicios.");
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
   
        }
    }
}
