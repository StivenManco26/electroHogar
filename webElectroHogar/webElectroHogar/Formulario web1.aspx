<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="Formulario web1.aspx.cs" Inherits="webElectroHogar.Formulario_web11" %>

<asp:Content ID="Content3" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <table align="center" class="auto-style7">
        <tr>
            <td class="auto-style8">Ingreso SIDEFA</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <table class="auto-style2">
                    <tr>
                        <td style="width: 40%">Usuario:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 40%">Contraseña:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Button ID="Button1" runat="server" Text="Ingresar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small" ForeColor="Red" Text="ERROR"></asp:Label>
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
    </style>
</asp:Content>

