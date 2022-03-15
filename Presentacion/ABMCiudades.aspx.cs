using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

using EntidadesCompartidas;
using Logica;

public partial class ABMCiudades : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            LimpioForm();

        }
    }



    private void LimpioForm()
    {
        btnCrear.Enabled = false;
        btnModificar.Enabled = false;
        btnEliminar.Enabled = false;
        btnBuscar.Enabled = true;
        btnLimpiar.Enabled = false;

        txtCodC.Text = "";
        txtCodC.Enabled = true;
        txtCodP.Text = "";
        txtCodP.Enabled = true;
        txtNom.Text = "";
        txtNom.Enabled = false;
    }

    private void ActivoBotones(bool Alta = true)
    {
        btnCrear.Enabled = Alta;
        btnModificar.Enabled = !Alta;
        btnEliminar.Enabled = !Alta;
        btnBuscar.Enabled = false;
        btnLimpiar.Enabled = true;

        txtCodC.Enabled = false;
        txtCodP.Enabled = false;
        txtNom.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string codCiudad;
            
            codCiudad = Convert.ToString(txtCodC.Text).Trim();

            string codPais;
            codPais = Convert.ToString(txtCodP.Text).Trim();

            if (codCiudad == "" || codPais == "")
            {
                throw new Exception("Ninguno de los codigos puede ser vacio");
            }

            Ciudad pCiudad = LogicaCiudades.Buscar(codCiudad, codPais);

            if (pCiudad != null)
            {
                txtCodP.Text = pCiudad.Pais.CodigoP;
                txtNom.Text = pCiudad.Nombre;

                ActivoBotones(false);
                Session["CiudadEncontrada"] = pCiudad;
            }
            else
            {
                ActivoBotones();
                lblError.Text = "No hay ciudades con ese codigo";
                lblError.ForeColor = Color.Black;

                Session["CiudadEncontrada"] = null;

            }

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
            Ciudad pCiudad = (Ciudad)Session["CiudadEncontrada"];

            pCiudad.Nombre = txtNom.Text.Trim();

            LogicaCiudades.Modificar(pCiudad);

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


    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        try
        {
            Ciudad pCiudad = (Ciudad)Session["CiudadEncontrada"];

            LogicaCiudades.EliminarCiudad(pCiudad);

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


    protected void btnCrear_Click(object sender, EventArgs e)
    {
        try
        {
            string codP = Convert.ToString(txtCodP.Text).Trim();
            string codC = Convert.ToString(txtCodC.Text).Trim();
            string pNombre = Convert.ToString(txtNom.Text).Trim();

            Pais pPais = LogicaPaises.Buscar(codP);


            Ciudad pCiudad = new Ciudad(pPais, codC, pNombre);

            LogicaCiudades.AgregarCiudad(pCiudad);

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
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        LimpioForm();
    }
}