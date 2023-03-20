using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaConvermex;
using EntidadesConvermex;
using System.Configuration;
using ClassLibrary1;

namespace WebConvermexFinal
{
    public partial class modificarPersonal : System.Web.UI.Page
    {
        LogicaTrabajador logTra = null;
        LogicaTrabajadorInner loginner = null;
        LogicaEstadoCivil logCivil = null;
        LogicaTipoSangre logTipo = null;
        LogicaNivelAcademico logAca = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logTra = new LogicaTrabajador(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaTra"] = logTra;

                loginner = new LogicaTrabajadorInner(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaTrabajadorInner"] = loginner;

                logCivil = new LogicaEstadoCivil(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaCivi"] = logCivil;

                logTipo = new LogicaTipoSangre(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaSangre"] = logTipo;

                logAca = new LogicaNivelAcademico(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaAcademico"] = logAca;
            }
            else
            {
                loginner = (LogicaTrabajadorInner)Session["logicaTrabajadorInner"];
                logTra = (LogicaTrabajador)Session["logicaTra"];
                logCivil = (LogicaEstadoCivil)Session["logicaCivil"];
                logTipo = (LogicaTipoSangre)Session["logicaSangre"];
                logAca = (LogicaNivelAcademico)Session["logicaAcademico"];
            }

            if (!IsPostBack)
            {
                showDrop();
            }
        }

        public void showDrop()
        {
            List<EntidadEstadoCivil> listaCivil = null;
            List<EntidadTipoSangre> listaTipo = null;
            List<EntidadNivelAcademico> listaAca = null;

            string h = "";
            listaCivil = logCivil.informacionEstadoCivil(ref h);
            listaTipo = logTipo.informacionTipoSangre(ref h);
            listaAca = logAca.informacionNivelAca(ref h);
            ddlEstadoCivil.Items.Clear();

            for (int i = 0; i < listaCivil.Count; i++)
            {
                ddlEstadoCivil.Items.Add(new ListItem(listaCivil[i].Estado, listaCivil[i].idEstadoCivil.ToString()));
            }

            ddlTipoSangre.Items.Clear();
            for (int t = 0; t < listaTipo.Count; t++)
            {
                ddlTipoSangre.Items.Add(new ListItem(listaTipo[t].Tipos, listaTipo[t].idTipoSangre.ToString()));
            }

            ddlNivelAcademico.Items.Clear();
            for (int p = 0; p < listaAca.Count; p++)
            {
                ddlNivelAcademico.Items.Add(new ListItem(listaAca[p].Nivel, listaAca[p].idNivelAcademico.ToString()));
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
                string nomBus = TxtNomBus.Text;
                string h = "";

                EntidadTrabajador ob = new EntidadTrabajador();
                ob = logTra.informacionTrabajador(ref h, nomBus);
            if (nomBus == ob.Nombre)
            {

                if (ob != null)
                {
                    txtNombre.Text = ob.Nombre.ToString();
                    TxtApellidoP.Text = ob.ApellidoP.ToString();
                    TxtApellidoM.Text = ob.ApellidoM.ToString();
                    txtEdad.Text = ob.Edad.ToString();
                    txtDireccion.Text = ob.Direccion.ToString();
                    txtFecha.Text = ob.FechaNacimiento.ToString();
                    txtNumTe.Text = ob.NumTelefono.ToString();
                    txtCurp.Text = ob.CURP.ToString();
                    txtRfc.Text = ob.RFC.ToString();
                    txtNss.Text = ob.NSS.ToString();
                    txtFechaIn.Text = ob.FechaIngreso.ToString();
                    txtCapacitacion.Text = ob.Capacitacion.ToString();
                    txtIdioma.Text = ob.Idiomas.ToString();
                    txtSalario.Text = ob.Salario.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se encontro el usuario correctamente');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El nombre no existe en la base de datos');", true);
            }
            
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnActualizarPersonal_Click(object sender, EventArgs e)
        {

            string men = "";
            string nombr = TxtNomBus.Text;
            EntidadTrabajador obnew = new EntidadTrabajador();

            string nombre = txtNombre.Text;
            string apP = TxtApellidoP.Text;
            string apM = TxtApellidoM.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            string dir = txtDireccion.Text;
            string fech = txtFecha.Text;
            string fechIn = txtFechaIn.Text;
            string numTe = txtNumTe.Text;
            string curp = txtCurp.Text;
            string rfc = txtRfc.Text;
            string nss = txtNss.Text;
            string capacita = txtCapacitacion.Text;
            string idioma = txtIdioma.Text;
            string salario = txtSalario.Text;
            int idSan = Convert.ToInt32(ddlTipoSangre.SelectedValue);
            int idNivel = Convert.ToInt32(ddlNivelAcademico.SelectedValue);
            int idEstado = Convert.ToInt32(ddlEstadoCivil.SelectedValue);

            obnew.Nombre = nombre;
            obnew.ApellidoP = apP;
            obnew.ApellidoM = apM;
            obnew.Edad = edad;
            obnew.Direccion = dir;
            obnew.FechaNacimiento = fech;
            obnew.NumTelefono = numTe;
            obnew.CURP = curp;
            obnew.RFC = rfc;
            obnew.NSS = nss;
            obnew.FechaIngreso = fechIn;
            obnew.Capacitacion = capacita;
            obnew.Idiomas = idioma;
            obnew.Salario = salario;
            obnew.idTipoSangre = idSan;
            obnew.idNivelAcademico = idNivel;
            obnew.idEstadoCivil = idEstado;
            logTra.editTrabajador(obnew, ref men, nombr);

            txtNombre.Text = "";
            TxtApellidoP.Text = "";
            TxtApellidoM.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            txtFecha.Text = "";
            txtNumTe.Text = "";
            txtCurp.Text = "";
            txtRfc.Text = "";
            txtNss.Text = "";
            txtFechaIn.Text = "";
            txtCapacitacion.Text = "";
            txtIdioma.Text = "";
            txtSalario.Text = "";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se modifico correctamente');", true);

        }
    }
}