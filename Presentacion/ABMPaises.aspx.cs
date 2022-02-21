using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Drawing;
using EntidadesCompartidas;
using Logica;

public partial class ABMPaises : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
            LimpioForm();
    }

    private void LimpioForm()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;
        btnBuscar.Enabled = true;

        txtCod.Text = "";
        txtCod.Enabled = true;
        txtNom.Text = "";
        txtNom.Enabled = false;
    }

    private void ActivoBotones(bool Alta = true)
    {
        btnAlta.Enabled = Alta;
        btnModificar.Enabled = !Alta;
        btnBaja.Enabled = !Alta;
        btnBuscar.Enabled = false;

        txtCod.Enabled = false;
        txtNom.Enabled = true;
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioForm();
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string codP = txtCod.Text.Trim();
        try
        {
            if (codP.Length == 0)
                throw new Exception("El Código no puede estar vacio");
            else if (codP.Length > 3)
                throw new Exception("El Código debe ser de 3 letras");

            Pais pPais = LogicaPaises.Buscar(codP);
            if (pPais != null)
            {
                txtNom.Text = pPais.Nombre;

                ActivoBotones(false);

                Session["PaisBuscado"] = pPais;
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Black;
                lblError.Text = "No hay Paises con ese código";

                Session["PaisBuscado"] = null;
            }
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            string codP = txtCod.Text.Trim();
            string nombre = txtNom.Text.Trim();

            Pais pais = new Pais(codP, nombre);

            LogicaPaises.AgregarPais(pais);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Alta con exito";

            LimpioForm();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pPais = (Pais)Session["PaisBuscado"];

            pPais.Nombre = txtNom.Text.Trim();

            LogicaPaises.ModificarPais(pPais);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Modificacion con exito";

            LimpioForm();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
    protected void btnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            Pais pPais = (Pais)Session["PaisBuscado"];

            LogicaPaises.EliminarPais(pPais);

            lblError.ForeColor = Color.Green;
            lblError.Text = "Eliminacion exitosa";

            LimpioForm();
        }
        catch (Exception ex)
        {
            lblError.ForeColor = Color.Red;
            lblError.Text = ex.Message;
        }
    }
}