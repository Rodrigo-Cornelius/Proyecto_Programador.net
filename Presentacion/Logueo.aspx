<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Logueo.aspx.cs" Inherits="Logueo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" style="width: 40%;">
            <tr>
                <td align="center" colspan="2">
                    <asp:Label ID="Label1" runat="server" 
                        Text="Bienvenido al Sistema de Pronosticos"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                </td>
            </tr>
            <tr>
                <td align="right" class="style2">
&nbsp;<asp:Label ID="Label2" runat="server" Text="Usuario:"></asp:Label>
                </td>
                <td align="center" class="style1">
                    <asp:TextBox ID="txtUsu" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" class="style4">
                    <asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="txtPass" runat="server" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" 
                        onclick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:Label ID="lblerror" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" class="style3" colspan="2">
                    <asp:LinkButton ID="lbtnVolver" runat="server" PostBackUrl="~/Default.aspx">Volver</asp:LinkButton>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
