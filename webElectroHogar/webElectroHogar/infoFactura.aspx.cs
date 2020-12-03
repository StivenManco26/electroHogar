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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int intNumero = Convert.ToInt32(Session["NroFac"]);
                    string strNombreAplic = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                    clsGeneralesBD objcnx = new clsGeneralesBD(strNombreAplic);
                    objcnx.SQL = "EXEC USP_Fac_Impresion " + intNumero + "; ";
                    if (!objcnx.llenarDataSet(false))
                        Response.Redirect("frmFacturacion.aspx");
                    //Definir el DataSet: dts
                    DataSet dts = new DataSet();
                    dts = objcnx.dataSetLleno;
                    objcnx = null;
                    if (dts.Tables[0].Rows.Count > 0)
                    {
                        string strDireccion = AppDomain.CurrentDomain.BaseDirectory;
                        // Descomentando la siguiente línea nos sirve para crear el XSD y posterior origen de datos con el
                        // esquema de las tablas que necesitamos (Van a ser dos: uno para encabezado y el otro para detalle).
                        // OJO: Solo descomentar la primera vez o cuando se modifique, luego comentarlo
                        //dts.WriteXmlSchema(strDireccion + "DataFactura.xsd");
                        this.rvMostrarRpte.LocalReport.DataSources.Clear();
                        rvMostrarRpte.Reset();
                        rvMostrarRpte.LocalReport.ReportEmbeddedResource = "rpteFactura.rdlc";
                        ReportDataSource rds1 = new ReportDataSource();
                        ReportDataSource rds2 = new ReportDataSource();
                        rds1.Name = "dsEncabFac";
                        rds1.Value = dts.Tables[0];
                        rds2.Name = "dsDetaFac";
                        rds2.Value = dts.Tables[1];
                        rvMostrarRpte.LocalReport.DataSources.Clear();
                        rvMostrarRpte.LocalReport.DataSources.Add(rds1);
                        rvMostrarRpte.LocalReport.DataSources.Add(rds2);
                        rvMostrarRpte.LocalReport.ReportPath = "rpteFactura.rdlc";
                        rvMostrarRpte.LocalReport.Refresh();
                    }
                    else
                        Response.Redirect("frmFacturacion.aspx");
                }
                catch
                { Response.Redirect("frmFacturacion.aspx"); }
            }
        }
    }
    
}