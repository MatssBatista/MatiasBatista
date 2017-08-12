<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 1163px;
        }
        .style2
        {
            width: 173px;
        }
        .style3
        {
            width: 173px;
            height: 31px;
        }
        .style4
        {
            width: 1163px;
            height: 31px;
        }
        .style5
        {
            height: 31px;
        }
        .style6
        {
            width: 173px;
            height: 23px;
        }
        .style7
        {
            width: 1163px;
            height: 23px;
        }
        .style8
        {
            height: 23px;
        }
        .style9
        {
            width: 1163px;
            font-size: x-large;
            font-family: Calibri;
        }
        .style10
        {
            width: 1163px;
            height: 23px;
            font-family: Calibri;
            font-size: large;
        }
    </style>
</head>
<body bgcolor="#ebd7c2">
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style9" style="text-align: center">
                    BiosRealState</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style10" style="text-align: center">
                    <strong>CONSULTA DE PROPIEDADES</strong></td>
                <td class="style8">
                    </td>
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
                    Buscar propiedades por </td>
                <td class="style1">
                    Acción:&nbsp;
                    <asp:DropDownList ID="ddlAccion" runat="server" Height="20px" Width="168px" 
                        AutoPostBack="True" onselectedindexchanged="drppaccion_SelectedIndexChanged">
                        <asp:ListItem Value="0">Seleccione una accion</asp:ListItem>
                        <asp:ListItem Value="venta">Venta</asp:ListItem>
                        <asp:ListItem Value="alquiler">Alquiler</asp:ListItem>
                        <asp:ListItem Value="permuta">Permuta</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    Tipo:
                    <asp:DropDownList ID="ddlTipo" runat="server" Height="20px" Width="172px">
                        <asp:ListItem Value="0">Todas las Propiedades</asp:ListItem>
                        <asp:ListItem Value="casa">Casas</asp:ListItem>
                        <asp:ListItem Value="apartamento">Apartamentos</asp:ListItem>
                        <asp:ListItem Value="local">Locales Comerciales</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    Departamento: 
                    <asp:DropDownList ID="ddlDepa" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="ddlDepa_SelectedIndexChanged1" Height="20px">
                        <asp:ListItem>Todos los Departamentos</asp:ListItem>
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
                &nbsp;&nbsp;Localidad:
                    <asp:DropDownList ID="ddlLocalidad" runat="server" Height="20px" Width="158px" 
                        Enabled="False">
                        <asp:ListItem>Todas las Zonas</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    Menor Precio:
                    <asp:TextBox ID="txtMenor" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style6">
                    </td>
                <td class="style7">
                    Mayor Precio: <asp:TextBox ID="txtMayor" runat="server"></asp:TextBox>
                    </td>
                <td class="style8">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td class="style1">
                    <asp:Button ID="btnfiltro" runat="server" onclick="btnfiltro_Click" 
                        Text="Aplicar Filtro" />
&nbsp;<asp:Button ID="btnlimpiar" runat="server" Text="Limpiar Filtro" 
                        onclick="btnlimpiar_Click" />
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Repeater ID="rpPropiedades" runat="server" 
                        onitemcommand="rpPropiedades_ItemCommand">
                    <ItemTemplate>
                        <table>
                            <tr bgcolor="#419683">
                                 <td> Pdn:  <asp:TextBox ID="txtppadron" runat="server" ReadOnly ="true" Text = '<%# Bind("Padron") %>'></asp:TextBox> <br /> </td>
                                <td> Dir:  <asp:TextBox ID="txtpdireccion" runat="server" ReadOnly ="true" Text='<%# Bind("Direccion") %>'></asp:TextBox> <br /> </td>
                                <td> Zna:  <asp:TextBox ID="txtpzona" runat="server" ReadOnly ="true" Text = '<%# Bind("Unazona.Nombre") %>'></asp:TextBox> <br /> </td>
                                <td> Acc:  <asp:TextBox ID="txtpaccion" runat="server" ReadOnly ="true" Text='<%# Bind("Accion") %>'></asp:TextBox> <br /> </td>
                                <td> <asp:Button ID="Button" runat="server" CommandName="VerPropiedad" style="text-align: center" Text="Ver la Propiedad" /> </td>
                              </tr>
                        </table>   
                    </ItemTemplate>
                    <AlternatingItemTemplate>
                        <table>
                            <tr bgcolor="#9FE9D8">
                                <td> Pdn:  <asp:TextBox ID="txtppadron" runat="server" ReadOnly ="true" Text = '<%# Bind("Padron") %>'></asp:TextBox> <br /> </td>
                                <td> Dir:  <asp:TextBox ID="txtpdireccion" runat="server" ReadOnly ="true" Text='<%# Bind("Direccion") %>'></asp:TextBox> <br /> </td>
                                <td> Zna:  <asp:TextBox ID="txtpzona" runat="server" ReadOnly ="true" Text = '<%# Bind("Unazona.Nombre") %>'></asp:TextBox> <br /> </td>
                                <td> Acc:  <asp:TextBox ID="txtpaccion" runat="server" ReadOnly ="true"  Text='<%# Bind("Accion") %>'></asp:TextBox> <br /> </td>
                                <td> <asp:Button ID="Button" runat="server" CommandName="VerPropiedad" style="text-align: center" Text="Ver la Propiedad" />  </td>
                           </tr>
                        </table>
                    </AlternatingItemTemplate>       
                    </asp:Repeater>
                </td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3" class="style8">
                    <asp:Label ID="lblerror" runat="server" EnableViewState="False"></asp:Label>
                </td>
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
                <td class="style3">
                    </td>
                <td class="style4">
                    </td>
                <td class="style5">
                    </td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
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
        </table>
    
    </div>
    </form>
</body>
</html>
