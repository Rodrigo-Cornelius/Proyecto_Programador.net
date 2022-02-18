using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PercistenciaPronostico
    {
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
            oComando.Parameters.AddWithValue("@UserName", pPronostico.Usuario);

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
            float maxTemp, minTemp;
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

                        ciudad = PersistenciaCiudad.Buscar(pCiudad.CodigoC);
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


    }
}
