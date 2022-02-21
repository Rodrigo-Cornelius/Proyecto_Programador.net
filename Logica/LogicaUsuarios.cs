using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaUsuarios
    {
        public static Usuario Buscar(string plogUser)
        {
            return PersistenciaUsuario.Buscar(plogUser);
        }

        public static Usuario Logueo (string pUserName, string pPass)
        {
            return PersistenciaUsuario.Logueo(pUserName, pPass);
        }

        public static void Agregar(Usuario pUsuario)
        {
            PersistenciaUsuario.Agregar(pUsuario);
        }

        public static void Eliminar(Usuario pUsuario)
        {
            PersistenciaUsuario.Eliminar(pUsuario);
        }

        public static void Modificar(Usuario pUsuario)
        {
            PersistenciaUsuario.Modificar(pUsuario);
        }



    }
}
