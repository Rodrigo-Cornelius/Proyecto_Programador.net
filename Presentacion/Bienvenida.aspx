<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="Bienvenida.aspx.cs" Inherits="Bienvenida" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Italic="True" 
                    Font-Size="XX-Large" ForeColor="#FF6600" 
                    Text="BIENVENIDO AL SISTEMA DE GESTION DE PRONOSTICOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="#FF6600" 
                    Text="SELECCIONE UNA OPCION EN EL MENU PRINCIPAL"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

