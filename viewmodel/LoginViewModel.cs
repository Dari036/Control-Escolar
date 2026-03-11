using modelocalidad.Models;

namespace modelocalidad.ViewModels
{
    public class LoginViewModel
    {
        private UsuarioModel usuarioModel = new UsuarioModel();

        public bool IniciarSesion(string correo, string password)
        {
            return usuarioModel.ValidarAdmin(correo, password);
        }
    }
}