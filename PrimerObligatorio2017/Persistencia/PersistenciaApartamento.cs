using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesCompartidas;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PersistenciaApartamento : InterfacePersistenciaApartamento
    {
        public Apartamento Buscar(int padron)
        
        {
            SqlConnection conexion = null;
            SqlDataReader drApto = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdBuscarApto = new SqlCommand("BuscarApartamento", conexion);
                cmdBuscarApto.CommandType = CommandType.StoredProcedure;

                cmdBuscarApto.Parameters.AddWithValue("@padron", padron);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdBuscarApto.Parameters.Add(valorRetorno);

                conexion.Open();

                cmdBuscarApto.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -2:
                        throw new ExcepcionPersonalizada("Ocurrio un error al buscar la propiedad.");
                        break;
                }

                drApto = cmdBuscarApto.ExecuteReader();

                Apartamento apto = null;

                if (drApto.HasRows)
                {
                    drApto.Read();
                    InterfacePersistenciaEmpleado interEmpleado = PersistenciaEmpleado.GetInstancia();
                    Empleado empleado = interEmpleado.Buscar((string)drApto["Empleado"]);

                    InterfacePersistenciaZona interZona = PersistenciaZona.GetInstancia();
                    Zonas zona = interZona.Buscar((string)drApto["Departamento"], (string)drApto["Localidad"]);

                    apto = new Apartamento((int)drApto["Padron"], (string)drApto["Direccion"], (int)drApto["Precio"], (string)drApto["Accion"],
                                               (int)drApto["Baños"], (int)drApto["Habitaciones"], (double)drApto["Area"], (int)drApto["Piso"], (bool)drApto["Ascensor"], empleado, zona);
                }

                return apto;
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
                if (drApto != null)
                {
                    drApto.Close();
                }

                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        public void Agregar(Apartamento unApto)
        {
            SqlConnection conexion = null;
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdAgregarApto= new SqlCommand("AgregarApartamento", conexion);
                cmdAgregarApto.CommandType = CommandType.StoredProcedure;

                cmdAgregarApto.Parameters.AddWithValue("@padron", unApto.Padron);
                cmdAgregarApto.Parameters.AddWithValue("@precio", unApto.Precio);
                cmdAgregarApto.Parameters.AddWithValue("@direccion", unApto.Direccion);
                cmdAgregarApto.Parameters.AddWithValue("@baños", unApto.Baños);
                cmdAgregarApto.Parameters.AddWithValue("@habitaciones", unApto.Habitaciones);
                cmdAgregarApto.Parameters.AddWithValue("@area", unApto.Tamaño);
                cmdAgregarApto.Parameters.AddWithValue("@accion", unApto.Accion);
                cmdAgregarApto.Parameters.AddWithValue("@departamento", unApto.UnaZona.Departamento);
                cmdAgregarApto.Parameters.AddWithValue("@localidad", unApto.UnaZona.Localidad);
                cmdAgregarApto.Parameters.AddWithValue("@empleado", unApto.UnEmpleado.NombreLogueo); 
                cmdAgregarApto.Parameters.AddWithValue("@piso", unApto.Piso);
                cmdAgregarApto.Parameters.AddWithValue("@ascensor", unApto.Ascensor);

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdAgregarApto.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdAgregarApto.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("El empleado no existe");
                        break;

                    case -2:
                        throw new ExcepcionPersonalizada("La zona no existe");
                        break;

                    case -3:
                        throw new ExcepcionPersonalizada("La propiedad ya existe");
                        break;

                    case -4 - 5:
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

        public void Eliminar(Apartamento unApto)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdEliminarApto = new SqlCommand("EliminarApartamento", conexion);
                cmdEliminarApto.CommandType = CommandType.StoredProcedure;

                cmdEliminarApto.Parameters.AddWithValue("@padron", unApto.Padron);


                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdEliminarApto.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdEliminarApto.ExecuteNonQuery();

                switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Problemas al intentar borrar las visitas");
                        break;

                    case -2 - 3:
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

        public void Modificar(Apartamento unApto)
        {
            SqlConnection conexion = null;

            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdModificarApto = new SqlCommand("ModificarApartamento", conexion);
                cmdModificarApto.CommandType = CommandType.StoredProcedure;

                cmdModificarApto.Parameters.AddWithValue("@padron", unApto.Padron);
                cmdModificarApto.Parameters.AddWithValue("@precio", unApto.Precio);
                cmdModificarApto.Parameters.AddWithValue("@direccion", unApto.Direccion);
                cmdModificarApto.Parameters.AddWithValue("@baños", unApto.Baños);
                cmdModificarApto.Parameters.AddWithValue("@habitaciones", unApto.Habitaciones);
                cmdModificarApto.Parameters.AddWithValue("@area", unApto.Tamaño);
                cmdModificarApto.Parameters.AddWithValue("@accion", unApto.Accion);
                cmdModificarApto.Parameters.AddWithValue("@departamento", unApto.UnaZona.Departamento);
                cmdModificarApto.Parameters.AddWithValue("@localidad", unApto.UnaZona.Localidad);
                cmdModificarApto.Parameters.AddWithValue("@empleado", unApto.UnEmpleado.NombreLogueo);
                cmdModificarApto.Parameters.AddWithValue("@piso", unApto.Piso);
                cmdModificarApto.Parameters.AddWithValue("@ascensor", unApto.Ascensor);

                 SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdModificarApto.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdModificarApto.ExecuteNonQuery();

               switch ((int)valorRetorno.Value)
                {
                    case -1:
                        throw new ExcepcionPersonalizada("Error al intentar modificar el usuario: " + unApto.UnEmpleado.NombreLogueo);
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

        public List<Apartamento> Listar()
        {
            SqlConnection conexion = null;
            SqlDataReader drApto = null;
            List<Apartamento> lista = new List<Apartamento>();
            try
            {
                conexion = new SqlConnection(Conexion.CadenaConexion);

                SqlCommand cmdListarApto= new SqlCommand("ListarApartamento", conexion);
                cmdListarApto.CommandType = CommandType.StoredProcedure;

                SqlParameter valorRetorno = new SqlParameter("@valorRetorno", SqlDbType.Int);
                valorRetorno.Direction = ParameterDirection.ReturnValue;
                cmdListarApto.Parameters.Add(valorRetorno);

                conexion.Open();
                cmdListarApto.ExecuteNonQuery();

                if ((int)valorRetorno.Value == -1)
                {
                    throw new ExcepcionPersonalizada("Ocurrio un problema al listar.");
                }

                drApto = cmdListarApto.ExecuteReader();

                Apartamento unApto = null;
                if (drApto.HasRows)
                {
                    while (drApto.Read())
                    {
                        InterfacePersistenciaEmpleado interEmpleado = PersistenciaEmpleado.GetInstancia();
                        Empleado empleado = interEmpleado.Buscar((string)drApto["Empleado"]);

                        InterfacePersistenciaZona interZona = PersistenciaZona.GetInstancia();
                        Zonas zona = interZona.Buscar((string)drApto["Departamento"], (string)drApto["Localidad"]);

                        unApto = new Apartamento((int)drApto["Padron"], (string)drApto["Direccion"], (int)drApto["Precio"], (string)drApto["Accion"],
                                                   (int)drApto["Baños"], (int)drApto["Habitaciones"], (double)drApto["Area"], (int)drApto["Piso"], (bool)drApto["Ascensor"], empleado, zona);
                        lista.Add(unApto);
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
                if (drApto != null)
                {
                    drApto.Close();
                }
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
        }

        //Singleton puro
        private static PersistenciaApartamento _instancia = null;

        private PersistenciaApartamento()
        { }

        public static PersistenciaApartamento GetInstancia()
        {
            if (_instancia == null)
            {
                _instancia = new PersistenciaApartamento();
            }

            return _instancia;
        }
    }
}
