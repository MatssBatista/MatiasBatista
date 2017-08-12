<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpleado.master" AutoEventWireup="true" CodeFile="ABMCasas.aspx.cs" Inherits="ABMCasas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">

        .style2
        {
            width: 159px;
        }
        .style1
        {
            width: 197px;
        }
        .style3
        {
            width: 159px;
            height: 26px;
        }
        .style4
        {
            width: 197px;
            height: 26px;
        }
        .style5
        {
            height: 26px;
        }
        .style6
        {
            width: 159px;
            height: 25px;
        }
        .style7
        {
            width: 197px;
            height: 25px;
        }
        .style8
        {
            height: 25px;
        }
        .style9
        {
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p class="style9">
        ABM Casa</p>
    <p>
        &nbsp;</p>
    <p>
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    Padron:</td>
                <td class="style1">
                    <asp:TextBox ID="txtPadron" runat="server"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" Text="Buscar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Departamento:</td>
                <td class="style1">
                    <asp:DropDownList ID="ddlDepa" runat="server" Enabled="False">
                        <asp:ListItem Value="G">Artigas</asp:ListItem>
                        <asp:ListItem Value="A">Canelones</asp:ListItem>
                        <asp:ListItem Value="E">Cerro Largo</asp:ListItem>
                        <asp:ListItem Value="L">Colonia</asp:ListItem>
                        <asp:ListItem Value="Q">Durazno</asp:ListItem>
                        <asp:ListItem Value="N">Flores</asp:ListItem>
                        <asp:ListItem Value="O">Florida</asp:ListItem>
                        <asp:ListItem Value="P">Lavalleja</asp:ListItem>
                        <asp:ListItem Value="B">Maldonado</asp:ListItem>
                        <asp:ListItem Value="S">Montevideo</asp:ListItem>
                        <asp:ListItem Value="I">Paysandú</asp:ListItem>
                        <asp:ListItem Value="J">Río Negro</asp:ListItem>
                        <asp:ListItem Value="F">Rivera</asp:ListItem>
                        <asp:ListItem Value="C">Rocha</asp:ListItem>
                        <asp:ListItem Value="H">Salto</asp:ListItem>
                        <asp:ListItem Value="M">San José</asp:ListItem>
                        <asp:ListItem Value="K">Soriano</asp:ListItem>
                        <asp:ListItem Value="R">Tacuarembó</asp:ListItem>
                        <asp:ListItem Value="D">Treinta y Tres</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Localidad:</td>
                <td class="style1">
                    <asp:TextBox ID="txtLoca" runat="server" Enabled="False"></asp:TextBox>
&nbsp;<asp:Button ID="btnBuscarZona" runat="server" Enabled="False" onclick="btnBuscarZona_Click" 
                        Text="Buscar" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Zona:</td>
                <td class="style1">
                    <asp:Label ID="lblZona" runat="server" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    Direccion:</td>
                <td class="style4">
                    <asp:TextBox ID="txtDireccion" runat="server" Enabled="False" Width="206px"></asp:TextBox>
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Empleado:</td>
                <td class="style1">
                    <asp:TextBox ID="txtEmpleado" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Accion:</td>
                <td class="style1">
                    <asp:DropDownList ID="ddlAccion" runat="server" Enabled="False">
                        <asp:ListItem Value="venta">Venta</asp:ListItem>
                        <asp:ListItem Value="alquiler">Alquiler</asp:ListItem>
                        <asp:ListItem Value="permuta">Permuta</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Precio:</td>
                <td class="style1">
                    <asp:TextBox ID="txtPrecio" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Tamaño:</td>
                <td class="style1">
                    <asp:TextBox ID="txtTamaño" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Habitaciones:</td>
                <td class="style1">
                    <asp:TextBox ID="txtHabitacion" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    Baños:</td>
                <td class="style1">
                    <asp:TextBox ID="txtBaño" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    Fondo o jardin:</td>
                <td class="style7">
&nbsp;<asp:RadioButton ID="rbtnSi" runat="server" GroupName="ascensor" Text="Si" Enabled="False" />
&nbsp;<asp:RadioButton ID="rbtnNo" runat="server" Checked="True" GroupName="ascensor" Text="No" 
                        Enabled="False" />
                </td>
                <td class="style8">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Tamaño del terreno</td>
                <td class="style1">
                    <asp:TextBox ID="txtTerreno" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" 
                        onclick="btnAgregar_Click" Enabled="False" />
&nbsp;
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" Enabled="False" 
                        onclick="btnModificar_Click" />
                </td>
                <td class="style1">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" Enabled="False" 
                        onclick="btnEliminar_Click" />
&nbsp;
                    <asp:Button ID="btnLimpiar" runat="server" Text="Limpiar formulario" 
                        Width="117px" onclick="btnLimpiar_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    </p>
    <p>
        <asp:Label ID="lblMensaje" runat="server" EnableViewState="False"></asp:Label>
    </p>
</asp:Content>

