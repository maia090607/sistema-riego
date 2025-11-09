using BLL;
using ENTITY;
using System;
using System.Windows.Forms;

namespace PROYECTO_RIEGO_AUTOMATICO
{
    public partial class INICIAR : Form
    {
        private int intentos = 3;
        private readonly ServiciosUsuario serviciosUsuario;

        public INICIAR()
        {
            InitializeComponent();
            serviciosUsuario = new ServiciosUsuario();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;

        }

        private bool ValidarInformacion(string nombreUsu, string contra)
        {
            if (intentos <= 0)
            {
                MessageBox.Show("Ha excedido el número máximo de intentos fallidos. La aplicación se cerrará.");
                Application.Exit();
                return false;
            }

            var usuario = serviciosUsuario.ValidarCredenciales(nombreUsu, contra);

            if (usuario.Entidad != null)
            {
                MessageBox.Show("✅ ACCESO CONCEDIDO");
                var todos = serviciosUsuario.ObtenerTodos();
                foreach(var item in todos.Lista)
                {
                    item.Accedio = false;
                    serviciosUsuario.Actualizar(item);
                }
                usuario.Entidad.Accedio = true;
                serviciosUsuario.Actualizar(usuario.Entidad);
                MENUPRINCIPAL form = new MENUPRINCIPAL();
                form.Show();
                this.Hide();
                return true;
            }
            else
            {
                intentos--;
                MessageBox.Show($"❌ Usuario o contraseña incorrectos. Intentos restantes: {intentos}");
                return false;
            }
        }

        private void INICIAR_Load(object sender, EventArgs e) {
        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            ValidarInformacion(txtUsuario.Text.Trim(), txtContraseña.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NuevoUsuario nuevoUsuario = new NuevoUsuario();
            nuevoUsuario.Show();
            this.Hide();
        }
    }
}
