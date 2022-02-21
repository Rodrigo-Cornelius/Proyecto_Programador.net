using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class RegistrarPronostico : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        try
        {
            if (!IsPostBack)
            {
                List<Ciudad> colCiudades = LogicaCiudades.ListarCiudades();

                if (colCiudades.Count > 0)
                {
                    Session["ListadoCiudades"] = colCiudades;
                    gvCiudad.DataSource = colCiudades;
                    gvCiudad.DataBind();
                }
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void gvCiudad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Ciudad> colCiudades = (List<Ciudad>)Session["ListadoCiudades"];
            int selIndex = gvCiudad.SelectedIndex;
            Session["CiudadSeleccionada"] = colCiudades[selIndex];

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        try
        {
            int codigo;
            float maxTemp;
            float minTemp;
            int velViento;
            string tipoCielo;
            DateTime fechaHora;
            int probLluvias;
            Ciudad ciudad;
            Usuario usuario;
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}