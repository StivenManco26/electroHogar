using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webElectroHogar
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        #region "Variables Globales"
        private static string strApp;
        private static int intOpcion;
        private DateTime dtmFecha;

        #endregion

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        private void llenarComboFormaPago()
        {
            try
            {
                Clases.clsFormaPago objXX = new Clases.clsFormaPago(strApp);
                if (!objXX.llenarCombo(this.ddlFormaPago))
                    Mensaje(objXX.Error);
                objXX = null;
                return;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                llenarComboFormaPago();
                this.ddlFormaPago.SelectedIndex = 0;
            }
        }

        protected void mnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {

        }

        protected void grvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}