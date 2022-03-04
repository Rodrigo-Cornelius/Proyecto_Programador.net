<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ListadoPorFecha.aspx.cs" Inherits="ListadoPorFecha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="2">
                LISTADO DE PRONOSTICOS POR FECHA</td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Seleccione la fecha:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:Button ID="btnBuscar" runat="server" onclick="btnBuscar_Click" 
                    Text="Buscar" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:GridView ID="gvPronos" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" CellSpacing="1">
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="ShortDate" HeaderText="Fecha" />
                        <asp:BoundField DataField="MaxTemp" HeaderText="Temp Maxima" />
                        <asp:BoundField DataField="MinTemp" HeaderText="Temp Minima" />
                        <asp:BoundField DataField="TipoCielo" HeaderText="Tipo de Cielo" />
                        <asp:BoundField DataField="ProbLluvias" HeaderText="Probabilidad de lluvias" />
                        <asp:BoundField DataField="VelViento" HeaderText="Velocidad del viento" />
                        <asp:BoundField DataField="Ciudad.Nombre" HeaderText="Ciudad" />
                        <asp:BoundField DataField="Usuario.Nombre" HeaderText="Creado por" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

