using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaConvermex;
using EntidadesConvermex;
using System.Configuration;

namespace WebConvermexFinal
{
    public partial class altaPersonal : System.Web.UI.Page
    {
        LogicaTrabajador logicaTra = null;
        LogicaEstadoCivil logCivil = null;
        LogicaTipoSangre logTipo = null;
        LogicaNivelAcademico logAca = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logicaTra = new LogicaTrabajador(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaTra"] = logicaTra;

                logCivil = new LogicaEstadoCivil(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaCivi"] = logCivil;

                logTipo = new LogicaTipoSangre(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaSangre"] = logTipo;

                logAca = new LogicaNivelAcademico(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaAcademico"] = logAca;
            }
            else
            {
                logicaTra = (LogicaTrabajador)Session["logicaTra"];
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

        public void MiMessageBox(string titulo, string mensaje, string icon)
        {
            this.ClientScript.RegisterStartupScript(this.GetType(), "scr1", "nuevoMensaje('" + titulo + "','" + mensaje + "','" + icon + "')", true);

        }

        protected void btnAgregarPersonal_Click(object sender, EventArgs e)
        {
            string g = "";
            string nombre = TxtNombre.Text;
            string apP = TxtApellidoP.Text;
            string apM = TxtApellidoM.Text;
            int edad = Convert.ToInt32(txtEdad.Text);
            string dir = txtDireccion.Text;
            string numTe = txtNumTe.Text;
            string curp = txtCurp.Text;
            string rfc = txtRfc.Text;
            string nss = txtNss.Text;
            string capacita = txtCapacitacion.Text;
            string idioma = txtIdioma.Text;
            string salario = txtSalario.Text;

            if (nombre != "" && apP != "" && apM != "" && edad != 0 && dir != "" && numTe != "" && curp != "" && rfc != "" && nss != "" && capacita != "" && idioma != "" && salario != "")
            {
                EntidadTrabajador nuevoU
                = new EntidadTrabajador()
                {
                    Nombre = nombre,
                    ApellidoP = apP,
                    ApellidoM = apM,
                    Edad = edad,
                    Direccion = dir,
                    FechaNacimiento = txtFecha.Value,
                    NumTelefono = numTe,
                    CURP = curp,
                    RFC = rfc,
                    NSS = nss,
                    FechaIngreso = txtFechaIn.Value,
                    Capacitacion = capacita,
                    Idiomas = idioma,
                    Salario = salario,
                    idTipoSangre = Convert.ToInt16(ddlTipoSangre.SelectedValue),
                    idNivelAcademico = Convert.ToInt16(ddlNivelAcademico.SelectedValue),
                    idEstadoCivil = Convert.ToInt16(ddlEstadoCivil.SelectedValue),
                };

                string cad = "";
                logicaTra.InsertarTrabajador(nuevoU, ref cad);
                TxtNombre.Text = "";
                TxtApellidoP.Text = "";
                TxtApellidoM.Text = "";
                txtEdad.Text = "";
                txtDireccion.Text = "";
                txtFecha.Value = "";
                txtNumTe.Text = "";
                txtCurp.Text = "";
                txtRfc.Text = "";
                txtNss.Text = "";
                txtFechaIn.Value = "";
                txtCapacitacion.Text = "";
                txtIdioma.Text = "";
                txtSalario.Text = "";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se incerto correctamente');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('ERROR DE INCERSION');", true);
            }
        }
    }
}