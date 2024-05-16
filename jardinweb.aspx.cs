using Jardines.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Jardines
{
    public partial class jardinweb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarDatos();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            JardinDAO jardinDAO = new JardinDAO();
            Jardin jardin=new Jardin();
         //   jardin.idJardin=int.Parse(txtIdJardin.Text);
            jardin.nombre=txtNombre.Text;
            jardin.direccion=txtDireccion.Text;
            jardin.estado=ddlEstado.Text;
            if (jardinDAO.validarNombre(jardin.nombre))
            {
                jardinDAO.registrar(jardin);
                cargarDatos();

                PanelRegistro.Visible = false;
                PanelConsulta.Visible = true;
            }
            else
            {
                lblMensaje.Text = "El nombre del Jardin ya existe";
            }
        }

        public void cargarDatos()
        {
            JardinDAO jardinDAO=new JardinDAO();

            gdvJardines.DataSource = jardinDAO.consultarTodos();
            gdvJardines.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            PanelConsulta.Visible = false;
            PanelRegistro.Visible = true;
            btnRegistrar.Visible = true;
            btnEditar.Visible = false;
            txtIdJardin.Visible = false;
            txtDireccion.Text = String.Empty;
            txtNombre.Text = String.Empty;
            lblMensaje.Text = "";
        }

        protected void gdvJardines_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow fila =(GridViewRow) ((Control)e.CommandSource).NamingContainer;
            int indice = fila.RowIndex;

            if(e.CommandName== "Eliminar")
            {
                JardinDAO jardinDAO = new JardinDAO();
                jardinDAO.eliminar(int.Parse(gdvJardines.Rows[indice].Cells[0].Text));
                cargarDatos();
            }
            else if (e.CommandName == "Editar")
            {
                PanelRegistro.Visible=true;
                PanelConsulta.Visible = false;
                btnRegistrar.Visible = false;
                btnEditar.Visible = true;
                lblMensaje.Text = "";

                txtIdJardin.Text= gdvJardines.Rows[indice].Cells[0].Text;
                txtIdJardin.Visible = true;
                txtIdJardin.ReadOnly= true;
                txtNombre.Text = gdvJardines.Rows[indice].Cells[1].Text;
                txtDireccion.Text = gdvJardines.Rows[indice].Cells[2].Text;
                ddlEstado.Text = gdvJardines.Rows[indice].Cells[3].Text;

            }

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            JardinDAO jardinDAO = new JardinDAO();
            Jardin jardin = new Jardin();
            jardin.idJardin = int.Parse(txtIdJardin.Text);
            jardin.nombre = txtNombre.Text;
            jardin.direccion = txtDireccion.Text;
            jardin.estado = ddlEstado.Text;

            jardinDAO.editar(jardin);
            cargarDatos();
            PanelRegistro.Visible = false;
            PanelConsulta.Visible = true;

        }
    }
}