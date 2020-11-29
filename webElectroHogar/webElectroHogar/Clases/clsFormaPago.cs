using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;

namespace webElectroHogar.Clases
{
    public class clsFormaPago
    {
        #region "Atributos / Propiedades"
        private string strApp;
        private string strSQL;
        public string Error { get; private set; }
        #endregion

        #region "Constructor"
        public clsFormaPago(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }
        #endregion

        #region "Métodos Públicos"
        public bool llenarCombo(DropDownList Cmb)
        {
            strSQL = "EXEC USP_FormaPago;";
            clsGenerales objGles = new clsGenerales();
            if (!objGles.llenarCombo(strApp, Cmb, strSQL, "Clave", "Dato"))
            {
                Error = objGles.Error;
                objGles = null;
                return false;
            }
            objGles = null;
            return true;
        }
        #endregion
    }
}