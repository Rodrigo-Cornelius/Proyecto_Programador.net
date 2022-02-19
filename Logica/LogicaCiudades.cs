using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;


namespace Logica
{
    public class LogicaCiudades
    {
        public static Ciudad Buscar(string pCodC)
        {
            return PersistenciaCiudad.Buscar(pCodC);
        }

        public static void AgregarCiudad(Ciudad pCiudad)
        {
            PersistenciaCiudad.AgregarCiudad(pCiudad);
        }

        public static void EliminarCiudad(Ciudad pCiudad)
        {
            PersistenciaCiudad.EliminarCiudad(pCiudad);
        }

        public static List<Ciudad> ListarCiudades(Pais pPais)
        {
            return PersistenciaCiudad.ListarCiudades(pPais);
        }
    }
}
