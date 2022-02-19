using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntidadesCompartidas
{
    public class Usuario
    {
        #region Atributos
        string userName;
        string password;
        string nombre;
        string apellido;
        #endregion

        #region Propiedades
        public string UserName
        {
            get { return userName; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe escribir un nombre de usuario");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre de usuario no puede exceder los 30 caracteres");
                else if (value.Trim().Length <= 3)
                {
                    throw new Exception("El nombre de usuario debe tener al menos 3 caracteres");
                }
                userName = value.Trim();
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe escribir una contraseña");
                else if (value.Trim().Length > 30)
                    throw new Exception("La contraseña no puede exceder los 30 caracteres");
                else if (value.Trim().Length < 8)
                {
                    throw new Exception("La contraseña debe tener al menos 8 caracteres");
                }
                password = value.Trim();
            }
        }
        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe escribir un nombre");
                else if (value.Trim().Length > 30)
                    throw new Exception("El nombre no puede exceder los 30 caracteres");
                nombre = value.Trim();
            }
        }
        public string Apellido
        {
            get { return apellido; }
            set
            {
                if (value.Trim() == "")
                    throw new Exception("Debe escribir un apellido");
                else if (value.Trim().Length > 30)
                    throw new Exception("El apellido no puede exceder los 30 caracteres");
                apellido = value.Trim();
            }
        }
        #endregion

        #region Constructor completo
        public Usuario(string pUserName, string pPassword, string pNombre, string pApellido)
        {
            UserName = pUserName;
            Password = pPassword;
            Nombre = pNombre;
            Apellido = pApellido;
        }
        #endregion

        #region Operaciones

        public override string ToString()
        {
            return ("Nombre de Usuario: " + userName + "\tNombre: " + nombre + "\tApellido: " + apellido);
        }

        #endregion
    }
}
