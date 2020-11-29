<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmFacturacion.aspx.cs" Inherits="webElectroHogar.Formulario_web13" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" class="auto-style7">
        <tr>
            <td class="auto-style8"><strong>Facturación</strong></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Panel ID="Panel1" runat="server" GroupingText="Encabezado">
                    <table align="center" class="auto-style9">
                        <tr>
                            <td class="auto-style10" style="width: 20%">Numero:</td>
                            <td class="auto-style11" style="width: 30%">
                                <asp:TextBox ID="txtNumero" runat="server" CssClass="auto-style14" Width="74%" ReadOnly="True"></asp:TextBox>
                                &nbsp;<span class="auto-style15"><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/imagenes/Buscar.jpg" />
                                </span></td>
                            <td class="auto-style12" style="width: 20%">Fecha:</span></td>
                            <td class="auto-style12" style="width: 30%">
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="auto-style14" Width="90%" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15" style="width: 20%">Cliente:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtCliente" runat="server" CssClass="auto-style14" Width="74%" ReadOnly="True"></asp:TextBox>
                                &nbsp;<span class="auto-style15"><asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/imagenes/Buscar.jpg" />
                                </span>
                            </td>
                            <td class="auto-style15" style="width: 20%">Nombre:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="auto-style14" Width="90%" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15" style="width: 20%">Forma pago:</td>
                            <td style="width: 30%">
                                <asp:DropDownList ID="ddlFormaPago" runat="server" CssClass="auto-style14" Width="90%">
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style15" style="width: 20%">F. Entrega:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtFechaEntr" runat="server" CssClass="auto-style14" Width="90%" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15" style="width: 20%">IVA:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtIVA" runat="server" CssClass="auto-style14" Width="90%" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="auto-style15" style="width: 20%">Descuento:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtDesc" runat="server" CssClass="auto-style14" Width="90%" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15" style="width: 20%">Total:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtTotal" runat="server" CssClass="auto-style14" Width="90%" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="auto-style15" style="width: 20%">Empleado:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtEmpleado" runat="server" CssClass="auto-style14" Width="90%" Font-Bold="True" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">
                    <asp:Menu ID="mnuOpciones" runat="server" BorderStyle="Solid" BorderWidth="2px" DynamicHorizontalOffset="2" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Small" Orientation="Horizontal" RenderingMode="Table" Width="100%">
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
            <td class="auto-style8">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style16">
                <asp:Panel ID="Panel2" runat="server" GroupingText="Producto">
                    <table class="auto-style2">
                        <tr>
                            <td style="width: 20%">Codigo:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtCodigo" runat="server" CssClass="auto-style14" Width="74%"></asp:TextBox>
                                &nbsp;<span class="auto-style15"><asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/imagenes/Buscar.jpg" />
                                </span>
                            </td>
                            <td style="width: 20%">Producto:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtProducto" runat="server" CssClass="auto-style14" Width="90%" ReadOnly="True"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">Cantidad:</td>
                            <td style="width: 30%">
                                <asp:TextBox ID="txtCant" runat="server" CssClass="auto-style14" Width="90%"></asp:TextBox>
                            </td>
                            <td style="width: 20%">&nbsp;</td>
                            <td style="width: 30%">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td class="auto-style17">
                <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:GridView ID="grvDatos" runat="server" OnRowDeleting="grvDatos_RowDeleting" Width="96%">
                    <Columns>
                        <asp:TemplateField ShowHeader="False">
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="itmEliminar" runat="server" AlternateText="Eliminar" CommandName="Delete" ImageUrl="~/Imagenes/error.ico" OnClientClick="return confirm('Desea Quitarlo?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="lblMsj" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="Small" ForeColor="#CC0000" Width="90%"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style7 {
            width: 98%;
        }
        .auto-style8 {
            font-size: medium;
        }
        .auto-style9 {
            width: 99%;
        }
        .auto-style10 {
            width: 25%;
            height: 23px;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style11 {
            width: 30%;
            height: 23px;
        }
        .auto-style12 {
            height: 23px;
        }
        .auto-style13 {
            font-size: medium;
            height: 22px;
        }
        .auto-style14 {
            font-size: medium;
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style15 {
            font-family: Arial, Helvetica, sans-serif;
        }
        .auto-style16 {
            font-size: medium;
            text-align: center;
        }
        .auto-style17 {
            font-size: medium;
            height: 22px;
            text-align: right;
        }
    </style>
</asp:Content>

