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
    public partial class Formulario_web16 : System.Web.UI.Page
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
                Usuario u = new Usuario();
                DataSet ds =  u.ListarUsuarioSQL();

                if (ds.Tables[0].Rows.Count > 0)
                {                
                    gvUsuario.DataSource = ds;
                    gvUsuario.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de usuarios');</script>");
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            string nom = txtNombre.Text;
            string rut = txtRut.Text +"-"+ txtDv.Text;
            if (rut.Length < 12)
                rut = "0" + rut;
            string clave = txtClave.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;
            bool cajero = false;
            bool admin = false;
            bool esjo = false;
            if (rdoCajero.Checked)
                cajero = true;
            if (rdoAdministrador.Checked)
                admin = true;
            if (rdoEsJo.Checked)
                esjo = true;

            bool resultado = u.CrearUsuarioSQL(rut,nom,clave,direccion,email,cajero,admin,esjo);

            if (resultado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! usuario no creado.');</script>");

            btnActualizar.Visible = false;
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            char cajero = 'F';
            char admin = 'F';
            char esjo = 'F';
            if(rdoCajero.Checked)
                cajero = 'T';
            if(rdoAdministrador.Checked)
                admin = 'T';
            if(rdoEsJo.Checked)
                esjo = 'T';
            string rut = txtRut.Text + "-" + txtDv.Text;
            if (rut.Length < 12)
                rut = "0" + rut;
            bool actualizado = u.ActualizarUsuarioSQL(txtId.Text,rut,
                                                        txtNombre.Text,txtClave.Text,txtDireccion.Text,txtEmail.Text,
                                                        cajero,admin,esjo);

            if(actualizado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! usuario no actualizado.');</script>");
        }

        protected void lbLimpiarUsuarios_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtRut.Text = string.Empty;
            txtDv.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtEmail.Text = string.Empty;
            rdoCajero.Checked = false;
            rdoAdministrador.Checked = false;
            rdoEsJo.Checked = false;
        }

        protected void gvUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                btnActualizar.Visible = true;
                Usuario u = new Usuario();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvUsuario.DataKeys[index].Value);
                Usuario us = u.RetornaUsuario(id.ToString());

                txtId.Text = us.Id;
                txtNombre.Text = us.Nombre;
                txtRut.Text = us.Rut.Substring(0, 10);
                txtDv.Text = us.Rut.Substring(11, 1);
                txtClave.Text = us.Clave;
                txtDireccion.Text = us.Direccion;
                txtEmail.Text = us.Email;

                if (us.EsCajero == 'T')
                    rdoCajero.Checked = true;

                if (us.EsAdmin == 'T')
                    rdoAdministrador.Checked = true;

                if (us.EsJefeOperaciones == 'T')
                    rdoEsJo.Checked = true;
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                Usuario u = new Usuario();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvUsuario.DataKeys[index].Value);
                bool eliminado = u.EliminarUsuarioSQL(id.ToString());

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