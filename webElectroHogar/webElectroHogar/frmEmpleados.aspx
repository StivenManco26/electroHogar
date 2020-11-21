<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmEmpleados.aspx.cs" Inherits="webElectroHogar.Formulario_web21" %>
<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="auto-style7">
        <tr>
            <td colspan="2">Empleados</td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">Código:</td>
            <td class="auto-style9"><strong>
                <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style17" Width="244px"></asp:TextBox>
                </strong>
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/imagenes/Buscar.jpg" Width="29px" />
                        </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Menu ID="mnuOpciones" runat="server" BorderStyle="Solid" BorderWidth="2px" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Small" OnMenuItemClick="mnuOpciones_MenuItemClick" Orientation="Horizontal" RenderingMode="Table" Width="100%">
                    <Items>
                        <asp:MenuItem Text="Buscar" Value="opcBuscar"></asp:MenuItem>
                        <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                        <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                        <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                        <asp:MenuItem Text="Cancelar" Value="opcCancelar"></asp:MenuItem>
                    </Items>
                    <StaticHoverStyle BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" />
                    <StaticMenuItemStyle HorizontalPadding="20px" />
                </asp:Menu>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Panel ID="Panel1" runat="server">
                    <table class="auto-style10">
                        <tr>
                            <td class="auto-style20">Nombre:</td>
                            <td class="auto-style21"><strong>
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="auto-style17" Width="244px"></asp:TextBox>
                                </strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style20">Dirección:</td>
                            <td class="auto-style21"><strong>
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="auto-style17" Width="244px"></asp:TextBox>
                                </strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style20">Ciudad:</td>
                            <td class="auto-style21">
                                <asp:DropDownList ID="DropDownList2" runat="server" CssClass="auto-style16" Height="32px" Width="254px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" Width="96%">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMsj" runat="server" CssClass="auto-style13"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style7 {
            width: 761px;
            font-size: medium;
        }
        .auto-style8 {
            width: 379px;
            text-align: right;
        }
        .auto-style9 {
            width: 380px;
            text-align: left;
        }
        .auto-style10 {
            width: 725px;
        }

        .auto-style16 {
            font-size: medium;
            margin-left: 0px;
        }

        .auto-style17 {
            font-weight: bold;
            font-size: medium;
        }
        .auto-style20 {
            width: 361px;
            text-align: right;
        }
        .auto-style21 {
            width: 362px;
            text-align: left;
        }

        .auto-style13 {
            color: #FF0000;
            font-size: small;
        }

        </style>
</asp:Content>

