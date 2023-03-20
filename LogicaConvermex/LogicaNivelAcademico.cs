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
    public class LogicaNivelAcademico
    {
        private AccesoSQL operaciones = null;

        public LogicaNivelAcademico(string cadconex)
        {
            operaciones = new AccesoSQL(cadconex);
        }

        public List<EntidadNivelAcademico> informacionNivelAca(ref string mensaje)
        {
            string consulta = "select idNivelAcademico, Nivel from NivelAcademico";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            List<EntidadNivelAcademico> misobjs = new List<EntidadNivelAcademico>();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.Add(
                        new EntidadNivelAcademico
                        {
                            idNivelAcademico = (int)contenedor[0],
                            Nivel = (string)contenedor[1]
                        }
                        );
                }
            }
            return misobjs;
        }

        public DataTable ObtenerNivelAcademico(ref string mensaje)
        {
            string consulta = "SELECT idNivelAcademico, Nivel from NivelAcademico;";

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
