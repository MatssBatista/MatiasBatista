using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ABMApartamento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.CacheControl = "no-cache";
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblMensaje.ForeColor = System.Drawing.Color.Red;
        lblMensaje.Text = "¡ERROR! " + mensajeError;
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
            if (propiedad is Apartamento)
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
                txtPiso.Text = ((Apartamento)propiedad).Piso.ToString();
                ((Apartamento)propiedad).Ascensor = true ? rbtnSi.Checked = true : rbtnNo.Checked = true;

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
                txtPiso.Enabled = true;
                rbtnNo.Enabled = true;
                rbtnSi.Enabled = true;
                
            }
            else
            {
                mostrarMensajeError("La propiedad que busco no es un apartamento.");
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
            txtPiso.Enabled = true;
            rbtnSi.Enabled = true;
            rbtnNo.Enabled = true;

            lblMensaje.Text = "No se encontro un apartamento con el padron " + padron + ", puede agregarlo ahora.";
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            Apartamento apto = CargarApartamento();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Agregar(apto);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al agregar el apartamento.");
            return;
        }

        lblMensaje.Text = "Apartamento agregado con Exito.";
        LimpiarFormulario();
    }

    protected Apartamento CargarApartamento()
    {
        int padron;
        string direccion = txtDireccion.Text;
        string accion = ddlAccion.SelectedValue;
        int precio;
        double tamaño;
        int habitacion;
        int baños;
        int piso;
        bool ascensor = false;
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
        catch (ExcepcionPersonalizada ex)
        {
            throw ex;
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
            throw new  ExcepcionPersonalizada("El Padron debe ser un numero entero.");
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
        try
        {
            piso = Convert.ToInt32(txtPiso.Text);
        }
        catch (FormatException)
        {
            throw new ExcepcionPersonalizada("El Piso debe ser un numero entero.");
        }

        if (rbtnSi.Checked)
        {
            ascensor = true;
        }

        Apartamento apartamento = new Apartamento(padron, direccion, precio, accion, baños, habitacion, tamaño, piso, ascensor, empleado, zona);
        return apartamento;
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Apartamento apto = CargarApartamento();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Modificar(apto);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al modificar el apartamento.");
            return;
        }

        lblMensaje.Text = "Apartamento modificado con Exito.";
        LimpiarFormulario();
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Apartamento apto = CargarApartamento();

            InterfaceLogicaPropiedad inter = FabricaLogica.GetLogicaPropiedad();

            inter.Eliminar(apto);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al eliminar el apartamento.");
            return;
        }

        lblMensaje.Text = "Apartamento eliminado con Exito.";
        LimpiarFormulario();
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void LimpiarFormulario()
    {
        ddlDepa.SelectedIndex = 0;
        ddlAccion.SelectedIndex = 0;

        txtPadron.Enabled = true;
        txtPadron.Text = string.Empty;
        txtDireccion.Text = string.Empty;

        ddlDepa.Enabled = false;
        txtLoca.Enabled = false;
        txtLoca.Text = string.Empty;
        btnBuscarZona.Enabled = false;
        txtDireccion.Enabled = false;
        ddlAccion.Enabled = false;
        txtPrecio.Enabled = false;
        txtTamaño.Enabled = false;
        txtHabitacion.Enabled = false;
        txtBaño.Enabled = false;
        txtPiso.Enabled = false;
        txtEmpleado.Enabled = false;

        txtEmpleado.Text = string.Empty;
        txtPrecio.Text = string.Empty;
        txtTamaño.Text = string.Empty;
        txtHabitacion.Text = string.Empty;
        txtBaño.Text = string.Empty;
        rbtnNo.Checked = true;
        rbtnNo.Enabled = false;
        rbtnSi.Enabled = false;
        txtPiso.Text = string.Empty;

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