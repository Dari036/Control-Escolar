using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using modelocalidad.config;
using modelocalidad.model;

namespace modelocalidad.repositories
{
    public class AuthRepository
    {
        public LoginResultado ValidarCredenciales(string correo, string contrasena)
        {
            var resultado = new LoginResultado
            {
                Exitoso = false,
                Mensaje = "Correo o contraseña incorrectos."
            };

            string query = @"
                SELECT 
                    u.id_usuario,
                    u.nombre_usuario,
                    u.correo,
                    r.nombre_rol
                FROM usuarios u
                INNER JOIN usuario_roles ur ON u.id_usuario = ur.id_usuario
                INNER JOIN roles r ON ur.id_rol = r.id_rol
                WHERE u.correo = @correo
                  AND u.contrasena_hash = @pass
                  AND u.estatus = 'activo'
                LIMIT 1;";

            using (MySqlConnection conexion = new MySqlConnection(DbConfig.CadenaConexion))
            {
                conexion.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@correo", correo);
                    cmd.Parameters.AddWithValue("@pass", contrasena);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resultado.Exitoso = true;
                            resultado.Mensaje = "Inicio de sesión correcto.";
                            resultado.IdUsuario = Convert.ToInt32(reader["id_usuario"]);
                            resultado.NombreUsuario = reader["nombre_usuario"].ToString();
                            resultado.Correo = reader["correo"].ToString();
                            resultado.Rol = reader["nombre_rol"].ToString();
                        }
                    }
                }
            }

            return resultado;
        }
    }
}