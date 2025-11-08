using BLL;
using ENTITY;
using System;
using System.Windows.Forms;


namespace PROYECTO_RIEGO_AUTOMATICO
{

    public partial class PLANTAS : Form
    {
        ServiciosPlanta serviciosPlanta;
        private string rutaImagenSeleccionada = string.Empty;
        public PLANTAS()
        {
            InitializeComponent();
            serviciosPlanta = new ServiciosPlanta();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private bool RegistrarPlanta()
        {
            if (ValidarCampos() == false)
            {
                return false;
            }
            Cultivo nuevaPlanta = new Cultivo();

            nuevaPlanta.IdPlanta = int.Parse(txtId.Text);
            nuevaPlanta.NombrePlanta = txtNombre.Text;
            nuevaPlanta.Descripcion = txtDescripcion.Text;
            nuevaPlanta.nivel_optimo_humedad = float.Parse(txtNivelHumedad.Text);
            nuevaPlanta.nivel_optimo_temperatura = float.Parse(txtNivelTemperatura.Text);
            nuevaPlanta.nivel_optimo_luz = float.Parse(txtNivelLuz.Text);
            nuevaPlanta.RutaImagen = rutaImagenSeleccionada;
            var plantaExistente = serviciosPlanta.BuscarPorId(nuevaPlanta.IdPlanta);   
            if (plantaExistente.Estado == true)
            {
                MessageBox.Show("Ya hay una planta registrada con este id");
                return false;
            }
            var mensaje = serviciosPlanta.Insertar(nuevaPlanta);
            MessageBox.Show(mensaje.Mensaje);
            LimpiarCampos();
            return true;
        }
        private void ActualizarPlanta()
        {
            
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, buscar la planta primero, antes de actualizar la planta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Cultivo plantaActualizada = new Cultivo();
            plantaActualizada.IdPlanta = int.Parse(txtId.Text);
            plantaActualizada.NombrePlanta = txtNombre.Text.Trim();
            plantaActualizada.Descripcion = txtDescripcion.Text.Trim();
            plantaActualizada.nivel_optimo_humedad = float.Parse(txtNivelHumedad.Text.Trim());
            plantaActualizada.nivel_optimo_temperatura = float.Parse(txtNivelTemperatura.Text.Trim());
            plantaActualizada.nivel_optimo_luz = float.Parse(txtNivelLuz.Text.Trim());
            plantaActualizada.RutaImagen = rutaImagenSeleccionada;
            var mensaje = serviciosPlanta.Actualizar(plantaActualizada);
            MessageBox.Show(mensaje.Mensaje);
        }
        private void EliminarPlanta()
        {
            if (!ValidarCampos())
            {
                MessageBox.Show("Por favor, buscar la planta primero, antes de actualizar la planta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(txtId.Text.Trim(), out int id))
            {
                MessageBox.Show("Por favor ingrese un ID válido (número entero).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var plantaExistente = serviciosPlanta.BuscarPorId(id);
            string nombre = plantaExistente.Entidad.NombrePlanta;
            DialogResult resultado = MessageBox.Show($"¿Seguro que quiere eliminar la planta con ID {plantaExistente.Entidad.IdPlanta}?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var PlantaEliminar = serviciosPlanta.Eliminar(plantaExistente.Entidad.IdPlanta);
                if (PlantaEliminar.Estado)
                {
                    MessageBox.Show($"La planta {nombre} fue eliminada correctamente");

                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar los cambios: ");
                }
                LimpiarCampos();
            }
            else
            {
                return;
            }
        }
        private void BuscarPlanta()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, digite el id de la planta que quiere buscar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var plantaExistente = serviciosPlanta.BuscarPorId(int.Parse(txtId.Text.Trim()));
            if (plantaExistente == null)
            {
                MessageBox.Show("No se encontró una planta con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtId.Text = plantaExistente.Entidad.IdPlanta.ToString();
            txtNombre.Text = plantaExistente.Entidad.NombrePlanta;
            txtDescripcion.Text = plantaExistente.Entidad.Descripcion;
            txtNivelHumedad.Text = plantaExistente.Entidad.nivel_optimo_humedad.ToString();
            txtNivelTemperatura.Text = plantaExistente.Entidad.nivel_optimo_temperatura.ToString();
            txtNivelLuz.Text = plantaExistente.Entidad.nivel_optimo_luz.ToString();

        }

        private void LimpiarCampos()
        {
            txtId.ResetText();
            txtNombre.ResetText();
            txtDescripcion.ResetText();
            txtNivelHumedad.ResetText();
            txtNivelTemperatura.ResetText();
            txtNivelLuz.ResetText();
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtDescripcion.Text) ||
                string.IsNullOrWhiteSpace(txtId.Text) ||
                string.IsNullOrWhiteSpace(txtNivelHumedad.Text) ||
                string.IsNullOrWhiteSpace(txtNivelTemperatura.Text) ||
                string.IsNullOrWhiteSpace(txtNivelLuz.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!int.TryParse(txtId.Text.Trim(), out _))
            {
                MessageBox.Show("El ID debe ser un número entero válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (int.TryParse(txtNombre.Text.Trim(), out _))
            {
                MessageBox.Show("El nombre no puede ser solo números.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!float.TryParse(txtNivelHumedad.Text.Trim(), out _) || !float.TryParse(txtNivelTemperatura.Text.Trim(), out _) || !float.TryParse(txtNivelLuz.Text.Trim(), out _))
            {
                MessageBox.Show("Los niveles deben ser números válidos (pueden tener decimales).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
                MENUPRINCIPAL menu = new MENUPRINCIPAL();
                menu.Show();
                this.Hide();
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            ActualizarPlanta();
        }

        private void PLANTAS_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RegistrarPlanta();
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                rutaImagenSeleccionada = dialogo.FileName;
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna imagen.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            EliminarPlanta();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BuscarPlanta();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
