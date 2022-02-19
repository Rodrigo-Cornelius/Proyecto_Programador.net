using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;


namespace Persistencia
{
    public class PersistenciaUsuario
    {
        public static Usuario Buscar(string pUserName)
        {
            string password, nombre, apellido;

            Usuario resUsuario = null;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@username", pUserName);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        password = (string)oReader["pass"];
                        nombre = (string)oReader["nombre"];
                        apellido = (string)oReader["apellido"];

                        resUsuario = new Usuario(pUserName, password, nombre, apellido);
                    }

                }
                oReader.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resUsuario;
        }

        public static void Agregar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@UserName", pUsuario.UserName);
            oComando.Parameters.AddWithValue("@Pass", pUsuario.Password);
            oComando.Parameters.AddWithValue("@Nom", pUsuario.Nombre);
            oComando.Parameters.AddWithValue("@Ape", pUsuario.Apellido);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("No existe un Usuario que tenga ese codigo");
                }
                if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error inesperado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Eliminar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BajaUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@UserName", pUsuario.UserName);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("No existe un Usuario que tenga ese codigo");
                }
                if (resultado == -2)
                {
                    throw new Exception("El usuario tiene pronosticos asociados, no se puede eliminar");
                }
                if (resultado == -3)
                {
                    throw new Exception("Ocurrio un error inesperado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static void Modificar(Usuario pUsuario)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarUsuario", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@UserName", pUsuario.UserName);
            oComando.Parameters.AddWithValue("@Pass", pUsuario.Password);
            oComando.Parameters.AddWithValue("@Nom", pUsuario.Nombre);
            oComando.Parameters.AddWithValue("@Ape", pUsuario.Apellido);

            SqlParameter oRetorno = new SqlParameter("@Retorno", SqlDbType.Int);
            oRetorno.Direction = ParameterDirection.ReturnValue;
            oComando.Parameters.Add(oRetorno);

            try
            {
                oConexion.Open();
                oComando.ExecuteNonQuery();

                int resultado = Convert.ToInt32(oComando.Parameters["@Retorno"].Value);

                if (resultado == -1)
                {
                    throw new Exception("No existe un Usuario que tenga ese codigo");
                }                
                if (resultado == -2)
                {
                    throw new Exception("Ocurrio un error inesperado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
        }

        public static Usuario Logueo(string pUserName, string pPass)
        {
            string nombre, apellido;

            Usuario resUsuario = null;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("logueo", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@nom", pUserName);
            oComando.Parameters.AddWithValue("@pass", pPass);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombre"];
                        apellido = (string)oReader["apellido"];

                        resUsuario = new Usuario(pUserName, pPass, nombre, apellido);
                    }

                }
                oReader.Close();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            finally
            {
                oConexion.Close();
            }
            return resUsuario;
        }

        
    }
}
