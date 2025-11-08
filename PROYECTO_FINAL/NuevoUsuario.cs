using BLL;
using ENTITY;
using System;
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
                MessageBox.Show("Por favor, complete todos los campos y no pueden haber espacios." , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cbRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.Parse(txtId.Text) <= 0)
            {
                MessageBox.Show("El ID de usuario debe ser un número positivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("El correo debe contener '@'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }
            return true;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void NuevoUsuario_Load_1(object sender, EventArgs e)
        {

        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            if (Obtenerdatos())
            {
                LimpiarCampos();
                return;
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            INICIAR form = new INICIAR();
            form.Show();
            this.Hide();
        }
    }
}
