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
    public class LogicaTrabajadorInner
    {
        private AccesoSQL operaciones = null;

        public LogicaTrabajadorInner(string cadconex)
        {
            operaciones = new AccesoSQL(cadconex);
        }

        public EntidadTrabajadorInner informacionTrabajadorInner(ref string mensaje, string nom)
        {
            string consulta = "SELECT Trabajador.idTrabajador, Trabajador.Nombre, Trabajador.ApellidoP, Trabajador.ApellidoM, Trabajador.Edad, Trabajador.Direccion, Trabajador.FechaNacimiento, Trabajador.NumTelefono, Trabajador.CURP, Trabajador.RFC, Trabajador.NSS, Trabajador.FechaIngreso, Trabajador.Capacitacion, Trabajador.Idiomas, Trabajador.Salario, TipoSangre.Tipos, NivelAcademico.Nivel, EstadoCivil.Estado FROM Trabajador INNER JOIN TipoSangre ON Trabajador.idTrabajador = TipoSangre.idTipoSangre INNER JOIN NivelAcademico ON Trabajador.idNivelAcademico = NivelAcademico.idNivelAcademico INNER JOIN EstadoCivil ON Trabajador.idEstadoCivil = EstadoCivil.idEstadoCivil WHERE Nombre = '" + nom + "'";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            EntidadTrabajadorInner misobjs = new EntidadTrabajadorInner();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.idTrabajador = (int)contenedor[0];
                    misobjs.Nombre = (string)contenedor[1];
                    misobjs.ApellidoP = (string)contenedor[2];
                    misobjs.ApellidoM = (string)contenedor[3];
                    misobjs.Edad = (int)contenedor[4];
                    misobjs.Direccion = (string)contenedor[5];
                    misobjs.FechaNacimiento = (string)contenedor[6];
                    misobjs.NumTelefono = (string)contenedor[7];
                    misobjs.CURP = (string)contenedor[8];
                    misobjs.RFC = (string)contenedor[9];
                    misobjs.NSS = (string)contenedor[10];
                    misobjs.FechaIngreso = (string)contenedor[11];
                    misobjs.Capacitacion = (string)contenedor[12];
                    misobjs.Idiomas = (string)contenedor[13];
                    misobjs.Salario = (string)contenedor[14];
                    misobjs.Tipo = (string)contenedor[15];
                    misobjs.Nivel = (string)contenedor[16];
                    misobjs.Estado = (string)contenedor[17];
                }
            }
            return misobjs;
        }

        public EntidadTrabajadorInner informacionTrabajadorInner2(ref string mensaje)
        {
            string consulta = "SELECT Trabajador.idTrabajador, Trabajador.Nombre, Trabajador.ApellidoP, Trabajador.ApellidoM, Trabajador.Edad, Trabajador.Direccion, Trabajador.FechaNacimiento, Trabajador.NumTelefono, Trabajador.CURP, Trabajador.RFC, Trabajador.NSS, Trabajador.FechaIngreso, Trabajador.Capacitacion, Trabajador.Idiomas, Trabajador.Salario, TipoSangre.Tipos, NivelAcademico.Nivel, EstadoCivil.Estado FROM Trabajador INNER JOIN TipoSangre ON Trabajador.idTrabajador = TipoSangre.idTipoSangre INNER JOIN NivelAcademico ON Trabajador.idNivelAcademico = NivelAcademico.idNivelAcademico INNER JOIN EstadoCivil ON Trabajador.idEstadoCivil = EstadoCivil.idEstadoCivil;";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            EntidadTrabajadorInner misobjs = new EntidadTrabajadorInner();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.idTrabajador = (int)contenedor[0];
                    misobjs.Nombre = (string)contenedor[1];
                    misobjs.ApellidoP = (string)contenedor[2];
                    misobjs.ApellidoM = (string)contenedor[3];
                    misobjs.Edad = (int)contenedor[4];
                    misobjs.Direccion = (string)contenedor[5];
                    misobjs.FechaNacimiento = (string)contenedor[6];
                    misobjs.NumTelefono = (string)contenedor[7];
                    misobjs.CURP = (string)contenedor[8];
                    misobjs.RFC = (string)contenedor[9];
                    misobjs.NSS = (string)contenedor[10];
                    misobjs.FechaIngreso = (string)contenedor[11];
                    misobjs.Capacitacion = (string)contenedor[12];
                    misobjs.Idiomas = (string)contenedor[13];
                    misobjs.Salario = (string)contenedor[14];
                    misobjs.Tipo = (string)contenedor[15];
                    misobjs.Nivel = (string)contenedor[16];
                    misobjs.Estado = (string)contenedor[17];
                }
            }
            return misobjs;
        }

        public DataTable ObtenerTrabajadores(ref string mensaje)
        {
            string consulta = "SELECT idTrabajador, Nombre, ApellidoP, ApellidoM, Edad, Direccion, FechaNacimiento from Trabajador;";

            DataTable salidaDT = null;
            DataSet contenedorDS = null;

            contenedorDS = operaciones.ConsultaDS(consulta, operaciones.abrirConexion(ref mensaje), ref mensaje);


            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }

        public DataTable ObtenerTrabajadores2(ref string mensaje)
        {
            string consulta = "SELECT NumTelefono, CURP, RFC, NSS, FechaIngreso from Trabajador;";

            DataTable salidaDT = null;
            DataSet contenedorDS = null;

            contenedorDS = operaciones.ConsultaDS(consulta, operaciones.abrirConexion(ref mensaje), ref mensaje);

            if (contenedorDS != null)
            {
                salidaDT = contenedorDS.Tables[0];
            }
            return salidaDT;
        }

        public DataTable ObtenerTrabajadores3(ref string mensaje)
        {
            string consulta = "SELECT Trabajador.Capacitacion, Trabajador.Idiomas, Trabajador.Salario, TipoSangre.Tipos, NivelAcademico.Nivel, EstadoCivil.Estado FROM Trabajador INNER JOIN TipoSangre ON Trabajador.idTrabajador = TipoSangre.idTipoSangre INNER JOIN NivelAcademico ON Trabajador.idNivelAcademico = NivelAcademico.idNivelAcademico INNER JOIN EstadoCivil ON Trabajador.idEstadoCivil = EstadoCivil.idEstadoCivil; ";

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
