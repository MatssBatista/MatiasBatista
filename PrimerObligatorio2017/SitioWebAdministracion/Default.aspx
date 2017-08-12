<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 23px;
            text-align: left;
        }
        .style2
        {}
        .style3
        {
            height: 23px;
            width: 418px;
        }
        .style4
        {
            width: 419px;
        }
        .style5
        {
            height: 23px;
            width: 419px;
        }
        .style6
        {
            width: 348px;
        }
        .style7
        {
            height: 23px;
            width: 348px;
        }
        .style8
        {
            height: 23px;
        }
        .style9
        {
            height: 22px;
        }
        .style10
        {
            width: 419px;
            height: 22px;
        }
        .style11
        {
            color: #000000;
        }
        .style12
        {
            font-size: x-large;
            font-family: Calibri;
        }
    </style>
</head>
<body bgcolor="#c0d6d6">
    <form id="form1" runat="server">
    <div>
    
        <table style="width: 87%;">
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center" class="style12">
                    <strong>BiosRealState</strong></td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1" colspan="4">
                    <asp:Label ID="lblbienvenida" runat="server" 
                        style="text-align: center; color: #000000;" 
                        
                        Text="Bienvenido/a al sitio web de BiosRealState por favor ingrese nombre de Usuario y contraseña para acceder a nuestro sitio, muchas gracas."></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td style="text-align: left" class="style6">
                    <asp:Label ID="lblnombre" runat="server" style="text-align: center; " 
                        Text="Nombre de Usuario:" CssClass="style11"></asp:Label>
                &nbsp;<asp:TextBox ID="txtNomLogueo" runat="server" Width="198px"></asp:TextBox>
                </td>
                <td style="text-align: center">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style7">
                    <asp:Label ID="lblcontraseña" runat="server" Text="Contraseña:" 
                        CssClass="style11"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtContraseña" runat="server" Width="198px" 
                        TextMode="Password"></asp:TextBox>
                </td>
                <td class="style1">
                    <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click1" Text="IR" />
                </td>
                <td class="style1">
                    </td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style1" colspan="2">
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style1" colspan="4">
            <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                </td>
                <td class="style1" colspan="2">
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    </td>
                <td colspan="2" class="style9">
                    </td>
                <td class="style10">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style1">
                    </td>
                <td class="style1" colspan="2">
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style8">
                    </td>
                <td colspan="2" class="style8">
                    </td>
                <td class="style5">
                    </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td colspan="2">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
