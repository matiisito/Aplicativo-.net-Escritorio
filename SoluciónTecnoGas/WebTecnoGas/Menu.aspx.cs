using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTecnoGas
{
    public partial class Formulario_web13 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btnVolver.Visible = false;
            if (Session["Usuario"].ToString().Equals("Administrador"))
            {
                lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
            }
            else
            {
                Response.Redirect("LogIn.aspx");
            }
        }

        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("LogIn.aspx");
        }
    }
}