<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="Bienvenida.aspx.cs" Inherits="Bienvenida" %>

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
            <td align="center" class="style1">
                <asp:Label ID="Label2" runat="server" 
                    Text="BIENVENIDO AL SISTEMA DE PRONOSTICOS"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" class="style1">
                <asp:Label ID="Label1" runat="server" 
                    Text="SELECCIONE UNA OPCION DEL MENU PRINCIPAL"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

