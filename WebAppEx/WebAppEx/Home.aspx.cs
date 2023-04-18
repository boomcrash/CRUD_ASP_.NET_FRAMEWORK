using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebAppEx.Datos;
using WebAppEx.model;

namespace WebAppEx
{
    public partial class Home : System.Web.UI.Page
    {
        PersonaDatos personaObject = new PersonaDatos();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                mensajeNombre.Visible = false;
                mensajeEdad.Visible = false;
                mensajeCorreo.Visible = false;
                mensaje.Visible = false;
                mensajeDos.Visible = false;
                string nombre = nombreTextBox.Text;
                string edadString = edadTextBox.Text;
                string correo = correoTextBox.Text;

                bool nombreInvalido = false;
                bool edadInvalida = false;
                bool correoInvalido = false;

                // Validación de nombre (hasta 15 caracteres)
                if (!Regex.IsMatch(nombre, @"^[A-Za-z]{1,15}$"))
                {
                    mensajeNombre.Visible = true;
                    nombreInvalido = true;
                }

                // Validación de edad (entre 18 y 45 años)
                int edad;
                if (!int.TryParse(edadString, out edad) || edad < 18 || edad > 45)
                {
                    mensajeEdad.Visible = true;
                    edadInvalida = true;
                }

                // Validación de correo electrónico (formato)
                if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                {
                   mensajeCorreo.Visible = true;
                    correoInvalido = true;
                }

                if (!nombreInvalido&&!edadInvalida&&!correoInvalido)
                {
                    if (personaObject.insertarUsuario(new Persona(nombre,edad,correo)))
                    {
                        mensajeSuccess.Text = $"Se registró el usuario {nombre} con edad {edad} y correo {correo}";
                        mensaje.Visible = true;
                    }
                    else
                    {
                        mensajeError.Text = $"Error durante el intento de registro !";
                        mensajeDos.Visible = true;
                    }

                }
                else
                {
                    mensajeError.Text = $"Error al tratar de ingresar el usuario";
                    mensajeDos.Visible = true;
                }

                nombreTextBox.Text = "";
                edadTextBox.Text = "";
                correoTextBox.Text = "";


            }
            catch (Exception ex)
            {
                statusLabel.Text = "ERROR : "+ex.Message;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            nombreTextBox.Text = "";
            edadTextBox.Text = "";
            correoTextBox.Text = "";
            Response.Redirect("/Home.aspx");
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/ListUsers.aspx");
        }
    }
}