<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="frmClientes.aspx.cs" Inherits="webElectroHogar.Formulario_web2" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table class="auto-style11">
        <tr>
            <td class="auto-style7">Clientes</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <table align="center" class="auto-style9">
                    <tr>
                        <td class="auto-style10">Nro. de documento: </td>
                        <td class="auto-style22">
                            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                            &nbsp;
                            <asp:ImageButton ID="ImageButton1" runat="server" Height="23px" ImageUrl="~/imagenes/Buscar.jpg" Width="29px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style10">&nbsp;</td>
                        <td class="auto-style22">&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="agregar cliente" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                <asp:Panel ID="Panel1" runat="server">
                    <table class="auto-style17">
                        <tr>
                            <td class="auto-style15">Nombre Completo:</td>
                            <td class="auto-style25">
                                <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style23">Tipo de documento:</td>
                            <td class="auto-style25">
                                <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem>CC</asp:ListItem>
                                    <asp:ListItem>CE</asp:ListItem>
                                    <asp:ListItem>NIT</asp:ListItem>
                                    <asp:ListItem>TI</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">Ciudad:</td>
                            <td class="auto-style21">
                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="auto-style16" Height="33px" Width="309px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">Mayorista:</td>
                            <td class="auto-style21">&nbsp; &nbsp;<asp:CheckBox ID="chckMayorista" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style21">&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server">
                </asp:GridView>
            </td>
        </tr>
    <tr>
        <td>
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblMsj" runat="server" CssClass="auto-style13"></asp:Label>
        </td>
    </tr>
    </table>
</asp:Content>
<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style7 {
            font-size: large;
        }

        .auto-style8 {
            height: 39px;
        }

        .auto-style9 {
            width: 756px;
        }

        .auto-style10 {
            text-align: right;
            width: 377px;
        }

        .auto-style11 {
            width: 100%;
            font-size: medium;
        }

        .auto-style12 {
            height: 27px;
        }

        .auto-style13 {
            color: #FF0000;
            font-size: small;
        }

        .auto-style15 {
            width: 384px;
            text-align: right;
        }

        .auto-style16 {
            font-size: medium;
            margin-left: 0px;
        }

        .auto-style17 {
            width: 771px;
            /*border: 3px solid #800000;*/
        }

        .auto-style21 {
            text-align: left;
            width: 385px;
        }

        .auto-style22 {
            width: 377px;
        }

        .auto-style23 {
            width: 384px;
            text-align: right;
            height: 34px;
        }

        .auto-style25 {
            width: 385px;
            height: 34px;
            text-align: left;
        }
    </style>
</asp:Content>

