<%@ Page Title="" Language="C#" MasterPageFile="~/MasterEmpleado.master" AutoEventWireup="true" CodeFile="ABMZonas.aspx.cs" Inherits="ABMZonas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
        }
        .style2
        {
            width: 95px;
            height: 23px;
        }
        .style3
        {
            height: 23px;
        }
        .style4
        {
            width: 378px;
        }
        .style5
        {
            height: 23px;
            width: 378px;
        }
        .style6
        {
            width: 95px;
            height: 26px;
        }
        .style7
        {
            width: 378px;
            height: 26px;
        }
        .style8
        {
            height: 26px;
        }
        .style9
        {
            height: 22px;
        }
        .style10
        {
            width: 378px;
            height: 22px;
        }
        .style11
        {
            width: 378px;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style11">
                ABM Zonas</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                Departamento:
            </td>
            <td class="style4">
                <asp:TextBox ID="txtdepartamento" runat="server" Width="16px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                Localidad:</td>
            <td class="style5">
                <asp:TextBox ID="txtlocalidad" runat="server" Width="60px"></asp:TextBox>
                <asp:Button ID="btnbuscar" runat="server" Text="Buscar" 
                    onclick="btnbuscar_Click" />
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1">
                Nombre:</td>
            <td class="style4">
                <asp:TextBox ID="txtnombre" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style6">
                Habitantes.</td>
            <td class="style7">
                <asp:TextBox ID="txthabitantes" runat="server" Enabled="False"></asp:TextBox>
            </td>
            <td class="style8">
            </td>
        </tr>
        <tr>
            <td class="style1">
                Servicios:</td>
            <td class="style4">
                <asp:TextBox ID="txtnuevoserv" runat="server" Width="283px" Enabled="False"></asp:TextBox>
                <asp:Button ID="btnsumar" runat="server" onclick="btnsumar_Click" 
                    Text="Sumar" Enabled="False" />
                <br />
                <asp:GridView ID="gvservicios" runat="server" 
                    onrowcancelingedit="gvservicios_RowCancelingEdit" 
                    onrowediting="gvservicios_RowEditing" 
                    onrowupdating="gvservicios_RowUpdating" 
                    onrowdeleting="gvservicios_RowDeleting">
                    <Columns>
                        <asp:CommandField HeaderText="Editar" ShowEditButton="True" ShowHeader="True" />
                         <asp:CommandField HeaderText="Eliminar" ShowDeleteButton="True" ShowHeader="True" />
                    </Columns>

                    <EmptyDataTemplate>
                        <asp:TextBox ID="txtservicios" runat="server"> </asp:TextBox>
                    </EmptyDataTemplate>

                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:Button ID="btnagregar" runat="server" Text="Agregar" 
                    onclick="btnagregar_Click" Enabled="False" />
&nbsp;
                <asp:Button ID="btnmodificar" runat="server" Text="Modificar" 
                    onclick="btnmodificar_Click" Enabled="False" />
&nbsp;
                <asp:Button ID="btneliminar" runat="server" Text="Eliminar" 
                    onclick="btneliminar_Click" Enabled="False" />
&nbsp;
                <asp:Button ID="btnlimpiar" runat="server" Text="Limpar Formulario" 
                    onclick="btnlimpiar_Click" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:Label ID="lblerror" runat="server" 
                    style="font-weight: 700; color: #000000; background-color: #FFFFFF" 
                    EnableViewState="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
                </td>
            <td class="style5">
                </td>
            <td class="style3">
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style9">
                </td>
            <td class="style10">
                </td>
            <td class="style9">
                </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">
            </td>
            <td class="style5">
            </td>
            <td class="style3">
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

