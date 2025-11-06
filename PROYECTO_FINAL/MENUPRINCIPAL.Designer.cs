using System.Drawing;
using System.Windows.Forms;

namespace PROYECTO_RIEGO_AUTOMATICO
{
    partial class MENUPRINCIPAL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea15 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend15 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint85 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint86 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 52D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint87 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint88 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40D, 55D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint89 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint90 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(60D, 100D);
            System.Windows.Forms.DataVisualization.Charting.Title title15 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint91 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint92 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 52D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint93 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint94 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40D, 55D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint95 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint96 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(60D, 100D);
            System.Windows.Forms.DataVisualization.Charting.Title title16 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENUPRINCIPAL));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.PanelPrincipal = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ImagenTemperatura = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTemperatura = new System.Windows.Forms.Label();
            this.PanelHumedad = new System.Windows.Forms.Panel();
            this.I = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lbHum = new System.Windows.Forms.Label();
            this.PanelPronostico = new System.Windows.Forms.Panel();
            this.ImagenPronostico = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lbDes = new System.Windows.Forms.Label();
            this.PanelViento = new System.Windows.Forms.Panel();
            this.ImagenViento = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbVie = new System.Windows.Forms.Label();
            this.PanelTemperatura = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTemp = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbUltimoRegado = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbConec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbFechaActual = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.BuscarHistorial = new System.Windows.Forms.Button();
            this.dtpFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartTemperatura = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRiego = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRiegoAuto = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.MDescripcion = new System.Windows.Forms.Label();
            this.Mnombre = new System.Windows.Forms.Label();
            this.Mluz = new System.Windows.Forms.Label();
            this.Mtemperatura = new System.Windows.Forms.Label();
            this.Mhumedad = new System.Windows.Forms.Label();
            this.MId = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPlantas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPlanta = new System.Windows.Forms.PictureBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.btnHacerCambios = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtEmailUsu = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtNombreUsuariodelUsuario = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.pbImagenUsuario = new System.Windows.Forms.PictureBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.button5 = new System.Windows.Forms.Button();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnHistorial = new System.Windows.Forms.Button();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button7 = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.MenuTrancision = new System.Windows.Forms.Timer(this.components);
            this.timerTiempo = new System.Windows.Forms.Timer(this.components);
            this.timerClima = new System.Windows.Forms.Timer(this.components);
            this.timerGraficas = new System.Windows.Forms.Timer(this.components);
            this.cyberTextBox1 = new ReaLTaiizor.Controls.CyberTextBox();
            this.dreamTextBox1 = new ReaLTaiizor.Controls.DreamTextBox();
            this.aloneTextBox1 = new ReaLTaiizor.Controls.AloneTextBox();
            this.button9 = new ReaLTaiizor.Controls.Button();
            this.airButton1 = new ReaLTaiizor.Controls.AirButton();
            this.tabControl.SuspendLayout();
            this.PanelPrincipal.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).BeginInit();
            this.PanelHumedad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.I)).BeginInit();
            this.PanelPronostico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).BeginInit();
            this.PanelViento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).BeginInit();
            this.PanelTemperatura.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).BeginInit();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel12.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.PanelPrincipal);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(226, 42);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(793, 463);
            this.tabControl.TabIndex = 14;
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PanelPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.PanelPrincipal.Controls.Add(this.panel3);
            this.PanelPrincipal.Controls.Add(this.PanelHumedad);
            this.PanelPrincipal.Controls.Add(this.PanelPronostico);
            this.PanelPrincipal.Controls.Add(this.PanelViento);
            this.PanelPrincipal.Controls.Add(this.PanelTemperatura);
            this.PanelPrincipal.Controls.Add(this.panel1);
            this.PanelPrincipal.Location = new System.Drawing.Point(4, 24);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.PanelPrincipal.Size = new System.Drawing.Size(785, 435);
            this.PanelPrincipal.TabIndex = 0;
            this.PanelPrincipal.Text = "INICIO";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ImagenTemperatura);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbTemperatura);
            this.panel3.Location = new System.Drawing.Point(76, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(275, 161);
            this.panel3.TabIndex = 27;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // ImagenTemperatura
            // 
            this.ImagenTemperatura.Image = global::PROYECTO_FINAL.Properties.Resources.temperatura_alta;
            this.ImagenTemperatura.Location = new System.Drawing.Point(98, 7);
            this.ImagenTemperatura.Name = "ImagenTemperatura";
            this.ImagenTemperatura.Size = new System.Drawing.Size(74, 76);
            this.ImagenTemperatura.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenTemperatura.TabIndex = 23;
            this.ImagenTemperatura.TabStop = false;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Orange;
            this.label13.Location = new System.Drawing.Point(30, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(227, 21);
            this.label13.TabIndex = 1;
            this.label13.Text = "TEMPERATURA";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label13_Click);
            // 
            // lbTemperatura
            // 
            this.lbTemperatura.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemperatura.ForeColor = System.Drawing.Color.White;
            this.lbTemperatura.Location = new System.Drawing.Point(36, 110);
            this.lbTemperatura.Name = "lbTemperatura";
            this.lbTemperatura.Size = new System.Drawing.Size(204, 37);
            this.lbTemperatura.TabIndex = 2;
            this.lbTemperatura.Text = "90.0 °C";
            this.lbTemperatura.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbTemperatura.Click += new System.EventHandler(this.lbTemperatura_Click);
            // 
            // PanelHumedad
            // 
            this.PanelHumedad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PanelHumedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelHumedad.Controls.Add(this.I);
            this.PanelHumedad.Controls.Add(this.label10);
            this.PanelHumedad.Controls.Add(this.lbHum);
            this.PanelHumedad.Location = new System.Drawing.Point(77, 172);
            this.PanelHumedad.Name = "PanelHumedad";
            this.PanelHumedad.Padding = new System.Windows.Forms.Padding(4);
            this.PanelHumedad.Size = new System.Drawing.Size(274, 135);
            this.PanelHumedad.TabIndex = 24;
            // 
            // I
            // 
            this.I.Image = global::PROYECTO_FINAL.Properties.Resources.humedad;
            this.I.Location = new System.Drawing.Point(97, 10);
            this.I.Name = "I";
            this.I.Size = new System.Drawing.Size(58, 55);
            this.I.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.I.TabIndex = 21;
            this.I.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label10.Location = new System.Drawing.Point(49, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 27);
            this.label10.TabIndex = 22;
            this.label10.Text = "HUMEDAD";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbHum
            // 
            this.lbHum.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lbHum.ForeColor = System.Drawing.Color.White;
            this.lbHum.Location = new System.Drawing.Point(35, 94);
            this.lbHum.Name = "lbHum";
            this.lbHum.Size = new System.Drawing.Size(171, 35);
            this.lbHum.TabIndex = 19;
            this.lbHum.Text = "H";
            this.lbHum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelPronostico
            // 
            this.PanelPronostico.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PanelPronostico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelPronostico.Controls.Add(this.ImagenPronostico);
            this.PanelPronostico.Controls.Add(this.label11);
            this.PanelPronostico.Controls.Add(this.lbDes);
            this.PanelPronostico.Location = new System.Drawing.Point(420, 6);
            this.PanelPronostico.Name = "PanelPronostico";
            this.PanelPronostico.Padding = new System.Windows.Forms.Padding(4);
            this.PanelPronostico.Size = new System.Drawing.Size(275, 161);
            this.PanelPronostico.TabIndex = 24;
            // 
            // ImagenPronostico
            // 
            this.ImagenPronostico.Image = global::PROYECTO_FINAL.Properties.Resources.pronostico_del_tiempo;
            this.ImagenPronostico.Location = new System.Drawing.Point(104, 7);
            this.ImagenPronostico.Name = "ImagenPronostico";
            this.ImagenPronostico.Size = new System.Drawing.Size(67, 69);
            this.ImagenPronostico.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenPronostico.TabIndex = 0;
            this.ImagenPronostico.TabStop = false;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.label11.Location = new System.Drawing.Point(36, 85);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(204, 25);
            this.label11.TabIndex = 23;
            this.label11.Text = "PRONÓSTICO";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDes
            // 
            this.lbDes.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDes.ForeColor = System.Drawing.Color.White;
            this.lbDes.Location = new System.Drawing.Point(40, 106);
            this.lbDes.Name = "lbDes";
            this.lbDes.Size = new System.Drawing.Size(204, 40);
            this.lbDes.TabIndex = 24;
            this.lbDes.Text = "Despejado";
            this.lbDes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelViento
            // 
            this.PanelViento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PanelViento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelViento.Controls.Add(this.ImagenViento);
            this.PanelViento.Controls.Add(this.label12);
            this.PanelViento.Controls.Add(this.lbVie);
            this.PanelViento.Location = new System.Drawing.Point(420, 173);
            this.PanelViento.Name = "PanelViento";
            this.PanelViento.Padding = new System.Windows.Forms.Padding(4);
            this.PanelViento.Size = new System.Drawing.Size(274, 135);
            this.PanelViento.TabIndex = 25;
            // 
            // ImagenViento
            // 
            this.ImagenViento.Image = global::PROYECTO_FINAL.Properties.Resources.norte;
            this.ImagenViento.Location = new System.Drawing.Point(113, 7);
            this.ImagenViento.Name = "ImagenViento";
            this.ImagenViento.Size = new System.Drawing.Size(67, 61);
            this.ImagenViento.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenViento.TabIndex = 23;
            this.ImagenViento.TabStop = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.LightSkyBlue;
            this.label12.Location = new System.Drawing.Point(42, 61);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(204, 36);
            this.label12.TabIndex = 1;
            this.label12.Text = "VIENTO";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbVie
            // 
            this.lbVie.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbVie.ForeColor = System.Drawing.Color.White;
            this.lbVie.Location = new System.Drawing.Point(40, 95);
            this.lbVie.Name = "lbVie";
            this.lbVie.Size = new System.Drawing.Size(204, 33);
            this.lbVie.TabIndex = 2;
            this.lbVie.Text = "Norte";
            this.lbVie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PanelTemperatura
            // 
            this.PanelTemperatura.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.PanelTemperatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelTemperatura.Controls.Add(this.label9);
            this.PanelTemperatura.Controls.Add(this.lbTemp);
            this.PanelTemperatura.Location = new System.Drawing.Point(76, 5);
            this.PanelTemperatura.Name = "PanelTemperatura";
            this.PanelTemperatura.Padding = new System.Windows.Forms.Padding(4);
            this.PanelTemperatura.Size = new System.Drawing.Size(275, 161);
            this.PanelTemperatura.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Orange;
            this.label9.Location = new System.Drawing.Point(0, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "TEMPERATURA";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTemp
            // 
            this.lbTemp.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbTemp.ForeColor = System.Drawing.Color.White;
            this.lbTemp.Location = new System.Drawing.Point(0, 69);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(204, 26);
            this.lbTemp.TabIndex = 2;
            this.lbTemp.Text = "28.0 °C";
            this.lbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Location = new System.Drawing.Point(57, 313);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(662, 114);
            this.panel1.TabIndex = 13;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(241, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(209, 111);
            this.panel5.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PROYECTO_FINAL.Properties.Resources.drenaje;
            this.pictureBox1.Location = new System.Drawing.Point(73, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 31;
            this.pictureBox1.TabStop = false;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.MintCream;
            this.label17.Location = new System.Drawing.Point(56, 82);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 24);
            this.label17.TabIndex = 30;
            this.label17.Text = "ESTADO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label18.Location = new System.Drawing.Point(6, 58);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(200, 24);
            this.label18.TabIndex = 28;
            this.label18.Text = "BOMBA DE AGUA";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.lbUltimoRegado);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Location = new System.Drawing.Point(456, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(203, 108);
            this.panel6.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::PROYECTO_FINAL.Properties.Resources.regando_plantas;
            this.pictureBox3.Location = new System.Drawing.Point(71, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(57, 61);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 33;
            this.pictureBox3.TabStop = false;
            // 
            // lbUltimoRegado
            // 
            this.lbUltimoRegado.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUltimoRegado.ForeColor = System.Drawing.Color.MintCream;
            this.lbUltimoRegado.Location = new System.Drawing.Point(1, 78);
            this.lbUltimoRegado.Name = "lbUltimoRegado";
            this.lbUltimoRegado.Size = new System.Drawing.Size(204, 24);
            this.lbUltimoRegado.TabIndex = 31;
            this.lbUltimoRegado.Text = "FECHA";
            this.lbUltimoRegado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbUltimoRegado.Click += new System.EventHandler(this.lbUltimoRegado_Click);
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label16.Location = new System.Drawing.Point(28, 57);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(147, 24);
            this.label16.TabIndex = 31;
            this.label16.Text = "ULTIMO RIEGO";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lbConec);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(6, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(232, 111);
            this.panel4.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PROYECTO_FINAL.Properties.Resources.senal_satelital;
            this.pictureBox2.Location = new System.Drawing.Point(78, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(69, 71);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 25;
            this.pictureBox2.TabStop = false;
            // 
            // lbConec
            // 
            this.lbConec.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConec.ForeColor = System.Drawing.Color.MintCream;
            this.lbConec.Location = new System.Drawing.Point(103, 80);
            this.lbConec.Name = "lbConec";
            this.lbConec.Size = new System.Drawing.Size(126, 24);
            this.lbConec.TabIndex = 24;
            this.lbConec.Text = "ESTADO";
            this.lbConec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbConec.Click += new System.EventHandler(this.label14_Click_1);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label8.Location = new System.Drawing.Point(12, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "ESTADO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbFechaActual);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.BuscarHistorial);
            this.tabPage2.Controls.Add(this.dtpFechaBusqueda);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.grilla);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(785, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HISTORIALES";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbFechaActual
            // 
            this.lbFechaActual.AutoSize = true;
            this.lbFechaActual.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaActual.Location = new System.Drawing.Point(126, 379);
            this.lbFechaActual.Name = "lbFechaActual";
            this.lbFechaActual.Size = new System.Drawing.Size(150, 25);
            this.lbFechaActual.TabIndex = 6;
            this.lbFechaActual.Text = "FECHA ACTUAL";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label19.Location = new System.Drawing.Point(141, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(413, 26);
            this.label19.TabIndex = 5;
            this.label19.Text = "HISTORIAL DE RIEGOS EN LAS PLANTAS";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button8.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.Control;
            this.button8.Location = new System.Drawing.Point(598, 333);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 29);
            this.button8.TabIndex = 4;
            this.button8.Text = "LIMPIAR";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // BuscarHistorial
            // 
            this.BuscarHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.BuscarHistorial.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BuscarHistorial.ForeColor = System.Drawing.SystemColors.Control;
            this.BuscarHistorial.Location = new System.Drawing.Point(598, 299);
            this.BuscarHistorial.Name = "BuscarHistorial";
            this.BuscarHistorial.Size = new System.Drawing.Size(106, 29);
            this.BuscarHistorial.TabIndex = 3;
            this.BuscarHistorial.Text = "BUSCAR..";
            this.BuscarHistorial.UseVisualStyleBackColor = false;
            this.BuscarHistorial.Click += new System.EventHandler(this.BuscarHistorial_Click);
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(282, 319);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(292, 28);
            this.dtpFechaBusqueda.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(89, 317);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 25);
            this.label15.TabIndex = 1;
            this.label15.Text = "BUSCAR HISTORIAL";
            // 
            // grilla
            // 
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Location = new System.Drawing.Point(130, 77);
            this.grilla.Name = "grilla";
            this.grilla.Size = new System.Drawing.Size(459, 185);
            this.grilla.TabIndex = 0;
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick_1);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartTemperatura);
            this.tabPage3.Controls.Add(this.chartRiego);
            this.tabPage3.Controls.Add(this.btnRiegoAuto);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(785, 435);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RIEGO MANUAL";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click_1);
            // 
            // chartTemperatura
            // 
            chartArea15.AxisX.Interval = 10D;
            chartArea15.AxisX.Title = "Tiempo (m)";
            chartArea15.AxisY.Title = "Grados de Temperatura (C°)";
            chartArea15.BackColor = System.Drawing.Color.White;
            chartArea15.Name = "AreaPrincipal";
            this.chartTemperatura.ChartAreas.Add(chartArea15);
            legend15.Name = "Temperatura";
            this.chartTemperatura.Legends.Add(legend15);
            this.chartTemperatura.Location = new System.Drawing.Point(12, 222);
            this.chartTemperatura.Name = "chartTemperatura";
            series15.BorderWidth = 3;
            series15.ChartArea = "AreaPrincipal";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series15.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            series15.IsVisibleInLegend = false;
            series15.Legend = "Temperatura";
            series15.MarkerColor = System.Drawing.Color.Black;
            series15.MarkerSize = 8;
            series15.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series15.Name = "TEMPERATURA DEL AMBIENTE";
            series15.Points.Add(dataPoint85);
            series15.Points.Add(dataPoint86);
            series15.Points.Add(dataPoint87);
            series15.Points.Add(dataPoint88);
            series15.Points.Add(dataPoint89);
            series15.Points.Add(dataPoint90);
            this.chartTemperatura.Series.Add(series15);
            this.chartTemperatura.Size = new System.Drawing.Size(579, 207);
            this.chartTemperatura.TabIndex = 3;
            this.chartTemperatura.Text = "chart2";
            title15.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title15.Name = "Title1";
            title15.Text = "GRAFICA DE LA HUMEDAD DEL SUELO";
            this.chartTemperatura.Titles.Add(title15);
            this.chartTemperatura.Click += new System.EventHandler(this.chart2_Click);
            // 
            // chartRiego
            // 
            chartArea16.AxisX.Interval = 10D;
            chartArea16.AxisX.Title = "Tiempo (m)";
            chartArea16.AxisY.Title = "Nivel de humedad (%)";
            chartArea16.BackColor = System.Drawing.Color.White;
            chartArea16.Name = "AreaPrincipal";
            this.chartRiego.ChartAreas.Add(chartArea16);
            legend16.Name = "Humedad";
            this.chartRiego.Legends.Add(legend16);
            this.chartRiego.Location = new System.Drawing.Point(12, 9);
            this.chartRiego.Name = "chartRiego";
            series16.BorderWidth = 3;
            series16.ChartArea = "AreaPrincipal";
            series16.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series16.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(134)))), ((int)(((byte)(75)))));
            series16.IsVisibleInLegend = false;
            series16.Legend = "Humedad";
            series16.MarkerColor = System.Drawing.Color.Black;
            series16.MarkerSize = 8;
            series16.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series16.Name = "HUMEDAD DEL SUELO";
            series16.Points.Add(dataPoint91);
            series16.Points.Add(dataPoint92);
            series16.Points.Add(dataPoint93);
            series16.Points.Add(dataPoint94);
            series16.Points.Add(dataPoint95);
            series16.Points.Add(dataPoint96);
            this.chartRiego.Series.Add(series16);
            this.chartRiego.Size = new System.Drawing.Size(579, 207);
            this.chartRiego.TabIndex = 2;
            this.chartRiego.Text = "chart2";
            title16.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title16.Name = "Title1";
            title16.Text = "GRAFICA DE LA HUMEDAD DEL SUELO";
            this.chartRiego.Titles.Add(title16);
            this.chartRiego.Click += new System.EventHandler(this.chartRiego_Click);
            // 
            // btnRiegoAuto
            // 
            this.btnRiegoAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.btnRiegoAuto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRiegoAuto.Location = new System.Drawing.Point(642, 77);
            this.btnRiegoAuto.Name = "btnRiegoAuto";
            this.btnRiegoAuto.Size = new System.Drawing.Size(113, 54);
            this.btnRiegoAuto.TabIndex = 0;
            this.btnRiegoAuto.Text = "INICIAR RIEGO MANUAL";
            this.btnRiegoAuto.UseVisualStyleBackColor = false;
            this.btnRiegoAuto.Click += new System.EventHandler(this.btnRiegoAuto_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(785, 435);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MIS PLANTAS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.MDescripcion);
            this.panel2.Controls.Add(this.Mnombre);
            this.panel2.Controls.Add(this.Mluz);
            this.panel2.Controls.Add(this.Mtemperatura);
            this.panel2.Controls.Add(this.Mhumedad);
            this.panel2.Controls.Add(this.MId);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.cbPlantas);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.pbPlanta);
            this.panel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 424);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(378, 135);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 57);
            this.button1.TabIndex = 28;
            this.button1.Text = "MANIPULAR PLANTAS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_3);
            // 
            // MDescripcion
            // 
            this.MDescripcion.AutoSize = true;
            this.MDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.MDescripcion.Location = new System.Drawing.Point(561, 330);
            this.MDescripcion.Name = "MDescripcion";
            this.MDescripcion.Size = new System.Drawing.Size(122, 30);
            this.MDescripcion.TabIndex = 27;
            this.MDescripcion.Text = "Descripción";
            // 
            // Mnombre
            // 
            this.Mnombre.AutoSize = true;
            this.Mnombre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mnombre.Location = new System.Drawing.Point(50, 224);
            this.Mnombre.Name = "Mnombre";
            this.Mnombre.Size = new System.Drawing.Size(91, 30);
            this.Mnombre.TabIndex = 26;
            this.Mnombre.Text = "Nombre";
            // 
            // Mluz
            // 
            this.Mluz.AutoSize = true;
            this.Mluz.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mluz.Location = new System.Drawing.Point(144, 314);
            this.Mluz.Name = "Mluz";
            this.Mluz.Size = new System.Drawing.Size(45, 30);
            this.Mluz.TabIndex = 25;
            this.Mluz.Text = "Luz";
            // 
            // Mtemperatura
            // 
            this.Mtemperatura.AutoSize = true;
            this.Mtemperatura.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mtemperatura.Location = new System.Drawing.Point(211, 142);
            this.Mtemperatura.Name = "Mtemperatura";
            this.Mtemperatura.Size = new System.Drawing.Size(137, 30);
            this.Mtemperatura.TabIndex = 24;
            this.Mtemperatura.Text = "Temperatura";
            this.Mtemperatura.Click += new System.EventHandler(this.Mtemperatura_Click);
            // 
            // Mhumedad
            // 
            this.Mhumedad.AutoSize = true;
            this.Mhumedad.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mhumedad.Location = new System.Drawing.Point(243, 233);
            this.Mhumedad.Name = "Mhumedad";
            this.Mhumedad.Size = new System.Drawing.Size(106, 30);
            this.Mhumedad.TabIndex = 23;
            this.Mhumedad.Text = "Humedad";
            // 
            // MId
            // 
            this.MId.AutoSize = true;
            this.MId.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MId.Location = new System.Drawing.Point(89, 131);
            this.MId.Name = "MId";
            this.MId.Size = new System.Drawing.Size(31, 30);
            this.MId.TabIndex = 22;
            this.MId.Text = "Id";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Khaki;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(401, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 42);
            this.button2.TabIndex = 21;
            this.button2.Text = "BUSCAR";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(208, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 32);
            this.label7.TabIndex = 6;
            this.label7.Text = "Temperatura";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(113, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 13;
            this.label1.Text = "BUSCA TU PLANTA";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(51, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre";
            // 
            // cbPlantas
            // 
            this.cbPlantas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlantas.FormattingEnabled = true;
            this.cbPlantas.Location = new System.Drawing.Point(339, 29);
            this.cbPlantas.Name = "cbPlantas";
            this.cbPlantas.Size = new System.Drawing.Size(143, 33);
            this.cbPlantas.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 32);
            this.label5.TabIndex = 4;
            this.label5.Text = "Identificación";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(128, 284);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 32);
            this.label4.TabIndex = 3;
            this.label4.Text = "Luz Necesaria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(576, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 32);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descripción";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(223, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Humedad";
            // 
            // pbPlanta
            // 
            this.pbPlanta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPlanta.Location = new System.Drawing.Point(509, 23);
            this.pbPlanta.Name = "pbPlanta";
            this.pbPlanta.Size = new System.Drawing.Size(267, 243);
            this.pbPlanta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanta.TabIndex = 0;
            this.pbPlanta.TabStop = false;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(785, 435);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "CONFIGURACION";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.airButton1);
            this.tabPage1.Controls.Add(this.button9);
            this.tabPage1.Controls.Add(this.aloneTextBox1);
            this.tabPage1.Controls.Add(this.dreamTextBox1);
            this.tabPage1.Controls.Add(this.cyberTextBox1);
            this.tabPage1.Controls.Add(this.cbRol);
            this.tabPage1.Controls.Add(this.btnHacerCambios);
            this.tabPage1.Controls.Add(this.button10);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.txtNombreUsuario);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.txtEmailUsu);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.txtNombreUsuariodelUsuario);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtIdUsuario);
            this.tabPage1.Controls.Add(this.pbImagenUsuario);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(785, 435);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "USUARIO";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Items.AddRange(new object[] {
            "Cuidador",
            "Espectador",
            "Dueño"});
            this.cbRol.Location = new System.Drawing.Point(353, 244);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(164, 25);
            this.cbRol.TabIndex = 16;
            // 
            // btnHacerCambios
            // 
            this.btnHacerCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHacerCambios.Location = new System.Drawing.Point(586, 88);
            this.btnHacerCambios.Name = "btnHacerCambios";
            this.btnHacerCambios.Size = new System.Drawing.Size(122, 27);
            this.btnHacerCambios.TabIndex = 14;
            this.btnHacerCambios.Text = "HACER CAMBIOS";
            this.btnHacerCambios.UseVisualStyleBackColor = false;
            this.btnHacerCambios.Click += new System.EventHandler(this.btnHacerCambios_Click);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.NavajoWhite;
            this.button10.Location = new System.Drawing.Point(115, 275);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(107, 46);
            this.button10.TabIndex = 13;
            this.button10.Text = "Subir Foto";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_1);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(356, 221);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(28, 17);
            this.label24.TabIndex = 12;
            this.label24.Text = "Rol";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(353, 160);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 17);
            this.label25.TabIndex = 10;
            this.label25.Text = "Nombre";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Location = new System.Drawing.Point(554, 327);
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(164, 25);
            this.txtNombreUsuario.TabIndex = 9;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(572, 205);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(46, 17);
            this.label23.TabIndex = 6;
            this.label23.Text = "Email ";
            // 
            // txtEmailUsu
            // 
            this.txtEmailUsu.Location = new System.Drawing.Point(572, 227);
            this.txtEmailUsu.Name = "txtEmailUsu";
            this.txtEmailUsu.Size = new System.Drawing.Size(164, 25);
            this.txtEmailUsu.TabIndex = 5;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(353, 93);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(128, 17);
            this.label21.TabIndex = 4;
            this.label21.Text = "Nombre de Usuario";
            // 
            // txtNombreUsuariodelUsuario
            // 
            this.txtNombreUsuariodelUsuario.Location = new System.Drawing.Point(144, 327);
            this.txtNombreUsuariodelUsuario.Name = "txtNombreUsuariodelUsuario";
            this.txtNombreUsuariodelUsuario.Size = new System.Drawing.Size(164, 25);
            this.txtNombreUsuariodelUsuario.TabIndex = 3;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(353, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(96, 17);
            this.label20.TabIndex = 2;
            this.label20.Text = "Identificación ";
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(353, 327);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(164, 25);
            this.txtIdUsuario.TabIndex = 1;
            // 
            // pbImagenUsuario
            // 
            this.pbImagenUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagenUsuario.Location = new System.Drawing.Point(23, 14);
            this.pbImagenUsuario.Name = "pbImagenUsuario";
            this.pbImagenUsuario.Size = new System.Drawing.Size(285, 255);
            this.pbImagenUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenUsuario.TabIndex = 0;
            this.pbImagenUsuario.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.nightControlBox1);
            this.panel7.Controls.Add(this.btnHam);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1031, 42);
            this.panel7.TabIndex = 15;
            // 
            // nightControlBox1
            // 
            this.nightControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nightControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.nightControlBox1.CloseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.nightControlBox1.CloseHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nightControlBox1.DefaultLocation = true;
            this.nightControlBox1.DisableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.DisableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.nightControlBox1.EnableCloseColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMaximizeButton = true;
            this.nightControlBox1.EnableMaximizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.EnableMinimizeButton = true;
            this.nightControlBox1.EnableMinimizeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.nightControlBox1.Location = new System.Drawing.Point(892, 0);
            this.nightControlBox1.MaximizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MaximizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.MinimizeHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.nightControlBox1.MinimizeHoverForeColor = System.Drawing.Color.White;
            this.nightControlBox1.Name = "nightControlBox1";
            this.nightControlBox1.Size = new System.Drawing.Size(139, 31);
            this.nightControlBox1.TabIndex = 1;
            // 
            // btnHam
            // 
            this.btnHam.Image = global::PROYECTO_FINAL.Properties.Resources.menu;
            this.btnHam.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnHam.InitialImage")));
            this.btnHam.Location = new System.Drawing.Point(11, 7);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(33, 29);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHam.TabIndex = 0;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Controls.Add(this.panel10);
            this.flowLayoutPanel1.Controls.Add(this.panel9);
            this.flowLayoutPanel1.Controls.Add(this.panel13);
            this.flowLayoutPanel1.Controls.Add(this.panel11);
            this.flowLayoutPanel1.Controls.Add(this.panel8);
            this.flowLayoutPanel1.Controls.Add(this.panel12);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(216, 463);
            this.flowLayoutPanel1.TabIndex = 16;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.button5);
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(220, 47);
            this.panel10.TabIndex = 3;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button5.Image = global::PROYECTO_FINAL.Properties.Resources.home_6821152__1_;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(-4, -5);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.button5.Size = new System.Drawing.Size(237, 56);
            this.button5.TabIndex = 1;
            this.button5.Text = "                INICIO";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnHistorial);
            this.panel9.Location = new System.Drawing.Point(3, 56);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(220, 47);
            this.panel9.TabIndex = 3;
            // 
            // btnHistorial
            // 
            this.btnHistorial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistorial.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnHistorial.Image = global::PROYECTO_FINAL.Properties.Resources.grafico__1_1;
            this.btnHistorial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.Location = new System.Drawing.Point(-4, -6);
            this.btnHistorial.Name = "btnHistorial";
            this.btnHistorial.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.btnHistorial.Size = new System.Drawing.Size(237, 57);
            this.btnHistorial.TabIndex = 0;
            this.btnHistorial.Text = "                HISTORIAL";
            this.btnHistorial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorial.UseVisualStyleBackColor = false;
            this.btnHistorial.Click += new System.EventHandler(this.btnHistorial_Click_1);
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.button7);
            this.panel13.Location = new System.Drawing.Point(3, 109);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(220, 47);
            this.panel13.TabIndex = 4;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button7.Image = global::PROYECTO_FINAL.Properties.Resources.watering_can_179154;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Location = new System.Drawing.Point(-4, -8);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.button7.Size = new System.Drawing.Size(237, 62);
            this.button7.TabIndex = 0;
            this.button7.Text = "                RIEGO MANUAL";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click_1);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.button6);
            this.panel11.Location = new System.Drawing.Point(3, 162);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(220, 47);
            this.panel11.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button6.Image = global::PROYECTO_FINAL.Properties.Resources.lily_7148928;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(-4, -4);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.button6.Size = new System.Drawing.Size(237, 58);
            this.button6.TabIndex = 0;
            this.button6.Text = "                MIS PLANTAS";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click_1);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button3);
            this.panel8.Location = new System.Drawing.Point(3, 215);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(220, 47);
            this.panel8.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Image = global::PROYECTO_FINAL.Properties.Resources.gear_14038827;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(-4, -8);
            this.button3.Name = "button3";
            this.button3.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.button3.Size = new System.Drawing.Size(237, 61);
            this.button3.TabIndex = 0;
            this.button3.Text = "                AJUSTES";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_3);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.button4);
            this.panel12.Location = new System.Drawing.Point(3, 268);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(220, 47);
            this.panel12.TabIndex = 3;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Image = global::PROYECTO_FINAL.Properties.Resources.user_11043331;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(-4, -4);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(21, 0, 0, 0);
            this.button4.Size = new System.Drawing.Size(237, 55);
            this.button4.TabIndex = 0;
            this.button4.Text = "                USUARIO";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // MenuTrancision
            // 
            this.MenuTrancision.Enabled = true;
            this.MenuTrancision.Interval = 10;
            this.MenuTrancision.Tick += new System.EventHandler(this.MenuTrancision_Tick_1);
            // 
            // timerTiempo
            // 
            this.timerTiempo.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // timerClima
            // 
            this.timerClima.Interval = 600000;
            this.timerClima.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timerGraficas
            // 
            this.timerGraficas.Interval = 600000;
            this.timerGraficas.Tick += new System.EventHandler(this.timerGraficas_Tick);
            // 
            // cyberTextBox1
            // 
            this.cyberTextBox1.Alpha = 20;
            this.cyberTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.cyberTextBox1.Background_WidthPen = 3F;
            this.cyberTextBox1.BackgroundPen = true;
            this.cyberTextBox1.ColorBackground = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberTextBox1.ColorBackground_Pen = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberTextBox1.ColorLighting = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberTextBox1.ColorPen_1 = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(200)))), ((int)(((byte)(238)))));
            this.cyberTextBox1.ColorPen_2 = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(52)))), ((int)(((byte)(68)))));
            this.cyberTextBox1.CyberTextBoxStyle = ReaLTaiizor.Enum.Cyber.StateStyle.Custom;
            this.cyberTextBox1.Font = new System.Drawing.Font("Arial", 10F);
            this.cyberTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.cyberTextBox1.Lighting = false;
            this.cyberTextBox1.LinearGradientPen = false;
            this.cyberTextBox1.Location = new System.Drawing.Point(352, 117);
            this.cyberTextBox1.Name = "cyberTextBox1";
            this.cyberTextBox1.PenWidth = 15;
            this.cyberTextBox1.RGB = false;
            this.cyberTextBox1.Rounding = true;
            this.cyberTextBox1.RoundingInt = 60;
            this.cyberTextBox1.Size = new System.Drawing.Size(200, 40);
            this.cyberTextBox1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.cyberTextBox1.TabIndex = 17;
            this.cyberTextBox1.Tag = "Cyber";
            this.cyberTextBox1.TextButton = "Cyber Text";
            this.cyberTextBox1.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.cyberTextBox1.Timer_RGB = 300;
            // 
            // dreamTextBox1
            // 
            this.dreamTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dreamTextBox1.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.dreamTextBox1.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(41)))), ((int)(((byte)(41)))));
            this.dreamTextBox1.ColorC = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.dreamTextBox1.ColorD = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.dreamTextBox1.ColorE = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dreamTextBox1.ColorF = System.Drawing.Color.Black;
            this.dreamTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(218)))), ((int)(((byte)(255)))));
            this.dreamTextBox1.Location = new System.Drawing.Point(359, 183);
            this.dreamTextBox1.Name = "dreamTextBox1";
            this.dreamTextBox1.Size = new System.Drawing.Size(193, 25);
            this.dreamTextBox1.TabIndex = 18;
            // 
            // aloneTextBox1
            // 
            this.aloneTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.aloneTextBox1.EnabledCalc = true;
            this.aloneTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.aloneTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.aloneTextBox1.Location = new System.Drawing.Point(352, 54);
            this.aloneTextBox1.MaxLength = 32767;
            this.aloneTextBox1.MultiLine = false;
            this.aloneTextBox1.Name = "aloneTextBox1";
            this.aloneTextBox1.ReadOnly = false;
            this.aloneTextBox1.Size = new System.Drawing.Size(177, 29);
            this.aloneTextBox1.TabIndex = 19;
            this.aloneTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.aloneTextBox1.UseSystemPasswordChar = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button9.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Image = null;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button9.Location = new System.Drawing.Point(586, 39);
            this.button9.Name = "button9";
            this.button9.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button9.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button9.Size = new System.Drawing.Size(120, 40);
            this.button9.TabIndex = 20;
            this.button9.Text = "GUARDAR CAMBIOS";
            this.button9.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // airButton1
            // 
            this.airButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.airButton1.Customization = "7e3t//Ly8v/r6+v/5ubm/+vr6//f39//p6en/zw8PP8UFBT/gICA/w==";
            this.airButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.airButton1.Image = null;
            this.airButton1.Location = new System.Drawing.Point(256, 341);
            this.airButton1.Name = "airButton1";
            this.airButton1.NoRounding = false;
            this.airButton1.Size = new System.Drawing.Size(8, 10);
            this.airButton1.TabIndex = 21;
            this.airButton1.Text = "airButton1";
            this.airButton1.Transparent = false;
            // 
            // MENUPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1031, 505);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MENUPRINCIPAL";
            this.Text = "MENUPRINCIPAL";
            this.Load += new System.EventHandler(this.MENUPRINCIPAL_Load_1);
            this.Resize += new System.EventHandler(this.MENUPRINCIPAL_Resize);
            this.tabControl.ResumeLayout(false);
            this.PanelPrincipal.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).EndInit();
            this.PanelHumedad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.I)).EndInit();
            this.PanelPronostico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).EndInit();
            this.PanelViento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).EndInit();
            this.PanelTemperatura.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).EndInit();
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl;
        private TabPage PanelPrincipal;
        private TabPage tabPage2;
        private Label lbDes;
        private Label lbTemp;
        private Label lbHum;
        private Label lbVie;
        private Panel panel1;
        private TabPage tabPage3;
        private TabPage tabPage5;
        private TabPage tabPage4;
        private Panel panel2;
        private Label Mnombre;
        private Label Mluz;
        private Label Mtemperatura;
        private Label Mhumedad;
        private Label MId;
        private Button button2;
        private Label label7;
        private Label label1;
        private Label label6;
        private ComboBox cbPlantas;
        private Label label5;
        private Label label4;
        private Label label2;
        private PictureBox pbPlanta;
        private Label MDescripcion;
        private Label label3;
        private Button button1;
        private Panel PanelTemperatura;
        private Panel PanelHumedad;
        private Label label10;
        private Panel PanelPronostico;
        private Label label11;
        private Panel PanelViento;
        private Label label12;
        private Label label9;
        private PictureBox ImagenPronostico;
        private PictureBox I;
        private PictureBox ImagenViento;
        private Panel panel3;
        private Label label13;
        private Label lbTemperatura;
        private PictureBox ImagenTemperatura;
        private Panel panel5;
        private Panel panel4;
        private Label label8;
        private Label lbConec;
        private Label label17;
        private Label label18;
        private Button btnRiegoAuto;
        private DataGridView grilla;
        private Panel panel7;
        private PictureBox btnHam;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel11;
        private Button button6;
        private Panel panel10;
        private Panel panel9;
        private Button btnHistorial;
        private Panel panel8;
        private Button button3;
        private Panel panel12;
        private Button button4;
        private System.Windows.Forms.Timer MenuTrancision;
        private Panel panel13;
        private Button button7;
        private Label label15;
        private Button BuscarHistorial;
        private DateTimePicker dtpFechaBusqueda;
        private Button button8;
        private Label label19;
        private Label lbFechaActual;
        private System.Windows.Forms.Timer timerTiempo;
        private TabPage tabPage1;
        private PictureBox pbImagenUsuario;
        private Label label23;
        private TextBox txtEmailUsu;
        private Label label24;
        private Label label25;
        private Button btnHacerCambios;
        private Button button10;
        private Button button5;
        private Panel panel6;
        private Label lbUltimoRegado;
        private Label label16;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRiego;
        private ComboBox cbRol;
        private TextBox txtNombreUsuario;
        private Label label21;
        private TextBox txtNombreUsuariodelUsuario;
        private Label label20;
        private TextBox txtIdUsuario;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperatura;
        private Timer timerClima;
        private Timer timerGraficas;
        private ReaLTaiizor.Controls.AloneTextBox aloneTextBox1;
        private ReaLTaiizor.Controls.DreamTextBox dreamTextBox1;
        private ReaLTaiizor.Controls.CyberTextBox cyberTextBox1;
        private ReaLTaiizor.Controls.Button button9;
        private ReaLTaiizor.Controls.AirButton airButton1;
    }
}