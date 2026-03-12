using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using modelocalidad.model;
using modelocalidad.repositories;

namespace modelocalidad.services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService()
        {
            _authRepository = new AuthRepository();
        }

        public LoginResultado IniciarSesion(UsuarioLogin usuario)
        {
            var resultado = _authRepository.ValidarCredenciales(usuario.Correo, usuario.Contrasena);

            if (!resultado.Exitoso)
                return resultado;

            if (!string.IsNullOrWhiteSpace(usuario.Categoria))
            {
                if (resultado.Rol != usuario.Categoria)
                {
                    return new LoginResultado
                    {
                        Exitoso = false,
                        Mensaje = $"El usuario no pertenece a la categoría seleccionada: {usuario.Categoria}."
                    };
                }
            }

            return resultado;
        }
    }
}