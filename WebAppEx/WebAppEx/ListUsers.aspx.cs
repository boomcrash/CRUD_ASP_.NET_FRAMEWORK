using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEx.AppCode;
using WebAppEx.Datos;
using WebAppEx.model;


namespace WebAppEx
{
    public partial class ListUsers : System.Web.UI.Page
    {
        PersonaDatos personaObject = new PersonaDatos();
        protected void Page_Load(object sender, EventArgs e)
        {


                llenarDatos();

            
        }
        public void llenarDatos()
        {
            gridPersonas.DataSource = personaObject.consultarUsuarios();
            gridPersonas.DataBind();
            gridPersonas.UseAccessibleHeader = true;
        }

        protected void gridPersonas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gridPersonas.SelectedIndex >= 0)
            {
                
                GridViewRow row = gridPersonas.SelectedRow;
                string columna1 = row.Cells[0].Text;
                string columna2 = row.Cells[1].Text;
                string columna3 = row.Cells[2].Text;


            }
        }

        protected void gridPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gridPersonas.Rows[e.RowIndex].Cells[0].Text);
            if (personaObject.eliminarUsuario(id))
            {
                Response.Redirect("/ListUsers.aspx");
            }
        }

        protected void gridPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {

            // obtener el objeto de la fila seleccionada
            GridViewRow row = gridPersonas.Rows[e.NewEditIndex];
            int id = Convert.ToInt32(row.Cells[0].Text);

 
            if (id>0)
            {
                Response.Redirect($"/Editar.aspx?id={id}");
            }
        }




        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }



    }
}