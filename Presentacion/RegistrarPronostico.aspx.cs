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
        txtFecha.Attributes.Add("Type", "Date");
        txtHora.Attributes.Add("Type", "Time");
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
                else
                {
                    throw new Exception("No hay ciudades registradas");
                }
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    private void LimpioFormulario()
    {
        txtFecha.Text = "";
        txtTempMax.Text = "";
        txtTempMin.Text = "";
        txtVelViento.Text = "";
        txtHora.Text = "";
        txtFecha.Text = "";
        txtProbLluvias.Text = "";
        gvCiudad.SelectedIndex = -1;
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
            
            int maxTemp = Convert.ToInt32(txtTempMax.Text.Trim());
            int minTemp = Convert.ToInt32(txtTempMin.Text.Trim());
            int velViento = Convert.ToInt32(txtVelViento.Text.Trim());
            string tipoCielo = ddlTipoCielo.SelectedItem.Text;

            string fecha = txtFecha.Text.Trim();
            string hora = txtHora.Text.Trim();
            int[] fecHora = ConvertirFechaHora(fecha, hora);
            DateTime fechaHora = new DateTime(fecHora[0], fecHora[1], fecHora[2], fecHora[3], fecHora[4], 0);

            int probLluvias = Convert.ToInt32(txtProbLluvias.Text);
            Ciudad ciudad = (Ciudad)Session["CiudadSeleccionada"];
            Usuario usuario = (Usuario)Session["Usuario"];

            Pronostico pPronostico = new Pronostico(0, maxTemp, minTemp, velViento, tipoCielo, fechaHora, probLluvias, ciudad, usuario);

            int nuevoID = LogicaPronosticos.Agregar(pPronostico);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Pronostico agregado correctamente con id " + Convert.ToString(nuevoID);

            LimpioFormulario();

        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    private int[] ConvertirFechaHora(string pFecha, string pHoraMinutos)
    {
        int[] resultado = new int[5];
        try
        {
            string[] subFecha = pFecha.Split('-');
            string[] subHoraMin = pHoraMinutos.Split(':');
            resultado[0] = Convert.ToInt32(subFecha[0]);
            resultado[1] = Convert.ToInt32(subFecha[1]);
            resultado[2] = Convert.ToInt32(subFecha[2]);
            resultado[3] = Convert.ToInt32(subHoraMin[0]);
            resultado[4] = Convert.ToInt32(subHoraMin[1]);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return resultado;
    }
}