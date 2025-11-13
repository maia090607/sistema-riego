using System;
using System.Drawing;
using System.Windows.Forms;

namespace PROYECTO_RIEGO_AUTOMATICO
{
    partial class MenuCuidador
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 45D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 52D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 60D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(5D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(6D, 10D);
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.panel7 = new System.Windows.Forms.Panel();
            this.nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel11 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.MenuTrancision = new System.Windows.Forms.Timer(this.components);
            this.timerTiempo = new System.Windows.Forms.Timer(this.components);
            this.timerClima = new System.Windows.Forms.Timer(this.components);
            this.timerHumedad = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnEliminarUsuario = new ReaLTaiizor.Controls.Button();
            this.btnSubirFoto = new ReaLTaiizor.Controls.Button();
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
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chartCultivo = new System.Windows.Forms.DataVisualization.Charting.Chart();
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
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.chartRiego = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnRiegoAuto = new System.Windows.Forms.Button();
            this.PanelPrincipal = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.lbTemperatura = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label26 = new System.Windows.Forms.Label();
            this.lblHumedad = new System.Windows.Forms.Label();
            this.panel12 = new ReaLTaiizor.Controls.Panel();
            this.chartClima = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbFechaInicio = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbEstadodeBomba = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbConec = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbUltimoRegado = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.PanelHumedad = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.lbHum = new System.Windows.Forms.Label();
            this.PanelPronostico = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lbDes = new System.Windows.Forms.Label();
            this.PanelViento = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.lbVie = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnHam = new System.Windows.Forms.PictureBox();
            this.ImagenTemperatura = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.I = new System.Windows.Forms.PictureBox();
            this.ImagenPronostico = new System.Windows.Forms.PictureBox();
            this.ImagenViento = new System.Windows.Forms.PictureBox();
            this.pbPlanta = new System.Windows.Forms.PictureBox();
            this.pbImagenUsuario = new System.Windows.Forms.PictureBox();
            this.panel7.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCultivo)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).BeginInit();
            this.PanelPrincipal.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartClima)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.PanelHumedad.SuspendLayout();
            this.PanelPronostico.SuspendLayout();
            this.PanelViento.SuspendLayout();
            this.tabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.I)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).BeginInit();
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.flowLayoutPanel1.Controls.Add(this.panel10);
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
            // panel13
            // 
            this.panel13.Controls.Add(this.button7);
            this.panel13.Location = new System.Drawing.Point(3, 56);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(220, 47);
            this.panel13.TabIndex = 4;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.button6);
            this.panel11.Location = new System.Drawing.Point(3, 109);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(220, 47);
            this.panel11.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button4);
            this.panel8.Location = new System.Drawing.Point(3, 162);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(220, 47);
            this.panel8.TabIndex = 2;
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
            // timerHumedad
            // 
            this.timerHumedad.Interval = 1000;
            this.timerHumedad.Tick += new System.EventHandler(this.timerHumedad_Tick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbRol);
            this.tabPage1.Controls.Add(this.btnEliminarUsuario);
            this.tabPage1.Controls.Add(this.btnSubirFoto);
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
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Area3DStyle.Inclination = 25;
            chartArea1.Name = "MainArea";
            this.chartCultivo.ChartAreas.Add(chartArea1);
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.IsTextAutoFit = false;
            legend1.Name = "Legend1";
            this.chartCultivo.Legends.Add(legend1);
            this.chartCultivo.Location = new System.Drawing.Point(-3, 339);
            this.chartCultivo.Name = "chartCultivo";
            this.chartCultivo.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.EarthTones;
            series1.ChartArea = "MainArea";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            series1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VALY";
            series1.Legend = "Legend1";
            series1.LegendText = "#VALX";
            series1.Name = "DatosClimáticos";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartCultivo.Series.Add(series1);
            this.chartCultivo.Size = new System.Drawing.Size(573, 263);
            this.chartCultivo.TabIndex = 31;
            this.chartCultivo.Text = "chart1";
            title1.Name = "Title1";
            this.chartCultivo.Titles.Add(title1);
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
            this.button2.Location = new System.Drawing.Point(439, 136);
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
            this.MDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MDescripcion.Location = new System.Drawing.Point(587, 468);
            this.MDescripcion.Name = "MDescripcion";
            this.MDescripcion.Size = new System.Drawing.Size(98, 18);
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
            this.label3.Location = new System.Drawing.Point(724, 423);
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
            // tabPage3
            // 
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
            // chartRiego
            // 
            chartArea2.AxisX.Title = "Tiempo (m)";
            chartArea2.AxisY.Title = "Nivel de humedad (%)";
            chartArea2.BackColor = System.Drawing.Color.White;
            chartArea2.Name = "AreaPrincipal";
            this.chartRiego.ChartAreas.Add(chartArea2);
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Humedad";
            this.chartRiego.Legends.Add(legend2);
            this.chartRiego.Location = new System.Drawing.Point(3, 3);
            this.chartRiego.Name = "chartRiego";
            series2.BorderWidth = 3;
            series2.ChartArea = "AreaPrincipal";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(134)))), ((int)(((byte)(75)))));
            series2.IsVisibleInLegend = false;
            series2.Legend = "Humedad";
            series2.MarkerColor = System.Drawing.Color.Black;
            series2.MarkerSize = 8;
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "HUMEDAD DEL SUELO";
            series2.Points.Add(dataPoint1);
            series2.Points.Add(dataPoint2);
            series2.Points.Add(dataPoint3);
            series2.Points.Add(dataPoint4);
            series2.Points.Add(dataPoint5);
            series2.Points.Add(dataPoint6);
            this.chartRiego.Series.Add(series2);
            this.chartRiego.Size = new System.Drawing.Size(692, 506);
            this.chartRiego.TabIndex = 2;
            this.chartRiego.Text = "chart2";
            title2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title2.Name = "Title1";
            title2.Text = "GRAFICA DE LA HUMEDAD DEL SUELO";
            this.chartRiego.Titles.Add(title2);
            this.chartRiego.Click += new System.EventHandler(this.chartRiego_Click);
            // 
            // btnRiegoAuto
            // 
            this.btnRiegoAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(50)))));
            this.btnRiegoAuto.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.btnRiegoAuto.Location = new System.Drawing.Point(752, 265);
            this.btnRiegoAuto.Name = "btnRiegoAuto";
            this.btnRiegoAuto.Size = new System.Drawing.Size(247, 100);
            this.btnRiegoAuto.TabIndex = 0;
            this.btnRiegoAuto.Text = "INICIAR RIEGO MANUAL";
            this.btnRiegoAuto.UseVisualStyleBackColor = false;
            this.btnRiegoAuto.Click += new System.EventHandler(this.btnRiegoAuto_Click);
            // 
            // PanelPrincipal
            // 
            this.PanelPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.PanelPrincipal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.PanelPrincipal.Controls.Add(this.panel3);
            this.PanelPrincipal.Controls.Add(this.panel1);
            this.PanelPrincipal.Controls.Add(this.panel12);
            this.PanelPrincipal.Controls.Add(this.lbFechaInicio);
            this.PanelPrincipal.Controls.Add(this.panel5);
            this.PanelPrincipal.Controls.Add(this.panel4);
            this.PanelPrincipal.Controls.Add(this.panel6);
            this.PanelPrincipal.Controls.Add(this.PanelHumedad);
            this.PanelPrincipal.Controls.Add(this.PanelPronostico);
            this.PanelPrincipal.Controls.Add(this.PanelViento);
            this.PanelPrincipal.Location = new System.Drawing.Point(4, 24);
            this.PanelPrincipal.Name = "PanelPrincipal";
            this.PanelPrincipal.Padding = new System.Windows.Forms.Padding(3);
            this.PanelPrincipal.Size = new System.Drawing.Size(1019, 605);
            this.PanelPrincipal.TabIndex = 0;
            this.PanelPrincipal.Text = "INICIO";
            this.PanelPrincipal.Click += new System.EventHandler(this.PanelPrincipal_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.ImagenTemperatura);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.lbTemperatura);
            this.panel3.Location = new System.Drawing.Point(15, 13);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 152);
            this.panel3.TabIndex = 27;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.pictureBox5);
            this.panel1.Controls.Add(this.lblHumedad);
            this.panel1.Location = new System.Drawing.Point(748, 370);
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
            // lblHumedad
            // 
            this.lblHumedad.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHumedad.ForeColor = System.Drawing.Color.MintCream;
            this.lblHumedad.Location = new System.Drawing.Point(60, 93);
            this.lblHumedad.Name = "lblHumedad";
            this.lblHumedad.Size = new System.Drawing.Size(126, 46);
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
            chartArea3.Area3DStyle.Enable3D = true;
            chartArea3.Area3DStyle.Inclination = 25;
            chartArea3.Name = "MainArea";
            this.chartClima.ChartAreas.Add(chartArea3);
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend3.IsTextAutoFit = false;
            legend3.Name = "Legend1";
            this.chartClima.Legends.Add(legend3);
            this.chartClima.Location = new System.Drawing.Point(0, -1);
            this.chartClima.Name = "chartClima";
            series3.ChartArea = "MainArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            series3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series3.IsValueShownAsLabel = true;
            series3.Label = "#VALY";
            series3.Legend = "Legend1";
            series3.LegendText = "#VALX";
            series3.Name = "DatosClimáticos";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.chartClima.Series.Add(series3);
            this.chartClima.Size = new System.Drawing.Size(319, 392);
            this.chartClima.TabIndex = 28;
            this.chartClima.Text = "chart1";
            title3.Name = "Title1";
            this.chartClima.Titles.Add(title3);
            // 
            // lbFechaInicio
            // 
            this.lbFechaInicio.AutoSize = true;
            this.lbFechaInicio.Font = new System.Drawing.Font("Microsoft JhengHei", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFechaInicio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbFechaInicio.Location = new System.Drawing.Point(375, 173);
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
            // lbEstadodeBomba
            // 
            this.lbEstadodeBomba.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadodeBomba.ForeColor = System.Drawing.Color.MintCream;
            this.lbEstadodeBomba.Location = new System.Drawing.Point(22, 82);
            this.lbEstadodeBomba.Name = "lbEstadodeBomba";
            this.lbEstadodeBomba.Size = new System.Drawing.Size(168, 24);
            this.lbEstadodeBomba.TabIndex = 30;
            this.lbEstadodeBomba.Text = "ESTADO";
            this.lbEstadodeBomba.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbEstadodeBomba.Click += new System.EventHandler(this.lbEstadodeBomba_Click);
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
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.pictureBox2);
            this.panel4.Controls.Add(this.lbConec);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(27, 372);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(245, 133);
            this.panel4.TabIndex = 0;
            // 
            // lbConec
            // 
            this.lbConec.Font = new System.Drawing.Font("Segoe UI Black", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbConec.ForeColor = System.Drawing.Color.MintCream;
            this.lbConec.Location = new System.Drawing.Point(38, 102);
            this.lbConec.Name = "lbConec";
            this.lbConec.Size = new System.Drawing.Size(154, 24);
            this.lbConec.TabIndex = 24;
            this.lbConec.Text = "ESTADO";
            this.lbConec.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbConec.Click += new System.EventHandler(this.label14_Click_1);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label8.Location = new System.Drawing.Point(-4, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(249, 24);
            this.label8.TabIndex = 23;
            this.label8.Text = "ESTADO DEL PROGRAMA";
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
            this.PanelHumedad.Size = new System.Drawing.Size(266, 136);
            this.PanelHumedad.TabIndex = 24;
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.PanelPrincipal);
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
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cbRol
            // 
            this.cbRol.Enabled = false;
            this.cbRol.Items.AddRange(new object[] {
            "Cuidador",
            "Dueño"});
            this.cbRol.Location = new System.Drawing.Point(534, 360);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(143, 25);
            this.cbRol.TabIndex = 28;
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
            // btnHam
            // 
            this.btnHam.Image = global::PROYECTO_FINAL.Properties.Resources.menu;
            this.btnHam.InitialImage = null;
            this.btnHam.Location = new System.Drawing.Point(11, 7);
            this.btnHam.Name = "btnHam";
            this.btnHam.Size = new System.Drawing.Size(33, 29);
            this.btnHam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHam.TabIndex = 0;
            this.btnHam.TabStop = false;
            this.btnHam.Click += new System.EventHandler(this.btnHam_Click);
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
            // pictureBox5
            // 
            this.pictureBox5.Image = global::PROYECTO_FINAL.Properties.Resources.agriculture_15785894__1_;
            this.pictureBox5.Location = new System.Drawing.Point(65, 0);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(108, 93);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 25;
            this.pictureBox5.TabStop = false;
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
            // pbImagenUsuario
            // 
            this.pbImagenUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbImagenUsuario.Image = global::PROYECTO_FINAL.Properties.Resources.admin_14471192;
            this.pbImagenUsuario.Location = new System.Drawing.Point(23, 14);
            this.pbImagenUsuario.Name = "pbImagenUsuario";
            this.pbImagenUsuario.Size = new System.Drawing.Size(315, 307);
            this.pbImagenUsuario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagenUsuario.TabIndex = 0;
            this.pbImagenUsuario.TabStop = false;
            // 
            // MenuCuidador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1269, 681);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MenuCuidador";
            this.Text = "MENUPRINCIPAL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MENUPRINCIPAL_FormClosing);
            this.Load += new System.EventHandler(this.MENUPRINCIPAL_Load_1);
            this.Resize += new System.EventHandler(this.MENUPRINCIPAL_Resize);
            this.panel7.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCultivo)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRiego)).EndInit();
            this.PanelPrincipal.ResumeLayout(false);
            this.PanelPrincipal.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartClima)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.PanelHumedad.ResumeLayout(false);
            this.PanelPronostico.ResumeLayout(false);
            this.PanelViento.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenTemperatura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.I)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPronostico)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenViento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlanta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagenUsuario)).EndInit();
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
        private Panel panel8;
        private Button button4;
        private System.Windows.Forms.Timer MenuTrancision;
        private Panel panel13;
        private Button button7;
        private System.Windows.Forms.Timer timerTiempo;
        private Button button5;
        private Timer timerClima;
        private Timer timerHumedad;
        private TabPage tabPage1;
        private ReaLTaiizor.Controls.Button btnEliminarUsuario;
        private ReaLTaiizor.Controls.Button btnSubirFoto;
        private ReaLTaiizor.Controls.AloneTextBox txtEmailUsu;
        private ReaLTaiizor.Controls.AloneTextBox txtNombreUsuario;
        private ReaLTaiizor.Controls.Button btnCerrarsession;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCultivo;
        private ReaLTaiizor.Controls.Button button2;
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
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRiego;
        private Button btnRiegoAuto;
        private TabPage PanelPrincipal;
        private Panel panel3;
        private PictureBox ImagenTemperatura;
        private Label label13;
        private Label lbTemperatura;
        private Panel panel1;
        private Label label26;
        private PictureBox pictureBox5;
        private Label lblHumedad;
        private ReaLTaiizor.Controls.Panel panel12;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartClima;
        private Label lbFechaInicio;
        private Panel panel5;
        private PictureBox pictureBox1;
        private Label lbEstadodeBomba;
        private Label label18;
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
        private TabControl tabControl;
        private ErrorProvider errorProvider1;
        private ComboBox cbRol;
    }
}