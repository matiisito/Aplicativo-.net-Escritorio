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
    public partial class Formulario_web14 : System.Web.UI.Page
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
                Cliente cli = new Cliente();
                ddlCliente.DataSource = cli.ListarIdNombreSQL();
                ddlCliente.DataValueField = "ID_CLIENTE";
                ddlCliente.DataTextField = "NOMBRE_CLIENTE";
                ddlCliente.DataBind();
                Contrato cont = new Contrato();
                DataSet ds = cont.ListarCamposSQL();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gvContrato.DataSource = ds;
                    gvContrato.DataBind();
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Sin registros de contratos');</script>");
                }
                ddlCliente.SelectedValue = "0";
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Contrato c = new Contrato();
            string fecha = cFecha.SelectedDate.Day.ToString() + "-" + cFecha.SelectedDate.Month.ToString() + "-" + cFecha.SelectedDate.Year.ToString();
            char estatus = 'F';
            if(rdoActivo.Checked)
                estatus = 'T';
            bool ingresado = c.CrearContratoSQL(fecha,estatus.ToString(),ddlCliente.SelectedValue.ToString());

            if (ingresado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! contrato no creado.');</script>");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Contrato c = new Contrato();
            string fecha = cFecha.SelectedDate.Day.ToString() + "-" + cFecha.SelectedDate.Month.ToString() + "-" + cFecha.SelectedDate.Year.ToString();
            char estatus = 'F';
            if (rdoActivo.Checked)
                estatus = 'T';
            bool actualizado = c.ActualizaContratoSQL(txtId.Text, fecha, estatus.ToString(), ddlCliente.SelectedValue.ToString());

            if (actualizado)
                Response.Redirect(Request.RawUrl);
            else
                Response.Write(@"<script language='javascript'>alert('Problemas! contrato no actualizado.');</script>");

            btnActualizar.Visible = false;
        }

        protected void gvContrato_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Seleccionar"))
            {
                btnActualizar.Visible = true;
                Contrato c = new Contrato();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvContrato.DataKeys[index].Value);
                Contrato cont = c.RetornaContrato(id.ToString());

                txtId.Text = cont.Id;
                ddlCliente.SelectedValue = cont.Cliente;
                cFecha.SelectedDate = cont.FechaContrato;
                if (cont.Estatus == 'T')
                    rdoActivo.Checked = true;
                else
                    rdoInactivo.Checked = true;
            }

            if (e.CommandName.Equals("Eliminar"))
            {
                Contrato c = new Contrato();
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvContrato.DataKeys[index].Value);
                bool eliminado = c.EliminaContratoSQL(id.ToString());

                if (eliminado)
                    Response.Redirect(Request.RawUrl);
                else
                    Response.Write(@"<script language='javascript'>alert('Problemas! contrato no eliminado.');</script>");
            }
        }

        private void LimpiarControles()
        {
            txtId.Text = string.Empty;
            ddlCliente.SelectedValue = "0";
            cFecha.SelectedDate = DateTime.Today;
            rdoActivo.Checked = true;
        }

        protected void lbLimpiarUsuarios_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }
    }
}