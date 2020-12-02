using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using libGeneralesBD;


namespace webElectroHogar.Clases
{
    public class clsLogin
    {
        #region "Atributos / Propiedades"
        private string strApp;
        private string strSQL;
        public int codigo { get; set; }
        public int rpta { get; set; }
        public string nombre { get; set; }
        public string Error { get; private set; }
        private SqlDataReader myReader;

        #endregion

        #region "Constructor"
        public clsLogin(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            Error = string.Empty;
        }
        #endregion

        #region "Métodos Públicos"
        public bool validarLogin(string usu, string clave)
        {
            try
            {
                strSQL = "EXEC USP_Login_Validar '" + usu + "', '" + clave + "';";
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                myReader = objCnx.dataReaderLleno;
                myReader.Read();
                rpta = myReader.GetInt32(0);
                codigo = myReader.GetInt32(1);
                nombre = myReader.GetString(2);
                myReader.Close();
                return (rpta == 1) ;

            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
        #endregion
    }
}