using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EntidadesCompartidas;
using Persistencia;

namespace Logica
{
    public class LogicaPronosticos
    {
        public static int Agregar(Pronostico pPronostico)
        {
            return PersistenciaPronostico.Agregar(pPronostico);
        }

        public static List<Pronostico> ListarPronosticos(Ciudad pCiudad)
        {
            return PersistenciaPronostico.ListarPronosticos(pCiudad);
        }

        public static List<Pronostico> ListarPronosticos(DateTime pFecha)
        {
            return PersistenciaPronostico.ListarPronosticos(pFecha);
        }
        public static List<Pronostico> Buscar(Usuario pUsuario)
        {
            return PersistenciaPronostico.Buscar(pUsuario);
        }
    }
}
