using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using libGeneralesBD;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace webElectroHogar
{
    public partial class Formulario_web14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int intCodigo = Convert.ToInt32(Session["CodProd"]);
                    string strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    clsGeneralesBD objcnx = new clsGeneralesBD(strApp);
                    objcnx.SQL = "EXEC USP_Prod_BuscarXcodigo_Impresion " + intCodigo + "; ";
                    if (!objcnx.llenarDataSet(false))
                        Response.Redirect("frmProductos.aspx");
                    DataSet dts = new DataSet(); //Definir el DataSet: dts
                    dts = objcnx.dataSetLleno;
                    objcnx = null;
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        string strDireccion = AppDomain.CurrentDomain.BaseDirectory;
                        // NOTA: Descomentada la sgte línea solo la primera vez para realizar el diseño del reporte, luego comentar
                        //dts.WriteXmlSchema(strDireccion + "DataProducto.xsd");
                        this.rvMostrarRpte.LocalReport.DataSources.Clear();
                        this.rvMostrarRpte.Reset();
                        rvMostrarRpte.LocalReport.ReportEmbeddedResource = "rpteProducto.rdlc";
                        ReportDataSource rds = new ReportDataSource();
                        rds.Name = "dsProducto";
                        rds.Value = dts.Tables[0];
                        rvMostrarRpte.LocalReport.DataSources.Clear();
                        rvMostrarRpte.LocalReport.DataSources.Add(rds);
                        rvMostrarRpte.LocalReport.ReportPath = "rpteProducto.rdlc";
                        rvMostrarRpte.LocalReport.Refresh();
                    }
                    else
                        Response.Redirect("frmProductos.aspx");
                }
                catch
                { Response.Redirect("frmProductos.aspx"); }
            }
        }
    }
}