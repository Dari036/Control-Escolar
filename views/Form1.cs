// View: Form1.cs

using System;
using System.Drawing;
using System.Windows.Forms;
using modelocalidad.ViewModels;

namespace modelocalidad
{
    public partial class Form1 : Form
    {
        // ViewModel
        private LoginViewModel viewModel = new LoginViewModel();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            BtnIniciarSesion.Visible = false;
            txtCorreo.Visible = false;
            TxtContra.Visible = false;
        }

        // MOSTRAR CAMPOS SEGÚN CATEGORÍA
        private void button2_Click(object sender, EventArgs e)
        {
            if (CbCategoria.Text == "Estudiante" ||
                CbCategoria.Text == "Profesor" ||
                CbCategoria.Text == "Administrador")
            {
                button1.Visible = true;
                BtnIniciarSesion.Visible = true;
                txtCorreo.Visible = true;
                TxtContra.Visible = true;
            }
        }

        // LOGIN
        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            if (CbCategoria.SelectedItem == null ||
                txtCorreo.Text == "Correo" ||
                string.IsNullOrWhiteSpace(TxtContra.Text) ||
                TxtContra.Text == "Contraseña")
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }

            string correo = txtCorreo.Text;
            string password = TxtContra.Text;
            string categoria = CbCategoria.SelectedItem.ToString();

            bool acceso = viewModel.IniciarSesion(correo, password);

            if (acceso)
            {
                AbrirFormularioSegunCategoria(categoria);
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos.");
            }
        }

        // ABRIR FORMULARIO SEGÚN CATEGORÍA
        private void AbrirFormularioSegunCategoria(string categoria)
        {
            this.Hide();

            switch (categoria)
            {
                case "Administrador":
                    new admin().Show();
                    break;

                case "Profesor":
                    new maestro().Show();
                    break;

                case "Estudiante":
                    new estudiante().Show();
                    break;

                default:
                    MessageBox.Show("Categoría no válida.");
                    this.Show();
                    break;
            }
        }

        // PLACEHOLDER CORREO
        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.Black;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                txtCorreo.Text = "Correo";
                txtCorreo.ForeColor = Color.DimGray;
            }
        }

        // PLACEHOLDER CONTRASEÑA
        private void TxtContra_Enter(object sender, EventArgs e)
        {
            if (TxtContra.Text == "Contraseña")
            {
                TxtContra.Text = "";
                TxtContra.ForeColor = Color.Black;
                TxtContra.UseSystemPasswordChar = true;
            }
        }

        private void TxtContra_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtContra.Text))
            {
                TxtContra.Text = "Contraseña";
                TxtContra.ForeColor = Color.DimGray;
                TxtContra.UseSystemPasswordChar = false;
            }
        }

        // BOTÓN CERRAR
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // BOTÓN MINIMIZAR
        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}