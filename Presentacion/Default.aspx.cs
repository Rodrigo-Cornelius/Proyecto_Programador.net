using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        Session["Usuario"] = null;
        lblFecha.Text = DateTime.Today.ToShortDateString();
        string texto = "";
        try
        {
            List<Pronostico> allPronosticos = LogicaPronosticos.ListarPronosticos(DateTime.Now);
            if (allPronosticos.Count == 0)
                throw new Exception("No existen pronosticos para la fecha");

            foreach (Pronostico prono in allPronosticos)
                texto = texto == "" ? prono.ToString() : texto + "\n\n" + prono.ToString();
            txtListado.Text = texto;
        }
        catch (Exception ex)
        {            
            lblError.Text = ex.Message;
        }        
    }
    protected void lbLogin_Click(object sender, EventArgs e)
    {

    }
}