using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebAppEx.AppCode;
using WebAppEx.model;

namespace WebAppEx.Datos
{
    public class PersonaDatos
    {
        Conexion conexion = new Conexion();

        public PersonaDatos()
        {

        }

        public List<Persona> consultarUsuarios()
        {
            List<Persona> personas = new List<Persona>();
            SqlConnection con = conexion.Conectar();

            try
            {
                string query = "spConsultarPersonas";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Persona persona = new Persona();
                    persona.idPersona = Convert.ToInt32(dr["idPersona"]);
                    persona.Nombre = dr["Nombre"].ToString();
                    persona.Edad = Convert.ToInt32(dr["Edad"]);
                    persona.Correo = dr["Correo"].ToString();
                    persona.Estado = Convert.ToChar(dr["Estado"]);

                    personas.Add(persona);
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Se produjo un error al consultar personas: " + ex.Message);
            }
            finally
            {
                conexion.Desconectar(con);
            }

            return personas;
        }


        public Persona buscarUsuarioById(int idUsuario)
        {
            Persona persona = new Persona();

            SqlConnection con = conexion.Conectar();

            try
            {
                string query = "spConsultarPersona";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", idUsuario);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    persona.idPersona = Convert.ToInt32(dr["idPersona"]);
                    persona.Nombre = dr["Nombre"].ToString();
                    persona.Edad = Convert.ToInt32(dr["Edad"]);
                    persona.Correo = dr["Correo"].ToString();
                    persona.Estado = Convert.ToChar(dr["Estado"]);
                }
                return persona;
            }
            catch (Exception ex)
            {
                
                // Manejo de excepciones
                Console.WriteLine("Se produjo un error al consultar personas: " + ex.Message);
                return null;
            }
            finally
            {
                conexion.Desconectar(con);
            }
            
        }

        public bool insertarUsuario(Persona person)
        {

            Conexion conexion = new Conexion();
            SqlConnection con = conexion.Conectar();
            try
            {
                Persona persona = person;
                string query = "spInsertarPersona";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Desconectar(con);
            }
        }

        public bool editarUsuario(Persona persona)
        {
            Conexion conexion = new Conexion();
            SqlConnection con = conexion.Conectar();
            try
            {
                
                string query = "spActualizarPersona";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", persona.Nombre);
                cmd.Parameters.AddWithValue("@Edad", persona.Edad);
                cmd.Parameters.AddWithValue("@Correo", persona.Correo);
                cmd.Parameters.AddWithValue("@Estado", persona.Estado);
                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Desconectar(con);
            }
        }

        public bool eliminarUsuario(int idPersona)
        {

            Conexion conexion = new Conexion();
            SqlConnection con = conexion.Conectar();
            try
            {
                Persona persona = buscarUsuarioById(idPersona);

                string query = "spEliminarPersona";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPersona", persona.idPersona);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                conexion.Desconectar(con);
            }
        }





    }
}