using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca.Objetos;

namespace WebTecnoGas
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"].ToString().Equals("Administrador"))
            {
                lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }

            if (!Page.IsPostBack)
            {
                Producto p = new Producto();
                DataSet ds = p.ListarProductoSQL();
                CategoriaProducto cp = new CategoriaProducto();
                ddlCategoria.DataSource = cp.ListarIdNombreSQL().Tables["CATEGORIA_PRODUCTO"].DefaultView;
                ddlCategoria.DataTextField = "NOMBRE_CATEGORIAPRODUCTO";
                ddlCategoria.DataValueField = "ID_CATEGORIAPRODUCTO";
                ddlCategoria.DataBind();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvProducto.DataSource = ds;
                    gvProducto.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de productos');</script>");
                }

                ddlCategoria.SelectedIndex = 0;
            }
        }

        private void LimpiarControles()
        {
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            txtCantidad.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            rdoActivo.Checked = true;
            ddlCategoria.SelectedIndex = 0;

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            CategoriaProducto cp = new CategoriaProducto();
            bool estatus = false;
            string nom = txtNombre.Text;
            int cant = int.Parse(txtCantidad.Text);
            string desc = txtDescripcion.Text;
            if (rdoActivo.Checked == true)
                estatus = true;
            int precio = int.Parse(txtPrecio.Text);
            int categ = int.Parse(ddlCategoria.SelectedValue);
            bool resultado = p.CrearProductoSQL(nom, cant, desc, estatus, precio, categ);
            if (resultado == true)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! producto no creado.');</script>");
        }

        protected void lbLimpiarProductos_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            char activado = 'T';
            if (rdoInactivo.Checked)
                activado = 'F';
            bool actualizado = p.ActualizarProductoSQL(txtId.Text, txtNombre.Text, txtCantidad.Text,
                                                        txtDescripcion.Text, activado,
                                                        txtPrecio.Text, ddlCategoria.SelectedItem.ToString());

            if (actualizado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! el producto no pudo ser actualizado.');</script>");

            btnActualizar.Visible = false;
        }

        protected void gvProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                btnActualizar.Visible = true;
                Producto p = new Producto();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvProducto.DataKeys[index].Value);
                Producto prod = p.CreaProducto(id.ToString());

                txtId.Text = prod.Id_prod.ToString();
                txtNombre.Text = prod.Nombre_prod;
                txtCantidad.Text = prod.Cantidad_prod.ToString();
                txtDescripcion.Text = prod.Descripcion_prod;

                if (prod.Estatus_producto == 'T')
                    rdoActivo.Checked = true;
                else
                    rdoInactivo.Checked = false;

                txtPrecio.Text = prod.Precio_producto.ToString();
                ddlCategoria.SelectedValue = prod.Id_categoriaproducto.ToString();
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                Producto p = new Producto();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvProducto.DataKeys[index].Value);
                bool eliminado = p.EliminarProductoSQL(id.ToString());

                if (eliminado)
                    Response.Redirect(Request.RawUrl);
                else
                    Response.Write(@"<script language='javascript'>alert('Problemas! usuario no eliminado.');</script>");
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }
    }
}