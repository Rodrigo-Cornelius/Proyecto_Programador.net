using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using System.Drawing;

public partial class ListadoPorFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        txtFecha.Attributes.Add("Type", "Date");
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string fecha = txtFecha.Text;
        try
        {
            int[] fech = ConvertirFecha(fecha);
            DateTime pFecha = new DateTime(fech[0], fech[1], fech[2]);
            List<Pronostico> colPronosticos = LogicaPronosticos.ListarPronosticos(pFecha);
            
            if (colPronosticos.Count > 0)
            {
                gvPronos.DataSource = colPronosticos;
                gvPronos.DataBind();
            }
            else
            {
                gvPronos.DataSource = null;
                gvPronos.DataBind();
                throw new Exception("No hay pronosticos para mostrar");
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    private int[] ConvertirFecha(string pFecha)
    {
        int[] resultado = new int[3];
        try
        {
            string[] subFecha = pFecha.Split('-');
            resultado[0] = Convert.ToInt32(subFecha[0]);
            resultado[1] = Convert.ToInt32(subFecha[1]);
            resultado[2] = Convert.ToInt32(subFecha[2]);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return resultado;
    }
}