using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;


public partial class ABMZonas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtdepartamento.MaxLength = 1;
            txtlocalidad.MaxLength = 3;
            Session["Lista"] = null;
            gvservicios.Visible = true;
        }
        gvservicios.Visible = true;
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblerror.ForeColor = System.Drawing.Color.Red;
        lblerror.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        string departamento = "";
        string localidad = "";       

        if (txtdepartamento.Text.Trim().Length != 0)
        {
            departamento = txtdepartamento.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el departamento.<br>");
            return;
        }
        if (txtlocalidad.Text.Trim().Length != 0)
        {
            localidad = txtlocalidad.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la localidad.<br>");
            return;
        }
        Zonas unaZona = null;
        try
        {
            unaZona = FabricaLogica.GetLogicaZona().BuscarHabilitada(departamento, localidad);
        }
        catch (ExcepcionPersonalizada ex)
        {
            if (ex.Message == "Esta zona fue dada de baja.")
            {
                btnsumar.Enabled = true;
                btnagregar.Enabled = true;
                btnbuscar.Enabled = false;
                txtnombre.Enabled = true;
                txtnuevoserv.Enabled = true;
                txthabitantes.Enabled = true;

                lblerror.Text = "Esta zona fue dada de baja, pude darla de alta.";
                return;
            }
            else
            {
                mostrarMensajeError(ex.Message);
                return;
            }
            
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al buscar la Zona.");
            return;
        }

        if (unaZona == null)
        {
            lblerror.Text = "No se encontró la zona, puede agregarla ahora.";

            txtdepartamento.Enabled = false;
            txtlocalidad.Enabled = false;

            btnsumar.Enabled = true;
            btnagregar.Enabled = true;
            txthabitantes.Enabled = true;
            txtnombre.Enabled = true;
            txtnuevoserv.Enabled = true;
        }
        else
        {
            txtnombre.Enabled = true;
            txtnombre.Text = unaZona.Nombre;
            txthabitantes.Enabled = true;
            txthabitantes.Text = Convert.ToString(unaZona.Habitantes);
            txtnuevoserv.Enabled = true;
            btneliminar.Enabled = true;
            btnmodificar.Enabled = true;
            btnsumar.Enabled = true;

            if (unaZona.Servicios.Count > 0)
            {
                gvservicios.DataSource = unaZona.Servicios;
                gvservicios.DataBind();
                Session["Lista"] = unaZona.Servicios;
            }
            else
            {
                gvservicios.DataSourceID = null;
                gvservicios.DataSource = null;
                gvservicios.DataBind();
                gvservicios.Visible = false;
                lblerror.Text = "Esta zona no tiene servicios agregados.";

            }
        }
    }

    protected void gvservicios_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string departamento = txtdepartamento.Text;
        string localidad = txtlocalidad.Text;
        try
        {
            Zonas unaZona = FabricaLogica.GetLogicaZona().Buscar(departamento, localidad);
            if (unaZona == null)
            {
                gvservicios.EditIndex = e.NewEditIndex;
                gvservicios.DataSource = Session["ListaNueva"];
                gvservicios.DataBind();
            }
            else
            {
                gvservicios.EditIndex = e.NewEditIndex;
                gvservicios.DataSource = Session["Lista"];
                gvservicios.DataBind();
            }
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al editar el Servicio.");
            return;
        }

    }

    protected void gvservicios_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        string departamento = txtdepartamento.Text;
        string localidad = txtlocalidad.Text;
        try
        {
            Zonas unaZona = FabricaLogica.GetLogicaZona().Buscar(departamento, localidad);
            gvservicios.EditIndex = -1;
            if (unaZona == null)
            {
                gvservicios.DataSource = Session["ListaNueva"];
                gvservicios.DataBind();
            }
            else
            {
                gvservicios.DataSource = Session["Lista"];
                gvservicios.DataBind();
            }
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al cancelar la modificación del Servicio.");
            return;
        }
    }

    protected void gvservicios_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            if (Session["Lista"] == null)
            {
                List<string> otraLista = (List<string>)Session["ListaNueva"];
                GridViewRow rw = gvservicios.Rows[e.RowIndex];
                if (otraLista == null)
                {
                    otraLista = new List<string>();
                }
                otraLista[e.RowIndex] = ((TextBox)(rw.Cells[2].Controls[0])).Text;
                gvservicios.EditIndex = -1;
                gvservicios.DataSource = otraLista;
                gvservicios.DataBind();
            }
            else
            {
                List<string> unaLista = (List<string>)Session["Lista"];
                GridViewRow row = gvservicios.Rows[e.RowIndex];
                unaLista[e.RowIndex] = ((TextBox)(row.Cells[2].Controls[0])).Text;
                gvservicios.EditIndex = -1;
                gvservicios.DataSource = unaLista;
                gvservicios.DataBind();
            }
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al actualizar la modificación del Servicio.");
            return;
        }
    }

    protected void gvservicios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            if (Session["Lista"] == null)
            {
                List<string> otraLista = (List<string>)Session["ListaNueva"];
                if (otraLista == null)
                {
                    otraLista = new List<string>();
                }
                otraLista.RemoveAt(e.RowIndex);
                gvservicios.EditIndex = -1;
                gvservicios.DataSource = otraLista;
                gvservicios.DataBind();
                Session["ListaNueva"] = otraLista;
                if (otraLista.Count == 0)
                {
                    Session["ListaNueva"] = null;
                    gvservicios.Visible = false;
                }
            }
            else
            {
                List<string> unaLista = (List<string>)Session["Lista"];
                if (unaLista == null)
                {
                    unaLista = new List<string>();
                }
                unaLista.RemoveAt(e.RowIndex);
                gvservicios.EditIndex = -1;
                gvservicios.DataSource = unaLista;
                gvservicios.DataBind();
                Session["Lista"] = unaLista;
                if (unaLista.Count == 0)
                {
                    Session["Lista"] = null;
                    gvservicios.Visible = false;
                }
            }
            txtnuevoserv.Text = "";
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al eliminar el Servicio.");
            return;
        }
    }

    protected void btnmodificar_Click(object sender, EventArgs e)
    {
        string departamento = "";
        string localidad = "";
        string nombre = "";
        int habitantes = 0;
        List<string> oLista = (List<string>)Session["Lista"];

        if (txtdepartamento.Text.Trim().Length != 0)
        {
            departamento = txtdepartamento.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el departamento.<br>");
            return;
        }
        if (txtlocalidad.Text.Trim().Length != 0)
        {
            localidad = txtlocalidad.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la localidad.<br>");
            return;
        }
        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre<br>");
            return;
        }
        try
        {
            habitantes = Convert.ToInt32(txthabitantes.Text);
        }
        catch
        {
            mostrarMensajeError("Ingrese los habitantes<br>");
            return;
        }
        Zonas unaZona = null;
        try
        {
            unaZona = new Zonas(departamento, localidad, nombre, habitantes, oLista);
            FabricaLogica.GetLogicaZona().Modificar(unaZona);
            lblerror.Text = "La zona fue modificada con éxito";

            LimpiarFormulario();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al modificar la Zona.");
            return;
        }
    }

    protected void btnagregar_Click(object sender, EventArgs e)
    {
        string departamento = "";
        string localidad = "";
        string nombre = "";
        int habitantes = 0;
        List<string> oLista = (List<string>)Session["ListaNueva"];

        if (txtdepartamento.Text.Trim().Length != 0)
        {
            departamento = txtdepartamento.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el departamento.<br>");
            return;
        }
        if (txtlocalidad.Text.Trim().Length != 0)
        {
            localidad = txtlocalidad.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la localidad.<br>");
            return;
        }
        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre<br>");
            return;
        }
        try
        {
            habitantes = Convert.ToInt32(txthabitantes.Text);
        }
        catch
        {
            mostrarMensajeError("Ingrese los habitantes<br>");
            return;
        }
        Zonas unaZona = null;
        try
        {
            unaZona = new Zonas(departamento, localidad, nombre, habitantes, oLista);
            FabricaLogica.GetLogicaZona().Agregar(unaZona);
            lblerror.Text = "La zona fue agregada con éxito";

            LimpiarFormulario();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al agregar la Zona.");
            return;
        }
    }
    protected void btnsumar_Click(object sender, EventArgs e)
    {
        List<string> unaLista = (List<string>)Session["ListaNueva"];
        if (Session["Lista"] != null)
        {
            List<string> otraLista = (List<string>)Session["Lista"];
            if (otraLista == null)
            {
                otraLista = new List<string>();
            }
            if (txtnuevoserv.Text.Trim().Length != 0)
            {
                gvservicios.Visible = true;
                otraLista.Add(txtnuevoserv.Text);
                gvservicios.DataSource = otraLista;
                gvservicios.DataBind();
                Session["Lista"] = otraLista;
            }
            else
            {
                mostrarMensajeError("Ingrese un servicio.");
                return;
            }
        }
        else
        {
            if (unaLista == null)
            {
                unaLista = new List<string>();
            }
            if (txtnuevoserv.Text.Trim().Length != 0)
            {
                gvservicios.Visible = true;
                unaLista.Add(txtnuevoserv.Text);
                gvservicios.DataSource = unaLista;
                gvservicios.DataBind();
                Session["ListaNueva"] = unaLista;
            }
            else
            {
                mostrarMensajeError("Ingrese un servicio.");
                return;
            }
        }
        txtnuevoserv.Text = "";
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        LimpiarFormulario();
    }

    protected void btneliminar_Click(object sender, EventArgs e)
    {
        string departamento = "";
        string localidad = "";
        string nombre = "";
        int habitantes = 0;
        List<string> oLista = (List<string>)Session["Lista"];

        if (txtdepartamento.Text.Trim().Length != 0)
        {
            departamento = txtdepartamento.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el departamento.<br>");
            return;
        }
        if (txtlocalidad.Text.Trim().Length != 0)
        {
            localidad = txtlocalidad.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese la localidad.<br>");
            return;
        }
        if (txtnombre.Text.Trim().Length != 0)
        {
            nombre = txtnombre.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre<br>");
            return;
        }
        try
        {
            habitantes = Convert.ToInt32(txthabitantes.Text);
        }
        catch
        {
            mostrarMensajeError("Ingrese los habitantes<br>");
            return;
        }
        Zonas unaZona = null;
        try
        {
            unaZona = new Zonas(departamento, localidad, nombre, habitantes, oLista);
            FabricaLogica.GetLogicaZona().Eliminar(unaZona);
            lblerror.Text = "La zona fue eliminada con éxito";

            LimpiarFormulario();
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al eliminar la Zona.");
            return;
        }
    }

    protected void LimpiarFormulario()
    {
        txtdepartamento.Enabled = true;
        txtlocalidad.Enabled = true;
        txtdepartamento.Text = "";
        txtlocalidad.Text = "";
        txtnombre.Text = "";
        txthabitantes.Text = "";
        txtnuevoserv.Text = "";
        Session["Lista"] = null;
        Session["ListaNueva"] = null;
        gvservicios.DataSourceID = null;
        gvservicios.DataSource = null;
        gvservicios.DataBind();
        gvservicios.Visible = false;

        btnbuscar.Enabled = true;
        btnmodificar.Enabled = false;
        btnagregar.Enabled = false;
        btneliminar.Enabled = false;
        btnsumar.Enabled = false;

        txtnombre.Enabled = false;
        txthabitantes.Enabled = false;
        txtnuevoserv.Enabled = false;
    }
}
