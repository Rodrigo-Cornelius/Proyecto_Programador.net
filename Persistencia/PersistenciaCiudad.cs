using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaCiudad
    {
        public static Ciudad Buscar(string pCodC, string pCodP)
        {
            string nombre;
            Ciudad resCiudad = null;
            
            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BuscarCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@codC", pCodC);
            oComando.Parameters.AddWithValue("@codP", pCodP);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    if (oReader.Read())
                    {
                        nombre = (string)oReader["nombre"];
                        
                        resCiudad = new Ciudad(pCodP, pCodC, nombre);
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
            return resCiudad;
        }

        public static void AgregarCiudad(Ciudad pCiudad)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodP", pCiudad.CodigoP);
            oComando.Parameters.AddWithValue("@CodC", pCiudad.CodigoC);
            oComando.Parameters.AddWithValue("@Nom", pCiudad.Nombre);

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
                    throw new Exception("No existe un Pais que tenga ese codigo");
                }
                if (resultado == -2)
                {
                    throw new Exception("Ya existe una ciudad que tiene ese codigo");
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

        public static void EliminarCiudad(Ciudad pCiudad)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BajaCiudad", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@CodC", pCiudad.CodigoC);

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
                    throw new Exception("No existe una ciudad que tenga ese codigo");
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

        public static List<Ciudad> ListarCiudades(Pais pPais)
        {
            List<Ciudad> resCiudad = new List<Ciudad>();
            string codigoP, codigoC, nombre;


            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("ListadoCiudadesXPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;
            oComando.Parameters.AddWithValue("@CodP", pPais.CodigoP);

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoC = Convert.ToString(oReader["CodigoC"]);
                        nombre = Convert.ToString(oReader["Nombre"]);
                        codigoP = Convert.ToString(oReader["CodigoP"]);

                        Ciudad pCiudad = new Ciudad(codigoP, codigoC, nombre);

                        resCiudad.Add(pCiudad);
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
            return resCiudad;
        }
    }
}
