using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Pronostico
    {
        #region Atributos
        int codigo;
        float maxTemp;
        float minTemp;
        int velViento;
        string tipoCielo;
        DateTime fechaHora;
        int probLluvias;
        Ciudad ciudad;
        Usuario usuario;
        #endregion

        #region Propiedades
        public int Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }
        public float MaxTemp
        {
            get { return maxTemp; }
            set { maxTemp = value; }
               
        }
        public float MinTemp
        {
            get { return minTemp; }
            set { minTemp = value; }

        }
        public int VelViento
        {
            get { return velViento; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("La velocidad del viento debe ser mayor a 0");
                }
                velViento = value;
            }
        }
        public string TipoCielo
        {
            get { return tipoCielo; }
            set
            {
                string[] datosPosibles = { "despejado", "parcialmente nuboso", "nuboso" };
                if (Array.IndexOf(datosPosibles, value.ToLower().Trim()) == -1)
                {
                    throw new Exception("Los valores para tipo de cielo solo pueden ser: despejado, parcialmente nuboso o nuboso");
                }
                tipoCielo = value.ToLower().Trim();
            }
        }
        public DateTime FechaHora
        {
            get { return fechaHora; }
            set
            {
                if (DateTime.Compare(value, DateTime.Today) <= 0)
                {
                    throw new Exception("El pronostico debe ser realizado para una fecha y hora mayor a la actual");
                }
                fechaHora = value;
            }
        }
        public int ProbLluvias
        {
            get { return probLluvias; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new Exception("La probabilidad de lluvias y tormentas no puede ser menor a 0% ni mayor a 100%");
                }
                probLluvias = value;
            }
        }
        public Ciudad Ciudad
        {
            get { return ciudad; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El pronostico debe tener una Ciudad asociada");
                }
                ciudad = value;
            }
        }
        public Usuario Usuario
        {
            get { return usuario; }
            set
            {
                if (value == null)
                {
                    throw new Exception("El pronostico debe tener un usuario asociado");
                }
                usuario = value;
            }
        }
        #endregion

        #region Constructor Completo
        public Pronostico(int pCodigo, float pMaxTemp, float pMinTemp, int pVelViento, string pTipoCielo, DateTime pFechaHora, int pProbLluvias, Ciudad pCiudad, Usuario pUsuario)
        {
            if (pMaxTemp <= pMinTemp)
            {
                throw new Exception("La temperatura maxima no puede ser menor o igual a la temperatura minima");
            }
            Codigo = pCodigo;
            MaxTemp = pMaxTemp;
            MinTemp = pMinTemp;
            VelViento = pVelViento;
            TipoCielo = pTipoCielo;
            FechaHora = pFechaHora;
            ProbLluvias = pProbLluvias;
            Ciudad = pCiudad;
            Usuario = pUsuario;
        }
        #endregion

        #region Operaciones
        public override string ToString()
        {
            return ("Codigo: " + Codigo + "\nTemperatura Maxima: " + MaxTemp + "°" + "\nTemperatura Minima: " + MinTemp + "°" +
                "\nVelocidad del Viento: " + VelViento + "hPa" + "\nTipo de Cielo: " + TipoCielo +
                "\nFecha y hora: " + FechaHora + "\nProbabilidad de Lluvias: " + "%" + ProbLluvias + "\nCiudad: " + Ciudad.Nombre + "\nUsuario que lo ingresa: " + Usuario.UserName);
        }
        #endregion
    }
}
