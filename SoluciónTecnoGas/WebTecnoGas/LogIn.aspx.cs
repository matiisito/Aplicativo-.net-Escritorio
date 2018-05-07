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
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        private static string[] usuarios;
        protected void Page_Load(object sender, EventArgs e)
        {
            SiteMapPath1.Visible = false;
            lbtnLogOut.Visible = false;
            btnVolver.Visible = false;
            Usuario u = new Usuario();
            usuarios = u.ListarNombreUsuarioSQL();
            if (Page.IsPostBack)
            {
                Response.Write(@"<script language='javascript'>alert('Los datos son incorrectos.');</script>");
            }
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionList(string prefixText, int count, string contextKey)
        {
            return (from us in usuarios where us.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select us).Take(count).ToArray();
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario();
            DataSet usuario = u.CoincideUsuarioSQL(txtUsuario.Text, txtContraseña.Text);
            if (usuario.Tables[0].Rows.Count > 0)
            {
                if (usuario.Tables[0].Rows[0]["ESCAJERO_USUARIO"].ToString().Equals("T"))
                {
                    Session["Usuario"] = "Cajero";
                    Session["Nombre"] = txtUsuario.Text;
                    Response.Redirect("Venta.aspx");
                }
                if (usuario.Tables[0].Rows[0]["ESADMIN_USUARIO"].ToString().Equals("T"))
                {
                    Session["Usuario"] = "Administrador";
                    Session["Nombre"] = txtUsuario.Text;
                    Response.Redirect("Menu.aspx");
                }
                if (usuario.Tables[0].Rows[0]["ESJO_USUARIO"].ToString().Equals("T"))
                {
                    Session["Usuario"] = "Jefe de operaciones";
                    Session["Nombre"] = txtUsuario.Text;
                    Response.Redirect("Mantenedores.aspx");
                }

            }
        }
    }
}