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
        public static Ciudad Buscar(string pCodC, string pCodP)
        {
            return PersistenciaCiudad.Buscar(pCodC, pCodP);
        }

        public static void AgregarCiudad(Ciudad pCiudad)
        {
            PersistenciaCiudad.AgregarCiudad(pCiudad);
        }

        public static void EliminarCiudad(Ciudad pCiudad)
        {
            PersistenciaCiudad.EliminarCiudad(pCiudad);
        }

        public static List<Ciudad> ListarCiudades()
        {
            return PersistenciaCiudad.ListarCiudades();
        }

        public static List<Ciudad> ListarCiudades(Pais pPais)
        {
            return PersistenciaCiudad.ListarCiudades(pPais);
        }

        public static void Modificar(Ciudad pCiudad)
        {
            PersistenciaCiudad.Modificar(pCiudad);
        }
    }
}
