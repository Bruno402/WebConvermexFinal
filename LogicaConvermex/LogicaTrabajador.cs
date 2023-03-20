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
    public class LogicaTrabajador
    {
        private AccesoSQL operaciones = null;

        public LogicaTrabajador(string cadconex)
        {
            operaciones = new AccesoSQL(cadconex);
        }

        public EntidadTrabajador informacionTrabajador(ref string mensaje, string nom)
        {
            string consulta = "SELECT Nombre, ApellidoP, ApellidoM, Edad, Direccion, FechaNacimiento, NumTelefono, CURP, RFC, NSS, FechaIngreso, Capacitacion, Idiomas, Salario from Trabajador WHERE Nombre = '" + nom + "'";
            SqlDataReader contenedor = null;
            SqlConnection cntemp = null;
            EntidadTrabajador misobjs = new EntidadTrabajador();

            cntemp = operaciones.abrirConexion(ref mensaje);
            contenedor = operaciones.ConsultaReader(consulta, cntemp, ref mensaje);

            if (contenedor != null)
            {
                while (contenedor.Read())
                {
                    misobjs.Nombre = (string)contenedor[0];
                    misobjs.ApellidoP = (string)contenedor[1];
                    misobjs.ApellidoM = (string)contenedor[2];
                    misobjs.Edad = (int)contenedor[3];
                    misobjs.Direccion = (string)contenedor[4];
                    misobjs.FechaNacimiento = (string)contenedor[5];
                    misobjs.NumTelefono = (string)contenedor[6];
                    misobjs.CURP = (string)contenedor[7];
                    misobjs.RFC = (string)contenedor[8];
                    misobjs.NSS = (string)contenedor[9];
                    misobjs.FechaIngreso = (string)contenedor[10];
                    misobjs.Capacitacion = (string)contenedor[11];
                    misobjs.Idiomas = (string)contenedor[12];
                    misobjs.Salario = (string)contenedor[13];
                }
            }
            return misobjs;
        }

        public Boolean InsertarTrabajador(EntidadTrabajador ob_nuevo, ref string mensaje)
        {
            string sentencia = "insert into Trabajador (Nombre, ApellidoP, ApellidoM, Edad, Direccion, FechaNacimiento, NumTelefono, CURP, RFC, NSS, FechaIngreso, Capacitacion, Idiomas, Salario, idTipoSangre, idNivelAcademico, idEstadoCivil)" +
                "values (@Nombre, @ApellidoP, @ApellidoM, @Edad, @Direccion, @FechaNacimiento, @NumTelefono, @CURP, @RFC, @NSS, @FechaIngreso, @Capacitacion, @Idiomas, @Salario, @idTipoSangre, @idNivelAcademico, @idEstadoCivil);";
            Boolean salida = false;

            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("Nombre", SqlDbType.VarChar, 20),
                new SqlParameter("ApellidoP", SqlDbType.VarChar, 20),
                new SqlParameter("ApellidoM", SqlDbType.VarChar, 20),
                new SqlParameter("Edad", SqlDbType.Int),
                new SqlParameter("Direccion",SqlDbType.VarChar,100),
                new SqlParameter("FechaNacimiento",SqlDbType.VarChar, 20),
                new SqlParameter("NumTelefono",SqlDbType.VarChar, 30),
                new SqlParameter("CURP",SqlDbType.VarChar, 18),
                new SqlParameter("RFC",SqlDbType.VarChar, 12),
                new SqlParameter("NSS",SqlDbType.VarChar, 11),
                new SqlParameter("FechaIngreso",SqlDbType.VarChar, 30),
                new SqlParameter("Capacitacion",SqlDbType.VarChar, 100),
                new SqlParameter("Idiomas",SqlDbType.VarChar, 100),
                new SqlParameter("Salario",SqlDbType.VarChar, 100),
                new SqlParameter("idTipoSangre",SqlDbType.Int),
                new SqlParameter("idNivelAcademico",SqlDbType.Int),
                new SqlParameter("idEstadoCivil",SqlDbType.Int),
            };

            arregloPars[0].Value = ob_nuevo.Nombre;
            arregloPars[1].Value = ob_nuevo.ApellidoP;
            arregloPars[2].Value = ob_nuevo.ApellidoM;
            arregloPars[3].Value = ob_nuevo.Edad;
            arregloPars[4].Value = ob_nuevo.Direccion;
            arregloPars[5].Value = ob_nuevo.FechaNacimiento;
            arregloPars[6].Value = ob_nuevo.NumTelefono;
            arregloPars[7].Value = ob_nuevo.CURP;
            arregloPars[8].Value = ob_nuevo.RFC;
            arregloPars[9].Value = ob_nuevo.NSS;
            arregloPars[10].Value = ob_nuevo.FechaIngreso;
            arregloPars[11].Value = ob_nuevo.Capacitacion;
            arregloPars[12].Value = ob_nuevo.Idiomas;
            arregloPars[13].Value = ob_nuevo.Salario;
            arregloPars[14].Value = ob_nuevo.idTipoSangre;
            arregloPars[15].Value = ob_nuevo.idNivelAcademico;
            arregloPars[16].Value = ob_nuevo.idEstadoCivil;

            salida = operaciones.OperacionMasSeguraModificacionBD(sentencia, operaciones.abrirConexion(ref mensaje), ref mensaje, arregloPars);

            return salida;
        }

        public Boolean editTrabajador(EntidadTrabajador ob_nuevo, ref string mensaje, string nombre)
        {
            string sentencia = "UPDATE Trabajador set Nombre=@nuevoN,ApellidoP=@nuevoAP,ApellidoM=@nuevoAM,Edad=@nuevoED,Direccion=@nuevoDI, FechaNacimiento=@nuevoFN,NumTelefono=@nuevoNU, CURP=@nuevoCU, RFC=@nuevoRF, NSS=@nuevoNS, FechaIngreso=@nuevoFI, Capacitacion=@nuevoCA, Idiomas=@nuevoIDIO, Salario=@nuevoSAL, idTipoSangre=@nuevoTipo, idNivelAcademico=@nuevoNIAC, idEstadoCivil=@nuevoESCI where Nombre = '" + nombre + "'" ;
            Boolean salida = false;

            SqlParameter[] arregloPars = new SqlParameter[]
            {
                new SqlParameter("nuevoN", SqlDbType.VarChar, 20),
                new SqlParameter("nuevoAP", SqlDbType.VarChar, 20),
                new SqlParameter("nuevoAM", SqlDbType.VarChar, 20),
                new SqlParameter("nuevoED", SqlDbType.Int),
                new SqlParameter("nuevoDI",SqlDbType.VarChar,100),
                new SqlParameter("nuevoFN",SqlDbType.VarChar, 20),
                new SqlParameter("nuevoNU",SqlDbType.VarChar, 30),
                new SqlParameter("nuevoCU",SqlDbType.VarChar, 18),
                new SqlParameter("nuevoRF",SqlDbType.VarChar, 12),
                new SqlParameter("nuevoNS",SqlDbType.VarChar, 11),
                new SqlParameter("nuevoFI",SqlDbType.VarChar, 30),
                new SqlParameter("nuevoCA",SqlDbType.VarChar, 100),
                new SqlParameter("nuevoIDIO",SqlDbType.VarChar, 100),
                new SqlParameter("nuevoSAL",SqlDbType.VarChar, 100),
                new SqlParameter("nuevoTipo",SqlDbType.Int),
                new SqlParameter("nuevoNIAC",SqlDbType.Int),
                new SqlParameter("nuevoESCI",SqlDbType.Int),

            };
            arregloPars[0].Value = ob_nuevo.Nombre;
            arregloPars[1].Value = ob_nuevo.ApellidoP;
            arregloPars[2].Value = ob_nuevo.ApellidoM;
            arregloPars[3].Value = ob_nuevo.Edad;
            arregloPars[4].Value = ob_nuevo.Direccion;
            arregloPars[5].Value = ob_nuevo.FechaNacimiento;
            arregloPars[6].Value = ob_nuevo.NumTelefono;
            arregloPars[7].Value = ob_nuevo.CURP;
            arregloPars[8].Value = ob_nuevo.RFC;
            arregloPars[9].Value = ob_nuevo.NSS;
            arregloPars[10].Value = ob_nuevo.FechaIngreso;
            arregloPars[11].Value = ob_nuevo.Capacitacion;
            arregloPars[12].Value = ob_nuevo.Idiomas;
            arregloPars[13].Value = ob_nuevo.Salario;
            arregloPars[14].Value = ob_nuevo.idTipoSangre;
            arregloPars[15].Value = ob_nuevo.idNivelAcademico;
            arregloPars[16].Value = ob_nuevo.idEstadoCivil;



            salida = operaciones.OperacionMasSeguraModificacionBD(sentencia, operaciones.abrirConexion(ref mensaje), ref mensaje, arregloPars);



            return salida;
        }

       
    }
}
