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
    public class  LogicaEstadoCivil
    {
        private AccesoSQL operaciones = null;

        public LogicaEstadoCivil(string cadconex)
        {
            operaciones = new AccesoSQL(cadconex);
        }

        public List<EntidadEstadoCivil> informacionEstadoCivil(ref string mensaje)
        {
            string consulta = "select idEstadoCivil, Estado from EstadoCivil";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            List<EntidadEstadoCivil> misobjs = new List<EntidadEstadoCivil>();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.Add(
                        new EntidadEstadoCivil
                        {
                            idEstadoCivil = (int)contenedor[0],
                            Estado = (string)contenedor[1]
                        }
                        );
                }
            }
            return misobjs;
        }

        public DataTable ObtenerEstadoCivil(ref string mensaje)
        {
            string consulta = "SELECT idEstadoCivil, Estado from EstadoCivil;";

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
