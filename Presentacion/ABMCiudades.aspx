<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ABMCiudades.aspx.cs" Inherits="ABMCiudades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblTitulo" runat="server" Text="ABM CIUDADES"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCodC" runat="server" Text="Codigo Ciudad:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCodC" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" 
                    onclick="btnBuscar_Click" />    
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblCodP" runat="server" Text="Codigo Pais:"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtCodP" runat="server"></asp:TextBox>
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblNom" runat="server" Text="Nombre"></asp:Label>
            </td>
            <td class="style1">
                <asp:TextBox ID="txtNom" runat="server"></asp:TextBox>
                </td>
            <td class="style1">
                </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" 
                    onclick="btnModificar_Click" />
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" 
                    onclick="btnEliminar_Click" />
                <asp:Button ID="btnCrear" runat="server" Text="Crear" 
                    onclick="btnCrear_Click" />
                <asp:Button ID="btnLimpiar" runat="server" onclick="btnLimpiar_Click" 
                    Text="Limpiar Formulario" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:LinkButton ID="lbtnVolver" runat="server">Volver</asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>

