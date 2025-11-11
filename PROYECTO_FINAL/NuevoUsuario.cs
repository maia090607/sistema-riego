using BLL;
using ENTITY;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace PROYECTO_RIEGO_AUTOMATICO
{
    public partial class NuevoUsuario : Form
    {
        ServiciosUsuario serviciosUsuario;
        public NuevoUsuario()
        {
            InitializeComponent();
            serviciosUsuario = new ServiciosUsuario();
            this.StartPosition = FormStartPosition.CenterScreen;


        }
        public bool Obtenerdatos()
        {
            if (validarCampos() == false)
            {
                return false;
            }
            Usuario nuevoUsuario = new Usuario();
            nuevoUsuario.IdUsuario = int.Parse(txtId.Text);
            nuevoUsuario.Nombre = txtNombre.Text.Trim();
            nuevoUsuario.Email = txtEmail.Text.Trim();
            nuevoUsuario.NombreUsuario = txtUusario.Text.Trim();
            nuevoUsuario.Password = txtContraseña.Text.Trim();
            nuevoUsuario.Rol = cbRol.GetItemText(cbRol.SelectedItem);


            if (!ValidarUsuario())
            {
                return false;
            }
            var respuesta = serviciosUsuario.ValidarNombreUsuario(txtUusario.Text.Trim());

            if (respuesta.Estado)
            {
                MessageBox.Show(respuesta.Mensaje);
                return false;
            }

            var mensaje = serviciosUsuario.Insertar(nuevoUsuario);
            MessageBox.Show(mensaje.Mensaje);
            return true;

        }
        private bool ValidarUsuario()
        {
            var respuesta = serviciosUsuario.ValidarNombreUsuario(txtUusario.Text.Trim());

            if (respuesta.Estado)
            {
                MessageBox.Show(respuesta.Mensaje);
                return false;
            }
            return true;
        }

        public void LimpiarCampos()
        {
            txtNombre.ResetText();
            txtEmail.ResetText();
            txtContraseña.ResetText();
            txtId.ResetText();
            txtUusario.ResetText();
            cbRol.SelectedIndex = -1;
        }
        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtUusario.Text) || string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos y no pueden haber espacios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtId.Text) ||
                !int.TryParse(txtId.Text, out int id) ||
                id <= 0)
            {
                MessageBox.Show("El ID debe ser un número entero positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("El correo debe contener '@'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            if (!ValidarEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "El correo no tiene un formato válido (ejemplo: usuario@dominio.com)");
                MessageBox.Show("⚠️ El correo no tiene un formato válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtContraseña.Text) || txtContraseña.Text.Length < 4)
            {
                MessageBox.Show("La contraseña debe tener al menos 4 caracteres.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Si pasa la validación
            errorProvider1.Clear();
            return true;
        }
        private bool ValidarEmail(string email)
        {
            // Expresión regular igual a la usada en Oracle
            string patron = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";

            // Retorna true si el correo cumple el patrón
            return Regex.IsMatch(email, patron);
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NuevoUsuario_Load_1(object sender, EventArgs e)
        {
            picVerContraseña.Image = PROYECTO_FINAL.Properties.Resources.monkey_599687;
            txtContraseña.UseSystemPasswordChar = true;

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            INICIAR form = new INICIAR();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Obtenerdatos())
            {
                return;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }
        private bool mostrandoContraseña = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {


            mostrandoContraseña = !mostrandoContraseña;
            if (mostrandoContraseña)
            {
                txtContraseña.UseSystemPasswordChar = false;
                picVerContraseña.Image = PROYECTO_FINAL.Properties.Resources.Ojo_Cerrado;
            }
            else
            {
                txtContraseña.UseSystemPasswordChar = true;
                picVerContraseña.Image = PROYECTO_FINAL.Properties.Resources.monkey_599687;
            }
        }
    }
}

