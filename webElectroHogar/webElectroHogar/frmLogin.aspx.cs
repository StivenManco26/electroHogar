﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webElectroHogar
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        #region "Variables Globales"
        private static string strApp;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                strApp = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            string usu, clave;
            usu = this.txtUsuario.Text;
            clave = this.txtClave.Text;
            Clases.clsLogin objLog = new Clases.clsLogin(strApp);
            if(objLog.validarLogin(usu, clave))
            {
                Session["codigo"] = objLog.codigo;
                Session["empleado"] = objLog.nombre;
                Response.Redirect("frmInicio.aspx");
            }
            this.lblMsj.Text = "Usuario o contraseña incorrectos!";
        }
    }
}