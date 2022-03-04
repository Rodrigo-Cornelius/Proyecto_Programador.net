<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ABMPaises.aspx.cs" Inherits="ABMPaises" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table align="center" style="width: 29%;">
        <tr>
            <td align="center" class="style2">
                <asp:Label ID="lblTitulo" runat="server" Text="ABM PAISES" Font-Bold="True" 
                    Font-Size="X-Large" ForeColor="#FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblcod" runat="server" Text="Codigo:"></asp:Label>
                <asp:TextBox ID="txtCod" runat="server" Width="200px"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblNom" runat="server" Text="Nombre:"></asp:Label>
                <asp:TextBox ID="txtNom" runat="server" Width="200px"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btnAlta" runat="server" Text="Agregar" 
                    onclick="btnAlta_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBaja" runat="server" Text="Eliminar" 
                    onclick="btnBaja_Click" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

