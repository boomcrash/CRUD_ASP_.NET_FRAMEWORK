using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppEx.model
{
    public class Persona
    {
        public int? idPersona { get; set; }
        public string Nombre { get; set; }
        public int? Edad { get; set; }
        public string Correo { get; set; }
        public char? Estado { get; set; }

        public Persona()
        {

        }
        public Persona(string nombre,int edad,string correo)
        {
            this.Nombre = nombre;
            this.Edad = edad;
            this.Correo = correo;
        }

        public Persona(int id,string nombre, int edad, string correo,char estado)
        {
            this.idPersona = id;
            this.Nombre = nombre;
            this.Edad = edad;
            this.Correo = correo;
            this.Estado = estado;
        }
    }

}