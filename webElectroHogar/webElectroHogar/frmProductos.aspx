<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmProductos.aspx.cs" Inherits="webElectroHogar.Formulario_web12" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" class="auto-style7">
        <tr>
            <td class="auto-style13">
                <asp:Label ID="lblUsu" runat="server" CssClass="auto-style14" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style9"><strong>Productos</strong></td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <table align="center" class="auto-style8">
                    <tr>
                        <td style="width: 40%"><strong>Codigo:</strong></td>
                        <td>
                            <asp:TextBox ID="txtCodigo" runat="server" Width="80%" ReadOnly="True"></asp:TextBox>
&nbsp;<asp:ImageButton ID="imgButtonBuscar" runat="server" ImageUrl="~/imagenes/Buscar.jpg" Height="22px" Width="25px" OnClick="imgButtonBuscar_Click" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%"><strong>Descripción:</strong></td>
                        <td>
                            <asp:TextBox ID="txtDescripcion" runat="server" Width="80%" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%"><strong>Valor Unitario:</strong></td>
                        <td>
                            <asp:TextBox ID="txtValorUn" runat="server" Width="80%" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%"><strong>%IVA:</strong></td>
                        <td>
                            <asp:TextBox ID="txtIva" runat="server" Width="80%" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%"><strong>Clasificación:</strong></td>
                        <td>
                            <asp:DropDownList ID="ddlClasificacion" runat="server" Width="80%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Panel ID="Panel1" runat="server">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderStyle="Solid" BorderWidth="2px" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Small" Orientation="Horizontal" RenderingMode="Table" Width="100%" OnMenuItemClick="mnuOpciones_MenuItemClick">
                        <Items>
                            <asp:MenuItem Text="Buscar" Value="opcBuscar"></asp:MenuItem>
                            <asp:MenuItem Text="Agregar" Value="opcAgregar"></asp:MenuItem>
                            <asp:MenuItem Text="Modificar" Value="opcModificar"></asp:MenuItem>
                            <asp:MenuItem Text="Grabar" Value="opcGrabar"></asp:MenuItem>
                            <asp:MenuItem Text="Cancelar" Value="opcCancelar"></asp:MenuItem>
                            <asp:MenuItem Text="Imprimir" Value="opcImprimir"></asp:MenuItem>
                        </Items>
                        <StaticHoverStyle BorderStyle="Solid" BorderWidth="2px" ForeColor="Black" />
                        <StaticMenuItemStyle HorizontalPadding="20px" />
                    </asp:Menu>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:GridView ID="grvDatosProductos" runat="server" Width="98%">
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style9">
                <asp:Label ID="lblMsj" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Small" ForeColor="#CC0000" Width="90%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style7 {
            width: 98%;
        }
        .auto-style8 {
            width: 99%;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            font-size: medium;
            height: 22px;
        }
        .auto-style12 {
            font-size: medium;
            height: 27px;
        }
        .auto-style13 {
            font-size: medium;
            text-align: right;
        }
        .auto-style14 {
            font-size: small;
        }
    </style>
</asp:Content>

