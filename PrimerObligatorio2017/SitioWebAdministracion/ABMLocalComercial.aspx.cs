using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMLocalComercial : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        int padron;

        if (String.IsNullOrWhiteSpace(txtPadron.Text))
        {
            mostrarMensajeError("El Padron no puede quedar vacio.");
            return;
        }

        try
        {
            padron = Convert.ToInt32(txtPadron.Text);

            if (padron <= 0)
            {
                mostrarMensajeError("Para buscar una propiedad debe ingresar un numero positivo.");
                return;
            }
        }
        catch (FormatException)
        {
            mostrarMensajeError("El Padron debe ser un numero entero.");
            return;
        }

        Propiedad propiedad = null;

        try
        {
            InterfaceLogicaPropiedad interPropiedad = FabricaLogica.GetLogicaPropiedad();

            propiedad = interPropiedad.Buscar(padron);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al buscar la propiedad");
            return;
        }

        if (propiedad != null)
        {
            if (propiedad is LocalComercial)
            {
                ddlDepa.SelectedValue = propiedad.UnaZona.Departamento;
                txtLoca.Text = propiedad.UnaZona.Localidad;
                txtDireccion.Text = propiedad.Direccion;
                txtEmpleado.Text = propiedad.UnEmpleado.NombreLogueo;
                ddlAccion.SelectedValue = propiedad.Accion;
                txtPrecio.Text = propiedad.Precio.ToString();
                txtTamaño.Text = propiedad.Tamaño.ToString();
                txtHabitacion.Text = propiedad.Habitaciones.ToString();
                txtBaño.Text = propiedad.Baños.ToString();
                ((LocalComercial)propiedad).Habilitacion = true ? rbtnSi.Checked = true : rbtnNo.Checked = true;

                btnBuscar.Enabled = false;
                btnModificar.Enabled = true;
                btnEliminar.Enabled = true;

                txtPadron.Enabled = false;
                ddlDepa.Enabled = true;
                txtLoca.Enabled = true;
                btnBuscarZona.Enabled = true;
                txtDireccion.Focus();
                txtDireccion.Enabled = true;
                ddlAccion.Enabled = true;
                txtPrecio.Enabled = true;
                txtTamaño.Enabled = true;
                txtHabitacion.Enabled = true;
                txtBaño.Enabled = true;
                rbtnNo.Enabled = true;
                rbtnSi.Enabled = true;
            }
            else
            {
                mostrarMensajeError("La propiedad que busco no es un Local Comercial.");
                return;
            }
        }
        else
        {
            btnBuscar.Enabled = false;
            btnAgregar.Enabled = true;
            txtPadron.Enabled = false;
            txtEmpleado.Text = ((Empleado)Session["USER"]).NombreLogueo;
            txtEmpleado.Enabled = false;

            ddlDepa.Enabled = true;
            txtLoca.Enabled = true;
            btnBuscarZona.Enabled = true;
            txtDireccion.Focus();
            txtDireccion.Enabled = true;
            ddlAccion.Enabled = true;
            txtPrecio.Enabled = true;
            txtTamaño.Enabled = true;
            txtHabitacion.Enabled = true;
            txtBaño.Enabled = true;
            rbtnSi.Enabled = true;
            rbtnNo.Enabled = true;

            lblMensaje.Text = "No se encontro un local comercial con el padron " + padron + ", puede agregarlo ahora.";
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            LocalComercial local = CargarLocal();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Agregar(local);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al agregar el local comercial.");
            return;
        }

        lblMensaje.Text = "CLocal Comercial agregado con Exito.";
        LimpiarFormulario();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            LocalComercial local = CargarLocal();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Modificar(local);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al modificar el local.");
            return;
        }

        lblMensaje.Text = "Local Comercial modificado con Exito.";
        LimpiarFormulario();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            LocalComercial local = CargarLocal();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Eliminar(local);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al eliminar el Local comercial.");
            return;
        }

        lblMensaje.Text = "Local Comercial eliminado con Exito.";
        LimpiarFormulario();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
    }

    protected LocalComercial CargarLocal()
    {
        int padron;
        string direccion = txtDireccion.Text;
        string accion = ddlAccion.SelectedValue;
        int precio;
        double tamaño;
        int habitacion;
        int baños;
        bool habilitacion = false;
        Empleado empleado = null;
        Zonas zona = null;

        if (String.IsNullOrWhiteSpace(txtLoca.Text))
        {
            throw new ExcepcionPersonalizada("Debe indcar la localidad.");
        }
        string dep = ddlDepa.SelectedValue;
        string loc = txtLoca.Text;

        try
        {
            empleado = (Empleado)Session["USER"];
        }
        catch
        {
            throw new ExcepcionPersonalizada("Ocurrio un problema al buscar al empleado");
        }

        try
        {
            InterfaceLogicaZona inter = FabricaLogica.GetLogicaZona();
            zona = inter.Buscar(dep, loc);

            if (zona == null)
            {
                throw new ExcepcionPersonalizada("Debe ingresar una zona valida.");
            }
        }
        catch (ExcepcionPersonalizada ex)
        {
            throw ex;
        }
        catch
        {
            throw new ExcepcionPersonalizada("Ocurrio un problema al buscar la zona");
        }

        try
        {
            padron = Convert.ToInt32(txtPadron.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El Padron debe ser un numero entero.");
        }
        try
        {
            precio = Convert.ToInt32(txtPrecio.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El Precio debe ser un numero entero.");
        }
        try
        {
            tamaño = Convert.ToDouble(txtTamaño.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El Tamaño debe ser un numero decimal.");
        }
        try
        {
            habitacion = Convert.ToInt32(txtHabitacion.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El numero de habitaciones debe ser un numero entero.");
        }
        try
        {
            baños = Convert.ToInt32(txtBaño.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El numero de baños debe ser un numero entero.");
        }

        if (rbtnSi.Checked)
        {
            habilitacion = true;
        }

        LocalComercial local = new LocalComercial(padron, direccion, precio, accion, baños, habitacion, tamaño, habilitacion, empleado, zona);
        return local;
    }

    protected void LimpiarFormulario()
    {
        ddlDepa.SelectedIndex = 0;
        ddlDepa.Enabled = false;
        ddlAccion.SelectedIndex = 0;
        txtLoca.Enabled = false;
        txtLoca.Text = string.Empty;
        txtPadron.Enabled = true;
        txtPadron.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        btnBuscarZona.Enabled = false;
        txtDireccion.Enabled = false;
        ddlAccion.Enabled = false;
        txtPrecio.Enabled = false;
        txtPrecio.Text = string.Empty;
        txtTamaño.Enabled = false;
        txtTamaño.Text = string.Empty;
        txtHabitacion.Enabled = false;
        txtHabitacion.Text = string.Empty;
        txtBaño.Enabled = false;
        txtBaño.Text = string.Empty;
        txtEmpleado.Enabled = false;
        txtEmpleado.Text = string.Empty;
        rbtnNo.Checked = true;
        rbtnNo.Enabled = false;
        rbtnSi.Enabled = false;

        btnBuscar.Enabled = true;
        btnAgregar.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
    }

    protected void btnBuscarZona_Click(object sender, EventArgs e)
    {
        Zonas zona = null;
        string dep = ddlDepa.SelectedValue;

        if (String.IsNullOrWhiteSpace(txtLoca.Text))
        {
            mostrarMensajeError("Debe indcar la localidad.");
            return;
        }
        string loc = txtLoca.Text;

        InterfaceLogicaZona inter = FabricaLogica.GetLogicaZona();
        zona = inter.Buscar(dep, loc);

        if (zona == null)
        {
            lblZona.Text = "No se encontro la Zona";
            return;
        }
        else
        {
            lblZona.Text = zona.Nombre;
        }
    }
}