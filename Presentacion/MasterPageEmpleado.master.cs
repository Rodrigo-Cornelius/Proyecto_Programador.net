using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;

public partial class MasterPageEmpleado : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((Usuario)Session["Usuario"] != null)
                lblUsuario.Text = "Bienvenid@ " + ((Usuario)Session["Usuario"]).Nombre;
            else
                Response.Redirect("Default.aspx");                
        }
        catch
        {            
            Response.Redirect("Default.aspx");
        }
    }
    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
