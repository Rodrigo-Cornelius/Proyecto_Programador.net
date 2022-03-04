<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ABMCiudades.aspx.cs" Inherits="ABMCiudades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:39%;" align="center">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblTitulo" runat="server" Text="ABM CIUDADES" Font-Bold="True" 
                    Font-Size="X-Large" ForeColor="#FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCodC" runat="server" Text="Codigo Ciudad:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCodC" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />    
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblCodP" runat="server" Text="Codigo Pais:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtCodP" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblNom" runat="server" Text="Nombre"></asp:Label>
                :</td>
            <td align="left">
                <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnCrear" runat="server" Text="Agregar" 
                    onclick="btnCrear_Click" />
                &nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click" />
                &nbsp;
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    onclick="btnEliminar_Click" />
                &nbsp;
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar Formulario" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>

