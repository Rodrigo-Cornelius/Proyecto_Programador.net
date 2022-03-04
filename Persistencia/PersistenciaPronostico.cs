using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPronostico
    {
        public static List<Pronostico> Buscar(Usuario pUserName)
        {
            List<Pronostico> resPronos = new List<Pronostico>();
            string tipoCielo;
            int probLluvias, codigo, velViento;
            int maxTemp, minTemp;
            DateTime fechaHora;
            Ciudad ciudad;

            Pronostico oProno = null;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarUsuProno", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@UserName", pUserName.UserName);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        codigo = (int)oReader["codigo"];
                        probLluvias = (int)oReader["probLluvias"];
                        fechaHora = Convert.ToDateTime(oReader["fechaHora"]);
                        tipoCielo = (string)oReader["tipoCielo"];
                        velViento = (int)oReader["velViento"];
                        maxTemp = (int)oReader["maxTemp"];
                        minTemp = (int)oReader["minTemp"];
                        ciudad = PersistenciaCiudad.Buscar((string)oReader["codigoC"], (string)oReader["codigoP"]);

                        oProno = new Pronostico(codigo, maxTemp, minTemp, velViento, tipoCielo, fechaHora, probLluvias, ciudad, pUserName);
                        resPronos.Add(oProno);
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
            return resPronos;
        }

        public static List<Pronostico> Buscar(Ciudad pCiudad)
        {
            List<Pronostico> resPronos = new List<Pronostico>();
            string tipoCielo, userName;
            int probLluvias, codigo, velViento;
            int maxTemp, minTemp;
            DateTime fechaHora;
            Usuario user;

            Pronostico oProno = null;

            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ListadoPronosticosXCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodC", pCiudad.CodigoC);
            oComando.Parameters.AddWithValue("@CodP", pCiudad.CodigoP);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        codigo = (int)oReader["codigo"];
                        probLluvias = (int)oReader["probLluvias"];
                        fechaHora = Convert.ToDateTime(oReader["fechaHora"]);
                        tipoCielo = (string)oReader["tipoCielo"];
                        velViento = (int)oReader["velViento"];
                        maxTemp = (int)oReader["maxTemp"];
                        minTemp = (int)oReader["minTemp"];
                        userName = (string)oReader["userName"];
                        user = PersistenciaUsuario.Buscar(userName);
                        

                        oProno = new Pronostico(codigo, maxTemp, minTemp, velViento, tipoCielo, fechaHora, probLluvias, pCiudad, user);
                        resPronos.Add(oProno);
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
            return resPronos;
        }

        public static int Agregar(Pronostico pPronostico)
        {
            int codPeri;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaPronostico", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Lluvias", pPronostico.ProbLluvias);
            oComando.Parameters.AddWithValue("@FechaHora", pPronostico.FechaHora);
            oComando.Parameters.AddWithValue("@TipoCielo", pPronostico.TipoCielo);
            oComando.Parameters.AddWithValue("@VelViento", pPronostico.VelViento);
            oComando.Parameters.AddWithValue("@MaxTemp", pPronostico.MaxTemp);
            oComando.Parameters.AddWithValue("@MinTemp", pPronostico.MinTemp);
            oComando.Parameters.AddWithValue("@CodC", pPronostico.Ciudad.CodigoC);
            oComando.Parameters.AddWithValue("@CodP", pPronostico.Ciudad.CodigoP);
            oComando.Parameters.AddWithValue("@UserName", pPronostico.Usuario.UserName);

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
                    throw new Exception("No se puede crear un pronostico para una ciudad en una misma fecha y hora");
                }
                else if (resultado == -2)
                {
                    throw new Exception("Occurrio un error inesperado");
                }
                else
                {
                    codPeri = resultado;
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
            return codPeri;
        }

        public static List<Pronostico> ListarPronosticos(Ciudad pCiudad)
        {
            List<Pronostico> resPronosticos = new List<Pronostico>();
            int codigo;
            int maxTemp, minTemp;
            int velViento, probLluvias;
            string tipoCielo, userName;
            DateTime fechaHora;
            Ciudad ciudad;
            Usuario usuario;



            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("ListadoPronosticosXCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@codC", pCiudad.CodigoC);
            oComando.Parameters.AddWithValue("@codP", pCiudad.CodigoP);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        codigo = Convert.ToInt32(oReader["codigo"]);
                        maxTemp = Convert.ToInt32(oReader["maxTemp"]);
                        minTemp = Convert.ToInt32(oReader["minTemp"]);
                        velViento = Convert.ToInt32(oReader["velViento"]);
                        probLluvias = Convert.ToInt32(oReader["probLluvias"]);
                        tipoCielo = Convert.ToString(oReader["tipoCielo"]);
                        userName = Convert.ToString(oReader["userName"]);
                        fechaHora = Convert.ToDateTime(oReader["fechaHora"]);

                        ciudad = PersistenciaCiudad.Buscar(pCiudad.CodigoC,pCiudad.CodigoP);
                        usuario = PersistenciaUsuario.Buscar(userName);

                        Pronostico oPronostico = new Pronostico(codigo, maxTemp, minTemp, velViento, tipoCielo, fechaHora, probLluvias, ciudad, usuario);
                        resPronosticos.Add(oPronostico);
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
            return resPronosticos;
        }

        public static List<Pronostico> ListarPronosticos(DateTime pDateTime)
        {
            List<Pronostico> resPronosticos = new List<Pronostico>();
            int codigo;
            int maxTemp, minTemp;
            int velViento, probLluvias;
            string tipoCielo, userName, codigoC, codigoP;
            Ciudad ciudad;
            Usuario usuario;
            DateTime resultDateTime;



            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("ListadoPronosticoXFecha", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@Fecha", pDateTime);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {

                        codigo = Convert.ToInt32(oReader["codigo"]);
                        maxTemp = Convert.ToInt32(oReader["maxTemp"]);
                        minTemp = Convert.ToInt32(oReader["minTemp"]);
                        velViento = Convert.ToInt32(oReader["velViento"]);
                        probLluvias = Convert.ToInt32(oReader["probLluvias"]);
                        tipoCielo = Convert.ToString(oReader["tipoCielo"]);
                        userName = Convert.ToString(oReader["userName"]);
                        codigoC = Convert.ToString(oReader["codigoC"]);
                        codigoP = Convert.ToString(oReader["codigoP"]);
                        resultDateTime = Convert.ToDateTime(oReader["fechaHora"]);

                        ciudad = PersistenciaCiudad.Buscar(codigoC, codigoP);
                        usuario = PersistenciaUsuario.Buscar(userName);

                        Pronostico oPronostico = new Pronostico(codigo, maxTemp, minTemp, velViento, tipoCielo, resultDateTime, probLluvias, ciudad, usuario);
                        resPronosticos.Add(oPronostico);
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
            return resPronosticos;
        }

    }
}
