using System;
using System.Windows.Forms;
using modelocalidad.helpers;
using modelocalidad.model;
using modelocalidad.services;
using modelocalidad.viewmodel;

namespace modelocalidad
{
    public partial class Form1 : Form
    {
        private readonly LoginViewModel _loginViewModel;
        private readonly NavigationService _navigationService;

        public Form1()
        {
            InitializeComponent();

            _loginViewModel = new LoginViewModel();
            _navigationService = new NavigationService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            BtnIniciarSesion.Visible = false;
            txtCorreo.Visible = false;
            TxtContra.Visible = false;

            txtCorreo.Text = "Correo";
            txtCorreo.ForeColor = System.Drawing.Color.DimGray;

            TxtContra.Text = "Contraseña";
            TxtContra.ForeColor = System.Drawing.Color.DimGray;
            TxtContra.UseSystemPasswordChar = false;

            CbCategoria.Items.Clear();
            CbCategoria.Items.Add("Administrador");
            CbCategoria.Items.Add("Docente");
            CbCategoria.Items.Add("Estudiante");
        }

        // BOTÓN PARA MOSTRAR CAMPOS SEGÚN CATEGORÍA
        private void button2_Click(object sender, EventArgs e)
        {
            if (CbCategoria.Text == "Administrador" ||
                CbCategoria.Text == "Docente" ||
                CbCategoria.Text == "Estudiante")
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
            try
            {
                string categoria = CbCategoria.SelectedItem?.ToString() ?? CbCategoria.Text;

                LoginResultado resultado = _loginViewModel.Login(
                    txtCorreo.Text,
                    TxtContra.Text,
                    categoria
                );

                if (resultado.Exitoso)
                {
                    _navigationService.AbrirFormularioSegunRol(resultado.Rol, this);
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error general: " + ex.Message);
            }
        }

        // PLACEHOLDER CORREO
        private void textBox1_Enter(object sender, EventArgs e)
        {
            PlaceholderHelper.EnterTextBox(txtCorreo, "Correo");
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            PlaceholderHelper.LeaveTextBox(txtCorreo, "Correo");
        }

        // PLACEHOLDER CONTRASEÑA
        private void TxtContra_Enter(object sender, EventArgs e)
        {
            PlaceholderHelper.EnterTextBox(TxtContra, "Contraseña", true);
        }

        private void TxtContra_Leave(object sender, EventArgs e)
        {
            PlaceholderHelper.LeaveTextBox(TxtContra, "Contraseña", true);
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