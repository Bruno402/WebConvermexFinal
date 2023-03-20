using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicaConvermex;
using EntidadesConvermex;
using System.Configuration;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace WebConvermexFinal
{
    public partial class reportePersonal : System.Web.UI.Page
    {
        LogicaTrabajadorInner logicainner = null;
        LogicaEstadoCivil logEstado = null;
        LogicaNivelAcademico logNivAca = null;
        LogicaTipoSangre logTipSan = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                logicainner = new LogicaTrabajadorInner(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicainner"] = logicainner;

                logEstado = new LogicaEstadoCivil(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaEstado"] = logEstado;

                logNivAca = new LogicaNivelAcademico(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaNivAca"] = logNivAca;

                logTipSan = new LogicaTipoSangre(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaTipSan"] = logTipSan;
            }
            else
            {
                logicainner = (LogicaTrabajadorInner)Session["logicainner"];
                logEstado = (LogicaEstadoCivil)Session["logicaEstado"];
                logNivAca = (LogicaNivelAcademico)Session["logicaNivAca"];
                logTipSan = (LogicaTipoSangre)Session["logicaTipSan"];
            }
        }

        public void getTablaTrabajadores()
        {
            string m = "";
            GVmostrar.DataSource = logicainner.ObtenerTrabajadores(ref m);
            GVmostrar.DataBind();

        }

        public void getTablaTrabajadores2()
        {
            string m = "";
            GVmostrar2.DataSource = logicainner.ObtenerTrabajadores2(ref m);
            GVmostrar2.DataBind();

        }

        public void getTablaTrabajadores3()
        {
            string m = "";
            GVmostrar3.DataSource = logicainner.ObtenerTrabajadores3(ref m);
            GVmostrar3.DataBind();
        }

        public void getTablaEstadoCivil()
        {
            string m = "";
            GVmostrar.DataSource = logEstado.ObtenerEstadoCivil(ref m);
            GVmostrar.DataBind();
        }

        public void getTablaNivelAcademico()
        {
            string m = "";
            GVmostrar.DataSource = logNivAca.ObtenerNivelAcademico(ref m);
            GVmostrar.DataBind();
        }

        public void getTablaTipoSangre()
        {
            string m = "";
            GVmostrar.DataSource = logTipSan.ObtenerTipoSangre(ref m);
            GVmostrar.DataBind();
        }

        //protected void btnDescargarTrabajadores_Click(object sender, EventArgs e)
        //{
           
        //}

        protected void GVmostrar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVmostrar.PageIndex = e.NewPageIndex;
            getTablaTrabajadores();
        }

        protected void btnBuscarTabla_Click(object sender, EventArgs e)
        {
            if(ddlConsultaDatos.SelectedValue == "Trabajador")
            {
                GVmostrar2.Style["Visibility"] = "visible";
                GVmostrar3.Style["Visibility"] = "visible";
                getTablaTrabajadores();
                getTablaTrabajadores2();
                getTablaTrabajadores3();
            }
            else if(ddlConsultaDatos.SelectedValue == "Estado Civil")
            {
                getTablaEstadoCivil();
                GVmostrar2.Style["Visibility"] = "hidden";
                GVmostrar3.Style["Visibility"] = "hidden";
            }
            else if(ddlConsultaDatos.SelectedValue == "Nivel Academico")
            {
                getTablaNivelAcademico();
                GVmostrar2.Style["Visibility"] = "hidden";
                GVmostrar3.Style["Visibility"] = "hidden";
            }
            else if(ddlConsultaDatos.SelectedValue == "Tipo de Sangre")
            {
                getTablaTipoSangre();
                GVmostrar2.Style["Visibility"] = "hidden";
                GVmostrar3.Style["Visibility"] = "hidden";
            }
        }

        //protected void btnExportarWord_Click(object sender, EventArgs e)
        //{

        //}

        //protected void btnExportarPdf_Click(object sender, EventArgs e)
        //{

        //}
    }

}