using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
        string mensaje = (string)Session["Mensaje"];

        if (mensaje != null)
        {
            if (mensaje.Contains("¡ERROR!"))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }

            lblMensaje.Text = mensaje;

            Session.Remove("Mensaje");
        }       
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnIngresar_Click1(object sender, EventArgs e)
    {
        if (String.IsNullOrWhiteSpace(txtNomLogueo.Text))
        {
            lblMensaje.Text = "Debe ingresar el nombre de logueo.";
            return;
        }

        if (String.IsNullOrWhiteSpace(txtContraseña.Text))
        {
            lblMensaje.Text = "Debe ingresar la contraseña.";
            return;
        }        
        string nomLogueo = txtNomLogueo.Text;
        string contraseña = txtContraseña.Text;
        Empleado empleado;

        try
        {
            empleado = FabricaLogica.GetLogicaEmpleado().Buscar(nomLogueo);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al buscar el Empleado.");
            return;
        }


        if (empleado != null && empleado.Contraseña == contraseña)
        {
            Session["USER"] = empleado;

            Response.Redirect("ABMApartamento.aspx");
        }
        else
        {
            lblMensaje.Text = "¡ERROR! Nombre de usuario y/o contraseña incorrecto/a(s).";
        }
    }  
}