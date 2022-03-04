<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageEmpleado.master" AutoEventWireup="true" CodeFile="RegistrarPronostico.aspx.cs" Inherits="RegistrarPronostico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
    <style type="text/css">
        .style2
        {
            height: 220px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width:100%;">
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblTitulo" runat="server" Text="REGISTRAR PRONOSTICOS" 
                    Font-Bold="True" Font-Size="X-Large" ForeColor="#FF6600"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center" class="style2">
                <asp:GridView ID="gvCiudad" runat="server" AutoGenerateColumns="False" 
                    onselectedindexchanged="gvCiudad_SelectedIndexChanged" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="CodigoP" HeaderText="Codigo Pais" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:CommandField ButtonType="Button" HeaderText="Seleccionar" 
                            ShowSelectButton="True" />
                    </Columns>
                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblTempMax" runat="server" Text="Temperatuda Maxima:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtTempMax" runat="server" Width="50px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblTempMin" runat="server" Text="Temperatura Minima:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtTempMin" runat="server" Width="50px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" runat="server" Text="Velocidad del Viento:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtVelViento" runat="server" Width="50px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtFecha" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                Hora:</td>
            <td align="left">
                <asp:TextBox ID="txtHora" runat="server"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label2" runat="server" Text="Tipo de Cielo:"></asp:Label>
            </td>
            <td align="left">
                <asp:DropDownList ID="ddlTipoCielo" runat="server">
                    <asp:ListItem Value="despejado"></asp:ListItem>
                    <asp:ListItem Value="parcialmente nuboso"></asp:ListItem>
                    <asp:ListItem Value="nuboso"></asp:ListItem>
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label3" runat="server" Text="Probabilidad de Lluvias:"></asp:Label>
            </td>
            <td align="left">
                <asp:TextBox ID="txtProbLluvias" runat="server" Width="50px"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btnReg" runat="server" onclick="btnReg_Click" 
                    Text="Registrar" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                <asp:Label ID="lblError" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

