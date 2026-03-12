using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace modelocalidad.services
{
    public class NavigationService
    {
        public void AbrirFormularioSegunRol(string rol, Form formularioActual)
        {
            formularioActual.Hide();

            switch (rol)
            {
                case "Administrador":
                    new admin().Show();
                    break;

                case "Docente":
                    new maestro().Show();
                    break;

                case "Estudiante":
                    new estudiante().Show();
                    break;

                default:
                    MessageBox.Show("Rol no válido.");
                    formularioActual.Show();
                    break;
            }
        }
    }
}