using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaEmpleado : InterfacePersistenciaEmpleado
    {
        public Empleado Buscar(string nombre)
        {
            SqlConnection conexion = null;
            SqlDataReader drEmpleado = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarEmpleado = new SqlCommand("BuscarEmpleado", conexion);
                cmdBuscarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdBuscarEmpleado.Parameters.AddWithValue("@nombre", nombre);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBuscarEmpleado.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("Ocurrio un problema al buscar el empleado");
                }

                drEmpleado = cmdBuscarEmpleado.ExecuteReader();

                Empleado empleado = null;

                if (drEmpleado.HasRows)
                {
                    drEmpleado.Read();
                    empleado = new Empleado((string)drEmpleado["NombreLogueo"], (string)drEmpleado["Contraseña"]);
                }

                return empleado;
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
                if (drEmpleado != null)
                {
                    drEmpleado.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public Empleado BuscarHabilitado(string nombre)
        {
            SqlConnection conexion = null;
            SqlDataReader drEmpleado = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarEmpleado = new SqlCommand("BuscarEmpleadoHabilitado", conexion);
                cmdBuscarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdBuscarEmpleado.Parameters.AddWithValue("@nombre", nombre);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBuscarEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("El empleado fue dado de baja");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al buscar el empleado");
                        break;
                }

                drEmpleado = cmdBuscarEmpleado.ExecuteReader();

                Empleado empleado = null;

                if (drEmpleado.HasRows)
                {
                    drEmpleado.Read();
                    empleado = new Empleado((string)drEmpleado["NombreLogueo"], (string)drEmpleado["Contraseña"]);
                }

                return empleado;
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
                if (drEmpleado != null)
                {
                    drEmpleado.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Agregar(Empleado empleado)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarEmpleado = new SqlCommand("AltaEmpleado", conexion);
                cmdAgregarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdAgregarEmpleado.Parameters.AddWithValue("@NombreLogueo", empleado.NombreLogueo);
                cmdAgregarEmpleado.Parameters.AddWithValue("@Contraseña", empleado.Contraseña);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdAgregarEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al dar de alta el empleado.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("El empleado con el nombre de logueo " + empleado.NombreLogueo + " ya existe.");

                        break;
                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar el empleado.");
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
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Modificar(Empleado empleado)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarEmpleado = new SqlCommand("ModificarEmpleado", conexion);
                cmdModificarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdModificarEmpleado.Parameters.AddWithValue("@NombreLogueo", empleado.NombreLogueo);
                cmdModificarEmpleado.Parameters.AddWithValue("@Contraseña", empleado.Contraseña);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdModificarEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("El empleado con el nombre de logueo " + empleado.NombreLogueo + " fue dado de baja.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("El empleado con el nombre de logueo " + empleado.NombreLogueo + " no existe.");

                        break;
                    case -3:
                        throw new ExcepcionPersonalizada("OCurrio un problema al modificar el empleado.");
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
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Eliminar(Empleado empleado)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarEmpleado = new SqlCommand("BajaEmpleado", conexion);
                cmdEliminarEmpleado.CommandType = CommandType.StoredProcedure;

                cmdEliminarEmpleado.Parameters.AddWithValue("@NombreLogueo", empleado.NombreLogueo);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarEmpleado.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdEliminarEmpleado.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al dar de baja el empleado.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar el empleado.");

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
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        //Singleton puro
        private static PersistenciaEmpleado _instancia = null;

        private PersistenciaEmpleado()
        { }

        public static PersistenciaEmpleado GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaEmpleado();
            }

            return _instancia;
        }
    }
}
