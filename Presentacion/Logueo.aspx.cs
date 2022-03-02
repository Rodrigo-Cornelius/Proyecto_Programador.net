using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class Logueo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = LogicaUsuarios.Logueo(txtUsu.Text.Trim(), txtPass.Text.Trim());

            if (usuario != null)
            {
                Session["Usuario"] = usuario;
                Response.Redirect("Bienvenida.aspx");
            }
            else
                lblerror.Text = "Datos Incorrectos";
        }
        catch (Exception ex)
        {
            lblerror.Text = ex.Message;
        }
        
    }
}