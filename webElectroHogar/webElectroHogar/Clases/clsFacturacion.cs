using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using libGeneralesBD;
using libOpDescuento;

namespace webElectroHogar.Clases
{
    public class clsFacturacion
    {
        #region "Atributos / Propiedades"
        private string strApp;
        public DateTime Fecha { set; get; }
        public DateTime FechaEnt { set; get; }
        public int Numero { set; get; }
        public string Cliente { set; get; }
        public int FormaPago { set; get; }
        public float IVA { set; get; }
        public float Desc { set; get; }
        public float Total { set; get; }
        public string Nombre { private set; get; }
        public int CodEmpleado { set; get; }
        public string Empleado { private set; get; }
        public int Codigo { set; get; }
        public string Producto { set; get; }
        public float Cantidad { set; get; }
        public string Error { private set; get; }
        private int TipoCliente;
        private string strSQL;
        private DataSet Myds;
        private DataTable Mydt;
        private SqlDataReader MyReader;
        #endregion

        #region "Constructor"

        //Constructor Vacío
        public clsFacturacion(string Aplicacion)
        {
            strApp = Aplicacion;
            Fecha = DateTime.Now.Date;
            FechaEnt = DateTime.Now.Date;
            Numero = 0;
            Cliente = string.Empty;
            FormaPago = 0;
            IVA = 0;
            Desc = 0;
            Total = 0;
            Nombre = string.Empty;
            CodEmpleado = 0;
            Empleado = string.Empty;
            Codigo = 0;
            Producto = string.Empty;
            Cantidad = 0f;
            strSQL = string.Empty;
            Error = string.Empty;
        }

        //Constructor Completo
        public clsFacturacion(string Aplicacion, DateTime fecha, DateTime fechaEnt, int numero, string cliente, int formaPago, 
            float iva, float desc, float total, string nombre, int codEmpleado, string empleado, int codigo, string producto, float cantidad)
        {
            strApp = Aplicacion;
            Fecha = fecha;
            FechaEnt = fechaEnt;
            Numero = numero; 
            Cliente = cliente;
            FormaPago = formaPago;
            IVA = iva;
            Desc = desc;
            Total = total;
            Nombre = nombre;
            CodEmpleado = codEmpleado;
            Empleado = empleado;
            Codigo = codigo;
            Producto = producto;
            Cantidad = cantidad;
            strSQL = string.Empty;
            Error = string.Empty;
        }

        //Constructor Encabezado
        public clsFacturacion(string Aplicacion, DateTime fecha, DateTime fechaEnt, int numero, string cliente, int formaPago,
             int codEmpleado)
        {
            strApp = Aplicacion;
            Fecha = fecha;
            FechaEnt = fechaEnt;
            Numero = numero;
            Cliente = cliente;
            FormaPago = formaPago;
            IVA = 0f;
            Desc = 0f;
            Total = 0f;
            Nombre = string.Empty;
            CodEmpleado = codEmpleado;
            Empleado = string.Empty; ;
            Codigo = 0;
            Producto = string.Empty; ;
            Cantidad = 0f;
            strSQL = string.Empty;
            Error = string.Empty;
        }

        //Constructor Detalle
        public clsFacturacion(string Aplicacion, int numero, int codigo, float cantidad)
        {
            strApp = Aplicacion;
            Numero = numero;
            Codigo = codigo;
            Cantidad = cantidad;
            strSQL = string.Empty;
            Error = string.Empty;
        }

        #endregion

        #region "Métodos Privados"
        private bool ValidarDatosEncabezado()
        {
            if (Fecha > DateTime.Now.Date)
            {
                Error = "Fecha no válida";
                return false;
            }
            if (Fecha > FechaEnt)
            {
                Error = "Fecha de entegra no válida";
                return false;
            }
            if (string.IsNullOrEmpty(Cliente))
            {
                Error = "Nro. del Doc. del cliente no válido";
                return false;
            }
            if (Convert.ToInt32(Cliente) <= 0)
            {
                Error = "Nro. del Doc. del cliente no válido";
                return false;
            }
            if (FormaPago <= 0)
            {
                Error = "Falta la forma de pago de la factura";
                return false;
            }
            return true;
        }

        private bool ValidarDatosDetalle()
        {
            if (string.IsNullOrEmpty(Codigo.ToString()))
            {
                Error = "Nro. del producto no válido";
                return false;
            }
            if (Convert.ToInt32(Codigo) <= 0)
            {
                Error = "Nro. del producto no válido";
                return false;
            }
            if (string.IsNullOrEmpty(Cantidad.ToString()))
            {
                Error = "Cant. del producto no válido";
                return false;
            }
            if (Convert.ToInt32(Cantidad) <= 0)
            {
                Error = "Cant. del producto no válido";
                return false;
            }
            return true;
        }

        private bool Grabar()
        {
            try
            {
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.consultarValorUnico(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                Numero = Convert.ToInt32(objCnx.vrUnico);
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

        private void Grabar2()
        {
            try
            {
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.ejecutarSentencia(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return;
                }
                objCnx.cerrarCnx();
                objCnx = null;
            }
            catch (Exception ex)
            { Error = ex.Message; }
        }


        private bool BuscarTipoCliente(string NroDocCliente)
        {
            try
            {
                strSQL = "EXEC USP_Cli_TipoCliRN '" + NroDocCliente + "';";
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader = objCnx.dataReaderLleno;
                if (!MyReader.HasRows)
                {
                    Error = "No existe registro con el Documento: " + NroDocCliente;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader.Read();
                TipoCliente = MyReader.GetInt32(0);
                MyReader.Close();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        #endregion

        #region "Metodos Públicos"

        public bool BorrarDetalle(int Factura, int Seq)
        {
            try
            {
                strSQL = "EXEC USP_Fac_BorrarDetalle " + Factura + " , " + Seq + "; ";
                if (Grabar())
                {
                    Numero = Factura;
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool BuscarFactura(int Factura, GridView grid)
        {
            try
            {
                if (Factura <= 0 || grid == null)
                {
                    Error = "Nro. de Factura no Válido";
                    return false;
                }
                strSQL = "EXEC USP_Fac_BuscarXNumero " + Factura + ";";
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.llenarDataSet(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                Myds = objCnx.dataSetLleno;
                objCnx = null;
                Mydt = Myds.Tables[0];
                if (Mydt.Rows.Count <= 0)
                {
                    Error = "No existe la factura nro.: " + Factura;
                    Myds.Clear();
                    Myds = null;
                    return false;
                }
                DataRow dr = Mydt.Rows[0];
                Numero = Convert.ToInt32(dr["Numero"]); // ó dr[0]
                Fecha = Convert.ToDateTime(dr["Fecha"]);
                Cliente = dr["Cliente"].ToString();
                Nombre = dr["Nombre"].ToString();
                FormaPago = Convert.ToInt32(dr["FormaPago"]);
                FechaEnt = Convert.ToDateTime(dr["FechaEntrega"]);
                IVA = Convert.ToSingle(dr["IVA"]);
                Desc = Convert.ToSingle(dr["Descuento"]);
                Total = Convert.ToSingle(dr["Total"]);
                Empleado = dr["Empleado"].ToString();
                Mydt.Clear();
                Mydt = Myds.Tables[1];
                grid.DataSource = Mydt;
                grid.DataBind();
                grid.GridLines = GridLines.Both;
                grid.CellPadding = 1;
                grid.ForeColor = System.Drawing.Color.Black;
                grid.BackColor = System.Drawing.Color.Beige;
                grid.AlternatingRowStyle.BackColor = System.Drawing.Color.Gainsboro;
                grid.HeaderStyle.BackColor = System.Drawing.Color.Aqua;
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool BuscarNombreCliente(string NroDocCliente)
        {
            try
            {
                strSQL = "EXEC USP_Fac_BuscarCliente '" + NroDocCliente + "';";
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader = objCnx.dataReaderLleno;
                if (!MyReader.HasRows)
                {
                    Error = "No existe registro con el Documento: " + NroDocCliente;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader.Read();
                Nombre = MyReader.GetString(0);
                MyReader.Close();
                return true;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool BuscarNombreProducto(int Codigo)
        {
            try
            {
                strSQL = "EXEC USP_BuscarProducto " + Codigo + ";";
                clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                objCnx.SQL = strSQL;
                if (!objCnx.Consultar(false))
                {
                    Error = objCnx.Error;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader = objCnx.dataReaderLleno;
                if (!MyReader.HasRows)
                {
                    Error = "No existe registro con el Documento: " + Codigo;
                    objCnx.cerrarCnx();
                    objCnx = null;
                    return false;
                }
                MyReader.Read();
                Producto = MyReader.GetString(0);
                MyReader.Close();
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
            if (!ValidarDatosEncabezado()) //|| !ValidarDatosDetalle())
                return false;
            //Grabar el encabezado
            strSQL = "EXEC USP_Fac_Grabar_Agregar '" + Cliente + "'," + "'" + FormaPago + "'," + CodEmpleado + ";";
            if (!Grabar())
                return false;
            
            //Grabar el Detalle
            //strSQL = "EXEC USP_Fac_GrabarDetalle " + Numero + ", " + Codigo + ", "  + Cantidad + ", "+ PorcDesc + ";";
            //if (!Grabar())
                //return false;
            return true;
        }

        public bool ModificarMaestro()
        {
            if (Numero <= 0)
            {
                Error = "Nro. de Factura no Válido";
                return false;
            }
            if (!ValidarDatosEncabezado())
                return false;
            strSQL = "EXEC USP_Fac_Grabar_Modificar " + Numero + "," +  FormaPago + "," + "'" + FechaEnt +
            "'," + CodEmpleado + ";";
            if (!Grabar())
                return false;
            return true;
        }

        public bool BuscarCliente_Factura(string NroDocCliente, GridView grid)
        {
            try
            {
                if (BuscarNombreCliente(NroDocCliente))
                {
                    strSQL = "EXEC USP_Fac_BuscarFac_X_Cliente '" + NroDocCliente + "';";
                    clsGeneralesBD objCnx = new clsGeneralesBD(strApp);
                    objCnx.SQL = strSQL;
                    if (!objCnx.llenarDataSet(false))
                    {
                        Error = objCnx.Error;
                        objCnx.cerrarCnx();
                        objCnx = null;
                        return false;
                    }

                    Myds = objCnx.dataSetLleno;
                    objCnx = null;
                    Mydt = Myds.Tables[0];
                    if (Mydt.Rows.Count <= 0)
                    {
                        Error = "No existen facturas para el cliente con Nro. Doc.: " + NroDocCliente;
                        Myds.Clear();
                        Myds = null;
                        return false;
                    }
                    grid.DataSource = Mydt;
                    grid.DataBind();
                    grid.GridLines = GridLines.Both;
                    grid.CellPadding = 1;
                    grid.ForeColor = System.Drawing.Color.Black;
                    grid.BackColor = System.Drawing.Color.Beige;
                    grid.AlternatingRowStyle.BackColor = System.Drawing.Color.Gainsboro;
                    grid.HeaderStyle.BackColor = System.Drawing.Color.Aqua;
                    return true;
                }
                else
                {
                    Error = "No existe el cliente con Nro. Doc.: " + NroDocCliente;
                    return false;
                }
            }
            catch (Exception ex)
            {
                Error = ex.Message;
                return false;
            }
        }

        public bool GrabarDetalle()
        {
            try
            {
                if (!ValidarDatosDetalle())
                    return false;
                if (Numero <= 0)
                {
                    Error = "Nro. de Factura no Válido";
                    return false;
                }
                //Comienza RN
                float PorcDesc = -1;
                clsOpDescuento oO = new clsOpDescuento();
                oO.intTipo = TipoCliente;
                oO.intCant = Convert.ToInt32(Cantidad);
                if (BuscarTipoCliente(Cliente))
                {
                    if (oO.Descuento())
                        PorcDesc = oO.fltDesc;
                }
                strSQL = "EXEC USP_Fac_GrabarDetalle " + Numero + ", " + Codigo + ", " + Cantidad + ", " +
                PorcDesc + ";";
                if (!Grabar())
                    return false;
                return true;
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