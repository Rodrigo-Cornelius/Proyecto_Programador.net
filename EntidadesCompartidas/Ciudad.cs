using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Ciudad
    {
        #region Atributos
        string codigoP;
        string codigoC;
        string nombre;
        #endregion

        #region Propiedades
        public string CodigoP
        {
            get { return codigoP; }
            set
            {
                if (value.Trim().Length != 3 || value.Trim().Any(char.IsDigit) || value.Trim().Contains(" ") || value.Trim() == "")
                {
                    throw new Exception("El codigo de pais debe tener tres letras");
                }
                codigoP = value.Trim();
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
        #endregion

        #region Constructor completo
        public Ciudad(string pCodigoP, string pCodigoC, string pNombre)
        {
            CodigoP = pCodigoP;
            CodigoC = pCodigoC;
            Nombre = pNombre;
        }
        #endregion

        #region Operaciones
        #endregion
    }
}
