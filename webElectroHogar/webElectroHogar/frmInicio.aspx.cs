using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webElectroHogar
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        static string codigoUsu, nombreUsu;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                codigoUsu = Session["codigo"].ToString();
                if (string.IsNullOrEmpty(codigoUsu))
                    Response.Redirect("frmLogin.aspx");
                nombreUsu = Session["empleado"].ToString();
                this.lblUsu.Text = "Usuario: " + nombreUsu;
            }
        }
    }
}