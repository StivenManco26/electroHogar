<%@ Page Title="" Language="C#" MasterPageFile="~/frmPrincipal.Master" AutoEventWireup="true" CodeBehind="infoProducto.aspx.cs" Inherits="webElectroHogar.Formulario_web14" %><%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:Content ID="Content4" ContentPlaceHolderID="Cuerpo" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <rsweb:ReportViewer ID="rvMostrarRpte" runat="server" Width="98%">
        </rsweb:ReportViewer>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Content>
