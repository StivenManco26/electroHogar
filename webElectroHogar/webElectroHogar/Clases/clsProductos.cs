using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Referenciar y Usar
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using libGeneralesBD;

namespace webElectroHogar.Clases
{
    public class clsProductos
    {
        #region "Atributos/Propiedades"
        private string strApp;
        private string strSQL;
        public int codigo { get; set; }
        public string descripcion { get; set; }
        public decimal valorUnitario { get; set; }
        public double iva { get; set; }
        public int clasificacion { get; set; }
        public int codEmpleado { get; set; }
        public string Error { get; private set; }
        private SqlDataReader myReader;

        #endregion
        #region "Constructor"
        public clsProductos(string Aplicacion)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            codigo = 0;
            descripcion = string.Empty;
            valorUnitario = 0;
            iva = 0;
            Error = string.Empty;
            clasificacion = 0;
            codEmpleado = 0;
        }
        public clsProductos(string Aplicacion, int codig, string descrip, decimal valorUni, double iv, 
            int clasificaci, int codEmple)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            codigo = codig;
            descripcion = descrip;
            valorUnitario = valorUni;
            iva = iv;
            clasificacion = clasificaci;
            codEmpleado = codEmple;
            Error = string.Empty;
        }
        public clsProductos(string Aplicacion, int codig, string descrip, decimal valorUni, double iv,
            int clasificaci)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            codigo = codig;
            descripcion = descrip;
            valorUnitario = valorUni;
            iva = iv;
            clasificacion = clasificaci;
            codEmpleado = 0;
            Error = string.Empty;
        }
        public clsProductos(string Aplicacion, string descrip, decimal valorUni, double iv,
            int clasificaci)
        {
            strApp = Aplicacion;
            strSQL = string.Empty;
            codigo = 0;
            descripcion = descrip;
            valorUnitario = valorUni;
            iva = iv;
            clasificacion = clasificaci;
            codEmpleado = 0;
            Error = string.Empty;
        }
        #endregion
        private bool validarDatos()
        {
            if (string.IsNullOrEmpty(descripcion))
            {
                Error = "Falta la descripción";
                return false;
            }
            if (string.IsNullOrEmpty(valorUnitario.ToString()))
            {
                Error = "Falta el valor unitario";
                return false;
            }
            if (string.IsNullOrEmpty(iva.ToString()))
            {
                Error = "Falta el IVA";
                return false;
            }
            return true;
        }

        public bool llenarGrid(GridView Grid)
        {
            strSQL = "EXEC USP_Prod_BuscarGeneral;";
            clsGenerales objGles = new clsGenerales();
            if (!objGles.llenarGrid(strApp, Grid, strSQL))
            {
                Error = objGles.Error;
                objGles = null;
                return false;
            }
            objGles = null;
            return true;
        }
        private bool Grabar()
        {
            try
            {
                if (string.IsNullOrEmpty(strApp))
                {
                    Error = "Falta el nombre de la aplicación";
                    return false;
                }
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.consultarValorUnico(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                codigo = Convert.ToInt32(objCnx.vrUnico);
                objCnx.cerrarCnx();
                objCnx = null;
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
        
        public bool Buscar(int cod)
        {
            try
            {
                strSQL = "EXEC USP_Prod_BuscarXcodigo " + cod + ";";
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
                if (!myReader.HasRows)
                {
                    Error = "No existe registro con codigo: " + cod;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                myReader.Read();
                codigo = myReader.GetInt32(0);
                descripcion = myReader.GetString(1);
                valorUnitario = myReader.GetDecimal(2);
                valorUnitario = Math.Truncate(valorUnitario);
                iva = myReader.GetDouble(3);
                clasificacion = myReader.GetInt32(4);
                myReader.Close();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }
        public bool grabarMaestro()
        {
            if (!validarDatos())
                return false;
            strSQL = "EXEC USP_Prod_Grabar '" + descripcion + "', " + Math.Truncate(valorUnitario) + ", "
                + iva.ToString().Replace(',','.') + ", " + clasificacion + ", 1111;";
            return Grabar();
            //EXEC USP_Prod_Grabar 'MOTOROLA MOTO ONE 32GB', '460000', 0.19, 3, 1111
        }
        public bool modificarMaestro()
        {
            if (!validarDatos())
                return false;
            strSQL = "EXEC USP_Prod_Modificar " + codigo + ", " + "'" + descripcion + "', " + 
                Math.Truncate(valorUnitario) + ", " + iva.ToString().Replace(',', '.') + ", " + clasificacion + ", 1111;";
            return Grabar();
            //EXEC USP_Prod_Modificar 100,'LG SMARTV 32', 2000000, 0.19, 1, 1111
        }
    }
}