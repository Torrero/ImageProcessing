namespace AppCloudCover
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pictureBox_preview = new System.Windows.Forms.PictureBox();
            this.button_open_img = new System.Windows.Forms.Button();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_size_box = new System.Windows.Forms.TextBox();
            this.button_processing = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDrawFillRectangles = new System.Windows.Forms.Button();
            this.btnDrawBoxes = new System.Windows.Forms.Button();
            this.btnClearImg = new System.Windows.Forms.Button();
            this.btnTriangle = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_count_pixels_in_box = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_level_of_clouds = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textBox_SizeImage = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtBox_AverageCi = new System.Windows.Forms.TextBox();
            this.txtBox_TotalKoeff = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBoxCi3 = new System.Windows.Forms.TextBox();
            this.txtBoxCi2 = new System.Windows.Forms.TextBox();
            this.txtBoxCi1 = new System.Windows.Forms.TextBox();
            this.label_ci3 = new System.Windows.Forms.Label();
            this.label_ci2 = new System.Windows.Forms.Label();
            this.label_ci1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_MaxCi = new System.Windows.Forms.TextBox();
            this.txtBox_koef3 = new System.Windows.Forms.TextBox();
            this.txtBox_koef2 = new System.Windows.Forms.TextBox();
            this.txtBox_koef1 = new System.Windows.Forms.TextBox();
            this.trackBar_alpha = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtBox_countCloudPixels = new System.Windows.Forms.TextBox();
            this.checkBox_ShowProcess = new System.Windows.Forms.CheckBox();
            this.btnCalcCi = new System.Windows.Forms.Button();
            this.btn_show_triangles = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_calc_distribution = new System.Windows.Forms.Button();
            this.chart_distribution = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_distribution)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_preview
            // 
            this.pictureBox_preview.Location = new System.Drawing.Point(12, 475);
            this.pictureBox_preview.Name = "pictureBox_preview";
            this.pictureBox_preview.Size = new System.Drawing.Size(239, 162);
            this.pictureBox_preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_preview.TabIndex = 0;
            this.pictureBox_preview.TabStop = false;
            // 
            // button_open_img
            // 
            this.button_open_img.Dock = System.Windows.Forms.DockStyle.Left;
            this.button_open_img.Location = new System.Drawing.Point(0, 0);
            this.button_open_img.Name = "button_open_img";
            this.button_open_img.Size = new System.Drawing.Size(239, 30);
            this.button_open_img.TabIndex = 1;
            this.button_open_img.Text = "Открыть изображение";
            this.button_open_img.UseVisualStyleBackColor = true;
            this.button_open_img.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_fileName.Location = new System.Drawing.Point(0, 30);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.ReadOnly = true;
            this.textBox_fileName.Size = new System.Drawing.Size(675, 20);
            this.textBox_fileName.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(675, 547);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_size_box
            // 
            this.textBox_size_box.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_size_box.Location = new System.Drawing.Point(191, 6);
            this.textBox_size_box.Name = "textBox_size_box";
            this.textBox_size_box.Size = new System.Drawing.Size(60, 20);
            this.textBox_size_box.TabIndex = 4;
            this.textBox_size_box.TextChanged += new System.EventHandler(this.textBox_size_box_TextChanged);
            // 
            // button_processing
            // 
            this.button_processing.Location = new System.Drawing.Point(12, 108);
            this.button_processing.Name = "button_processing";
            this.button_processing.Size = new System.Drawing.Size(236, 23);
            this.button_processing.TabIndex = 5;
            this.button_processing.Text = "Обработка - метод квадрантов";
            this.button_processing.UseVisualStyleBackColor = true;
            this.button_processing.Click += new System.EventHandler(this.button_processing_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Размер примитива( X:Y) (пикс):";
            // 
            // btnDrawFillRectangles
            // 
            this.btnDrawFillRectangles.Location = new System.Drawing.Point(15, 149);
            this.btnDrawFillRectangles.Name = "btnDrawFillRectangles";
            this.btnDrawFillRectangles.Size = new System.Drawing.Size(106, 38);
            this.btnDrawFillRectangles.TabIndex = 7;
            this.btnDrawFillRectangles.Text = "Заскрасить объекты";
            this.btnDrawFillRectangles.UseVisualStyleBackColor = true;
            this.btnDrawFillRectangles.Click += new System.EventHandler(this.btnDrawFillRectangles_Click);
            // 
            // btnDrawBoxes
            // 
            this.btnDrawBoxes.Location = new System.Drawing.Point(136, 149);
            this.btnDrawBoxes.Name = "btnDrawBoxes";
            this.btnDrawBoxes.Size = new System.Drawing.Size(115, 38);
            this.btnDrawBoxes.TabIndex = 8;
            this.btnDrawBoxes.Text = "Рамки объектов и центры";
            this.btnDrawBoxes.UseVisualStyleBackColor = true;
            this.btnDrawBoxes.Click += new System.EventHandler(this.btnDrawBoxes_Click);
            // 
            // btnClearImg
            // 
            this.btnClearImg.Location = new System.Drawing.Point(12, 86);
            this.btnClearImg.Name = "btnClearImg";
            this.btnClearImg.Size = new System.Drawing.Size(236, 23);
            this.btnClearImg.TabIndex = 9;
            this.btnClearImg.Text = "Показать чистую картинку";
            this.btnClearImg.UseVisualStyleBackColor = true;
            this.btnClearImg.Click += new System.EventHandler(this.btnClearImg_Click);
            // 
            // btnTriangle
            // 
            this.btnTriangle.Location = new System.Drawing.Point(15, 193);
            this.btnTriangle.Name = "btnTriangle";
            this.btnTriangle.Size = new System.Drawing.Size(236, 23);
            this.btnTriangle.TabIndex = 10;
            this.btnTriangle.Text = "Обработка - триангуляция Делоне";
            this.btnTriangle.UseVisualStyleBackColor = true;
            this.btnTriangle.Click += new System.EventHandler(this.btnTriangle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Кол-во пикселей в примитиве:";
            // 
            // textBox_count_pixels_in_box
            // 
            this.textBox_count_pixels_in_box.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_count_pixels_in_box.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_count_pixels_in_box.Location = new System.Drawing.Point(191, 26);
            this.textBox_count_pixels_in_box.Name = "textBox_count_pixels_in_box";
            this.textBox_count_pixels_in_box.ReadOnly = true;
            this.textBox_count_pixels_in_box.Size = new System.Drawing.Size(60, 20);
            this.textBox_count_pixels_in_box.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Порог кол-ва облачных пикселей:";
            // 
            // textBox_level_of_clouds
            // 
            this.textBox_level_of_clouds.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_level_of_clouds.Location = new System.Drawing.Point(191, 46);
            this.textBox_level_of_clouds.Name = "textBox_level_of_clouds";
            this.textBox_level_of_clouds.Size = new System.Drawing.Size(60, 20);
            this.textBox_level_of_clouds.TabIndex = 13;
            this.textBox_level_of_clouds.TextChanged += new System.EventHandler(this.textBox_size_box_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_open_img);
            this.panel3.Controls.Add(this.textBox_fileName);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(675, 50);
            this.panel3.TabIndex = 17;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textBox_SizeImage);
            this.splitContainer1.Panel1.Controls.Add(this.label12);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_AverageCi);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_TotalKoeff);
            this.splitContainer1.Panel1.Controls.Add(this.label10);
            this.splitContainer1.Panel1.Controls.Add(this.label9);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxCi3);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxCi2);
            this.splitContainer1.Panel1.Controls.Add(this.txtBoxCi1);
            this.splitContainer1.Panel1.Controls.Add(this.label_ci3);
            this.splitContainer1.Panel1.Controls.Add(this.label_ci2);
            this.splitContainer1.Panel1.Controls.Add(this.label_ci1);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_MaxCi);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_koef3);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_koef2);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_koef1);
            this.splitContainer1.Panel1.Controls.Add(this.trackBar_alpha);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txtBox_countCloudPixels);
            this.splitContainer1.Panel1.Controls.Add(this.checkBox_ShowProcess);
            this.splitContainer1.Panel1.Controls.Add(this.btnCalcCi);
            this.splitContainer1.Panel1.Controls.Add(this.btn_show_triangles);
            this.splitContainer1.Panel1.Controls.Add(this.btnClearImg);
            this.splitContainer1.Panel1.Controls.Add(this.btnTriangle);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnDrawBoxes);
            this.splitContainer1.Panel1.Controls.Add(this.btnDrawFillRectangles);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_count_pixels_in_box);
            this.splitContainer1.Panel1.Controls.Add(this.button_processing);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_level_of_clouds);
            this.splitContainer1.Panel1.Controls.Add(this.textBox_size_box);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox_preview);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(951, 630);
            this.splitContainer1.SplitterDistance = 272;
            this.splitContainer1.TabIndex = 18;
            // 
            // textBox_SizeImage
            // 
            this.textBox_SizeImage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_SizeImage.Location = new System.Drawing.Point(136, 67);
            this.textBox_SizeImage.Name = "textBox_SizeImage";
            this.textBox_SizeImage.Size = new System.Drawing.Size(115, 20);
            this.textBox_SizeImage.TabIndex = 41;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 13);
            this.label12.TabIndex = 42;
            this.label12.Text = "Размер изображения";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(221, 320);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Ci сред.";
            // 
            // txtBox_AverageCi
            // 
            this.txtBox_AverageCi.Location = new System.Drawing.Point(213, 336);
            this.txtBox_AverageCi.Name = "txtBox_AverageCi";
            this.txtBox_AverageCi.ReadOnly = true;
            this.txtBox_AverageCi.Size = new System.Drawing.Size(50, 20);
            this.txtBox_AverageCi.TabIndex = 39;
            this.txtBox_AverageCi.Tag = "3";
            // 
            // txtBox_TotalKoeff
            // 
            this.txtBox_TotalKoeff.Location = new System.Drawing.Point(184, 422);
            this.txtBox_TotalKoeff.Name = "txtBox_TotalKoeff";
            this.txtBox_TotalKoeff.ReadOnly = true;
            this.txtBox_TotalKoeff.Size = new System.Drawing.Size(79, 20);
            this.txtBox_TotalKoeff.TabIndex = 37;
            this.txtBox_TotalKoeff.Tag = "3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 424);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Коэфф. общ плот. (Sci2+Sc3)/Sо";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Прозрачность:";
            // 
            // txtBoxCi3
            // 
            this.txtBoxCi3.Location = new System.Drawing.Point(78, 401);
            this.txtBoxCi3.Name = "txtBoxCi3";
            this.txtBoxCi3.ReadOnly = true;
            this.txtBoxCi3.Size = new System.Drawing.Size(166, 20);
            this.txtBoxCi3.TabIndex = 34;
            this.txtBoxCi3.Tag = "3";
            // 
            // txtBoxCi2
            // 
            this.txtBoxCi2.Location = new System.Drawing.Point(78, 380);
            this.txtBoxCi2.Name = "txtBoxCi2";
            this.txtBoxCi2.ReadOnly = true;
            this.txtBoxCi2.Size = new System.Drawing.Size(166, 20);
            this.txtBoxCi2.TabIndex = 32;
            this.txtBoxCi2.Tag = "3";
            // 
            // txtBoxCi1
            // 
            this.txtBoxCi1.Location = new System.Drawing.Point(78, 359);
            this.txtBoxCi1.Name = "txtBoxCi1";
            this.txtBoxCi1.ReadOnly = true;
            this.txtBoxCi1.Size = new System.Drawing.Size(166, 20);
            this.txtBoxCi1.TabIndex = 29;
            this.txtBoxCi1.Tag = "3";
            // 
            // label_ci3
            // 
            this.label_ci3.AutoSize = true;
            this.label_ci3.Location = new System.Drawing.Point(13, 404);
            this.label_ci3.Name = "label_ci3";
            this.label_ci3.Size = new System.Drawing.Size(31, 13);
            this.label_ci3.TabIndex = 35;
            this.label_ci3.Text = "0-0.8";
            // 
            // label_ci2
            // 
            this.label_ci2.AutoSize = true;
            this.label_ci2.Location = new System.Drawing.Point(13, 384);
            this.label_ci2.Name = "label_ci2";
            this.label_ci2.Size = new System.Drawing.Size(31, 13);
            this.label_ci2.TabIndex = 33;
            this.label_ci2.Text = "0-0.8";
            // 
            // label_ci1
            // 
            this.label_ci1.AutoSize = true;
            this.label_ci1.Location = new System.Drawing.Point(13, 363);
            this.label_ci1.Name = "label_ci1";
            this.label_ci1.Size = new System.Drawing.Size(31, 13);
            this.label_ci1.TabIndex = 31;
            this.label_ci1.Text = "0-0.8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(169, 320);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Max Ci";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(124, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Ci3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Ci2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 320);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Ci1";
            // 
            // txtBox_MaxCi
            // 
            this.txtBox_MaxCi.Location = new System.Drawing.Point(161, 336);
            this.txtBox_MaxCi.Name = "txtBox_MaxCi";
            this.txtBox_MaxCi.ReadOnly = true;
            this.txtBox_MaxCi.Size = new System.Drawing.Size(50, 20);
            this.txtBox_MaxCi.TabIndex = 21;
            this.txtBox_MaxCi.Tag = "3";
            // 
            // txtBox_koef3
            // 
            this.txtBox_koef3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.txtBox_koef3.Location = new System.Drawing.Point(109, 336);
            this.txtBox_koef3.Name = "txtBox_koef3";
            this.txtBox_koef3.Size = new System.Drawing.Size(50, 20);
            this.txtBox_koef3.TabIndex = 20;
            this.txtBox_koef3.Tag = "3";
            this.txtBox_koef3.Text = "1";
            this.txtBox_koef3.DoubleClick += new System.EventHandler(this.txtBox_koef2_DoubleClick);
            // 
            // txtBox_koef2
            // 
            this.txtBox_koef2.BackColor = System.Drawing.Color.Lime;
            this.txtBox_koef2.Location = new System.Drawing.Point(57, 336);
            this.txtBox_koef2.Name = "txtBox_koef2";
            this.txtBox_koef2.Size = new System.Drawing.Size(50, 20);
            this.txtBox_koef2.TabIndex = 19;
            this.txtBox_koef2.Tag = "2";
            this.txtBox_koef2.Text = "0,8";
            this.txtBox_koef2.DoubleClick += new System.EventHandler(this.txtBox_koef2_DoubleClick);
            // 
            // txtBox_koef1
            // 
            this.txtBox_koef1.Location = new System.Drawing.Point(5, 336);
            this.txtBox_koef1.Name = "txtBox_koef1";
            this.txtBox_koef1.Size = new System.Drawing.Size(50, 20);
            this.txtBox_koef1.TabIndex = 18;
            this.txtBox_koef1.Tag = "1";
            this.txtBox_koef1.DoubleClick += new System.EventHandler(this.txtBox_koef2_DoubleClick);
            // 
            // trackBar_alpha
            // 
            this.trackBar_alpha.Location = new System.Drawing.Point(18, 285);
            this.trackBar_alpha.Maximum = 255;
            this.trackBar_alpha.Name = "trackBar_alpha";
            this.trackBar_alpha.Size = new System.Drawing.Size(232, 45);
            this.trackBar_alpha.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 133);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Кол-во облачных пикселей";
            // 
            // txtBox_countCloudPixels
            // 
            this.txtBox_countCloudPixels.Location = new System.Drawing.Point(156, 130);
            this.txtBox_countCloudPixels.Name = "txtBox_countCloudPixels";
            this.txtBox_countCloudPixels.ReadOnly = true;
            this.txtBox_countCloudPixels.Size = new System.Drawing.Size(70, 20);
            this.txtBox_countCloudPixels.TabIndex = 26;
            this.txtBox_countCloudPixels.Tag = "3";
            // 
            // checkBox_ShowProcess
            // 
            this.checkBox_ShowProcess.AutoSize = true;
            this.checkBox_ShowProcess.Checked = true;
            this.checkBox_ShowProcess.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_ShowProcess.Location = new System.Drawing.Point(15, 222);
            this.checkBox_ShowProcess.Name = "checkBox_ShowProcess";
            this.checkBox_ShowProcess.Size = new System.Drawing.Size(134, 17);
            this.checkBox_ShowProcess.TabIndex = 17;
            this.checkBox_ShowProcess.Text = "Показывать процесс";
            this.checkBox_ShowProcess.UseVisualStyleBackColor = true;
            // 
            // btnCalcCi
            // 
            this.btnCalcCi.Location = new System.Drawing.Point(12, 442);
            this.btnCalcCi.Name = "btnCalcCi";
            this.btnCalcCi.Size = new System.Drawing.Size(236, 35);
            this.btnCalcCi.TabIndex = 16;
            this.btnCalcCi.Text = "Рассчитать Ci (коэф. геометрической концентрации) и раскрасить области";
            this.btnCalcCi.UseVisualStyleBackColor = true;
            this.btnCalcCi.Click += new System.EventHandler(this.btnCalcCi_Click);
            // 
            // btn_show_triangles
            // 
            this.btn_show_triangles.Location = new System.Drawing.Point(15, 245);
            this.btn_show_triangles.Name = "btn_show_triangles";
            this.btn_show_triangles.Size = new System.Drawing.Size(236, 23);
            this.btn_show_triangles.TabIndex = 15;
            this.btn_show_triangles.Text = "Показать треугольники";
            this.btn_show_triangles.UseVisualStyleBackColor = true;
            this.btn_show_triangles.Click += new System.EventHandler(this.btn_show_triangles_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer2.Size = new System.Drawing.Size(675, 630);
            this.splitContainer2.SplitterDistance = 79;
            this.splitContainer2.TabIndex = 18;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(965, 662);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(957, 636);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Обработка изображения";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_calc_distribution);
            this.tabPage2.Controls.Add(this.chart_distribution);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1020, 610);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Статистика";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_calc_distribution
            // 
            this.button_calc_distribution.Location = new System.Drawing.Point(34, 11);
            this.button_calc_distribution.Name = "button_calc_distribution";
            this.button_calc_distribution.Size = new System.Drawing.Size(189, 63);
            this.button_calc_distribution.TabIndex = 1;
            this.button_calc_distribution.Text = "Рассчитать распределение ";
            this.button_calc_distribution.UseVisualStyleBackColor = true;
            this.button_calc_distribution.Click += new System.EventHandler(this.button_calc_distribution_Click);
            // 
            // chart_distribution
            // 
            chartArea4.AxisX.MaximumAutoSize = 1F;
            chartArea4.Name = "ChartArea1";
            this.chart_distribution.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chart_distribution.Legends.Add(legend4);
            this.chart_distribution.Location = new System.Drawing.Point(6, 80);
            this.chart_distribution.Name = "chart_distribution";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series_Line_distribution";
            this.chart_distribution.Series.Add(series4);
            this.chart_distribution.Size = new System.Drawing.Size(987, 473);
            this.chart_distribution.TabIndex = 0;
            this.chart_distribution.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 662);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Обработка изображений";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_alpha)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart_distribution)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_preview;
        private System.Windows.Forms.Button button_open_img;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox_size_box;
        private System.Windows.Forms.Button button_processing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDrawFillRectangles;
        private System.Windows.Forms.Button btnDrawBoxes;
        private System.Windows.Forms.Button btnClearImg;
        private System.Windows.Forms.Button btnTriangle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_count_pixels_in_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_level_of_clouds;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_show_triangles;
        private System.Windows.Forms.Button btnCalcCi;
        private System.Windows.Forms.CheckBox checkBox_ShowProcess;
        private System.Windows.Forms.TextBox txtBox_koef2;
        private System.Windows.Forms.TextBox txtBox_koef1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.TextBox txtBox_MaxCi;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBox_koef3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBox_countCloudPixels;
        private System.Windows.Forms.TrackBar trackBar_alpha;
        private System.Windows.Forms.Label label_ci1;
        private System.Windows.Forms.TextBox txtBoxCi1;
        private System.Windows.Forms.Label label_ci3;
        private System.Windows.Forms.TextBox txtBoxCi3;
        private System.Windows.Forms.Label label_ci2;
        private System.Windows.Forms.TextBox txtBoxCi2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBox_TotalKoeff;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtBox_AverageCi;
		private System.Windows.Forms.TextBox textBox_SizeImage;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataVisualization.Charting.Chart chart_distribution;
		private System.Windows.Forms.Button button_calc_distribution;
    }
}

