using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using EntidadesCompartidas;


namespace Controles
{
    public class ControlPropiedad : WebControl, INamingContainer
    {

        private Label lblpadron;
        private Label lbldireccion;
        private Label lblprecio;
        private Label lblaccion;
        private Label lblbaños;
        private Label lblhabitaciones;
        private Label lbltamaño;
        private Label lbldepartamento;
        private Label lbllocalidad;
        private Label lblnombre;
        private Label lblhabitantes;
        private Label lblterreno;
        private Label lbljardin;
        private Label lblpiso;
        private Label lblascensor;
        private Label lblhabilitacion;

        Table tabla;
        TableRow fila1;
        TableRow fila2;
        TableRow fila3;
        TableRow fila4;
        TableRow fila5;
        TableRow fila6;
        TableRow fila7;
        TableRow fila8;
        TableRow fila9;
        TableRow fila10;
        TableRow fila11;
        TableRow fila12;
        TableRow fila13;
        TableRow fila14;
        TableRow fila15;
        TableRow fila16;
        TableCell celda1;
        TableCell celda2;
        TableCell celda3;
        TableCell celda4;
        TableCell celda5;
        TableCell celda6;
        TableCell celda7;
        TableCell celda8;
        TableCell celda9;
        TableCell celda10;
        TableCell celda11;
        TableCell celda12;
        TableCell celda13;
        TableCell celda14;
        TableCell celda15;
        TableCell celda16;
        TableCell celda17;
        TableCell celda18;
        TableCell celda19;
        TableCell celda20;
        TableCell celda21;
        TableCell celda22;
        TableCell celda23;
        TableCell celda24;
        TableCell celda25;
        TableCell celda26;
        TableCell celda27;
        TableCell celda28;
        TableCell celda29;
        TableCell celda30;
        TableCell celda31;
        TableCell celda32;
        
        private Panel panel;

        public void Cargar(Propiedad propiedad)
        {
            EnsureChildControls();

            lblpadron.Text = propiedad.Padron.ToString();
            lbldireccion.Text = propiedad.Direccion;
            lblprecio.Text = propiedad.Precio.ToString();
            lblaccion.Text = propiedad.Accion;
            lblbaños.Text = propiedad.Baños.ToString();
            lblhabitaciones.Text = propiedad.Habitaciones.ToString();
            lbltamaño.Text = propiedad.Tamaño.ToString();
            lbldepartamento.Text = propiedad.UnaZona.Departamento;
            lbllocalidad.Text = propiedad.UnaZona.Localidad;
            lblnombre.Text = propiedad.UnaZona.Nombre;
            lblhabitantes.Text = propiedad.UnaZona.Habitantes.ToString();

            if (propiedad is Casa)
            {
                Casa unaCasa = (Casa)propiedad;
                lblterreno.Text = unaCasa.Terreno.ToString();
                if (unaCasa.Jardin == true)
                {
                    lbljardin.Text = "Si";
                }
                else
                {
                    lbljardin.Text = "No";
                }                
                lblascensor.Text = ".........";
                lblpiso.Text = "..........";
            }
            else if (propiedad is Apartamento)
            {
                Apartamento unApto = (Apartamento)propiedad;
                if (unApto.Ascensor==true)
                {
                lblascensor.Text = "Si";                
                }
                else
                {
                    lblascensor.Text = "No";       
                }                
                lblpiso.Text = unApto.Piso.ToString();
                lblterreno.Text = ".........";
                lbljardin.Text = ".........";
            }
            else
            {
                LocalComercial unLocal = (LocalComercial)propiedad;
                if (unLocal.Habilitacion == true)
                {
                    lblhabilitacion.Text = "Si";                   
                }
                else
                {
                    lblhabilitacion.Text = "No";                    
                }
                lblascensor.Text = ".........";
                lblpiso.Text = "...........";
                lblterreno.Text = ".........";
                lbljardin.Text = ".........";
            }
        }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            panel = new Panel();
            tabla = new Table();
            fila1 = new TableRow();
            fila2 = new TableRow();
            fila3 = new TableRow();
            fila4 = new TableRow();
            fila5 = new TableRow();
            fila6 = new TableRow();
            fila7 = new TableRow();
            fila8 = new TableRow();
            fila9 = new TableRow();
            fila10 = new TableRow();
            fila11 = new TableRow();
            fila12 = new TableRow();
            fila13 = new TableRow();
            fila14 = new TableRow();
            fila15 = new TableRow();
            fila16 = new TableRow();
            tabla.ID = "tbtabla";
            tabla.BorderStyle = BorderStyle.Solid;
            celda1 = new TableCell();
            celda2 = new TableCell();
            celda3 = new TableCell();
            celda4 = new TableCell();
            celda5 = new TableCell();
            celda6 = new TableCell();
            celda7 = new TableCell();
            celda8 = new TableCell();
            celda9 = new TableCell();
            celda10 = new TableCell();
            celda11 = new TableCell();
            celda12 = new TableCell();
            celda13 = new TableCell();
            celda14 = new TableCell();
            celda15 = new TableCell();
            celda16 = new TableCell();
            celda17 = new TableCell();
            celda18 = new TableCell();
            celda19 = new TableCell();
            celda20 = new TableCell();
            celda21 = new TableCell();
            celda22 = new TableCell();
            celda23 = new TableCell();
            celda24 = new TableCell();
            celda25 = new TableCell();
            celda26 = new TableCell();
            celda27 = new TableCell();
            celda28 = new TableCell();
            celda29 = new TableCell();
            celda30 = new TableCell();
            celda31 = new TableCell();
            celda32 = new TableCell();
            lblpadron = new Label();
            lbldireccion = new Label();
            lblprecio = new Label();
            lblaccion = new Label();
            lblbaños = new Label();
            lblhabitaciones = new Label();
            lbltamaño = new Label();
            lbldepartamento = new Label();
            lbllocalidad = new Label();
            lblnombre = new Label();
            lblhabitantes = new Label();
            lblterreno = new Label();
            lbljardin = new Label();
            lblpiso = new Label();
            lblascensor = new Label();
            lblhabilitacion = new Label();
            celda1.Text = "Padrón:";
            celda2.Controls.Add(lblpadron);
            celda3.Text = "Dirección: ";
            celda4.Controls.Add(lbldireccion);
            celda5.Text = "Precio:";
            celda6.Controls.Add(lblprecio);
            celda7.Text = "Acción:";
            celda8.Controls.Add(lblaccion);
            celda9.Text = "Baños:";
            celda10.Controls.Add(lblbaños);
            celda11.Text = "Habitaciones:";
            celda12.Controls.Add(lblhabitaciones);
            celda13.Text = "Tamaño(m²):";
            celda14.Controls.Add(lbltamaño);
            celda15.Text = "Terreno:";
            celda16.Controls.Add(lblterreno);
            celda17.Text = "Jardín:";
            celda18.Controls.Add(lbljardin);
            celda19.Text = "Piso:";
            celda20.Controls.Add(lblpiso);
            celda21.Text = "Ascensor:";
            celda22.Controls.Add(lblascensor);
            celda23.Text = "Habilitación:";
            celda24.Controls.Add(lblhabilitacion);
            celda25.Text = "Departamento:";
            celda26.Controls.Add(lbldepartamento);
            celda27.Text = "Localidad:";
            celda28.Controls.Add(lbllocalidad);
            celda29.Text = "Nombre:";
            celda30.Controls.Add(lblnombre);
            celda31.Text = "Habitantes:";
            celda32.Controls.Add(lblhabitantes);
            fila1.Cells.Add(celda1);
            fila1.Cells.Add(celda2);
            fila2.Cells.Add(celda3);
            fila2.Cells.Add(celda4);
            fila3.Cells.Add(celda5);
            fila3.Cells.Add(celda6);
            fila4.Cells.Add(celda7);
            fila4.Cells.Add(celda8);
            fila5.Cells.Add(celda9);
            fila5.Cells.Add(celda10);
            fila6.Cells.Add(celda11);
            fila6.Cells.Add(celda12);
            fila7.Cells.Add(celda13);
            fila7.Cells.Add(celda14);
            fila8.Cells.Add(celda15);
            fila8.Cells.Add(celda16);
            fila9.Cells.Add(celda17);
            fila9.Cells.Add(celda18);
            fila10.Cells.Add(celda19);
            fila10.Cells.Add(celda20);
            fila11.Cells.Add(celda21);
            fila11.Cells.Add(celda22);
            fila12.Cells.Add(celda23);
            fila12.Cells.Add(celda24);
            fila13.Cells.Add(celda25);
            fila13.Cells.Add(celda26);
            fila14.Cells.Add(celda27);
            fila14.Cells.Add(celda28);
            fila15.Cells.Add(celda29);
            fila15.Cells.Add(celda30);
            fila16.Cells.Add(celda31);
            fila16.Cells.Add(celda32);
            tabla.Rows.Add(fila1);
            tabla.Rows.Add(fila2);
            tabla.Rows.Add(fila3);
            tabla.Rows.Add(fila4);
            tabla.Rows.Add(fila5);
            tabla.Rows.Add(fila6);
            tabla.Rows.Add(fila7);
            tabla.Rows.Add(fila8);
            tabla.Rows.Add(fila9);
            tabla.Rows.Add(fila10);
            tabla.Rows.Add(fila11);
            tabla.Rows.Add(fila12);
            tabla.Rows.Add(fila13);
            tabla.Rows.Add(fila14);
            tabla.Rows.Add(fila15);
            tabla.Rows.Add(fila16);
            panel.Controls.Add(tabla);

            this.Controls.Add(panel);

        }
    }
}
