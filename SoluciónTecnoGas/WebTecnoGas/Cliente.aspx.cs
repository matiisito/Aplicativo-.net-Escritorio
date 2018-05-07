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
    public partial class Formulario_web15 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"].ToString().Equals("Administrador"))
            {
                lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
            }
            else if (Session["Usuario"].ToString().Equals("Jefe de operaciones"))
            {
                SiteMapPath1.Visible = false;
                lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }

            if (!Page.IsPostBack)
            {
                Cliente c = new Cliente();
                DataSet ds = c.ListarClienteSQL();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvCliente.DataSource = ds;
                    gvCliente.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de clientes');</script>");
                }
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtDv.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFono.Text = string.Empty;
            txtGiro.Text = string.Empty;
        }

        protected void lbLimpiarUsuarios_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            string rut = txtRut.Text + "-" + txtDv.Text;
            if (rut.Length < 12)
                rut = "0" + rut;
            bool creado = c.CrearClienteSQL(rut, txtNombre.Text, txtDireccion.Text, txtEmail.Text, txtFono.Text, txtGiro.Text);
            if(creado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! cliente no creado.');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Cliente c = new Cliente();
            string rut = txtRut.Text + "-" + txtDv.Text;
            if (rut.Length < 12)
                rut = "0" + rut;
            bool actualizado = c.ActualizarClienteSQL(txtId.Text, rut, txtNombre.Text, 
                                                        txtDireccion.Text, txtEmail.Text, txtFono.Text, txtGiro.Text);

            if (actualizado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! cliente no actualizado.');</script>");

            btnActualizar.Visible = false;
        }

        protected void gvCliente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                Cliente c = new Cliente();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvCliente.DataKeys[index].Value);
                Cliente cli = c.RetornaCliente(id.ToString());

                txtId.Text = cli.Id;
                txtNombre.Text = cli.Nombre;
                txtRut.Text = cli.Rut.Substring(0, 10);
                txtDv.Text = cli.Rut.Substring(11, 1);
                txtDireccion.Text = cli.Direccion;
                txtEmail.Text = cli.Email;
                txtFono.Text = cli.Telefono;
                txtGiro.Text = cli.Giro;
                btnActualizar.Visible = true;
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                Cliente c = new Cliente();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvCliente.DataKeys[index].Value);
                bool eliminado = c.EliminarClienteSQL(id.ToString());

                if (eliminado)
                    Response.Redirect(Request.RawUrl);
                else
                    Response.Write(@"<script language='javascript'>alert('Problemas! cliente no eliminado.');</script>");
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }
    }
}