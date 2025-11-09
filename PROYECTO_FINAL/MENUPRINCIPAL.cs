using BLL;
using Entity;
using ENTITY;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PROYECTO_RIEGO_AUTOMATICO
{
    public partial class MENUPRINCIPAL : Form
    {
        ServiciosPlanta serviciosPlanta;
        ServicioHistorial servicioHistorial;
        ServiciosUsuario serviciosUsuario;
        ServicioGraficas servicioGraficas;
        ServiciosAlertas serviciosAlertas;
        ServicioClima servicioClima;
        private ServicioPuerto puerto;
        private float humedad_actual, temperatura_actual, viento_actual;
        private bool puedeRegar = true, Expandir = false;
        private int IdDelUsuario, contadorTiempo;
        private Size originalFormSize;

        public MENUPRINCIPAL()
        {
            serviciosPlanta = new ServiciosPlanta();
            servicioHistorial = new ServicioHistorial();
            serviciosUsuario = new ServiciosUsuario();
            servicioGraficas = new ServicioGraficas();
            serviciosAlertas = new ServiciosAlertas();
            servicioClima = new ServicioClima();
            InitializeComponent();
            ObtenerDatosClimaAsync();
            this.StartPosition = FormStartPosition.CenterScreen;
            originalFormSize = this.Size;

            cargarPlantas();
            puerto = new ServicioPuerto("COM3", 9600);
            puerto.DatosRecibidos += Puerto_DatosRecibidos;
        }
        private void Puerto_DatosRecibidos(string mensaje)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((Action)(() =>
                {
                    if (mensaje.StartsWith("Humedad:"))
                        lblHumedad.Text = mensaje + "%";
                    else
                        lbEstadodeBomba.Text = mensaje;
                }));
            }
            else
            {
                if (mensaje.StartsWith("Humedad:"))
                    lblHumedad.Text = mensaje + "%";
                else
                    lbEstadodeBomba.Text = mensaje;
            }
        }

        private int NuevoId()
        {
            var todas = serviciosAlertas.MostrarTodos();

            int nuevoId = 1;
            if (todas.Lista != null && todas.Lista.Count > 0)
                nuevoId = todas.Lista.Max(a => a.IdAlerta) + 1;
            return nuevoId;
        }
        public async Task ObtenerDatosClimaAsync()
        {
            string apiKey = "91c59362a4519b067f3be52b6fe361f3";
            string ciudad = "Valledupar";
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={ciudad}&appid={apiKey}&units=metric&lang=es";
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var weatherInfo = JsonSerializer.Deserialize<ENTITY.WeatherInfo>(responseBody);
                    lbTemperatura.Text = $"{weatherInfo.main.temp}°C";
                    lbHum.Text = $"{weatherInfo.main.humidity} %";
                    lbVie.Text = $"{weatherInfo.wind.speed} M/S";
                    lbDes.Text = $"{weatherInfo.weather[0].description.ToUpper()}";

                    temperatura_actual = (float)weatherInfo.main.temp;
                    humedad_actual = (float)weatherInfo.main.humidity;
                    viento_actual = (float)weatherInfo.wind.speed; 
                    ActualizarGraficoClima((float)weatherInfo.main.temp, (float)weatherInfo.main.humidity, (float)weatherInfo.wind.speed);


                    RegistroClimatico clima = new RegistroClimatico();
                    clima.Humedad_Ambiente = (float)Math.Round(humedad_actual, 2);
                    clima.Humedad_Suelo = (float)Math.Round(humedad_actual, 2);
                    clima.Temperatura_Ambiente = (float)Math.Round(temperatura_actual, 2);
                    clima.Viento = (float)Math.Round(viento_actual, 2);

                    var mensaje1 = servicioClima.Guardar(clima);
                    if (weatherInfo.main.temp > 35)
                    {
                        Alertas alerta = new Alertas
                        {
                            IdAlerta = NuevoId(),
                            FechaHora = DateTime.Now,
                            TipoAlerta = "Alta Temperatura",
                            Descripcion = $"La temperatura actual es de {weatherInfo.main.temp}°C, lo cual supera el umbral seguro.",
                            NivelCritico = "Alto",
                            Estado = false
                        };
                        var mensaje = serviciosAlertas.Agregar(alerta);
                    }
                    if (weatherInfo.main.humidity < 20)
                    {
                        Alertas alerta = new Alertas
                        {
                            IdAlerta = NuevoId(),
                            FechaHora = DateTime.Now,
                            TipoAlerta = "Baja Humedad",
                            Descripcion = $"La humedad actual es de {weatherInfo.main.humidity}%, lo cual está por debajo del umbral seguro.",
                            NivelCritico = "Medio",
                            Estado = false
                        };
                        var mensaje = serviciosAlertas.Agregar(alerta);
                    }
                    if (weatherInfo.wind.speed > 10)
                    {
                        Alertas alerta = new Alertas
                        {
                            IdAlerta = NuevoId(),
                            FechaHora = DateTime.Now,
                            TipoAlerta = "Viento Fuerte",
                            Descripcion = $"La velocidad del viento es de {weatherInfo.wind.speed} m/s, lo cual supera el umbral seguro.",
                            NivelCritico = "Bajo",
                            Estado = false
                        };
                        var mensaje = serviciosAlertas.Agregar(alerta);
                    }
                    if (weatherInfo.weather[0].description.ToLower().Contains("lluvia"))
                    {
                        Alertas alerta = new Alertas
                        {
                            IdAlerta = NuevoId(),
                            FechaHora = DateTime.Now,
                            TipoAlerta = "Lluvia",
                            Descripcion = $"Se ha detectado lluvia en la zona, lo cual puede afectar el riego automático.",
                            NivelCritico = "Bajo",
                            Estado = false
                        };
                        var mensaje = serviciosAlertas.Agregar(alerta);
                    }
                    if (weatherInfo.weather[0].description.ToLower().Contains("tormenta"))
                    {
                        Alertas alerta = new Alertas
                        {
                            IdAlerta = NuevoId(),
                            FechaHora = DateTime.Now,
                            TipoAlerta = "Tormenta",
                            Descripcion = $"Se ha detectado una tormenta en la zona, lo cual puede afectar el riego automático.",
                            NivelCritico = "Alto",
                            Estado = false
                        };
                        var mensaje = serviciosAlertas.Agregar(alerta);
                    }
                    var alertaClima = serviciosAlertas.MostrarTodos();
                    foreach (var alerta in alertaClima.Lista)
                    {
                        if (alerta.Estado == false)
                        {
                            // Aquí podrías implementar una notificación más sofisticada si lo deseas
                            MessageBox.Show($"Alerta: {alerta.TipoAlerta}\nDescripción: {alerta.Descripcion}\nNivel Crítico: {alerta.NivelCritico}", "Alerta Climática", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                }
                catch (Exception e)
                {
                    MessageBox.Show($"Error al obtener datos del clima: {e.Message}");
                    Alertas alerta = new Alertas
                    {
                        IdAlerta = NuevoId(),
                        FechaHora = DateTime.Now,
                        TipoAlerta = "Error Clima",
                        Descripcion = $"No se pudieron obtener los datos climáticos: {e.Message}",
                        NivelCritico = "Medio",
                        Estado = false
                    };
                    var mensaje = serviciosAlertas.Agregar(alerta);
                    MessageBox.Show(mensaje.Mensaje);
                }
            }
        } 

        private void ActualizarGraficoClima(float temp, float hum, float vie)
        {
            try
            {

                chartClima.Series.Clear();
                chartClima.Titles.Clear();

                Series serie = new Series("DatosClimáticos");
                serie.ChartType = SeriesChartType.Doughnut;
                serie.IsValueShownAsLabel = true;

                serie.Points.AddXY("Humedad (%)", Math.Round(hum, 0));
                serie.Points.AddXY("Viento (m/s)", Math.Round(vie, 2));
                serie.Points.AddXY("Temperatura (°C)", Math.Round(temp, 0));

                chartClima.Series.Add(serie);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar gráfico: {ex.Message}");
            }
        }
        private void ActualizarGraficoCultivo(float nivelHumedad, float nivelTemperatura, float nivelLuz)
        {
            try
            {

                chartCultivo.Series.Clear();
                chartCultivo.Titles.Clear();

                Series serie = new Series("NivelesÓptimos");
                serie.ChartType = SeriesChartType.Doughnut;
                serie.IsValueShownAsLabel = true;

                serie.Points.AddXY("Humedad óptima (%)", Math.Round(nivelHumedad, 0));
                serie.Points.AddXY("Temperatura óptima (°C)", Math.Round(nivelTemperatura, 0));
                serie.Points.AddXY("Luz óptima (%)", Math.Round(nivelLuz, 0));

                serie.Points[0].Color = Color.DeepSkyBlue;
                serie.Points[1].Color = Color.OrangeRed;
                serie.Points[2].Color = Color.Gold;

                chartCultivo.Titles.Add("Niveles Óptimos del Cultivo");

                chartCultivo.Series.Add(serie);

                chartCultivo.BackColor = Color.Transparent;
                chartCultivo.ChartAreas[0].BackColor = Color.Transparent;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al generar gráfico de cultivo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        public void cargarPlantas()
        {
            var lista = serviciosPlanta.ObtenerTodos();

            cbPlantas.DataSource = null;
            cbPlantas.Items.Clear();

            cbPlantas.DataSource = lista.Lista;
            cbPlantas.DisplayMember = "NombrePlanta"; // Lo que se muestra en el ComboBox
            cbPlantas.ValueMember = "IdPlanta";       // Valor interno (opcional)
        }
        private void BuscarPlanta()
        {
            if (cbPlantas.SelectedItem is Cultivo cultivo)
            {
                MId.Text = cultivo.IdPlanta.ToString();
                Mnombre.Text = cultivo.NombrePlanta;
                MDescripcion.Text = cultivo.Descripcion;
                Mhumedad.Text = cultivo.nivel_optimo_humedad.ToString("0.00") + "%";
                Mtemperatura.Text = cultivo.nivel_optimo_temperatura.ToString("0.00") + "C°";
                Mluz.Text = cultivo.nivel_optimo_luz.ToString("0.00") + "%";
                ActualizarGraficoCultivo(cultivo.nivel_optimo_humedad, cultivo.nivel_optimo_temperatura, cultivo.nivel_optimo_luz);
                if (!string.IsNullOrEmpty(cultivo.RutaImagen) && File.Exists(cultivo.RutaImagen))
                {
                    pbPlanta.Image = Image.FromFile(cultivo.RutaImagen);
                }
                else
                {
                    pbPlanta.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una planta primero.");
            }
        }
        private void ultimoRegado()
        {
            var lista = servicioHistorial.MostrarTodos();
            Historial_Riego ultimo = null;

            foreach (var item in lista)
            {
                ultimo = item;
            }

            if (ultimo != null)
            {
                lbUltimoRegado.Text = ultimo.Fecha.ToString("dd/MM/yyyy HH:mm:ss");
            }
            else
            {
                lbUltimoRegado.Text = "Sin registros";

            }

        }
        private void HacerCambios()
        {
            btnGuardarCambios.Enabled = true;
            btnEliminarUsuario.Enabled = true;
            btnSubirFoto.Enabled = true;
            btnSubirFoto.Enabled = true;
            txtIdUsuario.Enabled = true;
            txtNombreUsuario.Enabled = true;
            txtNombreUsuariodelUsuario.Enabled = true;
            txtEmailUsu.Enabled = true;
            cbRol.Enabled = true;

        }
        private void timerGraficaReal()
        {
            var listaDatos = servicioClima.MostrarTodos()?.Lista;

            if (listaDatos == null || listaDatos.Count == 0)
                return;

            // Tomar solo los últimos 10 registros
            var ultimosDatos = listaDatos.Count > 10
                ? listaDatos.Skip(listaDatos.Count - 10).ToList()
                : listaDatos;

            chartTemperatura.Series["TEMPERATURA DEL AMBIENTE"].Points.Clear();
            chartRiego.Series["HUMEDAD DEL SUELO"].Points.Clear();

            int contador = 0;

            foreach (var item in ultimosDatos)
            {
                contador += 10;
                chartTemperatura.Series["TEMPERATURA DEL AMBIENTE"].Points.AddXY(contador, item.Temperatura_Ambiente);
                chartRiego.Series["HUMEDAD DEL SUELO"].Points.AddXY(contador, item.Humedad_Suelo);
            }
        }

        private void GuardarCambios()
        {
            DialogResult resultado = MessageBox.Show($"¿Seguro que quiere hacer estos cambios?",
            "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                var usu = serviciosUsuario.BuscarPorId(IdDelUsuario);
                if (serviciosUsuario.ValidarNombreUsuario(txtNombreUsuariodelUsuario.Text) ==null && usu.Entidad.NombreUsuario != txtNombreUsuariodelUsuario.Text)
                {
                    MessageBox.Show("El ID ingresado ya pertenece a otro usuario. Cámbialo por favor.");
                    return;
                }

                // Validar que no exista otro usuario con el mismo nombre de usuario
                if (serviciosUsuario.BuscarPorId(int.Parse(txtIdUsuario.Text)) == null && serviciosUsuario.ValidarNombreUsuario(txtIdUsuario.Text) == null)
                {
                    MessageBox.Show("El nombre de usuario ya está en uso. Cámbialo por favor.");
                    return;
                }



                usu.Entidad.IdUsuario = int.Parse(txtIdUsuario.Text);
                usu.Entidad.NombreUsuario = txtNombreUsuariodelUsuario.Text;
                usu.Entidad.Nombre = txtNombreUsuario.Text;
                usu.Entidad.Email = txtEmailUsu.Text;
                usu.Entidad.Rol = cbRol.GetItemText(cbRol.SelectedItem);

                
                if (serviciosUsuario.Actualizar(usu.Entidad)!=null)
                {
                    MessageBox.Show($"El/La Usuari@ {usu.Entidad.NombreUsuario} fue actualizad@ correctamente");

                }
                else
                {
                    MessageBox.Show("Hubo un error al guardar los cambios: ");
                }
                CargarUsuario();
            }
            return;
        }
        private void CargarUsuario()
        {
            var list = serviciosUsuario.ObtenerTodos();
            foreach (var item in list.Lista)
            {
                if (item.Accedio == true)
                {
                    IdDelUsuario = item.IdUsuario;
                    break;
                }
            }

            var usuario = serviciosUsuario.BuscarPorId(IdDelUsuario);
            txtIdUsuario.Text = usuario.Entidad.IdUsuario.ToString();
            txtNombreUsuario.Text = usuario.Entidad.Nombre;
            txtNombreUsuariodelUsuario.Text = usuario.Entidad.NombreUsuario;
            cbRol.Text = usuario.Entidad.Rol;
            txtEmailUsu.Text = usuario.Entidad.Email;
            if (!string.IsNullOrEmpty(usuario.Entidad.RutaImagen) && File.Exists(usuario.Entidad.RutaImagen))
            {
                pbImagenUsuario.Image = Image.FromFile(usuario.Entidad.RutaImagen);
            }
            txtIdUsuario.Enabled = false;
            txtNombreUsuario.Enabled = false;
            txtNombreUsuariodelUsuario.Enabled = false;
            txtEmailUsu.Enabled = false;
            cbRol.Enabled = false;


        }

        private void ActualizarEstadoConexion()
        {
            if (Application.OpenForms["MENUPRINCIPAL"] != null)
            {
                lbConec.Text = "ACTIVO";
                lbConec.BackColor = ColorTranslator.FromHtml("#21864B"); // Verde
            }
            else
            {
                lbConec.Text = "DESCONECTADO";
                lbConec.BackColor = ColorTranslator.FromHtml("#8B0000"); // Rojo oscuro
            }
        }
        private void ActivarRiego()
        {
            try
            {
                DialogResult resultado = MessageBox.Show($"¿Seguro que quiere iniciar el riego?",
                    "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {

                    var lis = servicioHistorial.MostrarTodos();
                    Historial_Riego historial = new Historial_Riego();
                    historial.Temperatura = temperatura_actual;
                    historial.Humedad = humedad_actual;
                    historial.Fecha = DateTime.Now;
                    servicioHistorial.Guardar(historial);
                }
                else
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error..." + ex);
            }


        }
        private async Task CicloRiegoAsync()
        {
            if (puedeRegar)
            {
                puedeRegar = false;
                btnRiegoAuto.Enabled = false;

                ActivarRiego(); // Ejecuta el riego

                await Task.Delay(TimeSpan.FromSeconds(10));

                puedeRegar = true;
                btnRiegoAuto.Enabled = true;
                MessageBox.Show("Ya puedes volver a regar.");
            }
            else
            {
                MessageBox.Show("Debes esperar antes de volver a regar.");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            CicloRiegoAsync();
            ultimoRegado();
        }
        private bool CargarHistorial()
        {
            grilla.DataSource = servicioHistorial.MostrarTodos();
            return true;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void BuscarHistorialGrilla()
        {
            DateTime fechaSeleccionada = dtpFechaBusqueda.Value.Date;

            var lista = servicioHistorial.MostrarTodos();

            var resultados = lista.Where(x => x.Fecha.Date == fechaSeleccionada).ToList();

            if (resultados.Any())
            {
                grilla.DataSource = null; // limpiar primero
                grilla.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("No se encontraron registros para esa fecha.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BuscarHistorialGrillaAlertas()
        {
            DateTime fechaSeleccionada = calendarioAlertas.Value.Date;

            var lista = serviciosAlertas.MostrarTodos().Lista;

            var resultados = lista.Where(x => x.FechaHora.Date == fechaSeleccionada).ToList();

            if (resultados.Any())
            {
                grilla2.DataSource = null; // limpiar primero
                grilla2.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("No se encontraron registros para esa fecha.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BuscarPorFechaEnGrillaClima()
        {
            DateTime fechaSeleccionada = calendarioRiego.Value.Date;

            var lista = servicioClima.MostrarTodos().Lista;

            var resultados = lista.Where(x => x.Fecha.Date == fechaSeleccionada).ToList();

            if (resultados.Any())
            {
                grillaClima.DataSource = null; // limpiar primero
                grillaClima.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("No se encontraron registros para esa fecha.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            lbFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void btnHam_Click(object sender, EventArgs e)
        {
            MenuTrancision.Start();
        }
        private void MenuTrancision_Tick_1(object sender, EventArgs e)
        {
            if (Expandir)
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width <= 70)
                {
                    Expandir = false;
                    MenuTrancision.Stop();
                }

            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width >= 216)
                {
                    Expandir = true;
                    MenuTrancision.Stop();
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
        }

        private void tabPage3_Click_1(object sender, EventArgs e)
        {

        }

        private void lbUltimoRegado_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }
        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }
        private void btnHistorial_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 1;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 3;
        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnRiegoAuto_Click(object sender, EventArgs e)
        {
            CicloRiegoAsync();
            ultimoRegado();
        }

        private void grilla_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            servicioHistorial.MostrarTodos();

        }

        private void BuscarHistorial_Click(object sender, EventArgs e)
        {
            BuscarHistorialGrilla();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            CargarHistorial();
            dtpFechaBusqueda.ResetText();
        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            lbFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            lbFechaInicio.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        }

        private void MENUPRINCIPAL_Load_1(object sender, EventArgs e)
        {
            ActualizarEstadoConexion();
            ultimoRegado();
            CargarHistorial();
            timerTiempo.Start();
            timerClima.Start();
            timerGraficas.Start();
            CargarUsuario();
            timerGraficaReal();
            grilla2.CellValueChanged += grilla2_CellValueChanged;
            grilla2.CurrentCellDirtyStateChanged += grilla2_CurrentCellDirtyStateChanged;


        }

        private void btnHacerCambios_Click(object sender, EventArgs e)
        {
            HacerCambios();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            
        }
        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void lbTemperatura_Click(object sender, EventArgs e)
        {

        }

        private void MENUPRINCIPAL_Resize(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            ObtenerDatosClimaAsync();
        }

        private void chartRiego_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Mtemperatura_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            GuardarCambios();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            var usu = serviciosUsuario.BuscarPorId(IdDelUsuario);
            dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                usu.Entidad.RutaImagen = dialogo.FileName;
                serviciosUsuario.Actualizar(usu.Entidad);
                pbImagenUsuario.Image = Image.FromFile(usu.Entidad.RutaImagen);
            }
            else
            {
                MessageBox.Show("No se seleccionó ninguna imagen.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            INICIAR form = new INICIAR();
            form.Show();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show($"¿Seguro que quieres eliminar este Usuario?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                string contraseña = Interaction.InputBox($"Ingrese su la contraseña del Usuario {txtNombreUsuariodelUsuario.Text}:", "Registro obligatorio", "");
                var usu = serviciosUsuario.BuscarPorId(IdDelUsuario);
                if (contraseña == usu.Entidad.Password)
                {
                    var mensaje = serviciosUsuario.Eliminar(usu.Entidad.IdUsuario);
                    if (mensaje.Estado)
                    {
                        MessageBox.Show("Usuario eliminado correctamente. Volviendo a la pantalla de inicio de sesión.");
                        INICIAR form = new INICIAR();
                        form.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hubo un error al eliminar el usuario.");
                    }
                }
            }
        }

        private void PanelPrincipal_Click(object sender, EventArgs e)
        {

        }

        private void MId_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            BuscarPlanta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PLANTAS from = new PLANTAS();
            from.Show();
            this.Hide();
        }

        private void grilla2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button3.Select();
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            grilla2.DataSource = null;
            grilla2.DataSource = serviciosAlertas.MostrarTodos().Lista;
        }

        // Esto es para detectar cambios inmediatos en checkbox
        private void grilla2_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grilla2.IsCurrentCellDirty)
            {
                grilla2.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Esto es para ejecutar la actualización cuando cambió el valor
        private void grilla2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignorar cabecera

            // Verifica si la columna es la de Estado (ej: columna 5)
            if (grilla2.Columns[e.ColumnIndex].Name == "Estado")
            {
                var alerta = grilla2.Rows[e.RowIndex].DataBoundItem as Alertas;
                if (alerta != null)
                {
                    try
                    {
                        serviciosAlertas.Actualizar(alerta); // Actualiza directamente en BD
                        MessageBox.Show($"Alerta ID {alerta.IdAlerta} actualizada correctamente.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar alerta: {ex.Message}");
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var hacer = servicioClima.MostrarTodos().Lista;
            grillaClima.Columns["Humedad_Ambiente"].DefaultCellStyle.Format = "N2' %'";
            grillaClima.Columns["Humedad_Suelo"].DefaultCellStyle.Format = "N2' %'";
            grillaClima.Columns["Temperatura_Ambiente"].DefaultCellStyle.Format = "N2' C°'";

        }

        private void lblHumedad_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            BuscarPorFechaEnGrillaClima();
        }

        private void button10_Click_2(object sender, EventArgs e)
        {
            BuscarHistorialGrillaAlertas();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            grillaClima.DataSource = null;
            var lista = servicioClima.MostrarTodos().Lista.Select(c => new
            {
                c.Fecha,
                Humedad_Ambiente = $"{c.Humedad_Ambiente:F2}%",
                Humedad_Suelo = $"{c.Humedad_Suelo:F2}%",
                Temperatura_Ambiente = $"{c.Temperatura_Ambiente:F2} °C",
                Viento = $"{c.Viento:F2} m/s"
        }).ToList();
            grillaClima.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            grillaClima.DataSource = lista;

        }

        private void timerGraficas_Tick(object sender, EventArgs e)
        {
            timerGraficaReal();
        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 4;

        }

    }
}
