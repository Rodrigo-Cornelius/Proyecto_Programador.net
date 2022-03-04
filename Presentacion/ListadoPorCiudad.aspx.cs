using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Logica;
using EntidadesCompartidas;
using System.Drawing;

public partial class ListadoPorCiudad : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";
        try
        {
            if (!IsPostBack)
            {
                List<Pais> allPaises = LogicaPaises.ListarPaises();
                Session["TodosPaises"] = allPaises;

                if (allPaises.Count == 0)
                {
                    ddlPaises.Enabled = false;
                    throw new Exception("No existen paises en la base de datos");
                }
                else
                {

                    ListItem i;

                    foreach (var pais in allPaises)
                    {
                        i = new ListItem(pais.Nombre, pais.CodigoP);
                        ddlPaises.Items.Add(i);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void ddlPaises_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            gvPronosticos.DataSource = null;
            gvPronosticos.DataBind();
            gvCiudades.SelectedIndex = -1;
            string opcion = ddlPaises.SelectedValue;
            if (opcion == "0")
            {
                gvCiudades.DataSource = null;
                gvCiudades.DataBind();
                throw new Exception("Seleccione un Pais");

            }
            else
            {
                List<Pais> todoPaises = (List<Pais>)Session["TodosPaises"];

                List<Ciudad> ciudadesPorPais = new List<Ciudad>();
                foreach (var pais in todoPaises)
                {
                    if (pais.CodigoP == opcion)
                    {
                        ciudadesPorPais = LogicaCiudades.ListarCiudades(pais);
                        break;
                    }
                }
                if (ciudadesPorPais.Count == 0)
                {
                    gvCiudades.DataSource = null;
                    gvCiudades.DataBind();
                    throw new Exception("No existen ciudades para ese pais");
                }
                gvCiudades.DataSource = ciudadesPorPais;
                gvCiudades.DataBind();
                Session["CiudadesActuales"] = ciudadesPorPais;


               
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
        
    }


    protected void gvCiudades_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            List<Ciudad> ciudadesActuales = (List<Ciudad>)Session["CiudadesActuales"];
            Ciudad ciudadSeleccionada = ciudadesActuales[gvCiudades.SelectedIndex];

            List<Pronostico> pronoPorCiudad = LogicaPronosticos.Buscar(ciudadSeleccionada);

            gvPronosticos.DataSource = pronoPorCiudad;
            gvPronosticos.DataBind();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}