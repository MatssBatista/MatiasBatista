using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaLocalComercial : InterfacePersistenciaLocalComercial
    {
        public LocalComercial Buscar(int padron)
        {
            SqlConnection conexion = null;
            SqlDataReader drLocal = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarLocal = new SqlCommand("BuscarLocalComercial", conexion);
                cmdBuscarLocal.CommandType = CommandType.StoredProcedure;

                cmdBuscarLocal.Parameters.AddWithValue("@padron", padron);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarLocal.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdBuscarLocal.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un error al buscar la propiedad.");
                        break;
                }

                drLocal = cmdBuscarLocal.ExecuteReader();

                LocalComercial local = null;

                if (drLocal.HasRows)
                {
                    drLocal.Read();
                    InterfacePersistenciaEmpleado interEmpleado = PersistenciaEmpleado.GetInstancia();
                    Empleado empleado = interEmpleado.Buscar((string)drLocal["Empleado"]);

                    InterfacePersistenciaZona interZona = PersistenciaZona.GetInstancia();
                    Zonas zona = interZona.Buscar((string)drLocal["Departamento"], (string)drLocal["Localidad"]);

                    local = new LocalComercial((int)drLocal["Padron"], (string)drLocal["Direccion"], (int)drLocal["Precio"], (string)drLocal["Accion"],
                                               (int)drLocal["Baños"], (int)drLocal["Habitaciones"], (double)drLocal["Area"], (bool)drLocal["Habilitacion"], empleado, zona);
                }

                return local;
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
                if (drLocal != null)
                {
                    drLocal.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Agregar(LocalComercial local)
        {
            SqlConnection conexion = null;            
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarLocal = new SqlCommand("AgregarLocalComercial", conexion);
                cmdAgregarLocal.CommandType = CommandType.StoredProcedure;

                cmdAgregarLocal.Parameters.AddWithValue("@padron", local.Padron);
                cmdAgregarLocal.Parameters.AddWithValue("@precio",local.Precio);
                cmdAgregarLocal.Parameters.AddWithValue("@direccion", local.Direccion);
                cmdAgregarLocal.Parameters.AddWithValue("@baños", local.Baños);
                cmdAgregarLocal.Parameters.AddWithValue("@habitaciones", local.Habitaciones);
                cmdAgregarLocal.Parameters.AddWithValue("@area", local.Tamaño);
                cmdAgregarLocal.Parameters.AddWithValue("@accion", local.Accion);
                cmdAgregarLocal.Parameters.AddWithValue("@departamento", local.UnaZona.Departamento);
                cmdAgregarLocal.Parameters.AddWithValue("@localidad", local.UnaZona.Localidad);
                cmdAgregarLocal.Parameters.AddWithValue("@empleado", local.UnEmpleado.NombreLogueo);
                cmdAgregarLocal.Parameters.AddWithValue("@habilitacion", local.Habilitacion);      
      
                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarLocal.Parameters.Add(valorRetorno);

                conexion.Open();              
                cmdAgregarLocal.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("El empleado no existe");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("La zona no existe");
                        break;

                    case  -3:
                        throw new ExcepcionPersonalizada("La propiedad ya existe");
                        break;

                    case  -4 -5:
                        throw new ExcepcionPersonalizada("Error al intentar agregar la propiedad");
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

        public void Eliminar(LocalComercial Local)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarLocal = new SqlCommand("EliminarLocalComercial", conexion);
                cmdEliminarLocal.CommandType = CommandType.StoredProcedure;

                cmdEliminarLocal.Parameters.AddWithValue("@padron", Local.Padron);
                

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarLocal.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdEliminarLocal.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Problemas al intentar borrar las visitas");
                        break; 

                    case -2 -3:
                        throw new ExcepcionPersonalizada("Problemas al intentar eliminar la propiedad.");

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

        public void Modificar(LocalComercial local)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarLocal = new SqlCommand("ModificarLocalComercial", conexion);
                cmdModificarLocal.CommandType = CommandType.StoredProcedure;

                cmdModificarLocal.Parameters.AddWithValue("@padron", local.Padron);
                cmdModificarLocal.Parameters.AddWithValue("@precio", local.Precio);
                cmdModificarLocal.Parameters.AddWithValue("@direccion", local.Direccion);
                cmdModificarLocal.Parameters.AddWithValue("@baños", local.Baños);
                cmdModificarLocal.Parameters.AddWithValue("@habitaciones", local.Habitaciones);
                cmdModificarLocal.Parameters.AddWithValue("@area", local.Tamaño);
                cmdModificarLocal.Parameters.AddWithValue("@accion", local.Accion);
                cmdModificarLocal.Parameters.AddWithValue("@departamento", local.UnaZona.Departamento);
                cmdModificarLocal.Parameters.AddWithValue("@localidad", local.UnaZona.Localidad);
                cmdModificarLocal.Parameters.AddWithValue("@empleado", local.UnEmpleado.NombreLogueo);
                cmdModificarLocal.Parameters.AddWithValue("@habilitacion", local.Habilitacion);

                 SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarLocal.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdModificarLocal.ExecuteNonQuery();

               switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Error al intentar modificar el usuario: " + local.UnEmpleado.NombreLogueo);
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("La zona no existe");
                        break;

                    case  -3:
                        throw new ExcepcionPersonalizada("La propiedad ya existe");
                        break;

                    case  -4 -5:
                        throw new ExcepcionPersonalizada("Error al intentar modificar la propiedad");
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

        public List<LocalComercial> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drLocal = null;
            List<LocalComercial> lista = new List<LocalComercial>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarLocal = new SqlCommand("ListarLocalComercial", conexion);
                cmdListarLocal.CommandType = CommandType.StoredProcedure;

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdListarLocal.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdListarLocal.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("Ocurrio un problema al listar.");
                }

                drLocal = cmdListarLocal.ExecuteReader();

                LocalComercial Local = null;
                if (drLocal.HasRows)
                {
                    while (drLocal.Read())
                    {
                        InterfacePersistenciaEmpleado interEmpleado = PersistenciaEmpleado.GetInstancia();
                        Empleado empleado = interEmpleado.Buscar((string)drLocal["Empleado"]);

                        InterfacePersistenciaZona interZona = PersistenciaZona.GetInstancia();
                        Zonas zona = interZona.Buscar((string)drLocal["Departamento"], (string)drLocal["Localidad"]);

                        Local = new LocalComercial((int)drLocal["Padron"], (string)drLocal["Direccion"], (int)drLocal["Precio"], (string)drLocal["Accion"],
                                                   (int)drLocal["Baños"], (int)drLocal["Habitaciones"], (double)drLocal["Area"], (bool)drLocal["Habilitacion"], empleado, zona);
                        lista.Add(Local);
                    }
                }
                return lista;
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
                if (drLocal != null)
                {
                    drLocal.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

         //Singleton puro
        private static PersistenciaLocalComercial _instancia = null;

        private PersistenciaLocalComercial()
        { }

        public static PersistenciaLocalComercial GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaLocalComercial();
            }

            return _instancia;
        }
    }
}
