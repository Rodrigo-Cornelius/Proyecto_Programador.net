<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="ListadoPorCiudad.aspx.cs" Inherits="ListadoPorCiudad" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="3">
                LISTADO DE PRONOSTICOS POR CIUDAD</td>
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
            <td align="center" colspan="3">
                <asp:GridView ID="gvCiudades" runat="server" AutoGenerateColumns="False" 
                    CellPadding="4" onselectedindexchanged="gvCiudades_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField HeaderText="Ciudades" DataField="Nombre" />
                        <asp:CommandField ButtonType="Button" SelectText="Ver" 
                            ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#99CCFF" />
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
                <asp:GridView ID="gvPronosticos" runat="server">
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

