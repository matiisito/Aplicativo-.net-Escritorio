using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Biblioteca.Objetos;
using System.Data;

namespace WebTecnoGas
{
    public partial class Formulario_web12 : System.Web.UI.Page
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
                CategoriaProducto cp = new CategoriaProducto();
                DataSet ds = cp.ListarCamposSQL();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCategoriaProducto.DataSource = ds;
                    gvCategoriaProducto.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de categorias de productos');</script>");
                }
            }

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            CategoriaProducto cp = new CategoriaProducto();
            char estatus = 'F';
            if (rdoActivo.Checked == true)
                estatus = 'T';
            bool resultado = cp.CrearCategoriaProductoSQL(txtNombre.Text, estatus);
            if (resultado)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! categoria de productos no creada.');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            CategoriaProducto cp = new CategoriaProducto();
            char estatus = 'F';
            if(rdoActivo.Checked)
                estatus = 'T';
            bool actualizado = cp.ActualizarCategoriaProductoSQL(txtId.Text,txtNombre.Text,estatus);

            if (actualizado)
            {
                Response.Redirect(Request.RawUrl);
            }
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! categoria de productos no actualizada.');</script>");

            btnActualizar.Visible = false;
        }

        private void LimpiarControles()
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            rdoActivo.Checked = true;
        }

        protected void lbLimpiarProductos_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void gvCategoriaProducto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                btnActualizar.Visible = true;
                CategoriaProducto cp = new CategoriaProducto();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvCategoriaProducto.DataKeys[index].Value);
                CategoriaProducto capro = cp.RetornaCategoria(id.ToString());

                txtId.Text = capro.Id;
                txtNombre.Text = capro.Nombre;
                if (capro.Estatus == 'T')
                    rdoActivo.Checked = true;
                else
                    rdoInactivo.Checked = true;

            }

            if (e.CommandName.Equals("Eliminar"))
            {
                CategoriaProducto cp = new CategoriaProducto();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvCategoriaProducto.DataKeys[index].Value);
                bool eliminado = cp.EliminarCategoriaProductoSQL(id.ToString());

                if (eliminado)
                    Response.Redirect(Request.RawUrl);
                else
                    Response.Write(@"<script language='javascript'>alert('Problemas! categoria de productos no eliminada.');</script>");
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }
    }
}