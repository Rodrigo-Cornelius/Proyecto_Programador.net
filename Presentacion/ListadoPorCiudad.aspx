<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ListadoPorCiudad.aspx.cs" Inherits="ListadoPorCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" 
                    ForeColor="#FF6600" Text="LISTADO DE PRONOSTICOS POR CIUDAD"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                <asp:DropDownList ID="ddlPaises" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlPaises_SelectedIndexChanged">
                    <asp:ListItem Value="0">----------------</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
            <td align="center">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvCiudades" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" onselectedindexchanged="gvCiudades_SelectedIndexChanged" 
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Nombre Ciudad" DataField="Nombre" />
                        <asp:CommandField ButtonType="Button" SelectText="Ver" 
                            ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" Font-Bold="True" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblCiudades" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:GridView ID="gvPronosticos" runat="server" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" 
                    Font-Bold="True" HorizontalAlign="Center">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha" />
                        <asp:BoundField DataField="MaxTemp" HeaderText="Temp Maxima" />
                        <asp:BoundField DataField="MinTemp" HeaderText="Temp Minima" />
                        <asp:BoundField DataField="TipoCielo" HeaderText="Tipo de Cielo" />
                        <asp:BoundField DataField="ProbLluvias" HeaderText="Probabilidad de lluvias" />
                        <asp:BoundField DataField="VelViento" HeaderText="Velocidad del Viento" />
                        <asp:BoundField DataField="Ciudad.Nombre" HeaderText="Ciudad" />
                        <asp:BoundField DataField="Usuario.Nombre" HeaderText="Creado por" />
                    </Columns>
                    <EditRowStyle BackColor="#999999" />
                    <FooterStyle BackColor="#5D7B9D" ForeColor="White" Font-Bold="True" />
                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" 
                        HorizontalAlign="Center" VerticalAlign="Middle" />
                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" HorizontalAlign="Center" 
                        VerticalAlign="Middle" />
                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>

