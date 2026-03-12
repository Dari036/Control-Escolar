using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelocalidad.model;

namespace modelocalidad.helpers
{
    public static class ValidationHelper
    {
        public static string ValidarLogin(UsuarioLogin usuario)
        {
            if (usuario == null)
                return "No se recibió información de acceso.";

            if (string.IsNullOrWhiteSpace(usuario.Correo) || usuario.Correo == "Correo")
                return "Por favor, ingrese su correo.";

            if (string.IsNullOrWhiteSpace(usuario.Contrasena) || usuario.Contrasena == "Contraseña")
                return "Por favor, ingrese su contraseña.";

            if (string.IsNullOrWhiteSpace(usuario.Categoria))
                return "Por favor, seleccione una categoría.";

            return string.Empty;
        }
    }
}
