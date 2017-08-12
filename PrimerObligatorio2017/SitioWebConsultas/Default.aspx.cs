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
        if (!IsPostBack)
        {
            try
            {
                rpPropiedades.DataSource = FabricaLogica.GetLogicaPropiedad().Listar();
                rpPropiedades.DataBind();
            }
            catch
            {
                mostrarMensajeError("Ocurrio un problema al listar las propiedades");
                return;
            }
        }
    }

    protected void mostrarMensajeError(string mensajeError)
    {
        lblerror.ForeColor = System.Drawing.Color.Red;
        lblerror.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnfiltro_Click(object sender, EventArgs e)
    {
        List<Propiedad> propiedades = new List<Propiedad>();
        List<Propiedad> resultado = null;

        try
        {
            propiedades = FabricaLogica.GetLogicaPropiedad().Listar();
        }
        catch
        {
            mostrarMensajeError("Problemas al listar las propiedades.");
            return;
        }

        if (ddlAccion.SelectedIndex == 0)
        {
            mostrarMensajeError("Debe seleccionar un tipo de accion.");
            return;
        }
        else
        {
            resultado = (from pro in propiedades
                         where pro.Accion == ddlAccion.SelectedValue
                         select pro).ToList<Propiedad>();
        }

        if (ddlTipo.SelectedValue == "casa")
        {
            resultado = (from pro in resultado
                         where pro is Casa
                         select pro).ToList<Propiedad>();
        }
        else if (ddlTipo.SelectedValue == "apartamento")
        {
            resultado = (from pro in resultado
                         where pro is Apartamento
                         select pro).ToList<Propiedad>();
        }
        else if (ddlTipo.SelectedValue == "local")
        {
            resultado = (from pro in resultado
                         where pro is LocalComercial
                         select pro).ToList<Propiedad>();
        }

        if (ddlDepa.SelectedIndex != 0)
        {
            resultado = (from pro in resultado
                         where pro.UnaZona.Departamento == ddlDepa.SelectedValue
                         select pro).ToList<Propiedad>();
        }

        if (ddlLocalidad.SelectedIndex != 0)
        {
            resultado = (from pro in resultado
                         where pro.UnaZona.Departamento == ddlDepa.SelectedValue && pro.UnaZona.Localidad == ddlLocalidad.SelectedValue
                         select pro).ToList<Propiedad>();
        }
        int menor = 0;
        if (!String.IsNullOrWhiteSpace(txtMenor.Text))
        {

            try
            {
                menor = Convert.ToInt32(txtMenor.Text);

                if (menor <= 0)
                {
                    mostrarMensajeError("El precio debe ser mayor a cero.");
                    return;
                }
            }
            catch (FormatException)
            {
                mostrarMensajeError("El precio debe ser un numero entero");
                return;
            }

            resultado = (from pro in resultado
                         where pro.Precio >= menor
                         select pro).ToList<Propiedad>();
        }
        int mayor = 0;
        if (!String.IsNullOrWhiteSpace(txtMayor.Text))
        {

            try
            {
                mayor = Convert.ToInt32(txtMayor.Text);

                if (mayor <= 0)
                {
                    mostrarMensajeError("El precio debe ser mayor a cero.");
                    return;
                }
                if (menor == 0)
                {
                    mostrarMensajeError("Ingrese un precio menor.");
                    return;
                }
                if (mayor <= menor)
                {
                    mostrarMensajeError("Ingrese un precio mayor al precio menor anteriormente ingresado");
                    return;
                }
            }
            catch (FormatException)
            {
                mostrarMensajeError("El precio debe ser un numero entero");
                return;
            }

            resultado = (from pro in resultado
                         where pro.Precio <= mayor
                         select pro).ToList<Propiedad>();
        }
        if (menor > 0 && mayor == 0)
        {
            mostrarMensajeError("Si ingresa un precio menor, ingrese también un precio mayor.");
            return;
        }
        try
        {
            rpPropiedades.DataSource = resultado;
            rpPropiedades.DataBind();
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al listar las propiedades");
            return;
        }
        if (resultado.Count == 0)
        {
            lblerror.Text = "Por el momento no hay propiedades con éstas caractericticas";
        }
    }

    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        ddlAccion.SelectedIndex = 0;
        ddlTipo.SelectedIndex = 0;
        ddlDepa.SelectedIndex = 0;
        ddlLocalidad.Items.Clear();
        ddlLocalidad.Items.Insert(0, new ListItem("Todas las Zonas"));
        ddlLocalidad.SelectedIndex = 0;
        ddlLocalidad.Enabled = false;
        txtMayor.Text = string.Empty;
        txtMenor.Text = string.Empty;

        try
        {
            rpPropiedades.DataSource = FabricaLogica.GetLogicaPropiedad().Listar();
            rpPropiedades.DataBind();
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al listar las propiedades");
            return;
        }
    }

    protected void drppaccion_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlAccion.SelectedIndex == 0)
        {
            btnfiltro.Enabled = false;
        }
        else
        {
            btnfiltro.Enabled = true;
        }
    }

    protected void rpPropiedades_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "VerPropiedad")
        {
            try
            {
                Propiedad pro = Logica.FabricaLogica.GetLogicaPropiedad().Buscar(Convert.ToInt32(((TextBox)(e.Item.Controls[1])).Text));

                if (pro != null)
                {
                    Session["Propiedad"] = pro;
                    
                }
                else
                {
                    mostrarMensajeError("No se encontro la propiedad.");
                    return;
                }
            }
            catch (ExcepcionPersonalizada ex)
            {
                mostrarMensajeError(ex.Message);
                return;
            }
            catch (Exception ex)
            {
                mostrarMensajeError("Ocurrio un problema al buscar la propiedad.");
                return;
            }
            Response.Redirect("~/ConsultaDePropiedad.aspx");
        }
    }

    protected void ddlDepa_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlDepa.SelectedIndex == 0)
        {
            ddlLocalidad.Enabled = false;
            ddlLocalidad.Items.Clear();
            ddlLocalidad.Items.Insert(0, new ListItem("Todas las Zonas"));
            ddlLocalidad.SelectedIndex = 0;
        }
        else
        {
            ddlLocalidad.Enabled = true;

            try
            {
                List<Zonas> zonas = (from zona in Logica.FabricaLogica.GetLogicaZona().Listar()
                                     where zona.Departamento == ddlDepa.SelectedValue
                                     select zona).ToList<Zonas>();
                ddlLocalidad.Items.Clear();

                if (zonas.Count == 0)
                {
                    ddlLocalidad.Items.Insert(0, new ListItem("No se encontraron Zonas"));
                    ddlLocalidad.Enabled = false;
                }
                else
                {
                    foreach (Zonas z in zonas)
                    {
                        ddlLocalidad.Items.Add(new ListItem(z.Nombre, z.Localidad));
                    }

                    ddlLocalidad.Items.Insert(0, new ListItem("Todas las Zonas"));
                }
            }
            catch
            {
                mostrarMensajeError("Ocurrio un problema al listar las zonas.");
                return;
            }
        }
    }
}