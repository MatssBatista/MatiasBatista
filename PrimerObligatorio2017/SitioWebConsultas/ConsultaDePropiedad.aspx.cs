using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;
using Logica;

public partial class ConsultaDePropiedad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!IsPostBack)
        {            
            Propiedad p = (Propiedad)Session["Propiedad"];
            if (p is Casa)
            {
                Casa unaCasa = (Casa)p;
                ControlPropiedad1.Cargar(unaCasa);
            }
            else if (p is Apartamento)
            {
                Apartamento unApto = (Apartamento)p;
                ControlPropiedad1.Cargar(unApto);
            }
            else
            {
                LocalComercial unLocal = (LocalComercial)p;
                ControlPropiedad1.Cargar(unLocal);
            }                        
            clnvisita.SelectedDate = DateTime.Today;
        }       
    }
    protected void mostrarMensajeError(string mensajeError)
    {
        lblerror.ForeColor = System.Drawing.Color.Red;
        lblerror.Text = "¡ERROR! " + mensajeError;
    }

    protected void btnvisita_Click(object sender, EventArgs e)
    {
        int codigo = 1;
        string nombre = "";
        DateTime fecha = DateTime.Now;
        int hora = 0;
        int minutos = 0;
        string telefono = "";
        Propiedad p = p = (Propiedad)Session["Propiedad"];
        List<Visita> Lista = null;

        try
        {
            Lista = FabricaLogica.GetLogicaVisita().Listar(p.Padron);
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrio un problema al buscar las visitas");
            return;
        }

        if (txtnombrev.Text.Trim().Length != 0)
        {
            nombre = txtnombrev.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el nombre.<br>");
            return;
        }
        if (txttelv.Text.Trim().Length != 0)
        {
            telefono = txttelv.Text;
        }
        else
        {
            mostrarMensajeError("Ingrese el teléfono.<br>");
            return;
        }
        try
        {
            hora = Convert.ToInt32(txthora.Text);

            if (hora <= 0 || hora >= 23)
            {
                mostrarMensajeError("Ingrese una hora real");
                return;
            }
        }
        catch (FormatException)
        {
            mostrarMensajeError("Ingrese la hora en números.");
            return;
        }
        try
        {
            minutos = Convert.ToInt32(txtminutos.Text);

            if (minutos < 0 || minutos >= 59)
            {
                mostrarMensajeError("Ingrese los minutos correctamente");
                return;
            }
        }
        catch (FormatException)
        {
            mostrarMensajeError("Ingrese los minutos en números.");
            return;
        } 
        try
        {
            fecha = Convert.ToDateTime(clnvisita.SelectedDate.Day + "/" + clnvisita.SelectedDate.Month + "/" + clnvisita.SelectedDate.Year + " " + hora + ":" + minutos);
            DateTime fechalimite = fecha.AddMinutes(60);
            DateTime actuallimite = DateTime.Now.AddMinutes(60);
            if (fecha.DayOfYear == DateTime.Now.DayOfYear && fechalimite < actuallimite)
            {
                mostrarMensajeError("La visita tiene que tener como mínimo una hora de anticipación.");
                return;
            }
        }
        catch
        {
            mostrarMensajeError("Tiene que ingresar día y hora.");
            return;
        }        
        
        Visita unaVisita = null;
        try
        {
            unaVisita = new Visita(codigo, fecha, nombre, telefono, p);           
            int i = 1;
            int z = 1;
            if (Lista.Count == 0)
            {
                FabricaLogica.GetLogicaVisita().Agregar(unaVisita);
                lblerror.Text = "La visita fue agregada con éxito";
                txtnombrev.Text = "";
                txttelv.Text = "";
                txthora.Text = "";
                txtminutos.Text = "";    
            }
            else
            {
                foreach (Visita unVisitante in Lista)
                {
                    if (unVisitante.Telefono == unaVisita.Telefono)
                    {
                        i++;
                        if (i > 2)
                        {
                            mostrarMensajeError("No se pueden hacer mas de dos visitas para la misma propiedad");
                            return;
                        }
                    }
                    if (unVisitante.Telefono == unaVisita.Telefono && unVisitante.Fecha.Day == unaVisita.Fecha.Day && unVisitante.Fecha.Month == unaVisita.Fecha.Month && unVisitante.Fecha.Year == unaVisita.Fecha.Year)
                    {
                        z++;
                        if (z >= 1)
                        {
                            mostrarMensajeError("No se pueden hacer mas de una visita por dia a la misma propiedad");
                            return;
                        }
                    }
                    if (i > 2 && z >= 1)
                    {
                        mostrarMensajeError("Ésta visita no se puede realizar");
                        return;
                    }
                    else
                    {
                        FabricaLogica.GetLogicaVisita().Agregar(unaVisita);
                        lblerror.Text = "La visita fue agregada con éxito";
                        txtnombrev.Text = "";
                        txttelv.Text = "";
                        txthora.Text = "";
                        txtminutos.Text = "";    
                    }
                }
            }
        }
        catch (ExcepcionPersonalizada ex)
        {
            mostrarMensajeError(ex.Message);
            return;
        }
        catch
        {
            mostrarMensajeError("Ocurrió un problema al agregar la visita.");
            return;
        }
    }
    protected void btnlimpiar_Click(object sender, EventArgs e)
    {
        txtnombrev.Text = "";
        txttelv.Text = "";
        txthora.Text = "";
        txtminutos.Text = "";        
    }   
}