using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaZona : InterfacePersistenciaZona
    {
        public Zonas Buscar(string departamento, string localidad)
        {
            SqlConnection conexion = null;
            SqlDataReader drZona = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarZona = new SqlCommand("BuscarZona", conexion);
                cmdBuscarZona.CommandType = CommandType.StoredProcedure;

                cmdBuscarZona.Parameters.AddWithValue("@departamento", departamento);
                cmdBuscarZona.Parameters.AddWithValue("@localidad", localidad);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarZona.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBuscarZona.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("Ocurrio un problema al buscar la zona.");
                }

                drZona = cmdBuscarZona.ExecuteReader();

                Zonas zona = null;

                if (drZona.HasRows)
                {
                    drZona.Read();
                    List<string> servicios = PersistenciaServicio.Listar(departamento, localidad);
                    zona = new Zonas((string)drZona["Departamento"], (string)drZona["Localidad"], (string)drZona["Nombre"], (int)drZona["Habitantes"], servicios);
                }
                return zona;
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
                if (drZona != null)
                {
                    drZona.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public Zonas BuscarHabilitada(string departamento, string localidad)
        {
            SqlConnection conexion = null;
            SqlDataReader drZona = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarZona = new SqlCommand("BuscarZonaHabilitada", conexion);
                cmdBuscarZona.CommandType = CommandType.StoredProcedure;

                cmdBuscarZona.Parameters.AddWithValue("@departamento", departamento);
                cmdBuscarZona.Parameters.AddWithValue("@localidad", localidad);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarZona.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdBuscarZona.ExecuteNonQuery();
                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Esta zona fue dada de baja.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al buscar la zona.");

                        break;
                }

                drZona = cmdBuscarZona.ExecuteReader();

                Zonas zona = null;

                if (drZona.HasRows)
                {
                    drZona.Read();
                    List<string> servicios = PersistenciaServicio.Listar(departamento, localidad);
                    zona = new Zonas((string)drZona["Departamento"], (string)drZona["Localidad"], (string)drZona["Nombre"], (int)drZona["Habitantes"], servicios);
                }
                return zona;
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
                if (drZona != null)
                {
                    drZona.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Agregar(Zonas zona)
        {
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarZona = new SqlCommand("AgregarZona", conexion);
                cmdAgregarZona.CommandType = CommandType.StoredProcedure;

                cmdAgregarZona.Parameters.AddWithValue("@departamento", zona.Departamento);
                cmdAgregarZona.Parameters.AddWithValue("@localidad", zona.Localidad);
                cmdAgregarZona.Parameters.AddWithValue("@nombre", zona.Nombre);
                cmdAgregarZona.Parameters.AddWithValue("@habitantes", zona.Habitantes);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarZona.Parameters.Add(valorRetorno);

                conexion.Open();
                transaccion = conexion.BeginTransaction();

                cmdAgregarZona.Transaction = transaccion;

                cmdAgregarZona.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1 -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al agregar la zona.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("La zona con el departamento " + zona.Departamento + " y la localidad " + zona.Localidad + " ya existe.");

                        break;
                }

                if (zona.Servicios != null)
                {
                    foreach (string s in zona.Servicios)
                    {
                        PersistenciaServicio.Agregar(zona.Departamento, zona.Localidad, s, transaccion);
                    }
                }

                transaccion.Commit();
            }
            catch (ExcepcionPersonalizada ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
        }

        public void Modificar(Zonas zona)
        {
            SqlConnection conexion = null;
            SqlTransaction transaccion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarZona = new SqlCommand("ModificarZona", conexion);
                cmdModificarZona.CommandType = CommandType.StoredProcedure;

                cmdModificarZona.Parameters.AddWithValue("@departamento", zona.Departamento);
                cmdModificarZona.Parameters.AddWithValue("@localidad", zona.Localidad);
                cmdModificarZona.Parameters.AddWithValue("@nombre", zona.Nombre);
                cmdModificarZona.Parameters.AddWithValue("@habitantes", zona.Habitantes);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarZona.Parameters.Add(valorRetorno);

                conexion.Open();
                transaccion = conexion.BeginTransaction();

                cmdModificarZona.Transaction = transaccion;

                cmdModificarZona.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Esta zona fue dada de baja.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("La zona con el departamento " + zona.Departamento + " y la localidad " + zona.Localidad + "no existe.");

                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al modificar la zona.");

                        break;
                }

                PersistenciaServicio.Eliminar(zona.Departamento, zona.Localidad, transaccion);

                foreach (string s in zona.Servicios)
                {
                    PersistenciaServicio.Agregar(zona.Departamento, zona.Localidad, s, transaccion);
                }

                transaccion.Commit();
            }
            catch (ExcepcionPersonalizada ex)
            {
                transaccion.Rollback();
                throw ex;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                throw new ExcepcionPersonalizada("Ocurrió un problema al acceder a la base de datos.", ex);
            }
        }

        public void Eliminar(Zonas zona)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarZona = new SqlCommand("EliminarZona", conexion);
                cmdEliminarZona.CommandType = CommandType.StoredProcedure;

                cmdEliminarZona.Parameters.AddWithValue("@departamento", zona.Departamento);
                cmdEliminarZona.Parameters.AddWithValue("@localidad", zona.Localidad);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarZona.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdEliminarZona.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al dar de baja la zona.");

                        break;
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un problema al eliminar la zona.");

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

        public List<Zonas> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drZona = null;
            List<Zonas> zonas = new List<Zonas>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarZonas = new SqlCommand("ListarZonas", conexion);
                cmdListarZonas.CommandType = CommandType.StoredProcedure;

                conexion.Open();
                drZona = cmdListarZonas.ExecuteReader();

                Zonas zona = null;

                if (drZona.HasRows)
                {
                    while (drZona.Read())
                    {
                        List<string> servicios = PersistenciaServicio.Listar((string)drZona["Departamento"], (string)drZona["Localidad"]);
                        zona = new Zonas((string)drZona["Departamento"], (string)drZona["Localidad"], (string)drZona["Nombre"], (int)drZona["Habitantes"], servicios);
                        zonas.Add(zona);
                    }
                }
                return zonas;
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
                if (drZona != null)
                {
                    drZona.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        //Singleton puro
        private static PersistenciaZona _instancia = null;

        private PersistenciaZona()
        { }

        public static PersistenciaZona GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaZona();
            }

            return _instancia;
        }
    }
}
