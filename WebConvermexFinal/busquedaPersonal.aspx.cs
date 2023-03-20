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
    public partial class busquedaPersonal : System.Web.UI.Page
    {
        LogicaTrabajadorInner loginner = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loginner = new LogicaTrabajadorInner(ConfigurationManager.ConnectionStrings["cnlocal1"].ConnectionString);
                Session["logicaTrabajadorInner"] = loginner;
            }
            else
            {
                loginner = (LogicaTrabajadorInner)Session["logicaTrabajadorInner"];
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarPersonal_Click(object sender, EventArgs e)
        {
            string nomBus = TextBox1.Text;
            string h = "";

            EntidadTrabajadorInner ob = new EntidadTrabajadorInner();
            ob = loginner.informacionTrabajadorInner(ref h, nomBus);

            if(nomBus == ob.Nombre)
            {
                if(ob != null)
                {
                    txtNombre.Value = ob.Nombre.ToString();
                    TxtApellidoP.Value = ob.ApellidoP.ToString();
                    TxtApellidoM.Value = ob.ApellidoM.ToString();
                    txtEdad.Value = ob.Edad.ToString();
                    txtDireccion.Value = ob.Direccion.ToString();
                    txtFecha.Value = ob.FechaNacimiento.ToString();
                    txtNumTe.Value = ob.NumTelefono.ToString();
                    txtCurp.Value = ob.CURP.ToString();
                    txtRfc.Value = ob.RFC.ToString();
                    txtNss.Value = ob.NSS.ToString();
                    txtFechaIn.Value = ob.FechaIngreso.ToString();
                    txtCapacitacion.Value = ob.Capacitacion.ToString();
                    txtIdioma.Value = ob.Idiomas.ToString();
                    txtSalario.Value = ob.Salario.ToString();
                    txtTipoSan.Value = ob.Tipo.ToString();
                    txtNivAca.Value = ob.Nivel.ToString();
                    txtEstado.Value = ob.Estado.ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Se encontro el usuario correctamente');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El nombre no existe en la base de datos');", true);
            }
        }
    }
}