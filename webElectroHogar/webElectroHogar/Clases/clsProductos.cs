using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webElectroHogar.Clases
{
    public class clsProductos
    {
        #region "Atributos/Propiedades"
        private string strApp;
        private string strSQL;
        private string Error;

        #endregion
        #region "Constructor"
        public clsProductos(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }
        #endregion
    }
}