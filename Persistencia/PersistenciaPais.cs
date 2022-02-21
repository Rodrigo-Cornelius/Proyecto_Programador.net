using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using EntidadesCompartidas;

namespace Persistencia
{
    public class PersistenciaPais
    {
        public static void AgregarPais(Pais pPais)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("AltaPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cod", pPais.CodigoP);
            oComando.Parameters.AddWithValue("@Nom", pPais.Nombre);

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
                    throw new Exception("Ya existe un Pais con ese codigo");
                }
                if (resultado == -2)
                {
                    throw new Exception("Occurrio un error inesperado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message); throw;
            }
            finally
            {
                oConexion.Close();
            }

        }

        public static void EliminarPais(Pais pPais)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("BajaPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cod", pPais.CodigoP);

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
                    throw new Exception("No se pudo eliminar, el Pais tiene un pronostico asociado");
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

        public static void ModificarPais(Pais pPais)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.STR);
            SqlCommand oComando = new SqlCommand("ModificarPais", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            oComando.Parameters.AddWithValue("@Cod", pPais.CodigoP);
            oComando.Parameters.AddWithValue("@Nom", pPais.Nombre);

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

        public static List<Pais> ListarPaises()
        {
            List<Pais> resPais = new List<Pais>();
            string codigoP, nombre;


            SqlDataReader oReader;

            SqlConnection oConexion = new SqlConnection(Conexion.STR);

            SqlCommand oComando = new SqlCommand("ListadoPaises", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            try
            {
                oConexion.Open();
                oReader = oComando.ExecuteReader();

                if (oReader.HasRows)
                {
                    while (oReader.Read())
                    {
                        codigoP = Convert.ToString(oReader["CodigoP"]);
                        nombre = Convert.ToString(oReader["Nombre"]);

                        Pais pPais = new Pais(codigoP, nombre);

                        resPais.Add(pPais);
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
            return resPais;
        }

    }
}
