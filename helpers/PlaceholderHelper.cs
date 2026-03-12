using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;

namespace modelocalidad.helpers
{
    public static class PlaceholderHelper
    {
        public static void EnterTextBox(TextBox textBox, string placeholder, bool esPassword = false)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;

                if (esPassword)
                    textBox.UseSystemPasswordChar = true;
            }
        }

        public static void LeaveTextBox(TextBox textBox, string placeholder, bool esPassword = false)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.DimGray;

                if (esPassword)
                    textBox.UseSystemPasswordChar = false;
            }
        }
    }
}