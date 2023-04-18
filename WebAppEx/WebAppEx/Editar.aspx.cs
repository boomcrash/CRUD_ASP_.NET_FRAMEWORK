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
    public partial class Editar : System.Web.UI.Page
    {
        PersonaDatos personaObject = new PersonaDatos();
        int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);
            if (id > 0 && !IsPostBack)
            {
                Persona persona = personaObject.buscarUsuarioById(id);
                nombreTextBox.Text = persona.Nombre;
                edadTextBox.Text = persona.Edad.ToString();
                correoTextBox.Text= persona.Correo;
                estadoTextBox.Text = persona.Estado.ToString();
            }
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiar();
            Response.Redirect("/ListUsers.aspx");
        }



        public void limpiar()
        {
            nombreTextBox.Text = "";
            edadTextBox.Text = "";
            correoTextBox.Text = "";
            estadoTextBox.Text = "";

        }



        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                if (id > 0)
                {
                    mensajeNombre.Visible = false;
                    mensajeEdad.Visible = false;
                    mensajeCorreo.Visible = false;
                    mensaje.Visible = false;
                    mensajeDos.Visible = false;
                    mensajeEstado.Visible = false;

                    string nombre = nombreTextBox.Text;
                    string edadString = edadTextBox.Text;
                    string correo = correoTextBox.Text;
                    string estado = estadoTextBox.Text;

                    bool nombreInvalido = false;
                    bool edadInvalida = false;
                    bool correoInvalido = false;
                    bool estadoInvalido = false;

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

                    if (!Regex.IsMatch(estado, "^[AI]$"))
                    {
                        mensajeEstado.Visible = true;
                        estadoInvalido = true;
                    }

                    if (!nombreInvalido && !edadInvalida && !correoInvalido && !estadoInvalido)
                    {
                        Persona persona = new Persona(id, nombre, edad, correo, Convert.ToChar(estado));
                        if (personaObject.editarUsuario(persona))
                        {
                            limpiar();
                            Response.Redirect("/ListUsers.aspx");
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
                }


            }
            catch (Exception ex)
            {
                statusLabel.Text = "ERROR : " + ex.Message;
            }

        }
    }
}