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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MENUPRINCIPAL));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea17 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend17 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series17 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title17 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea18 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend18 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series18 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint49 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(10D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint50 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(20D, 52D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint51 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(30D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint52 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(40D, 55D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint53 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(50D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint54 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(60D, 100D);
            System.Windows.Forms.DataVisualization.Charting.Title title18 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea19 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend19 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series19 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint55 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint56 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 52D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint57 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint58 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 55D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint59 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 70D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint60 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, 100D);
            System.Windows.Forms.DataVisualization.Charting.Title title19 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea20 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend20 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series20 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title20 = new System.Windows.Forms.DataVisualization.Charting.Title();
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
            this.button4 = new System.Windows.Forms.Button();
            this.MenuTrancision = new System.Windows.Forms.Timer(this.components);
            this.timerTiempo = new System.Windows.Forms.Timer(this.components);
            this.timerClima = new System.Windows.Forms.Timer(this.components);
            this.timerGraficas = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEliminarUsuario = new ReaLTaiizor.Controls.Button();
            this.btnSubirFoto = new ReaLTaiizor.Controls.Button();
            this.cbRol = new ReaLTaiizor.Controls.AloneComboBox();
            this.txtEmailUsu = new ReaLTaiizor.Controls.AloneTextBox();
            this.txtNombreUsuario = new ReaLTaiizor.Controls.AloneTextBox();
            this.btnCerrarsession = new ReaLTaiizor.Controls.Button();
            this.txtIdUsuario = new ReaLTaiizor.Controls.AloneTextBox();
            this.btnGuardarCambios = new ReaLTaiizor.Controls.Button();
            this.txtNombreUsuariodelUsuario = new ReaLTaiizor.Controls.AloneTextBox();
            this.btnHacerCambios = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.pbImagenUsuario = new System.Windows.Forms.PictureBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartCultivo = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button1 = new ReaLTaiizor.Controls.Button();
            this.button2 = new ReaLTaiizor.Controls.Button();
            this.MDescripcion = new System.Windows.Forms.Label();
            this.Mnombre = new System.Windows.Forms.Label();
            this.Mluz = new System.Windows.Forms.Label();
            this.Mtemperatura = new System.Windows.Forms.Label();
            this.Mhumedad = new System.Windows.Forms.Label();
            this.MId = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPlantas = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pbPlanta = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button11 = new ReaLTaiizor.Controls.Button();
            this.calendarioRiego = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.grillaClima = new System.Windows.Forms.DataGridView();
            this.chartTemperatura = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRiego = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRiegoAuto = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button10 = new System.Windows.Forms.Button();
            this.calendarioAlertas = new System.Windows.Forms.DateTimePicker();
            this.label22 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.grilla2 = new System.Windows.Forms.DataGridView();
            this.lbFechaActual = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.BuscarHistorial = new System.Windows.Forms.Button();
            this.dtpFechaBusqueda = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.grilla = new System.Windows.Forms.DataGridView();
            this.PanelPrincipal = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lblHumedad = new System.Windows.Forms.Label();
            this.panel12 = new ReaLTaiizor.Controls.Panel();
            this.chartClima = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbEstadodeBomba = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ImagenTemperatura = new System.Windows.Forms.PictureBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTemperatura = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbConec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lbUltimoRegado = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCultivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaClima)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).BeginInit();
            this.PanelPrincipal.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartClima)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.PanelHumedad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.I)).BeginInit();
            this.PanelPronostico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).BeginInit();
            this.PanelViento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).BeginInit();
            this.PanelTemperatura.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.Controls.Add(this.nightControlBox1);
            this.panel7.Controls.Add(this.btnHam);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1269, 42);
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
            this.nightControlBox1.Location = new System.Drawing.Point(1130, 0);
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
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(224, 639);
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
            this.button5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnHistorial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.button6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.panel8.Controls.Add(this.button4);
            this.panel8.Location = new System.Drawing.Point(3, 215);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(220, 47);
            this.panel8.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnEliminarUsuario);
            this.tabPage1.Controls.Add(this.btnSubirFoto);
            this.tabPage1.Controls.Add(this.cbRol);
            this.tabPage1.Controls.Add(this.txtEmailUsu);
            this.tabPage1.Controls.Add(this.txtNombreUsuario);
            this.tabPage1.Controls.Add(this.btnCerrarsession);
            this.tabPage1.Controls.Add(this.txtIdUsuario);
            this.tabPage1.Controls.Add(this.btnGuardarCambios);
            this.tabPage1.Controls.Add(this.txtNombreUsuariodelUsuario);
            this.tabPage1.Controls.Add(this.btnHacerCambios);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.pbImagenUsuario);
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1019, 605);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "USUARIO";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click_1);
            // 
            // btnEliminarUsuario
            // 
            this.btnEliminarUsuario.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminarUsuario.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminarUsuario.Enabled = false;
            this.btnEliminarUsuario.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarUsuario.Image = null;
            this.btnEliminarUsuario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminarUsuario.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.Location = new System.Drawing.Point(882, 526);
            this.btnEliminarUsuario.Name = "btnEliminarUsuario";
            this.btnEliminarUsuario.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnEliminarUsuario.Size = new System.Drawing.Size(120, 40);
            this.btnEliminarUsuario.TabIndex = 27;
            this.btnEliminarUsuario.Text = "Eliminar Usuario";
            this.btnEliminarUsuario.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnEliminarUsuario.Click += new System.EventHandler(this.button12_Click);
            // 
            // btnSubirFoto
            // 
            this.btnSubirFoto.BackColor = System.Drawing.Color.Transparent;
            this.btnSubirFoto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubirFoto.Enabled = false;
            this.btnSubirFoto.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubirFoto.Image = null;
            this.btnSubirFoto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSubirFoto.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.Location = new System.Drawing.Point(99, 332);
            this.btnSubirFoto.Name = "btnSubirFoto";
            this.btnSubirFoto.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnSubirFoto.Size = new System.Drawing.Size(120, 40);
            this.btnSubirFoto.TabIndex = 25;
            this.btnSubirFoto.Text = "Subir Foto";
            this.btnSubirFoto.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnSubirFoto.Click += new System.EventHandler(this.button11_Click);
            // 
            // cbRol
            // 
            this.cbRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbRol.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRol.EnabledCalc = false;
            this.cbRol.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRol.FormattingEnabled = true;
            this.cbRol.ItemHeight = 20;
            this.cbRol.Items.AddRange(new object[] {
            "Cuidador",
            "Espectador",
            "Dueño"});
            this.cbRol.Location = new System.Drawing.Point(534, 361);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(177, 26);
            this.cbRol.TabIndex = 24;
            // 
            // txtEmailUsu
            // 
            this.txtEmailUsu.BackColor = System.Drawing.Color.Transparent;
            this.txtEmailUsu.EnabledCalc = false;
            this.txtEmailUsu.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailUsu.ForeColor = System.Drawing.Color.Black;
            this.txtEmailUsu.Location = new System.Drawing.Point(618, 247);
            this.txtEmailUsu.MaxLength = 32767;
            this.txtEmailUsu.MultiLine = false;
            this.txtEmailUsu.Name = "txtEmailUsu";
            this.txtEmailUsu.ReadOnly = false;
            this.txtEmailUsu.Size = new System.Drawing.Size(177, 29);
            this.txtEmailUsu.TabIndex = 23;
            this.txtEmailUsu.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtEmailUsu.UseSystemPasswordChar = false;
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.BackColor = System.Drawing.Color.Transparent;
            this.txtNombreUsuario.EnabledCalc = false;
            this.txtNombreUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtNombreUsuario.Location = new System.Drawing.Point(393, 249);
            this.txtNombreUsuario.MaxLength = 32767;
            this.txtNombreUsuario.MultiLine = false;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.ReadOnly = false;
            this.txtNombreUsuario.Size = new System.Drawing.Size(177, 29);
            this.txtNombreUsuario.TabIndex = 22;
            this.txtNombreUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombreUsuario.UseSystemPasswordChar = false;
            // 
            // btnCerrarsession
            // 
            this.btnCerrarsession.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrarsession.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrarsession.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarsession.Image = null;
            this.btnCerrarsession.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarsession.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.Location = new System.Drawing.Point(882, 20);
            this.btnCerrarsession.Name = "btnCerrarsession";
            this.btnCerrarsession.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnCerrarsession.Size = new System.Drawing.Size(120, 40);
            this.btnCerrarsession.TabIndex = 26;
            this.btnCerrarsession.Text = "Cerrar Sesión";
            this.btnCerrarsession.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnCerrarsession.Click += new System.EventHandler(this.button10_Click);
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.BackColor = System.Drawing.Color.Transparent;
            this.txtIdUsuario.EnabledCalc = false;
            this.txtIdUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtIdUsuario.Location = new System.Drawing.Point(382, 146);
            this.txtIdUsuario.MaxLength = 32767;
            this.txtIdUsuario.MultiLine = false;
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.ReadOnly = false;
            this.txtIdUsuario.Size = new System.Drawing.Size(177, 29);
            this.txtIdUsuario.TabIndex = 21;
            this.txtIdUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtIdUsuario.UseSystemPasswordChar = false;
            // 
            // btnGuardarCambios
            // 
            this.btnGuardarCambios.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarCambios.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarCambios.Enabled = false;
            this.btnGuardarCambios.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarCambios.Image = null;
            this.btnGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarCambios.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.Location = new System.Drawing.Point(509, 24);
            this.btnGuardarCambios.Name = "btnGuardarCambios";
            this.btnGuardarCambios.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btnGuardarCambios.Size = new System.Drawing.Size(120, 40);
            this.btnGuardarCambios.TabIndex = 20;
            this.btnGuardarCambios.Text = "Guardar Cambios";
            this.btnGuardarCambios.TextAlignment = System.Drawing.StringAlignment.Center;
            this.btnGuardarCambios.Click += new System.EventHandler(this.button9_Click);
            // 
            // txtNombreUsuariodelUsuario
            // 
            this.txtNombreUsuariodelUsuario.BackColor = System.Drawing.Color.Transparent;
            this.txtNombreUsuariodelUsuario.EnabledCalc = false;
            this.txtNombreUsuariodelUsuario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuariodelUsuario.ForeColor = System.Drawing.Color.Black;
            this.txtNombreUsuariodelUsuario.Location = new System.Drawing.Point(618, 146);
            this.txtNombreUsuariodelUsuario.MaxLength = 32767;
            this.txtNombreUsuariodelUsuario.MultiLine = false;
            this.txtNombreUsuariodelUsuario.Name = "txtNombreUsuariodelUsuario";
            this.txtNombreUsuariodelUsuario.ReadOnly = false;
            this.txtNombreUsuariodelUsuario.Size = new System.Drawing.Size(177, 29);
            this.txtNombreUsuariodelUsuario.TabIndex = 19;
            this.txtNombreUsuariodelUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtNombreUsuariodelUsuario.UseSystemPasswordChar = false;
            // 
            // btnHacerCambios
            // 
            this.btnHacerCambios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnHacerCambios.Location = new System.Drawing.Point(358, 20);
            this.btnHacerCambios.Name = "btnHacerCambios";
            this.btnHacerCambios.Size = new System.Drawing.Size(122, 44);
            this.btnHacerCambios.TabIndex = 14;
            this.btnHacerCambios.Text = "HACER CAMBIOS";
            this.btnHacerCambios.UseVisualStyleBackColor = false;
            this.btnHacerCambios.Click += new System.EventHandler(this.btnHacerCambios_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(529, 332);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 25);
            this.label24.TabIndex = 12;
            this.label24.Text = "Rol";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(377, 221);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 25);
            this.label25.TabIndex = 10;
            this.label25.Text = "Nombre";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(613, 221);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 25);
            this.label23.TabIndex = 6;
            this.label23.Text = "Email ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(602, 118);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(187, 25);
            this.label21.TabIndex = 4;
            this.label21.Text = "Nombre de Usuario";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(366, 118);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(138, 25);
            this.label20.TabIndex = 2;
            this.label20.Text = "Identificación ";
            // 
            // pbImagenUsuario
            // 
            this.pbImagenUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagenUsuario.Image = global::PROYECTO_FINAL.Properties.Resources.admin_14471192;
            this.pbImagenUsuario.Location = new System.Drawing.Point(23, 14);
            this.pbImagenUsuario.Name = "pbImagenUsuario";
            this.pbImagenUsuario.Size = new System.Drawing.Size(315, 307);
            this.pbImagenUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImagenUsuario.TabIndex = 0;
            this.pbImagenUsuario.TabStop = false;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPage4.Controls.Add(this.panel2);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1019, 605);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MIS PLANTAS";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.chartCultivo);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.MDescripcion);
            this.panel2.Controls.Add(this.Mnombre);
            this.panel2.Controls.Add(this.Mluz);
            this.panel2.Controls.Add(this.Mtemperatura);
            this.panel2.Controls.Add(this.Mhumedad);
            this.panel2.Controls.Add(this.MId);
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
            this.panel2.Size = new System.Drawing.Size(1013, 599);
            this.panel2.TabIndex = 12;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint_1);
            // 
            // chartCultivo
            // 
            this.chartCultivo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartCultivo.BackColor = System.Drawing.SystemColors.ControlLight;
            chartArea17.Area3DStyle.Enable3D = true;
            chartArea17.Area3DStyle.Inclination = 25;
            chartArea17.Name = "MainArea";
            this.chartCultivo.ChartAreas.Add(chartArea17);
            legend17.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend17.IsTextAutoFit = false;
            legend17.Name = "Legend1";
            this.chartCultivo.Legends.Add(legend17);
            this.chartCultivo.Location = new System.Drawing.Point(-3, 339);
            this.chartCultivo.Name = "chartCultivo";
            this.chartCultivo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series17.ChartArea = "MainArea";
            series17.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series17.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            series17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series17.IsValueShownAsLabel = true;
            series17.Label = "#VALY";
            series17.Legend = "Legend1";
            series17.LegendText = "#VALX";
            series17.Name = "DatosClimáticos";
            series17.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartCultivo.Series.Add(series17);
            this.chartCultivo.Size = new System.Drawing.Size(573, 263);
            this.chartCultivo.TabIndex = 31;
            this.chartCultivo.Text = "chart1";
            title17.Name = "Title1";
            this.chartCultivo.Titles.Add(title17);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button1.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = null;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button1.Location = new System.Drawing.Point(439, 122);
            this.button1.Name = "button1";
            this.button1.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button1.Size = new System.Drawing.Size(120, 87);
            this.button1.TabIndex = 30;
            this.button1.Text = "MANIPULAR PLANTAS";
            this.button1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button2.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = null;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button2.Location = new System.Drawing.Point(439, 76);
            this.button2.Name = "button2";
            this.button2.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button2.Size = new System.Drawing.Size(120, 40);
            this.button2.TabIndex = 29;
            this.button2.Text = "Buscar Planta";
            this.button2.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MDescripcion
            // 
            this.MDescripcion.AutoSize = true;
            this.MDescripcion.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.MDescripcion.Location = new System.Drawing.Point(576, 470);
            this.MDescripcion.Name = "MDescripcion";
            this.MDescripcion.Size = new System.Drawing.Size(122, 30);
            this.MDescripcion.TabIndex = 27;
            this.MDescripcion.Text = "Descripción";
            // 
            // Mnombre
            // 
            this.Mnombre.AutoSize = true;
            this.Mnombre.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mnombre.Location = new System.Drawing.Point(75, 285);
            this.Mnombre.Name = "Mnombre";
            this.Mnombre.Size = new System.Drawing.Size(91, 30);
            this.Mnombre.TabIndex = 26;
            this.Mnombre.Text = "Nombre";
            // 
            // Mluz
            // 
            this.Mluz.AutoSize = true;
            this.Mluz.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mluz.Location = new System.Drawing.Point(423, 285);
            this.Mluz.Name = "Mluz";
            this.Mluz.Size = new System.Drawing.Size(45, 30);
            this.Mluz.TabIndex = 25;
            this.Mluz.Text = "Luz";
            // 
            // Mtemperatura
            // 
            this.Mtemperatura.AutoSize = true;
            this.Mtemperatura.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.Mtemperatura.Location = new System.Drawing.Point(246, 166);
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
            this.Mhumedad.Location = new System.Drawing.Point(256, 285);
            this.Mhumedad.Name = "Mhumedad";
            this.Mhumedad.Size = new System.Drawing.Size(106, 30);
            this.Mhumedad.TabIndex = 23;
            this.Mhumedad.Text = "Humedad";
            // 
            // MId
            // 
            this.MId.AutoSize = true;
            this.MId.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MId.Location = new System.Drawing.Point(100, 170);
            this.MId.Name = "MId";
            this.MId.Size = new System.Drawing.Size(31, 30);
            this.MId.TabIndex = 22;
            this.MId.Text = "Id";
            this.MId.Click += new System.EventHandler(this.MId_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Segoe UI Black", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(243, 125);
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
            this.label1.Location = new System.Drawing.Point(58, 34);
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
            this.label6.Location = new System.Drawing.Point(80, 244);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 32);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre";
            // 
            // cbPlantas
            // 
            this.cbPlantas.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPlantas.FormattingEnabled = true;
            this.cbPlantas.Location = new System.Drawing.Point(338, 29);
            this.cbPlantas.Name = "cbPlantas";
            this.cbPlantas.Size = new System.Drawing.Size(143, 33);
            this.cbPlantas.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(58, 125);
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
            this.label4.Location = new System.Drawing.Point(410, 244);
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
            this.label3.Location = new System.Drawing.Point(624, 423);
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
            this.label2.Location = new System.Drawing.Point(251, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Humedad";
            // 
            // pbPlanta
            // 
            this.pbPlanta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPlanta.Location = new System.Drawing.Point(581, 11);
            this.pbPlanta.Name = "pbPlanta";
            this.pbPlanta.Size = new System.Drawing.Size(429, 409);
            this.pbPlanta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbPlanta.TabIndex = 0;
            this.pbPlanta.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button11);
            this.tabPage3.Controls.Add(this.calendarioRiego);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.button9);
            this.tabPage3.Controls.Add(this.grillaClima);
            this.tabPage3.Controls.Add(this.chartTemperatura);
            this.tabPage3.Controls.Add(this.chartRiego);
            this.tabPage3.Controls.Add(this.btnRiegoAuto);
            this.tabPage3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1019, 605);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RIEGO MANUAL";
            this.tabPage3.UseVisualStyleBackColor = true;
            this.tabPage3.Click += new System.EventHandler(this.tabPage3_Click_1);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button11.EnteredBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button11.EnteredColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Image = null;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.InactiveColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(34)))), ((int)(((byte)(37)))));
            this.button11.Location = new System.Drawing.Point(809, 524);
            this.button11.Name = "button11";
            this.button11.PressedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button11.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.button11.Size = new System.Drawing.Size(120, 40);
            this.button11.TabIndex = 21;
            this.button11.Text = "Buscar";
            this.button11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // calendarioRiego
            // 
            this.calendarioRiego.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarioRiego.Location = new System.Drawing.Point(725, 481);
            this.calendarioRiego.Name = "calendarioRiego";
            this.calendarioRiego.Size = new System.Drawing.Size(292, 28);
            this.calendarioRiego.TabIndex = 7;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(767, 453);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(193, 25);
            this.label17.TabIndex = 6;
            this.label17.Text = "BUSCAR POR FECHA";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button9.Location = new System.Drawing.Point(744, 372);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(141, 54);
            this.button9.TabIndex = 5;
            this.button9.Text = "RECARGAR HISTORIAL";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // grillaClima
            // 
            this.grillaClima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillaClima.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grillaClima.Location = new System.Drawing.Point(3, 360);
            this.grillaClima.Name = "grillaClima";
            this.grillaClima.Size = new System.Drawing.Size(715, 218);
            this.grillaClima.TabIndex = 4;
            this.grillaClima.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // chartTemperatura
            // 
            chartArea18.AxisX.Interval = 10D;
            chartArea18.AxisX.Title = "Tiempo (m)";
            chartArea18.AxisY.Title = "Grados de Temperatura (C°)";
            chartArea18.BackColor = System.Drawing.Color.White;
            chartArea18.Name = "AreaPrincipal";
            this.chartTemperatura.ChartAreas.Add(chartArea18);
            legend18.Name = "Temperatura";
            this.chartTemperatura.Legends.Add(legend18);
            this.chartTemperatura.Location = new System.Drawing.Point(510, 3);
            this.chartTemperatura.Name = "chartTemperatura";
            series18.BorderWidth = 3;
            series18.ChartArea = "AreaPrincipal";
            series18.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series18.Color = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(33)))), ((int)(((byte)(52)))));
            series18.IsVisibleInLegend = false;
            series18.Legend = "Temperatura";
            series18.MarkerColor = System.Drawing.Color.Black;
            series18.MarkerSize = 8;
            series18.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series18.Name = "TEMPERATURA DEL AMBIENTE";
            series18.Points.Add(dataPoint49);
            series18.Points.Add(dataPoint50);
            series18.Points.Add(dataPoint51);
            series18.Points.Add(dataPoint52);
            series18.Points.Add(dataPoint53);
            series18.Points.Add(dataPoint54);
            this.chartTemperatura.Series.Add(series18);
            this.chartTemperatura.Size = new System.Drawing.Size(506, 336);
            this.chartTemperatura.TabIndex = 3;
            this.chartTemperatura.Text = "chart2";
            title18.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title18.Name = "Title1";
            title18.Text = "GRAFICO DE LA TEMPERATURA DEL AMBIENTE";
            this.chartTemperatura.Titles.Add(title18);
            this.chartTemperatura.Click += new System.EventHandler(this.chart2_Click);
            // 
            // chartRiego
            // 
            chartArea19.AxisX.Interval = 10D;
            chartArea19.AxisX.Title = "Tiempo (m)";
            chartArea19.AxisY.Title = "Nivel de humedad (%)";
            chartArea19.BackColor = System.Drawing.Color.White;
            chartArea19.Name = "AreaPrincipal";
            this.chartRiego.ChartAreas.Add(chartArea19);
            legend19.Name = "Humedad";
            this.chartRiego.Legends.Add(legend19);
            this.chartRiego.Location = new System.Drawing.Point(3, 3);
            this.chartRiego.Name = "chartRiego";
            series19.BorderWidth = 3;
            series19.ChartArea = "AreaPrincipal";
            series19.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series19.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(134)))), ((int)(((byte)(75)))));
            series19.IsVisibleInLegend = false;
            series19.Legend = "Humedad";
            series19.MarkerColor = System.Drawing.Color.Black;
            series19.MarkerSize = 8;
            series19.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series19.Name = "HUMEDAD DEL SUELO";
            series19.Points.Add(dataPoint55);
            series19.Points.Add(dataPoint56);
            series19.Points.Add(dataPoint57);
            series19.Points.Add(dataPoint58);
            series19.Points.Add(dataPoint59);
            series19.Points.Add(dataPoint60);
            this.chartRiego.Series.Add(series19);
            this.chartRiego.Size = new System.Drawing.Size(501, 339);
            this.chartRiego.TabIndex = 2;
            this.chartRiego.Text = "chart2";
            title19.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title19.Name = "Title1";
            title19.Text = "GRAFICA DE LA HUMEDAD DEL SUELO";
            this.chartRiego.Titles.Add(title19);
            this.chartRiego.Click += new System.EventHandler(this.chartRiego_Click);
            // 
            // btnRiegoAuto
            // 
            this.btnRiegoAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.btnRiegoAuto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRiegoAuto.Location = new System.Drawing.Point(891, 371);
            this.btnRiegoAuto.Name = "btnRiegoAuto";
            this.btnRiegoAuto.Size = new System.Drawing.Size(129, 55);
            this.btnRiegoAuto.TabIndex = 0;
            this.btnRiegoAuto.Text = "INICIAR RIEGO MANUAL";
            this.btnRiegoAuto.UseVisualStyleBackColor = false;
            this.btnRiegoAuto.Click += new System.EventHandler(this.btnRiegoAuto_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.calendarioAlertas);
            this.tabPage2.Controls.Add(this.label22);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.grilla2);
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
            this.tabPage2.Size = new System.Drawing.Size(1019, 605);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "HISTORIALES";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button10.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.SystemColors.Control;
            this.button10.Location = new System.Drawing.Point(809, 509);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(103, 44);
            this.button10.TabIndex = 12;
            this.button10.Text = "BUSCAR..";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click_2);
            // 
            // calendarioAlertas
            // 
            this.calendarioAlertas.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendarioAlertas.Location = new System.Drawing.Point(723, 461);
            this.calendarioAlertas.Name = "calendarioAlertas";
            this.calendarioAlertas.Size = new System.Drawing.Size(292, 28);
            this.calendarioAlertas.TabIndex = 11;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(767, 433);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(169, 25);
            this.label22.TabIndex = 10;
            this.label22.Text = "BUSCAR ALERTAS";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.button3.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Location = new System.Drawing.Point(801, 367);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 46);
            this.button3.TabIndex = 9;
            this.button3.Text = "RECARGAR";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(178, 340);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(468, 27);
            this.label14.TabIndex = 8;
            this.label14.Text = "HISTORIAL DE ALERTAS DEL PROGRAMA";
            // 
            // grilla2
            // 
            this.grilla2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla2.Location = new System.Drawing.Point(28, 381);
            this.grilla2.Name = "grilla2";
            this.grilla2.Size = new System.Drawing.Size(689, 185);
            this.grilla2.TabIndex = 7;
            this.grilla2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla2_CellContentClick);
            // 
            // lbFechaActual
            // 
            this.lbFechaActual.AutoSize = true;
            this.lbFechaActual.Font = new System.Drawing.Font("Microsoft JhengHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaActual.Location = new System.Drawing.Point(534, 139);
            this.lbFechaActual.Name = "lbFechaActual";
            this.lbFechaActual.Size = new System.Drawing.Size(169, 26);
            this.lbFechaActual.TabIndex = 6;
            this.lbFechaActual.Text = "FECHA ACTUAL";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(27, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(461, 27);
            this.label19.TabIndex = 5;
            this.label19.Text = "HISTORIAL DE RIEGOS EN LAS PLANTAS";
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.button8.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.Control;
            this.button8.Location = new System.Drawing.Point(865, 157);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(106, 39);
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
            this.BuscarHistorial.Location = new System.Drawing.Point(865, 113);
            this.BuscarHistorial.Name = "BuscarHistorial";
            this.BuscarHistorial.Size = new System.Drawing.Size(106, 38);
            this.BuscarHistorial.TabIndex = 3;
            this.BuscarHistorial.Text = "BUSCAR..";
            this.BuscarHistorial.UseVisualStyleBackColor = false;
            this.BuscarHistorial.Click += new System.EventHandler(this.BuscarHistorial_Click);
            // 
            // dtpFechaBusqueda
            // 
            this.dtpFechaBusqueda.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaBusqueda.Location = new System.Drawing.Point(690, 79);
            this.dtpFechaBusqueda.Name = "dtpFechaBusqueda";
            this.dtpFechaBusqueda.Size = new System.Drawing.Size(292, 28);
            this.dtpFechaBusqueda.TabIndex = 2;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(497, 81);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(187, 25);
            this.label15.TabIndex = 1;
            this.label15.Text = "BUSCAR HISTORIAL";
            // 
            // grilla
            // 
            this.grilla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grilla.Location = new System.Drawing.Point(29, 77);
            this.grilla.Name = "grilla";
            this.grilla.Size = new System.Drawing.Size(452, 185);
            this.grilla.TabIndex = 0;
            this.grilla.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grilla_CellContentClick_1);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PanelPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPrincipal.Controls.Add(this.panel1);
            this.PanelPrincipal.Controls.Add(this.panel12);
            this.PanelPrincipal.Controls.Add(this.lbFechaInicio);
            this.PanelPrincipal.Controls.Add(this.panel5);
            this.PanelPrincipal.Controls.Add(this.panel3);
            this.PanelPrincipal.Controls.Add(this.panel4);
            this.PanelPrincipal.Controls.Add(this.panel6);
            this.PanelPrincipal.Controls.Add(this.PanelHumedad);
            this.PanelPrincipal.Controls.Add(this.PanelPronostico);
            this.PanelPrincipal.Controls.Add(this.PanelViento);
            this.PanelPrincipal.Controls.Add(this.PanelTemperatura);
            this.PanelPrincipal.Location = new System.Drawing.Point(4, 24);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.PanelPrincipal.Size = new System.Drawing.Size(1019, 605);
            this.PanelPrincipal.TabIndex = 0;
            this.PanelPrincipal.Text = "INICIO";
            this.PanelPrincipal.Click += new System.EventHandler(this.PanelPrincipal_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.lblHumedad);
            this.panel1.Location = new System.Drawing.Point(758, 372);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(245, 135);
            this.panel1.TabIndex = 26;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label26.Location = new System.Drawing.Point(3, 74);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(234, 24);
            this.label26.TabIndex = 26;
            this.label26.Text = "HUMEDAD DEL SUELO";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PROYECTO_FINAL.Properties.Resources.agriculture_15785894__1_;
            this.pictureBox5.Location = new System.Drawing.Point(65, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(108, 98);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
            // 
            // lblHumedad
            // 
            this.lblHumedad.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumedad.ForeColor = System.Drawing.Color.MintCream;
            this.lblHumedad.Location = new System.Drawing.Point(60, 96);
            this.lblHumedad.Name = "lblHumedad";
            this.lblHumedad.Size = new System.Drawing.Size(126, 37);
            this.lblHumedad.TabIndex = 24;
            this.lblHumedad.Text = "Humedad";
            this.lblHumedad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblHumedad.Click += new System.EventHandler(this.lblHumedad_Click);
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(51)))), ((int)(((byte)(63)))));
            this.panel12.Controls.Add(this.chartClima);
            this.panel12.EdgeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.panel12.Location = new System.Drawing.Point(365, 213);
            this.panel12.Name = "panel12";
            this.panel12.Padding = new System.Windows.Forms.Padding(5);
            this.panel12.Size = new System.Drawing.Size(319, 392);
            this.panel12.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.panel12.TabIndex = 31;
            this.panel12.Text = "panel12";
            // 
            // chartClima
            // 
            this.chartClima.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartClima.BackColor = System.Drawing.SystemColors.ControlLight;
            chartArea20.Area3DStyle.Enable3D = true;
            chartArea20.Area3DStyle.Inclination = 25;
            chartArea20.Name = "MainArea";
            this.chartClima.ChartAreas.Add(chartArea20);
            legend20.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend20.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend20.IsTextAutoFit = false;
            legend20.Name = "Legend1";
            this.chartClima.Legends.Add(legend20);
            this.chartClima.Location = new System.Drawing.Point(0, -1);
            this.chartClima.Name = "chartClima";
            series20.ChartArea = "MainArea";
            series20.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series20.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            series20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series20.IsValueShownAsLabel = true;
            series20.Label = "#VALY";
            series20.Legend = "Legend1";
            series20.LegendText = "#VALX";
            series20.Name = "DatosClimáticos";
            series20.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartClima.Series.Add(series20);
            this.chartClima.Size = new System.Drawing.Size(328, 392);
            this.chartClima.TabIndex = 28;
            this.chartClima.Text = "chart1";
            title20.Name = "Title1";
            this.chartClima.Titles.Add(title20);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbFechaInicio.Location = new System.Drawing.Point(383, 173);
            this.lbFechaInicio.Name = "lbFechaInicio";
            this.lbFechaInicio.Size = new System.Drawing.Size(234, 37);
            this.lbFechaInicio.TabIndex = 30;
            this.lbFechaInicio.Text = "FECHA ACTUAL";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.lbEstadodeBomba);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Location = new System.Drawing.Point(304, 21);
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
            // lbEstadodeBomba
            // 
            this.lbEstadodeBomba.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadodeBomba.ForeColor = System.Drawing.Color.MintCream;
            this.lbEstadodeBomba.Location = new System.Drawing.Point(56, 82);
            this.lbEstadodeBomba.Name = "lbEstadodeBomba";
            this.lbEstadodeBomba.Size = new System.Drawing.Size(98, 24);
            this.lbEstadodeBomba.TabIndex = 30;
            this.lbEstadodeBomba.Text = "ESTADO";
            this.lbEstadodeBomba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ImagenTemperatura);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbTemperatura);
            this.panel3.Location = new System.Drawing.Point(14, 5);
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lbConec);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(27, 394);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 111);
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
            this.lbConec.Location = new System.Drawing.Point(106, 80);
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
            this.label8.Location = new System.Drawing.Point(3, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "ESTADO";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel6.Controls.Add(this.pictureBox3);
            this.panel6.Controls.Add(this.lbUltimoRegado);
            this.panel6.Controls.Add(this.label16);
            this.panel6.Location = new System.Drawing.Point(528, 19);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(203, 113);
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
            // PanelHumedad
            // 
            this.PanelHumedad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.PanelHumedad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelHumedad.Controls.Add(this.I);
            this.PanelHumedad.Controls.Add(this.label10);
            this.PanelHumedad.Controls.Add(this.lbHum);
            this.PanelHumedad.Location = new System.Drawing.Point(15, 172);
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
            this.PanelPronostico.Location = new System.Drawing.Point(745, 6);
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
            this.lbDes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDes.ForeColor = System.Drawing.Color.White;
            this.lbDes.Location = new System.Drawing.Point(-2, 110);
            this.lbDes.Name = "lbDes";
            this.lbDes.Size = new System.Drawing.Size(279, 40);
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
            this.PanelViento.Location = new System.Drawing.Point(745, 173);
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
            this.PanelTemperatura.Location = new System.Drawing.Point(14, 5);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.PanelPrincipal);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(236, 48);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1027, 633);
            this.tabControl.TabIndex = 14;
            // 
            // MENUPRINCIPAL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1269, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MENUPRINCIPAL";
            this.Text = "MENUPRINCIPAL";
            this.Load += new System.EventHandler(this.MENUPRINCIPAL_Load_1);
            this.Resize += new System.EventHandler(this.MENUPRINCIPAL_Resize);
            this.panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCultivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillaClima)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grilla2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grilla)).EndInit();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartClima)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.PanelHumedad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.I)).EndInit();
            this.PanelPronostico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).EndInit();
            this.PanelViento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).EndInit();
            this.PanelTemperatura.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
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
        private Button button4;
        private System.Windows.Forms.Timer MenuTrancision;
        private Panel panel13;
        private Button button7;
        private System.Windows.Forms.Timer timerTiempo;
        private Button button5;
        private Timer timerClima;
        private Timer timerGraficas;
        private TabPage tabPage1;
        private ReaLTaiizor.Controls.Button btnEliminarUsuario;
        private ReaLTaiizor.Controls.Button btnCerrarsession;
        private ReaLTaiizor.Controls.Button btnSubirFoto;
        private ReaLTaiizor.Controls.AloneComboBox cbRol;
        private ReaLTaiizor.Controls.AloneTextBox txtEmailUsu;
        private ReaLTaiizor.Controls.AloneTextBox txtNombreUsuario;
        private ReaLTaiizor.Controls.AloneTextBox txtIdUsuario;
        private ReaLTaiizor.Controls.Button btnGuardarCambios;
        private ReaLTaiizor.Controls.AloneTextBox txtNombreUsuariodelUsuario;
        private Button btnHacerCambios;
        private Label label24;
        private Label label25;
        private Label label23;
        private Label label21;
        private Label label20;
        private PictureBox pbImagenUsuario;
        private TabPage tabPage4;
        private Panel panel2;
        private Label MDescripcion;
        private Label Mnombre;
        private Label Mluz;
        private Label Mtemperatura;
        private Label Mhumedad;
        private Label MId;
        private Label label7;
        private Label label1;
        private Label label6;
        private ComboBox cbPlantas;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private PictureBox pbPlanta;
        private TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTemperatura;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRiego;
        private Button btnRiegoAuto;
        private TabPage tabPage2;
        private Label lbFechaActual;
        private Label label19;
        private Button button8;
        private Button BuscarHistorial;
        private DateTimePicker dtpFechaBusqueda;
        private Label label15;
        private DataGridView grilla;
        private TabPage PanelPrincipal;
        private Panel panel5;
        private PictureBox pictureBox1;
        private Label lbEstadodeBomba;
        private Label label18;
        private Panel panel3;
        private PictureBox ImagenTemperatura;
        private Label label13;
        private Label lbTemperatura;
        private Panel panel4;
        private PictureBox pictureBox2;
        private Label lbConec;
        private Label label8;
        private Panel panel6;
        private PictureBox pictureBox3;
        private Label lbUltimoRegado;
        private Label label16;
        private Panel PanelHumedad;
        private PictureBox I;
        private Label label10;
        private Label lbHum;
        private Panel PanelPronostico;
        private PictureBox ImagenPronostico;
        private Label label11;
        private Label lbDes;
        private Panel PanelViento;
        private PictureBox ImagenViento;
        private Label label12;
        private Label lbVie;
        private Panel PanelTemperatura;
        private Label label9;
        private Label lbTemp;
        private TabControl tabControl;
        private ReaLTaiizor.Controls.Button button1;
        private ReaLTaiizor.Controls.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCultivo;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartClima;
        private Label lbFechaInicio;
        private ReaLTaiizor.Controls.Panel panel12;
        private Label label14;
        private DataGridView grilla2;
        private Button button3;
        private Panel panel1;
        private PictureBox pictureBox5;
        private Label lblHumedad;
        private Label label26;
        private DataGridView grillaClima;
        private Button button9;
        private DateTimePicker calendarioRiego;
        private Label label17;
        private ReaLTaiizor.Controls.Button button11;
        private Button button10;
        private DateTimePicker calendarioAlertas;
        private Label label22;
    }
}