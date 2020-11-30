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
        private DateTime dtmFecha, dtmFechaEnt;
        private int intNumero, intCliente, intFormaPago;
        private float fltIVA, fltDesc, fltTotal;
        private string strNombre, strEmpleado;

        #endregion

        #region "Métodos Personales"

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

        private void Limpiar()
        {
            Mensaje(string.Empty);
            this.txtNumero.Text = string.Empty;
            this.txtFecha.Text = string.Empty;
            this.txtCliente.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.ddlFormaPago.SelectedIndex = 0;
            this.txtFechaEntr.Text = string.Empty;
            this.txtIVA.Text = string.Empty;
            this.txtDesc.Text = string.Empty;
            this.txtTotal.Text = string.Empty;
            this.txtEmpleado.Text = string.Empty;
            LimpiarDetalle();
            this.grvDatos.DataSource = null;
            this.grvDatos.DataBind();
        }

        private void LimpiarDetalle()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCant.Text = string.Empty;
        }

        #endregion



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