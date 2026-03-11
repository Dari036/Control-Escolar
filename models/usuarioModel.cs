using MySql.Data.MySqlClient;
using System;

namespace modelocalidad.Models
{
    public class UsuarioModel
    {
        private string cadenaConexion = "Server=127.0.0.1;Database=siib;Uid=root;Pwd=;";

        public bool ValidarAdmin(string correo, string password)
        {
            string query = @"SELECT COUNT(*) 
                             FROM admin
                             WHERE AdminCorreo = @correo 
                             AND AdminContraseña = @pass";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@pass", password);

                int existe = Convert.ToInt32(cmd.ExecuteScalar());

                return existe > 0;
            }
        }
    }
}