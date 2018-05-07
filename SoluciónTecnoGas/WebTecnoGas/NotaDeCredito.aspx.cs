using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebTecnoGas
{
    public partial class Formulario_web19 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"].ToString().Equals("Administrador"))
            {
                btnIrMóduloVenta.Visible = false;
                lblBienvenida.Text = "HOLA, " + Session["Nombre"].ToString();
                lblCargo.Text = "USTED ES, " + Session["Usuario"].ToString().ToUpper();
            }
            else if (Session["Usuario"].ToString().Equals("Cajero"))
            {
                btnVolver.Visible = false;
                SiteMapPath1.Visible = false;
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