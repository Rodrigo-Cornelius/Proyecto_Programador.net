using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using EntidadesCompartidas;
using Logica;
using System.Drawing;

public partial class ABMUsuarios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblError.Text = "";

        if (!IsPostBack)
        {
            LimpioForm();

            txtPass.Attributes.Add("Type", "Password");
        }
    }

    private void LimpioForm()
    {
        btnAlta.Enabled = false;
        btnModificar.Enabled = false;
        btnBaja.Enabled = false;
        btnBuscar.Enabled = true;

        txtUsu.Text = "";
        txtUsu.Enabled = true;
        txtPass.Text = "";
        txtPass.Enabled = false;
        txtNom.Text = "";
        txtNom.Enabled = false;
        txtApe.Text = "";
        txtApe.Enabled = false;
    }

    private void ActivoBotones(bool Alta = true)
    {
        btnAlta.Enabled = Alta;
        btnModificar.Enabled = !Alta;
        btnBaja.Enabled = !Alta;
        btnBuscar.Enabled = false;

        txtUsu.Enabled = false;        
        txtPass.Enabled = true;
        txtNom.Enabled = true;
        txtApe.Enabled = true;
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        string logUser = txtUsu.Text.Trim();
        try
        {
            if (logUser.Length == 0)
                throw new Exception("El Usuario no puede estar vacio");
            else if (logUser.Length < 3)
                throw new Exception("El Usuario debe tener al menos 3 caracteres");

            Usuario pUsuario = LogicaUsuarios.Buscar(logUser);
                                    
            if (pUsuario != null)
            {
                txtPass.Text = pUsuario.Password;
                txtNom.Text = pUsuario.Nombre;
                txtApe.Text = pUsuario.Apellido;

                ActivoBotones(false);

                Session["UsuarioBuscado"] = pUsuario;

                List<Pronostico> pUserProno = LogicaPronosticos.Buscar(pUsuario);

                if (pUserProno.Count != 0)
                {
                    btnBaja.Enabled = false;
                }
            }
            else
            {
                ActivoBotones();

                lblError.ForeColor = Color.Black;
                lblError.Text = "No hay usuarios con ese Nombre de Usuario";

                Session["UsuarioBuscado"] = null;
            }
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
    protected void btnAlta_Click(object sender, EventArgs e)
    {
        try
        {
            string logUser = txtUsu.Text.Trim();
            string pass = txtPass.Text;
            string nom = txtNom.Text.Trim();
            string ape = txtApe.Text.Trim();

            Usuario usu = new Usuario(logUser, pass, nom, ape);

            LogicaUsuarios.Agregar(usu);

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
            Usuario pUsu = (Usuario)Session["UsuarioBuscado"];

            pUsu.Password = txtPass.Text;
            pUsu.Nombre = txtNom.Text.Trim();
            pUsu.Apellido = txtApe.Text.Trim();

            LogicaUsuarios.Modificar(pUsu);

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
            Usuario pUsu = (Usuario)Session["UsuarioBuscado"];

            LogicaUsuarios.Eliminar(pUsu);

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