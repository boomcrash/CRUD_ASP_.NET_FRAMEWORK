using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace WebAppEx.AppCode
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        private SqlConnection conexion;

        public Conexion()
        {
            cadenaSQL = ConfigurationManager.ConnectionStrings["sqlServerDatabase"].ConnectionString;
        }

        public string getCadenaSQL()
        {
            Console.WriteLine(cadenaSQL);
            return cadenaSQL;
        }

        public SqlConnection Conectar()
        {
            try
            {
                conexion = new SqlConnection(cadenaSQL);
                conexion.Open();
                Console.WriteLine("Conectado a la base de datos.");
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                return null;
            }
        }
        public void Desconectar(SqlConnection conexion)
        {
            if (conexion.State == ConnectionState.Open)
            {
                conexion.Close();
                Console.WriteLine("Desconectado de la base de datos.");
            }
            else
            {
                Console.WriteLine("La conexión no está abierta.");
            }
        }

    }
}