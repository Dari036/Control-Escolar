using MySql.Data.MySqlClient;
using System;

namespace modelocalidad.model
{
    public class UsuarioLogin
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Categoria { get; set; }
    }
}