using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Biblioteca.Objetos;

namespace WebTecnoGas
{
    public partial class Formulario_web110 : System.Web.UI.Page
    {
        private static string[] productos;
        private static string[] combustibles;
        private static string[] clientes;
        private static DataTable dt;
        private static DataTable dtc;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Terminal t = new Terminal();
                string mac = t.ObtenerDireccionMAC();
                if (t.CajaAbierta(mac))
                {
                    lblEstatusCaja.Text = "CAJA ABIERTA";
                    lblCajero.Text = "CAJERO ASIGNADO, "+t.NombreCajero(mac);
                }
                else
                {
                    lblEstatusCaja.Text = "CAJA CERRADA";
                    CajaCerrada();
                }

                if (Session["Usuario"].ToString().Equals("Administrador"))
                {
                    CajaCerrada();
                    lblCajero.Visible = true;
                    btnIrNotaDeCredito.Visible = false;
                    lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                    lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
                }
                else if (Session["Usuario"].ToString().Equals("Cajero"))
                {
                    Usuario u = new Usuario();
                    string id_usuario = u.EncuentraIdUsuario(Session["Nombre"].ToString());
                    if(t.TerminalLibre(mac))
                    {
                        t.ActualizarTerminalSQL(t.RetornaId(mac), mac, 'T', id_usuario);
                        Response.Redirect("Venta.aspx");
                    }
                    else if (t.CoincidenUsuarioTerminal(id_usuario, mac))
                    {
                        lbtnLogOut.Visible = false;
                        btnLiberar.Visible = true;
                        btnVolver.Visible = false;
                        SiteMapPath1.Visible = false;
                        lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                        lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper() +" ASIGNADO";
                    }
                    else
                    {
                        Response.Redirect("LogIn.aspx");
                    }
                }
                else
                {
                    Response.Redirect("LogIn.aspx");
                }

                Producto p = new Producto();
                productos = p.ListarNombreProductoSQL();
                combustibles = p.ListarNombreCombustibleSQL();
                Cliente c = new Cliente();
                clientes = c.ListarNombreClienteSQL();
                dt = new DataTable();
                dt.Columns.Add(new DataColumn("", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PRODUCTO", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("DESCRIPCION", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("CANTIDAD", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("PRECIO", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("TOTAL", System.Type.GetType("System.String")));
                dt.Columns.Add(new DataColumn("", System.Type.GetType("System.String")));
                dtc = new DataTable();
                dtc.Columns.Add(new DataColumn("", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("PATENTE", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("PRODUCTO", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("DESCRIPCION", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("CANTIDAD", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("PRECIO", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("TOTAL", System.Type.GetType("System.String")));
                dtc.Columns.Add(new DataColumn("", System.Type.GetType("System.String")));
            }
        }

        private void CajaCerrada()
        {
            btnAgregar.Enabled = false;
            btnLiberar.Enabled = false;
            btnPagar.Enabled = false;
            txtProducto.Enabled = false;
            txtProducto_AutoCompleteExtender.Enabled = false;
            txtCombustibles.Enabled = false;
            txtCombustibles_AutoCompleteExtender.Enabled = false;
            rdoCliente.Enabled = false;
            rdoNoCliente.Enabled = false;
            rdoCombustibles.Enabled = false;
            rdoOtros.Enabled = false;
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListProductos(string prefixText, int count, string contextKey)
        {
            return (from prod in productos where prod.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select prod).Take(count).ToArray();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListCombustibles(string prefixText, int count, string contextKey)
        {
            return (from comb in combustibles where comb.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select comb).Take(count).ToArray();
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListClientes(string prefixText, int count, string contextKey)
        {
            return (from cli in clientes where cli.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select cli).Take(count).ToArray();
        }

        private string RetornaIdProducto(string id)
        {
            try
            {
                string identificador = string.Empty;

                int cont = 0;
                foreach (char c in id)
                {
                    if (c == '-')
                    {
                        break;
                    }
                    cont = cont + 1;
                }

                cont = cont - 1;
                identificador = id.Substring(0, cont);

                return identificador;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        protected void rdoNoCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = false;
        }

        protected void rdoCliente_CheckedChanged(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
        }

        protected void txtProducto_TextChanged(object sender, EventArgs e)
        {
            lblStock.Visible = true;
            txtStock.Visible = true;
            Producto p = new Producto();
            string id = RetornaIdProducto(txtProducto.Text);

            if (id != null)
            {
                string[] producto = p.RetonaIdDescripcionPrecioProducto(id);
                if (producto != null)
                {
                    txtId.Text = id;
                    txtNomProd.Text = producto[0];
                    txtDescri.Text = producto[1];
                    txtPrecio.Text = producto[2];
                    txtStock.Text = producto[3];
                }
                txtCantidad.Enabled = true;
                txtCantidad_NumericUpDownExtender.Enabled = true;
            }
            else
            {
                LimpiarControles();
            }
        }

        private void LimpiarControles()
        {
            lblStock.Visible = false;
            txtStock.Visible = false;
            txtStock.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = false;
            txtProducto.Text = string.Empty;
            txtProducto.Enabled = true;
            txtProducto.Visible = true;
            txtCombustibles.Visible = false;
            lblPatente.Visible = false;
            txtPatente.Visible = false;
            rfvPatente.Enabled = false;
            rfvPatente.Visible = false;
            btnAgregar.Enabled = true;
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;
            txtCantidad_NumericUpDownExtender.Enabled = false;
            rdoNoCliente.Checked = true;
            rdoOtros.Checked = true;
            txtId.Text = string.Empty;
            txtNomProd.Text = string.Empty;
            txtDescri.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtTotal.Text = string.Empty;
            btnGuardar.Visible = false;
            gvVenta.Visible = true;
            gvVentaCombustible.DataSource = null;
            gvVentaCombustible.DataBind();
            gvVentaCombustible.Visible = false;
            dtc.Clear();
        }

        private int ProductoExisteGridView(string id)
        {
            int existe = -1;
            int cont = 0;

            foreach (DataRow dr in dt.Rows)
            {
                if (dr[1].ToString() == id)
                {
                    existe = cont;
                    break;
                }
                cont = cont + 1;
            }

            return existe;
        }

        private int ProductoExisteGridViewCombustible(string id, string patente)
        {
            int existe = -1;
            int cont = 0;

            foreach (DataRow dr in dtc.Rows)
            {
                if (dr[1].ToString().Equals(id) && dr[2].ToString().Equals(patente))
                {
                    existe = cont;
                    break;
                }
                cont = cont + 1;
            }

            return existe;
        }

        private void EditaProductoGridView(int indice, int cantidad,int total)
        {
            dt.Rows[indice][4] = (int.Parse(dt.Rows[indice][4].ToString()) + cantidad).ToString();
            dt.Rows[indice][6] = (int.Parse(dt.Rows[indice][6].ToString()) + total).ToString();
        }
        
        private void EditaCombustibleGridView(int indice, int cantidad, int total)
        {
            dtc.Rows[indice][5] = (int.Parse(dtc.Rows[indice][5].ToString()) + cantidad).ToString();
            dtc.Rows[indice][7] = (int.Parse(dtc.Rows[indice][7].ToString()) + total).ToString();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            lblObservacion.Visible = true;
            txtObservacion.Visible = true;
            btnCancelar.Visible = true;
            btnPagar.Visible = true;
            if (rdoOtros.Checked)
            {
                int indice = ProductoExisteGridView(txtId.Text);
                if (indice == -1)
                {
                    int total = int.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text);
                    DataRow dr = dt.NewRow();
                    dr[1] = txtId.Text;
                    dr[2] = txtNomProd.Text;
                    dr[3] = txtDescri.Text;
                    dr[4] = txtCantidad.Text;
                    dr[5] = txtPrecio.Text;
                    dr[6] = total.ToString();
                    dt.Rows.Add(dr);
                    gvVenta.DataSource = dt;
                    gvVenta.DataBind();
                    lblTotal.Text = "$" + CalculaTotalVenta();
                    LimpiarControles();
                }
                else
                {
                    int cant = int.Parse(txtCantidad.Text);
                    int total = int.Parse(txtPrecio.Text) * cant;
                    EditaProductoGridView(indice, cant, total);
                    gvVenta.DataSource = dt;
                    gvVenta.DataBind();
                    lblTotal.Text = "$" + CalculaTotalVenta();
                    LimpiarControles();
                }
            }

            if (rdoCombustibles.Checked)
            {
                int indice = ProductoExisteGridViewCombustible(txtId.Text, txtPatente.Text);
                if (indice == -1)
                {
                    int total = int.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text);
                    DataRow dr = dtc.NewRow();
                    dr[1] = txtId.Text;
                    dr[2] = txtPatente.Text;
                    dr[3] = txtNomProd.Text;
                    dr[4] = txtDescri.Text;
                    dr[5] = txtCantidad.Text;
                    dr[6] = txtPrecio.Text;
                    dr[7] = total.ToString();
                    dtc.Rows.Add(dr);
                    gvVentaCombustible.DataSource = dtc;
                    gvVentaCombustible.DataBind();
                    lblTotal.Text = "$" + CalculaTotalVentaCombustible();
                    LimpiarControlesCombustibles();
                }
                else
                {
                    int cant = int.Parse(txtCantidad.Text);
                    int total = int.Parse(txtPrecio.Text) * cant;
                    EditaCombustibleGridView(indice, cant, total);
                    gvVentaCombustible.DataSource = dtc;
                    gvVentaCombustible.DataBind();
                    lblTotal.Text = "$" + CalculaTotalVentaCombustible();
                    LimpiarControlesCombustibles();
                }
            }
        }

        private int CalculaTotalVenta()
        {
            int suma = 0;
            foreach (DataRow dr in dt.Rows)
            {
                suma = suma + int.Parse(dr[6].ToString());
            }
            return suma;
        }

        private int CalculaTotalVentaCombustible()
        {
            int suma = 0;
            foreach (DataRow dr in dtc.Rows)
            {
                suma = suma + int.Parse(dr[7].ToString());
            }
            return suma;
        }

        protected void gvVenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Eliminar"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                dt.Rows.RemoveAt(index);
                gvVenta.DataSource = dt;
                gvVenta.DataBind();
                lblTotal.Text = "$" + CalculaTotalVenta();
            }

            if (e.CommandName.Equals("Seleccionar"))
            {
                btnGuardar.Visible = true;
                txtCantidad.Enabled = true;
                txtCantidad_NumericUpDownExtender.Enabled = true;
                txtProducto.Enabled = false;
                btnAgregar.Enabled = false;
                int index = Convert.ToInt32(e.CommandArgument);
                txtId.Text = dt.Rows[index][1].ToString();
                txtNomProd.Text = dt.Rows[index][2].ToString();
                txtProducto.Text = dt.Rows[index][2].ToString();
                txtDescri.Text = dt.Rows[index][3].ToString();
                txtCantidad.Text = dt.Rows[index][4].ToString();
                txtPrecio.Text = dt.Rows[index][5].ToString();
                txtTotal.Text = dt.Rows[index][6].ToString();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (rdoOtros.Checked)
            {
                int index = ProductoExisteGridView(txtId.Text);
                int total = int.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text);
                dt.Rows[index][1] = txtId.Text;
                dt.Rows[index][2] = txtNomProd.Text;
                dt.Rows[index][3] = txtDescri.Text;
                dt.Rows[index][4] = txtCantidad.Text;
                dt.Rows[index][5] = txtPrecio.Text;
                dt.Rows[index][6] = total.ToString();
                gvVenta.DataSource = dt;
                gvVenta.DataBind();
                lblTotal.Text = "$" + CalculaTotalVenta();
                LimpiarControles();
            }

            if (rdoCombustibles.Checked)
            {
                int index = ProductoExisteGridViewCombustible(txtId.Text , txtPatente.Text);
                int total = int.Parse(txtPrecio.Text) * int.Parse(txtCantidad.Text);
                dtc.Rows[index][1] = txtId.Text;
                dtc.Rows[index][2] = txtPatente.Text;
                dtc.Rows[index][3] = txtCombustibles.Text;
                dtc.Rows[index][4] = txtDescri.Text;
                dtc.Rows[index][5] = txtCantidad.Text;
                dtc.Rows[index][6] = txtPrecio.Text;
                dtc.Rows[index][7] = total.ToString();
                gvVentaCombustible.DataSource = dtc;
                gvVentaCombustible.DataBind();
                lblTotal.Text = "$" + CalculaTotalVentaCombustible();
                LimpiarControlesCombustibles();
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }

        protected void rdoOtros_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControles();
            lblTotal.Text = string.Empty;
        }

        private void LimpiarControlesCombustibles()
        {
            lblStock.Visible = false;
            txtStock.Visible = false;
            txtStock.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = false;
            txtProducto.Visible = false;
            txtCombustibles.Text = string.Empty;
            txtCombustibles.Enabled = true;
            txtCombustibles.Visible = true;
            lblPatente.Visible = true;
            txtPatente.Visible = true;
            txtPatente.Text = string.Empty;
            txtPatente.Enabled = true;
            btnAgregar.Enabled = true;
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;
            txtCantidad_NumericUpDownExtender.Enabled = false;
            rdoNoCliente.Checked = true;
            rdoCombustibles.Checked = true;
            txtId.Text = string.Empty;
            txtNomProd.Text = string.Empty;
            txtDescri.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtTotal.Text = string.Empty;
            btnGuardar.Visible = false;
            gvVentaCombustible.Visible = true;
            rfvPatente.Enabled = true;
            rfvPatente.Visible = true;
            gvVenta.DataSource = null;
            gvVenta.DataBind();
            gvVenta.Visible = false;
            dt.Clear();
        }

        protected void rdoCombustibles_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarControlesCombustibles();
            lblTotal.Text = string.Empty;
        }

        protected void txtCombustibles_TextChanged(object sender, EventArgs e)
        {
            lblStock.Visible = true;
            txtStock.Visible = true;
            Producto p = new Producto();
            string id = RetornaIdProducto(txtCombustibles.Text);

            if (id != null)
            {
                string[] producto = p.RetonaIdDescripcionPrecioProducto(id);
                if (producto != null)
                {
                    txtId.Text = id;
                    txtNomProd.Text = producto[0];
                    txtDescri.Text = producto[1];
                    txtPrecio.Text = producto[2];
                    txtStock.Text = producto[3];
                }
                txtCantidad.Enabled = true;
                txtCantidad_NumericUpDownExtender.Enabled = true;
            }
            else
            {
                LimpiarControlesCombustibles();
            }
        }

        protected void gvVentaCombustible_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Eliminar"))
            {
                int index = Convert.ToInt32(e.CommandArgument);
                dtc.Rows.RemoveAt(index);
                gvVentaCombustible.DataSource = dtc;
                gvVentaCombustible.DataBind();
                lblTotal.Text = "$" + CalculaTotalVentaCombustible();
            }

            if (e.CommandName.Equals("Seleccionar"))
            {
                btnGuardar.Visible = true;
                txtCantidad.Enabled = true;
                txtCantidad_NumericUpDownExtender.Enabled = true;
                txtCombustibles.Enabled = false;
                txtPatente.Enabled = false;
                btnAgregar.Enabled = false;
                int index = Convert.ToInt32(e.CommandArgument);
                txtId.Text = dtc.Rows[index][1].ToString();
                txtPatente.Text = dtc.Rows[index][2].ToString();
                txtCombustibles.Text = dtc.Rows[index][3].ToString();
                txtDescri.Text = dtc.Rows[index][4].ToString();
                txtCantidad.Text = dtc.Rows[index][5].ToString();
                txtPrecio.Text = dtc.Rows[index][6].ToString();
                txtTotal.Text = dtc.Rows[index][7].ToString();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            lblObservacion.Visible = false;
            txtObservacion.Visible = false;
            txtObservacion.Text = string.Empty;

            if (rdoOtros.Checked)
            {
                LimpiarControles();
                gvVenta.DataSource = null;
                gvVenta.DataBind();
                dt.Clear();
                lblTotal.Text = string.Empty;
            }

            if (rdoCombustibles.Checked)
            {
                LimpiarControlesCombustibles();
                gvVentaCombustible.DataSource = null;
                gvVentaCombustible.DataBind();
                dtc.Clear();
                lblTotal.Text = string.Empty;
            }

            btnPagar.Visible = false;
            btnCancelar.Visible = false;
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            lblObservacion.Visible = false;
            txtObservacion.Visible = false;
            Cliente c = new Cliente();
            string id_cliente = c.EncuentraIdCliente(txtNombre.Text);

            if (rdoNoCliente.Checked)
                id_cliente = "1";

            Venta v = new Venta();
            Usuario u = new Usuario();
            string id_usuario = u.EncuentraIdUsuario(Session["Nombre"].ToString());
            string dia = DateTime.Now.Day.ToString();
            if (dia.Length < 2)
                dia = "0" + dia;
            string mes = DateTime.Now.Month.ToString();
            if (mes.Length < 2)
                mes = "0" + mes;
            string anio = DateTime.Now.Year.ToString();
            if (anio.Length < 2)
                anio = "0" + anio;
            string hora = DateTime.Now.Hour.ToString();
            if (hora.Length < 2)
                hora = "0" + hora;
            string min = DateTime.Now.Minute.ToString();
            if (min.Length < 2)
                min = "0" + min;
            string sec = DateTime.Now.Second.ToString();
            if (sec.Length < 2)
                sec = "0" + sec;
            string fecha = dia +"-"+ mes +"-"+anio+" "+hora+":"+min+":"+sec;
            string total = lblTotal.Text.Substring(1);
            char comercial = 'F';
            if(rdoCliente.Checked)
                comercial = 'T';
            string observacion = txtObservacion.Text;

            if (rdoOtros.Checked)
            {
                v.CrearVentaSQL(fecha, "", total, comercial, 'T', 'F', observacion, id_cliente, id_usuario, "1");
                string id_venta = v.EncuentraIdVenta(fecha,id_usuario);
                foreach (DataRow dr in dt.Rows)
                {
                    v.CrearDetalleVentaSQL(id_venta, dr[4].ToString(), dr[6].ToString(), dr[1].ToString());
                }
                LimpiarControles();
                gvVenta.DataSource = null;
                gvVenta.DataBind();
                dt.Clear();
                lblTotal.Text = string.Empty;
            }

            if (rdoCombustibles.Checked)
            {
                v.CrearVentaSQL(fecha, txtPatente.Text, total, comercial, 'T', 'F', observacion, id_cliente, id_usuario, "1");
                string id_venta = v.EncuentraIdVenta(fecha, id_usuario);
                foreach (DataRow dr in dtc.Rows)
                {
                    v.CrearDetalleVentaSQL(id_venta, dr[5].ToString(), dr[7].ToString(), dr[1].ToString());
                }
                LimpiarControlesCombustibles();
                gvVentaCombustible.DataSource = null;
                gvVentaCombustible.DataBind();
                dtc.Clear();
                lblTotal.Text = string.Empty;
            }

            btnCancelar.Visible = false;
            btnPagar.Visible = false;
            txtObservacion.Text = string.Empty;
        }

        protected void btnLiberar_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            string mac = t.ObtenerDireccionMAC();
            t.ActualizarTerminalSQL(t.RetornaId(mac), mac, 'F', "1");
            lblEstatusCaja.Text = "CAJA CERRADA";
            Response.Redirect("LogIn.aspx");
        }

    }
}