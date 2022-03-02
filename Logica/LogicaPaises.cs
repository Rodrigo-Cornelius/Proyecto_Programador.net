using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPaises
    {
        public static Pais Buscar(string pCodP)
        {
            return PersistenciaPais.Buscar(pCodP);
        }

        public static void AgregarPais(Pais pPais)
        {
            PersistenciaPais.AgregarPais(pPais);
        }

        public static void EliminarPais(Pais pPais)
        {
            PersistenciaPais.EliminarPais(pPais);
        }

        public static void ModificarPais(Pais pPais)
        {
            PersistenciaPais.ModificarPais(pPais);
        }

        public static List<Pais> ListarPaises()
        {
            return PersistenciaPais.ListarPaises();
        }
    }
}
