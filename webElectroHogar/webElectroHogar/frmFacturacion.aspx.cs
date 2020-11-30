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
        private int intNumero, intFormaPago, intCodigo, intCantidad;
        private float fltIVA, fltDesc, fltTotal;
        private string strCliente, strNombre, strEmpleado;

        #endregion

        #region "Métodos Personales"

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        protected void imgBtnBuscarCli_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                strCliente = this.txtCliente.Text.Trim();
                if (string.IsNullOrEmpty(strCliente))
                {
                    Mensaje("Nro. de Doc. del Cliente no válido");
                    this.txtCliente.Focus();
                    return;
                }
                this.txtCliente.ReadOnly = true;
                this.imgBtnBuscarCli.Visible = false;
                Clases.clsFacturacion objXX = new Clases.clsFacturacion(strApp);
                if (intOpcion == 0)
                {
                    if (!objXX.BuscarCliente_Factura(strCliente, this.grvDatos))
                    {
                        this.txtNombre.Text = objXX.Nombre;
                        Mensaje(objXX.Error);
                        objXX = null;
                        return;
                    }
                }                
                if(objXX.BuscarNombreCliente(this.txtCliente.Text.Trim()))
                    this.txtNombre.Text = objXX.Nombre;
                this.grvDatos.Columns[0].Visible = false;
                objXX = null;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
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

        protected void imgBtnBuscarNum_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                this.imgBtnBuscarNum.Visible = false;
                this.txtNumero.ReadOnly = true;
                intNumero = Convert.ToInt32(this.txtNumero.Text);
                if (intNumero <= 0)
                {
                    Mensaje("Nro. de factura no válido");
                    return;
                }
                BuscarXNumero();
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

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Mensaje(string.Empty);
            if (intOpcion != 2)
            {
                Mensaje("Opción no válida");
                return;
            }
            try
            {
                intNumero = Convert.ToInt32(this.txtNumero.Text);
                intCodigo = Convert.ToInt32(this.txtCodigo.Text);
                intCantidad = Convert.ToInt32(this.txtCant.Text);
                Clases.clsFacturacion objXX = new Clases.clsFacturacion(strApp, intNumero, intCodigo, intCantidad);
                if (!objXX.GrabarDetalle())
                {
                    Mensaje("Error -> " + objXX.Error);
                    objXX = null;
                    return;
                }
                //ibtnBuscarCaso_Click(null, null);
                this.txtProducto.Text = string.Empty;
                this.txtCant.Text = string.Empty;
                //this.btnAdicionar.Visible = false;
                Mensaje("Detalle grabado con éxito");
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void imgBtnBuscarCod_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                intCodigo = Convert.ToInt32(this.txtCodigo.Text.Trim());
                if (intCodigo<100)
                {
                    Mensaje("Codigo no válido");
                    this.txtCodigo.Focus();
                    return;
                }
                this.txtCodigo.ReadOnly = true;
                this.imgBtnBuscarCli.Visible = false;
                Clases.clsFacturacion objXX = new Clases.clsFacturacion(strApp);
                if (objXX.BuscarNombreProducto(intCodigo))
                {
                    this.txtProducto.Text = objXX.Producto;
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }
                objXX = null;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
                return;
            }
        }

        private void LimpiarDetalle()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtProducto.Text = string.Empty;
            this.txtCant.Text = string.Empty;
        }

        private void BuscarXNumero()
        {
            this.grvDatos.Columns[0].Visible = true;
            Clases.clsFacturacion objXX = new Clases.clsFacturacion(strApp);
            if (!objXX.BuscarFactura(intNumero, this.grvDatos))
            {
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
            this.txtNumero.Text = intNumero.ToString();
            this.txtFecha.Text = objXX.Fecha.ToShortDateString();
            this.txtCliente.Text = objXX.Cliente;
            this.txtNombre.Text = objXX.Nombre;
            this.ddlFormaPago.SelectedValue = objXX.FormaPago.ToString();
            this.txtFechaEntr.Text = objXX.FechaEnt.ToShortDateString();
            this.txtIVA.Text = objXX.IVA.ToString();
            this.txtDesc.Text = objXX.Desc.ToString();
            this.txtTotal.Text = objXX.Total.ToString();
            this.txtEmpleado.Text = objXX.Empleado;
            if (intOpcion == 1 || intOpcion == 2)
            {
                this.imgBtnBuscarCod.Visible = true;
                this.btnAdicionar.Visible = true;
                this.pnlProducto.Visible = true;
                this.pnlProducto.Enabled = true;
                this.txtFechaEntr.ReadOnly = false;
                this.txtFechaEntr.Enabled = true;
                this.txtCodigo.Enabled = true;
            }
            
            objXX = null;
        }
        
        private void Grabar()
        {
            if (intOpcion != 1 && intOpcion != 2)
            {
                Mensaje("Opción no válida, favor consultar con el Admón del Sistema");
                return;
            }
            intNumero = (intOpcion == 1) ? 0 : Convert.ToInt32(this.txtNumero.Text);
            strCliente = this.txtCliente.Text;
            intFormaPago = this.ddlFormaPago.SelectedIndex+1;
            strNombre = this.txtCliente.Text;
            //Traer codigo y nombre de empleado
            

            if (intOpcion == 1) // Agregar
            {
                dtmFecha = Convert.ToDateTime(this.txtFecha.Text);
                dtmFechaEnt = Convert.ToDateTime(this.txtFechaEntr.Text);
                
                Clases.clsFacturacion objXX1 = new Clases.clsFacturacion(
                    strApp, dtmFecha, dtmFechaEnt, intNumero, strCliente, intFormaPago, 1111);

                if (!objXX1.grabarMaestro())
                {
                    Mensaje(objXX1.Error);
                    objXX1 = null;
                    return;
                }
                intNumero = objXX1.Numero;
                objXX1 = null;
            }
            else // Modificar
            {
                dtmFecha = Convert.ToDateTime(this.txtFecha.Text);
                dtmFechaEnt = Convert.ToDateTime(this.txtFechaEntr.Text);
                Clases.clsFacturacion objXX2 = new Clases.clsFacturacion(
                    strApp, dtmFecha, dtmFechaEnt, intNumero, strCliente, intFormaPago, 1111);
                if (!objXX2.ModificarMaestro())
                {
                    Mensaje(objXX2.Error);
                    objXX2 = null;
                    return;
                }
                intNumero = objXX2.Numero;
                objXX2 = null;
            }
            if (intNumero == 0)
            {
                Limpiar();
                Mensaje("Error al grabar, favor consultar con el Admón del sistema");
                return;
            }
            this.txtNumero.Text = intNumero.ToString();
            imgBtnBuscarNum_Click(null, null);
            this.pnlProducto.Enabled = false;
            this.txtCliente.ReadOnly = true;
            LimpiarDetalle();
            Mensaje("Registro grabado con éxito");
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
            this.txtNumero.ReadOnly = true;
            this.imgBtnBuscarNum.Visible = false;
            this.txtCliente.ReadOnly = true;
            this.imgBtnBuscarCli.Visible = false;
            this.pnlProducto.Enabled = false;
            this.btnAdicionar.Visible = false;
            Mensaje(string.Empty);
            switch (this.mnuOpciones.SelectedValue)
            {
                case "opcAgregar":
                    intOpcion = 1;
                    Limpiar();
                    this.txtCliente.ReadOnly = false;
                    this.txtCliente.Enabled = true;
                    this.txtFechaEntr.ReadOnly = false;
                    this.txtFechaEntr.Enabled = true;
                    this.imgBtnBuscarCli.Visible = true;
                    this.btnAdicionar.Visible = true;
                    this.txtCliente.Focus();
                    this.txtFecha.Text = DateTime.Today.Date.ToShortDateString();
                    break;
                case "opcModificar":
                    intOpcion = 2;
                    Limpiar();
                    this.imgBtnBuscarNum.Visible = true;
                    this.txtNumero.ReadOnly = false;
                    this.txtNumero.Focus();
                    break;
                case "opcBuscarXNumero":
                    intOpcion = 0;
                    Limpiar();
                    this.txtNumero.ReadOnly = false;
                    this.imgBtnBuscarNum.Visible = true;
                    this.txtNumero.Focus();
                    break;
                case "opcBuscarXCliente":
                    intOpcion = 0;
                    Limpiar();
                    this.txtCliente.ReadOnly = false;
                    this.imgBtnBuscarCli.Visible = true;
                    this.txtCliente.Focus();
                    break;
                case "opcGrabar":
                    Grabar();
                    intOpcion = 0;
                    break;
                case "opcCancelar":
                    intOpcion = 0;
                    Limpiar();
                    break;
                case "opcImprimir":
                    intOpcion = 0;
                    break;
                default:
                    Mensaje("Opción no válida");
                    break;
            }
        }

        protected void grvDatos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}