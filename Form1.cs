using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace modelocalidad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // BOTÓN PARA MOSTRAR CAMPOS SEGÚN CATEGORÍA
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

            string categoriaSeleccionada = CbCategoria.SelectedItem.ToString();

            string cadenaConexion = "Server=127.0.0.1;Database=siib;Uid=root;Pwd=;";

            // Consulta corregida (sin alias incorrectos)
            string query = @"
                SELECT COUNT(*) 
                FROM admin
                WHERE AdminCorreo = @correo 
                AND AdminContraseña = @pass";

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                try
                {
                    conexion.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@pass", TxtContra.Text);

                    int existe = Convert.ToInt32(cmd.ExecuteScalar());

                    if (existe > 0)
                    {
                        AbrirFormularioSegunCategoria(categoriaSeleccionada);
                    }
                    else
                    {
                        MessageBox.Show("Correo o contraseña incorrectos.");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error MySQL: " + ex.Number + " - " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error general: " + ex.Message);
                }
            }
        }

        // ABRIR FORMULARIO SEGÚN CATEGORÍA (CORREGIDO)
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
        private void textBox1_Enter(object sender, EventArgs e)
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