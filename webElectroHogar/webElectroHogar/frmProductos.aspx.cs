﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webElectroHogar
{
    public partial class Formulario_web12 : System.Web.UI.Page
    {
        #region "Variables Globales"
        static string codigoUsu, nombreUsu;
        private static string strApp;
        private static int intOpcion;
        private static int intCodigo;
        private static string strDescripcion;
        private static decimal dcmlValorUnitario;
        private static double dblIva;
        private static int intClasificacion;

        #endregion

        #region "Métodos propios"

        private void Mensaje(string Texto)
        {
            this.lblMsj.Text = Texto.Trim();
        }

        private void llenarComboClasific()
        {
            try
            {
                Clases.clsClasificacion objXX = new Clases.clsClasificacion(strApp);
                if (!objXX.llenarCombo(this.ddlClasificacion))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }
                objXX = null;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        private void llenarGridProductos()
        {
            try
            {
                Clases.clsProductos objXX = new Clases.clsProductos(strApp);
                if (!objXX.llenarGrid(this.grvDatosProductos))
                {
                    Mensaje(objXX.Error);
                    objXX = null;
                    return;
                }
                objXX = null;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                codigoUsu = Session["codigo"].ToString();
                if (string.IsNullOrEmpty(codigoUsu))
                    Response.Redirect("frmLogin.aspx");
                nombreUsu = Session["empleado"].ToString();
                this.lblUsu.Text = "Usuario: " + nombreUsu;
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
                intOpcion = 0;
                llenarComboClasific();
                this.ddlClasificacion.SelectedIndex = 0;
                llenarGridProductos();
            }
        }

        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.ddlClasificacion.SelectedIndex = 0;
            this.txtDescripcion.Text = string.Empty;
            this.txtIva.Text = string.Empty;
            this.txtValorUn.Text = string.Empty;
            Mensaje(string.Empty);
        }
        private void Buscar()
        {
            Clases.clsProductos objXX = new Clases.clsProductos(strApp);
            if (!objXX.Buscar(intCodigo))
            {
                Limpiar();
                Mensaje(objXX.Error);
                objXX = null;
                return;
            }
            this.txtCodigo.Text = objXX.codigo.ToString();
            this.txtDescripcion.Text = objXX.descripcion;
            this.txtValorUn.Text = objXX.valorUnitario.ToString();
            this.txtIva.Text = objXX.iva.ToString();
            this.ddlClasificacion.SelectedIndex = objXX.clasificacion - 1   ;
            objXX = null;
        }
        private void Grabar()
        {
            try
            {
                if (intOpcion != 1 && intOpcion != 2)
                {
                    Mensaje("Opción no válida");
                    return;
                }
                intCodigo = (intOpcion == 1) ? 0 : Convert.ToInt32(this.txtCodigo.Text);
                strDescripcion = this.txtDescripcion.Text.Trim();
                dcmlValorUnitario = Convert.ToDecimal(this.txtValorUn.Text);
                dblIva = Convert.ToDouble(this.txtIva.Text.Replace(".", ","));
                intClasificacion = this.ddlClasificacion.SelectedIndex+1;
                Clases.clsProductos objXX = new Clases.clsProductos(strApp, intCodigo,
                strDescripcion, dcmlValorUnitario, dblIva, intClasificacion, Convert.ToInt32(codigoUsu));
                if (intOpcion == 1) // Agregar
                {
                    if (!objXX.grabarMaestro())
                    {
                        Mensaje(objXX.Error);
                        objXX = null;
                        return;
                    }
                    intCodigo = objXX.codigo;
                }
                else // Modificar
                if (!objXX.modificarMaestro())
                {
                    Mensaje(objXX.Error);
                    return;
                }
                intCodigo = objXX.codigo;
                objXX = null;
                if (intCodigo == -1)
                {
                    Mensaje("Ya existe un registro con dichos valores");
                    return;
                }
                else if (intCodigo == 0)
                {
                    Mensaje("Error al procesar registro, Consultar con el Admón del sistema");
                    return;
                }
                Mensaje("Registro Grabado con éxito");
                llenarGridProductos();
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }

        protected void mnuOpciones_MenuItemClick(object sender, MenuEventArgs e)
        {
            Mensaje(string.Empty);
            switch (this.mnuOpciones.SelectedValue)
            {
                case "opcAgregar":
                    intOpcion = 1;
                    Limpiar();
                    this.imgButtonBuscar.Visible = false;
                    this.txtCodigo.ReadOnly = true;
                    this.txtDescripcion.ReadOnly = false;
                    this.txtDescripcion.Focus();
                    this.txtValorUn.ReadOnly = false;
                    this.txtIva.ReadOnly = false;
                    this.ddlClasificacion.Enabled = true;
                    break;
                case "opcModificar":
                    intOpcion = 2;
                    this.imgButtonBuscar.Visible = false;
                    this.txtCodigo.ReadOnly = true;
                    this.txtDescripcion.ReadOnly = false;
                    this.txtDescripcion.Focus();
                    this.txtValorUn.ReadOnly = false;
                    this.txtIva.ReadOnly = false;
                    this.ddlClasificacion.Enabled = true;
                    break;
                case "opcBuscar":
                    intOpcion = 0;
                    Limpiar();
                    this.imgButtonBuscar.Visible = true;
                    this.txtDescripcion.ReadOnly = true;
                    this.txtIva.ReadOnly = true;
                    this.txtValorUn.ReadOnly = true;
                    this.ddlClasificacion.Enabled = false;
                    this.txtCodigo.Enabled = true;
                    this.txtCodigo.ReadOnly = false;
                    this.txtCodigo.Focus();
                    break;
                case "opcGrabar":
                    Grabar();
                    intOpcion = 0;
                    Limpiar();
                    break;
                case "opcCancelar":
                    Limpiar();
                    if (intOpcion == 1 || intOpcion == 2)
                    {
                        Limpiar();
                    }
                    intOpcion = 0;
                    break;
                case "opcImprimir":
                    intOpcion = 0;
                    if (string.IsNullOrEmpty(this.txtCodigo.Text))
                    {
                        Mensaje("Debe ingresar un Código de Producto Válido");
                        return;
                    }
                    intCodigo = Convert.ToInt32(this.txtCodigo.Text);
                    if (intCodigo<99)
                    {
                        Mensaje("Código de Producto no Válido");
                        return;
                    }
                    Session["CodProd"] = intCodigo;
                    Response.Redirect("infoProducto.aspx");
                    break;
            }
        }

        protected void imgButtonBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Mensaje(string.Empty);
                intCodigo = Convert.ToInt32(this.txtCodigo.Text.Trim());
                if (intCodigo < 100)
                {
                    Mensaje("Código de producto no válido");
                    return;
                }
                this.imgButtonBuscar.Visible = false;
                Buscar();
                this.txtCodigo.ReadOnly = true;
                this.imgButtonBuscar.Visible = false;
            }
            catch (Exception ex)
            {
                Mensaje(ex.Message);
            }
        }
    }
}