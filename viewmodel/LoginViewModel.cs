
using modelocalidad.helpers;
using modelocalidad.model;
using modelocalidad.services;

namespace modelocalidad.viewmodel
{
    public class LoginViewModel
    {
        private readonly AuthService _authService;

        public LoginViewModel()
        {
            _authService = new AuthService();
        }

        public LoginResultado Login(string correo, string contrasena, string categoria)
        {
            var usuario = new UsuarioLogin
            {
                Correo = correo,
                Contrasena = contrasena,
                Categoria = categoria
            };

            string errorValidacion = ValidationHelper.ValidarLogin(usuario);

            if (!string.IsNullOrWhiteSpace(errorValidacion))
            {
                return new LoginResultado
                {
                    Exitoso = false,
                    Mensaje = errorValidacion
                };
            }

            return _authService.IniciarSesion(usuario);
        }
    }
}