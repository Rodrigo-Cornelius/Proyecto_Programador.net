using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Ciudad
    {
        #region Atributos
        Pais pais;
        string codigoC;
        string nombre;
        #endregion

        #region Propiedades
        public Pais Pais
        {
            get { return pais; }
            set
            {
                if (value == null)
                {
                    throw new Exception("Debe existir algun pais asociado");
                }
                pais = value;
            }
        }
        public string CodigoC
        {
            get { return codigoC; }
            set
            {
                if (value.Trim().Length != 3 || value.Trim().Any(char.IsDigit) || value.Trim().Contains(" ") || value.Trim() == "")
                {
                    throw new Exception("El codigo de ciudad debe tener tres letras");
                }
                codigoC = value.Trim();
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El nombre no puede estar vacio");
                }
                if (value.Trim().Length > 30)
                {
                    throw new Exception("El nombre no puede contener mas de 30 caracteres");
                }
                nombre = value.Trim();
            }
        }

        public string CodigoP
        {
            get { return pais.CodigoP; }
        }

        #endregion

        #region Constructor completo
        public Ciudad(Pais pPais, string pCodigoC, string pNombre)
        {
            Pais = pPais;
            CodigoC = pCodigoC;
            Nombre = pNombre;
        }
        #endregion

        #region Operaciones
        public override string ToString()
        {
            return ("Codigo pais: " + Pais.CodigoP + "Codigo ciudad: " + CodigoC + "\nNombre de la Ciudad: " + Nombre);
        }
        #endregion
    }
}
