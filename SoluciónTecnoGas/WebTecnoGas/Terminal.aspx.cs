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
    public partial class Formulario_web17 : System.Web.UI.Page
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
                Terminal t = new Terminal();
                DataSet ds = t.ListarCamposGridView();
                Usuario u = new Usuario();
                DataSet dsu = u.ListarIdNombreCajeroSQL();
                ddlUsuario.DataSource = dsu.Tables[0].DefaultView;
                ddlUsuario.DataValueField = "ID_USUARIO";
                ddlUsuario.DataTextField = "NOMBRE_USUARIO";
                ddlUsuario.DataBind();
                            
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvTerminal.DataSource = ds;
                    gvTerminal.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de terminales');</script>");
                }
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            char estatus = 'F';
            if(rdoActivo.Checked)
                estatus = 'T';
            bool ingresado = t.CrearTerminalSQL(txtMac.Text, estatus, ddlUsuario.SelectedValue.ToString());

            if (ingresado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! terminal no ingresado.');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            char estatus = 'F';

            if (rdoActivo.Checked)            
                estatus = 'T';

            bool actualizado = t.ActualizarTerminalSQL(txtId.Text,txtMac.Text,estatus,ddlUsuario.SelectedValue.ToString());

            if (actualizado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! terminal no actualizado.');</script>");

            btnActualizar.Visible = false;
        }

        private void LimpiarControles()
        {
            txtId.Text = string.Empty;
            txtMac.Text = string.Empty;
            rdoActivo.Checked = true;
        }

        protected void lbLimpiarProductos_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void gvTerminal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                btnActualizar.Visible = true;
                Terminal t = new Terminal();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvTerminal.DataKeys[index].Value);
                Terminal term = t.RetornaTerminal(id.ToString());

                txtId.Text = term.Id;
                txtMac.Text = term.Mac;
                if (term.Estatus == 'T')
                    rdoActivo.Checked = true;
                else
                    rdoInactivo.Checked = true;
                ddlUsuario.SelectedValue = term.Usuario;
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                Terminal t = new Terminal();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvTerminal.DataKeys[index].Value);
                bool eliminado = t.EliminarTerminalSQL(id.ToString());

                if (eliminado)
                    Response.Redirect(Request.RawUrl);
                else
                    Response.Write(@"<script language='javascript'>alert('Problemas! terminal no eliminado.');</script>");
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }

        protected void btnMac_Click(object sender, EventArgs e)
        {
            Terminal t = new Terminal();
            string mac = t.ObtenerDireccionMAC();
            txtMac.Text = mac;
        }
    }
}