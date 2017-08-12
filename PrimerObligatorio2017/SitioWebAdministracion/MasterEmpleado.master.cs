using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class MasterEmpleado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        Empleado empleado = (Empleado)Session["USER"];

        if (!(empleado is Empleado))
        {
            Session["Mensaje"] = "¡ERROR! Usted no está autorizado para acceder a esta página.";

            Response.Redirect("~/Default.aspx");
        }
        lblnempleado.Text = ((Empleado)Session["USER"]).NombreLogueo;       
    }
    protected void lnksalir_Click(object sender, EventArgs e)
    {
        Session["USER"] = null;
        Response.Redirect("Default.aspx");
    }
}
