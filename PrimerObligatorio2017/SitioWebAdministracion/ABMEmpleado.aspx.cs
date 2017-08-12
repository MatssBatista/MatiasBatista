using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMEmpleado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtcontraseña.Text = "";
            txtnombre.Text = "";
            btnagregar.Enabled = false;
            btneliminar.Enabled = false;
            btnmodificar.Enabled = false;
            txtcontraseña.Enabled = false;
            txtRepetir.Enabled = false;
        }
        lblerror.Text = "";
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblerror.ForeColor = System.Drawing.Color.Red;
        lblerror.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        string nombre = "";

        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre.<br>");
            return;
        }
        Empleado unEmpleado = null;
        try
        {
            unEmpleado = FabricaLogica.GetLogicaEmpleado().BuscarHabilitado(nombre);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al buscar el empleado.");
            return;
        }
        if (unEmpleado == null)
        {
            lblerror.Text = "No se encontró el empleado, pero puede agregarlo";
            txtnombre.Enabled = false;
            txtcontraseña.Enabled = true;
            txtRepetir.Enabled = true;
            btnagregar.Enabled = true;
        }
        else
        {
            if (unEmpleado.NombreLogueo == ((Empleado)Session["USER"]).NombreLogueo)
            {
                txtnombre.Text = unEmpleado.NombreLogueo;
                btnmodificar.Enabled = true;
                txtnombre.Enabled = false;
                txtcontraseña.Enabled = true;
                txtRepetir.Enabled = true;

                lblerror.Text = "Se ha encontrado su usuario.";
            }
            else
            {
                txtnombre.Text = unEmpleado.NombreLogueo;
                btneliminar.Enabled = true;
                txtnombre.Enabled = false;
                lblerror.Text = "Usuario encontrado con exito.";

                Session["Empleado"] = unEmpleado;
            }
        }
    }

    protected void btnagregar_Click(object sender, EventArgs e)
    {
        string nombre = "";
        string contraseña = "";

        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre.<br>");
            return;
        }
        if (txtcontraseña.Text.Trim().Length != 0)
        {
            contraseña = txtcontraseña.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la contraseña.<br>");
            return;
        }
        if (txtRepetir.Text.Trim().Length != 0)
        {
            if (txtRepetir.Text != contraseña)
            {
                mostrarMensajeError("Debe repetir correctamente la contraseña.");
                return;
            }
        }
        else
        {
            mostrarMensajeError("Debe repetir la contraseña.");
            return;
        }
        Empleado unEmpleado = null;
        try
        {
            unEmpleado = new Empleado(nombre, contraseña);
            FabricaLogica.GetLogicaEmpleado().Agregar(unEmpleado);
            lblerror.Text = "El empleado fue agregado con éxito";
            Limpiar();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al agregar el empleado.");
            return;
        }
    }

    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        string nombre = "";
        string contraseña = "";

        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre.<br>");
            return;
        }
        if (txtcontraseña.Text.Trim().Length != 0)
        {
            contraseña = txtcontraseña.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la contraseña.<br>");
            return;
        }
        if (txtRepetir.Text.Trim().Length != 0)
        {
            if (txtRepetir.Text != contraseña)
            {
                mostrarMensajeError("Debe repetir correctamente la contraseña.");
                return;
            }
        }
        else
        {
            mostrarMensajeError("Debe repetir la contraseña.");
            return;
        }
        Empleado unEmpleado = null;
        try
        {
            unEmpleado = new Empleado(nombre, contraseña);
            FabricaLogica.GetLogicaEmpleado().Modificar(unEmpleado);
            lblerror.Text = "El empleado fue modificado con éxito";

            Limpiar();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al modificar el empleado.");
            return;
        }
    }

    protected void btneliminar_Click(object sender, EventArgs e)
    {
        string nombre = "";
        Empleado emp = (Empleado)Session["USER"];

        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre.<br>");
            return;
        }
        Empleado unEmpleado = null;
        try
        {
            unEmpleado = (Empleado)Session["Empleado"];
            if (unEmpleado.NombreLogueo == emp.NombreLogueo)
            {
                lblerror.Text = "No se puede eliminar a sí mismo!";
            }
            else
            {
                FabricaLogica.GetLogicaEmpleado().Eliminar(unEmpleado);
                lblerror.Text = "El empleado fue eliminado con éxito";

                Limpiar();
            }
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al eliminar el empleado.");
            return;
        }
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        Limpiar();
    }

    protected void Limpiar()
    {
        txtnombre.Text = "";
        txtnombre.Enabled = true;
        txtcontraseña.Text = "";
        txtRepetir.Text = "";
        txtRepetir.Enabled = false;
        txtnombre.ReadOnly = false;
        txtcontraseña.Enabled = false;
        btnagregar.Enabled = false;
        btneliminar.Enabled = false;
        btnmodificar.Enabled = false;
    }
}