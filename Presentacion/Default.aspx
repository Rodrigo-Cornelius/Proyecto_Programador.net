<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table style="width:100%;">
            <tr>
                <td align="center" colspan="3">
                    <asp:Label ID="Label1" runat="server" Text="LISTADO DE PRONOSTICOS DEL DIA"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <asp:Label ID="lblFecha" runat="server"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="3">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:TextBox ID="txtListado" runat="server" Height="500px" Width="500px" TextMode="MultiLine" Wrap="true">
                        </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="lblError" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="3">
                    <asp:LinkButton ID="lbLogin" runat="server" onclick="lbLogin_Click" 
                        PostBackUrl="~/Logueo.aspx">LOGIN</asp:LinkButton>
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
