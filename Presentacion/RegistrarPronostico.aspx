<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="RegistrarPronostico.aspx.cs" Inherits="RegistrarPronostico" %>

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
                <asp:Label ID="lblTitulo" runat="server" Text="Registar Pronostico"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="gvCiudad" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="gvCiudad_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="CodigoP" HeaderText="Codigo Pais" />
                        <asp:BoundField DataField="CodigoC" HeaderText="Codigo Ciudad" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:CommandField ButtonType="Button" HeaderText="Seleccionar" 
                            ShowSelectButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#CCFFFF" Font-Bold="True" />
                </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblTempMax" runat="server" Text="Temperatuda Maxima:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtTempMax" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblTempMin" runat="server" Text="Temperatura Minima:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtTempMin" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="Velocidad del Viento:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtVelViento" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1">
                Hora:</td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="Tipo de Cielo:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:DropDownList ID="ddlTipoCielo" runat="server">
                    <asp:ListItem Value="despejado"></asp:ListItem>
                    <asp:ListItem Value="parcialmente nuboso"></asp:ListItem>
                    <asp:ListItem Value="nuboso"></asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="Probabilidad de Lluvias:"></asp:Label>
            </td>
            <td class="style1" colspan="2">
                <asp:TextBox ID="txtProbLluvias" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td class="style1" colspan="3">
                <asp:Button ID="btnReg" runat="server" onclick="btnReg_Click" 
                    Text="Registrar" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

