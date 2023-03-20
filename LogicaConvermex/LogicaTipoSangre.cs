using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;
using System.Data;
using System.Data.SqlClient;
using EntidadesConvermex;

namespace LogicaConvermex
{
    public class LogicaTipoSangre
    {
        private AccesoSQL operaciones = null;

        public LogicaTipoSangre(string cadconex)
        {
            operaciones = new AccesoSQL(cadconex);
        }

        public List<EntidadTipoSangre> informacionTipoSangre(ref string mensaje)
        {
            string consulta = "select idTipoSangre, Tipos from TipoSangre";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            List<EntidadTipoSangre> misobjs = new List<EntidadTipoSangre>();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.Add(
                        new EntidadTipoSangre
                        {
                            idTipoSangre = (int)contenedor[0],
                            Tipos = (string)contenedor[1]
                        }
                        );
                }
            }
            return misobjs;
        }

        public DataTable ObtenerTipoSangre(ref string mensaje)
        {
            string consulta = "select idTipoSangre, Tipos from TipoSangre;";

            DataTable salidaDT = null;
            DataSet contenedorDS = null;

            contenedorDS = operaciones.ConsultaDS(consulta, operaciones.abrirConexion(ref mensaje), ref mensaje);


            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }
    }
}
