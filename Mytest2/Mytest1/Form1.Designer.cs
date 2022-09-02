namespace Mytest1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_Total_Temp = new System.Windows.Forms.TextBox();
            this.textBox_Total_L_D = new System.Windows.Forms.TextBox();
            this.textBox_Total_Light = new System.Windows.Forms.TextBox();
            this.textBox_Total_Dark = new System.Windows.Forms.TextBox();
            this.textBox_Total_Co = new System.Windows.Forms.TextBox();
            this.textBox_Average_Temp = new System.Windows.Forms.TextBox();
            this.textBox_Average_L_D = new System.Windows.Forms.TextBox();
            this.textBox_Average_Light = new System.Windows.Forms.TextBox();
            this.textBox_Average_Dark = new System.Windows.Forms.TextBox();
            this.textBox_Average_Co = new System.Windows.Forms.TextBox();
            this.textBox_Max_Temp = new System.Windows.Forms.TextBox();
            this.textBox_Max_L_D = new System.Windows.Forms.TextBox();
            this.textBox_Max_Light = new System.Windows.Forms.TextBox();
            this.textBox_Max_Dark = new System.Windows.Forms.TextBox();
            this.textBox_Max_Co = new System.Windows.Forms.TextBox();
            this.textBox_Min_Temp = new System.Windows.Forms.TextBox();
            this.textBox_Min_L_D = new System.Windows.Forms.TextBox();
            this.textBox_Min_Light = new System.Windows.Forms.TextBox();
            this.textBox_Min_Dark = new System.Windows.Forms.TextBox();
            this.textBox_Min_Co = new System.Windows.Forms.TextBox();
            this.textBox_Last_Temp = new System.Windows.Forms.TextBox();
            this.textBox_Last_L_D = new System.Windows.Forms.TextBox();
            this.textBox_Last_Light = new System.Windows.Forms.TextBox();
            this.textBox_Last_Dark = new System.Windows.Forms.TextBox();
            this.textBox_Last_Co = new System.Windows.Forms.TextBox();
            this.label_Count = new System.Windows.Forms.Label();
            this.label_Average = new System.Windows.Forms.Label();
            this.label_Max = new System.Windows.Forms.Label();
            this.label_Min = new System.Windows.Forms.Label();
            this.label_Temp_C = new System.Windows.Forms.Label();
            this.label_L_D_Vol = new System.Windows.Forms.Label();
            this.label_Light_Vol = new System.Windows.Forms.Label();
            this.label_Dark_Vol = new System.Windows.Forms.Label();
            this.label_Co_Vol = new System.Windows.Forms.Label();
            this.label_Current = new System.Windows.Forms.Label();
            this.textBox_Event = new System.Windows.Forms.TextBox();
            this.textBox_CO_BAT = new System.Windows.Forms.TextBox();
            this.textBox_MCU_BAT = new System.Windows.Forms.TextBox();
            this.textBox_CO_PPM = new System.Windows.Forms.TextBox();
            this.label_Event = new System.Windows.Forms.Label();
            this.label_Co_Bat = new System.Windows.Forms.Label();
            this.label_Mcu_Bat = new System.Windows.Forms.Label();
            this.label_Co_Ppm = new System.Windows.Forms.Label();
            this.Dark_Series_Button = new System.Windows.Forms.RadioButton();
            this.GroupBox1_Dark = new System.Windows.Forms.GroupBox();
            this.GroupBox1_Light = new System.Windows.Forms.GroupBox();
            this.Light_Series_Button = new System.Windows.Forms.RadioButton();
            this.GroupBox1_L_D = new System.Windows.Forms.GroupBox();
            this.L_D_Series_Button = new System.Windows.Forms.RadioButton();
            this.GroupBox1_Co = new System.Windows.Forms.GroupBox();
            this.Co_Series_Button = new System.Windows.Forms.RadioButton();
            this.pictureBox1_On_Off = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GroupBox1_Dark.SuspendLayout();
            this.GroupBox1_Light.SuspendLayout();
            this.GroupBox1_L_D.SuspendLayout();
            this.GroupBox1_Co.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_On_Off)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "端口号：";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(64, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(67, 20);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(149, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "波特率：";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(213, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(122, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(39, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "打开串口";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.MySerialPort_DataReceived);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button2.Location = new System.Drawing.Point(210, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(61, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "保存";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button3.Location = new System.Drawing.Point(148, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "清除";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.richTextBox1.Location = new System.Drawing.Point(1, 265);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.richTextBox1.Size = new System.Drawing.Size(334, 344);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.textBox_Event);
            this.panel1.Controls.Add(this.textBox_CO_BAT);
            this.panel1.Controls.Add(this.textBox_MCU_BAT);
            this.panel1.Controls.Add(this.textBox_CO_PPM);
            this.panel1.Controls.Add(this.label_Event);
            this.panel1.Controls.Add(this.label_Co_Bat);
            this.panel1.Controls.Add(this.label_Mcu_Bat);
            this.panel1.Controls.Add(this.label_Co_Ppm);
            this.panel1.Cursor = System.Windows.Forms.Cursors.No;
            this.panel1.Location = new System.Drawing.Point(1, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 200);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox_Total_Temp);
            this.panel2.Controls.Add(this.textBox_Total_L_D);
            this.panel2.Controls.Add(this.textBox_Total_Light);
            this.panel2.Controls.Add(this.textBox_Total_Dark);
            this.panel2.Controls.Add(this.textBox_Total_Co);
            this.panel2.Controls.Add(this.textBox_Average_Temp);
            this.panel2.Controls.Add(this.textBox_Average_L_D);
            this.panel2.Controls.Add(this.textBox_Average_Light);
            this.panel2.Controls.Add(this.textBox_Average_Dark);
            this.panel2.Controls.Add(this.textBox_Average_Co);
            this.panel2.Controls.Add(this.textBox_Max_Temp);
            this.panel2.Controls.Add(this.textBox_Max_L_D);
            this.panel2.Controls.Add(this.textBox_Max_Light);
            this.panel2.Controls.Add(this.textBox_Max_Dark);
            this.panel2.Controls.Add(this.textBox_Max_Co);
            this.panel2.Controls.Add(this.textBox_Min_Temp);
            this.panel2.Controls.Add(this.textBox_Min_L_D);
            this.panel2.Controls.Add(this.textBox_Min_Light);
            this.panel2.Controls.Add(this.textBox_Min_Dark);
            this.panel2.Controls.Add(this.textBox_Min_Co);
            this.panel2.Controls.Add(this.textBox_Last_Temp);
            this.panel2.Controls.Add(this.textBox_Last_L_D);
            this.panel2.Controls.Add(this.textBox_Last_Light);
            this.panel2.Controls.Add(this.textBox_Last_Dark);
            this.panel2.Controls.Add(this.textBox_Last_Co);
            this.panel2.Controls.Add(this.label_Count);
            this.panel2.Controls.Add(this.label_Average);
            this.panel2.Controls.Add(this.label_Max);
            this.panel2.Controls.Add(this.label_Min);
            this.panel2.Controls.Add(this.label_Temp_C);
            this.panel2.Controls.Add(this.label_L_D_Vol);
            this.panel2.Controls.Add(this.label_Light_Vol);
            this.panel2.Controls.Add(this.label_Dark_Vol);
            this.panel2.Controls.Add(this.label_Co_Vol);
            this.panel2.Controls.Add(this.label_Current);
            this.panel2.Location = new System.Drawing.Point(0, 48);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(333, 155);
            this.panel2.TabIndex = 8;
            // 
            // textBox_Total_Temp
            // 
            this.textBox_Total_Temp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Total_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Total_Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Total_Temp.Location = new System.Drawing.Point(275, 124);
            this.textBox_Total_Temp.Multiline = true;
            this.textBox_Total_Temp.Name = "textBox_Total_Temp";
            this.textBox_Total_Temp.Size = new System.Drawing.Size(38, 19);
            this.textBox_Total_Temp.TabIndex = 21;
            this.textBox_Total_Temp.Text = "null";
            this.textBox_Total_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Total_L_D
            // 
            this.textBox_Total_L_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Total_L_D.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Total_L_D.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Total_L_D.Location = new System.Drawing.Point(215, 124);
            this.textBox_Total_L_D.Multiline = true;
            this.textBox_Total_L_D.Name = "textBox_Total_L_D";
            this.textBox_Total_L_D.Size = new System.Drawing.Size(38, 19);
            this.textBox_Total_L_D.TabIndex = 22;
            this.textBox_Total_L_D.Text = "null";
            this.textBox_Total_L_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Total_Light
            // 
            this.textBox_Total_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Total_Light.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Total_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Total_Light.Location = new System.Drawing.Point(155, 124);
            this.textBox_Total_Light.Multiline = true;
            this.textBox_Total_Light.Name = "textBox_Total_Light";
            this.textBox_Total_Light.Size = new System.Drawing.Size(38, 19);
            this.textBox_Total_Light.TabIndex = 20;
            this.textBox_Total_Light.Text = "null";
            this.textBox_Total_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Total_Dark
            // 
            this.textBox_Total_Dark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Total_Dark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Total_Dark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Total_Dark.Location = new System.Drawing.Point(95, 124);
            this.textBox_Total_Dark.Multiline = true;
            this.textBox_Total_Dark.Name = "textBox_Total_Dark";
            this.textBox_Total_Dark.Size = new System.Drawing.Size(38, 19);
            this.textBox_Total_Dark.TabIndex = 18;
            this.textBox_Total_Dark.Text = "null";
            this.textBox_Total_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Total_Co
            // 
            this.textBox_Total_Co.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Total_Co.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Total_Co.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Total_Co.Location = new System.Drawing.Point(35, 124);
            this.textBox_Total_Co.Multiline = true;
            this.textBox_Total_Co.Name = "textBox_Total_Co";
            this.textBox_Total_Co.Size = new System.Drawing.Size(38, 19);
            this.textBox_Total_Co.TabIndex = 19;
            this.textBox_Total_Co.Text = "null";
            this.textBox_Total_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Average_Temp
            // 
            this.textBox_Average_Temp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Average_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Average_Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Average_Temp.Location = new System.Drawing.Point(275, 100);
            this.textBox_Average_Temp.Multiline = true;
            this.textBox_Average_Temp.Name = "textBox_Average_Temp";
            this.textBox_Average_Temp.Size = new System.Drawing.Size(38, 19);
            this.textBox_Average_Temp.TabIndex = 16;
            this.textBox_Average_Temp.Text = "null";
            this.textBox_Average_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Average_L_D
            // 
            this.textBox_Average_L_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Average_L_D.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Average_L_D.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Average_L_D.Location = new System.Drawing.Point(215, 100);
            this.textBox_Average_L_D.Multiline = true;
            this.textBox_Average_L_D.Name = "textBox_Average_L_D";
            this.textBox_Average_L_D.Size = new System.Drawing.Size(38, 19);
            this.textBox_Average_L_D.TabIndex = 17;
            this.textBox_Average_L_D.Text = "null";
            this.textBox_Average_L_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Average_Light
            // 
            this.textBox_Average_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Average_Light.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Average_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Average_Light.Location = new System.Drawing.Point(155, 100);
            this.textBox_Average_Light.Multiline = true;
            this.textBox_Average_Light.Name = "textBox_Average_Light";
            this.textBox_Average_Light.Size = new System.Drawing.Size(38, 19);
            this.textBox_Average_Light.TabIndex = 15;
            this.textBox_Average_Light.Text = "null";
            this.textBox_Average_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Average_Dark
            // 
            this.textBox_Average_Dark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Average_Dark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Average_Dark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Average_Dark.Location = new System.Drawing.Point(95, 100);
            this.textBox_Average_Dark.Multiline = true;
            this.textBox_Average_Dark.Name = "textBox_Average_Dark";
            this.textBox_Average_Dark.Size = new System.Drawing.Size(38, 19);
            this.textBox_Average_Dark.TabIndex = 13;
            this.textBox_Average_Dark.Text = "null";
            this.textBox_Average_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Average_Co
            // 
            this.textBox_Average_Co.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Average_Co.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Average_Co.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Average_Co.Location = new System.Drawing.Point(35, 100);
            this.textBox_Average_Co.Multiline = true;
            this.textBox_Average_Co.Name = "textBox_Average_Co";
            this.textBox_Average_Co.Size = new System.Drawing.Size(38, 19);
            this.textBox_Average_Co.TabIndex = 14;
            this.textBox_Average_Co.Text = "null";
            this.textBox_Average_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Max_Temp
            // 
            this.textBox_Max_Temp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Max_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Max_Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Max_Temp.Location = new System.Drawing.Point(275, 75);
            this.textBox_Max_Temp.Multiline = true;
            this.textBox_Max_Temp.Name = "textBox_Max_Temp";
            this.textBox_Max_Temp.Size = new System.Drawing.Size(38, 19);
            this.textBox_Max_Temp.TabIndex = 11;
            this.textBox_Max_Temp.Text = "null";
            this.textBox_Max_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Max_L_D
            // 
            this.textBox_Max_L_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Max_L_D.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Max_L_D.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Max_L_D.Location = new System.Drawing.Point(215, 75);
            this.textBox_Max_L_D.Multiline = true;
            this.textBox_Max_L_D.Name = "textBox_Max_L_D";
            this.textBox_Max_L_D.Size = new System.Drawing.Size(38, 19);
            this.textBox_Max_L_D.TabIndex = 12;
            this.textBox_Max_L_D.Text = "null";
            this.textBox_Max_L_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Max_Light
            // 
            this.textBox_Max_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Max_Light.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Max_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Max_Light.Location = new System.Drawing.Point(155, 75);
            this.textBox_Max_Light.Multiline = true;
            this.textBox_Max_Light.Name = "textBox_Max_Light";
            this.textBox_Max_Light.Size = new System.Drawing.Size(38, 19);
            this.textBox_Max_Light.TabIndex = 10;
            this.textBox_Max_Light.Text = "null";
            this.textBox_Max_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Max_Dark
            // 
            this.textBox_Max_Dark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Max_Dark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Max_Dark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Max_Dark.Location = new System.Drawing.Point(95, 75);
            this.textBox_Max_Dark.Multiline = true;
            this.textBox_Max_Dark.Name = "textBox_Max_Dark";
            this.textBox_Max_Dark.Size = new System.Drawing.Size(38, 19);
            this.textBox_Max_Dark.TabIndex = 8;
            this.textBox_Max_Dark.Text = "null";
            this.textBox_Max_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Max_Co
            // 
            this.textBox_Max_Co.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Max_Co.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Max_Co.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Max_Co.Location = new System.Drawing.Point(35, 75);
            this.textBox_Max_Co.Multiline = true;
            this.textBox_Max_Co.Name = "textBox_Max_Co";
            this.textBox_Max_Co.Size = new System.Drawing.Size(38, 19);
            this.textBox_Max_Co.TabIndex = 9;
            this.textBox_Max_Co.Text = "null";
            this.textBox_Max_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Min_Temp
            // 
            this.textBox_Min_Temp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Min_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Min_Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Min_Temp.Location = new System.Drawing.Point(275, 50);
            this.textBox_Min_Temp.Multiline = true;
            this.textBox_Min_Temp.Name = "textBox_Min_Temp";
            this.textBox_Min_Temp.Size = new System.Drawing.Size(38, 19);
            this.textBox_Min_Temp.TabIndex = 6;
            this.textBox_Min_Temp.Text = "null";
            this.textBox_Min_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Min_L_D
            // 
            this.textBox_Min_L_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Min_L_D.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Min_L_D.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Min_L_D.Location = new System.Drawing.Point(215, 50);
            this.textBox_Min_L_D.Multiline = true;
            this.textBox_Min_L_D.Name = "textBox_Min_L_D";
            this.textBox_Min_L_D.Size = new System.Drawing.Size(38, 19);
            this.textBox_Min_L_D.TabIndex = 7;
            this.textBox_Min_L_D.Text = "null";
            this.textBox_Min_L_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Min_Light
            // 
            this.textBox_Min_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Min_Light.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Min_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Min_Light.Location = new System.Drawing.Point(155, 50);
            this.textBox_Min_Light.Multiline = true;
            this.textBox_Min_Light.Name = "textBox_Min_Light";
            this.textBox_Min_Light.Size = new System.Drawing.Size(38, 19);
            this.textBox_Min_Light.TabIndex = 5;
            this.textBox_Min_Light.Text = "null";
            this.textBox_Min_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Min_Dark
            // 
            this.textBox_Min_Dark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Min_Dark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Min_Dark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Min_Dark.Location = new System.Drawing.Point(95, 50);
            this.textBox_Min_Dark.Multiline = true;
            this.textBox_Min_Dark.Name = "textBox_Min_Dark";
            this.textBox_Min_Dark.Size = new System.Drawing.Size(38, 19);
            this.textBox_Min_Dark.TabIndex = 3;
            this.textBox_Min_Dark.Text = "null";
            this.textBox_Min_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Min_Co
            // 
            this.textBox_Min_Co.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Min_Co.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Min_Co.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Min_Co.Location = new System.Drawing.Point(35, 50);
            this.textBox_Min_Co.Multiline = true;
            this.textBox_Min_Co.Name = "textBox_Min_Co";
            this.textBox_Min_Co.Size = new System.Drawing.Size(38, 19);
            this.textBox_Min_Co.TabIndex = 4;
            this.textBox_Min_Co.Text = "null";
            this.textBox_Min_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Last_Temp
            // 
            this.textBox_Last_Temp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Last_Temp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Last_Temp.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Last_Temp.Location = new System.Drawing.Point(275, 23);
            this.textBox_Last_Temp.Multiline = true;
            this.textBox_Last_Temp.Name = "textBox_Last_Temp";
            this.textBox_Last_Temp.Size = new System.Drawing.Size(38, 19);
            this.textBox_Last_Temp.TabIndex = 2;
            this.textBox_Last_Temp.Text = "null";
            this.textBox_Last_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Last_L_D
            // 
            this.textBox_Last_L_D.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Last_L_D.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Last_L_D.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Last_L_D.Location = new System.Drawing.Point(215, 23);
            this.textBox_Last_L_D.Multiline = true;
            this.textBox_Last_L_D.Name = "textBox_Last_L_D";
            this.textBox_Last_L_D.Size = new System.Drawing.Size(38, 19);
            this.textBox_Last_L_D.TabIndex = 2;
            this.textBox_Last_L_D.Text = "null";
            this.textBox_Last_L_D.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Last_Light
            // 
            this.textBox_Last_Light.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Last_Light.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Last_Light.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Last_Light.Location = new System.Drawing.Point(155, 23);
            this.textBox_Last_Light.Multiline = true;
            this.textBox_Last_Light.Name = "textBox_Last_Light";
            this.textBox_Last_Light.Size = new System.Drawing.Size(38, 19);
            this.textBox_Last_Light.TabIndex = 2;
            this.textBox_Last_Light.Text = "null";
            this.textBox_Last_Light.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Last_Dark
            // 
            this.textBox_Last_Dark.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Last_Dark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Last_Dark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Last_Dark.Location = new System.Drawing.Point(95, 23);
            this.textBox_Last_Dark.Multiline = true;
            this.textBox_Last_Dark.Name = "textBox_Last_Dark";
            this.textBox_Last_Dark.Size = new System.Drawing.Size(38, 19);
            this.textBox_Last_Dark.TabIndex = 2;
            this.textBox_Last_Dark.Text = "null";
            this.textBox_Last_Dark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_Last_Co
            // 
            this.textBox_Last_Co.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Last_Co.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Last_Co.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Last_Co.Location = new System.Drawing.Point(35, 23);
            this.textBox_Last_Co.Multiline = true;
            this.textBox_Last_Co.Name = "textBox_Last_Co";
            this.textBox_Last_Co.Size = new System.Drawing.Size(38, 19);
            this.textBox_Last_Co.TabIndex = 2;
            this.textBox_Last_Co.Text = "null";
            this.textBox_Last_Co.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Count
            // 
            this.label_Count.AutoSize = true;
            this.label_Count.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Count.Location = new System.Drawing.Point(0, 125);
            this.label_Count.Name = "label_Count";
            this.label_Count.Size = new System.Drawing.Size(29, 12);
            this.label_Count.TabIndex = 1;
            this.label_Count.Text = "统计";
            // 
            // label_Average
            // 
            this.label_Average.AutoSize = true;
            this.label_Average.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Average.Location = new System.Drawing.Point(0, 100);
            this.label_Average.Name = "label_Average";
            this.label_Average.Size = new System.Drawing.Size(29, 12);
            this.label_Average.TabIndex = 1;
            this.label_Average.Text = "平均";
            // 
            // label_Max
            // 
            this.label_Max.AutoSize = true;
            this.label_Max.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Max.Location = new System.Drawing.Point(0, 75);
            this.label_Max.Name = "label_Max";
            this.label_Max.Size = new System.Drawing.Size(29, 12);
            this.label_Max.TabIndex = 1;
            this.label_Max.Text = "最大";
            // 
            // label_Min
            // 
            this.label_Min.AutoSize = true;
            this.label_Min.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Min.Location = new System.Drawing.Point(0, 50);
            this.label_Min.Name = "label_Min";
            this.label_Min.Size = new System.Drawing.Size(29, 12);
            this.label_Min.TabIndex = 1;
            this.label_Min.Text = "最小";
            // 
            // label_Temp_C
            // 
            this.label_Temp_C.AutoSize = true;
            this.label_Temp_C.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Temp_C.Location = new System.Drawing.Point(274, 5);
            this.label_Temp_C.Name = "label_Temp_C";
            this.label_Temp_C.Size = new System.Drawing.Size(46, 12);
            this.label_Temp_C.TabIndex = 1;
            this.label_Temp_C.Text = "T(°C)";
            this.label_Temp_C.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_L_D_Vol
            // 
            this.label_L_D_Vol.AutoSize = true;
            this.label_L_D_Vol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_L_D_Vol.Location = new System.Drawing.Point(213, 5);
            this.label_L_D_Vol.Name = "label_L_D_Vol";
            this.label_L_D_Vol.Size = new System.Drawing.Size(47, 12);
            this.label_L_D_Vol.TabIndex = 1;
            this.label_L_D_Vol.Text = "L-D(V)";
            this.label_L_D_Vol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Light_Vol
            // 
            this.label_Light_Vol.AutoSize = true;
            this.label_Light_Vol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Light_Vol.Location = new System.Drawing.Point(158, 5);
            this.label_Light_Vol.Name = "label_Light_Vol";
            this.label_Light_Vol.Size = new System.Drawing.Size(33, 12);
            this.label_Light_Vol.TabIndex = 1;
            this.label_Light_Vol.Text = "L(V)";
            this.label_Light_Vol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Dark_Vol
            // 
            this.label_Dark_Vol.AutoSize = true;
            this.label_Dark_Vol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Dark_Vol.Location = new System.Drawing.Point(99, 5);
            this.label_Dark_Vol.Name = "label_Dark_Vol";
            this.label_Dark_Vol.Size = new System.Drawing.Size(33, 12);
            this.label_Dark_Vol.TabIndex = 1;
            this.label_Dark_Vol.Text = "D(V)";
            this.label_Dark_Vol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Co_Vol
            // 
            this.label_Co_Vol.AutoSize = true;
            this.label_Co_Vol.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Co_Vol.Location = new System.Drawing.Point(35, 5);
            this.label_Co_Vol.Name = "label_Co_Vol";
            this.label_Co_Vol.Size = new System.Drawing.Size(40, 12);
            this.label_Co_Vol.TabIndex = 1;
            this.label_Co_Vol.Text = "Co(V)";
            this.label_Co_Vol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_Current
            // 
            this.label_Current.AutoSize = true;
            this.label_Current.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Current.Location = new System.Drawing.Point(0, 25);
            this.label_Current.Name = "label_Current";
            this.label_Current.Size = new System.Drawing.Size(29, 12);
            this.label_Current.TabIndex = 1;
            this.label_Current.Text = "最近";
            // 
            // textBox_Event
            // 
            this.textBox_Event.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_Event.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Event.Location = new System.Drawing.Point(265, 22);
            this.textBox_Event.Name = "textBox_Event";
            this.textBox_Event.Size = new System.Drawing.Size(62, 21);
            this.textBox_Event.TabIndex = 7;
            this.textBox_Event.Text = "null";
            this.textBox_Event.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_CO_BAT
            // 
            this.textBox_CO_BAT.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_CO_BAT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CO_BAT.Location = new System.Drawing.Point(178, 22);
            this.textBox_CO_BAT.Name = "textBox_CO_BAT";
            this.textBox_CO_BAT.Size = new System.Drawing.Size(62, 21);
            this.textBox_CO_BAT.TabIndex = 6;
            this.textBox_CO_BAT.Text = "0";
            this.textBox_CO_BAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_MCU_BAT
            // 
            this.textBox_MCU_BAT.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_MCU_BAT.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_MCU_BAT.Location = new System.Drawing.Point(89, 22);
            this.textBox_MCU_BAT.Name = "textBox_MCU_BAT";
            this.textBox_MCU_BAT.Size = new System.Drawing.Size(62, 21);
            this.textBox_MCU_BAT.TabIndex = 5;
            this.textBox_MCU_BAT.Text = "0";
            this.textBox_MCU_BAT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox_CO_PPM
            // 
            this.textBox_CO_PPM.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textBox_CO_PPM.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox_CO_PPM.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_CO_PPM.Location = new System.Drawing.Point(2, 22);
            this.textBox_CO_PPM.Name = "textBox_CO_PPM";
            this.textBox_CO_PPM.Size = new System.Drawing.Size(64, 21);
            this.textBox_CO_PPM.TabIndex = 4;
            this.textBox_CO_PPM.Text = "0";
            this.textBox_CO_PPM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_Event
            // 
            this.label_Event.AutoSize = true;
            this.label_Event.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Event.Location = new System.Drawing.Point(277, 4);
            this.label_Event.Name = "label_Event";
            this.label_Event.Size = new System.Drawing.Size(35, 12);
            this.label_Event.TabIndex = 3;
            this.label_Event.Text = "Event";
            // 
            // label_Co_Bat
            // 
            this.label_Co_Bat.AutoSize = true;
            this.label_Co_Bat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Co_Bat.Location = new System.Drawing.Point(180, 4);
            this.label_Co_Bat.Name = "label_Co_Bat";
            this.label_Co_Bat.Size = new System.Drawing.Size(59, 12);
            this.label_Co_Bat.TabIndex = 2;
            this.label_Co_Bat.Text = "CO_Bat(V)";
            // 
            // label_Mcu_Bat
            // 
            this.label_Mcu_Bat.AutoSize = true;
            this.label_Mcu_Bat.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Mcu_Bat.Location = new System.Drawing.Point(90, 4);
            this.label_Mcu_Bat.Name = "label_Mcu_Bat";
            this.label_Mcu_Bat.Size = new System.Drawing.Size(65, 12);
            this.label_Mcu_Bat.TabIndex = 1;
            this.label_Mcu_Bat.Text = "MCU_Bat(V)";
            // 
            // label_Co_Ppm
            // 
            this.label_Co_Ppm.AutoSize = true;
            this.label_Co_Ppm.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Co_Ppm.Location = new System.Drawing.Point(10, 4);
            this.label_Co_Ppm.Name = "label_Co_Ppm";
            this.label_Co_Ppm.Size = new System.Drawing.Size(47, 12);
            this.label_Co_Ppm.TabIndex = 0;
            this.label_Co_Ppm.Text = "CO(ppm)";
            // 
            // Dark_Series_Button
            // 
            this.Dark_Series_Button.AutoSize = true;
            this.Dark_Series_Button.Checked = true;
            this.Dark_Series_Button.ForeColor = System.Drawing.SystemColors.MenuText;
            this.Dark_Series_Button.Location = new System.Drawing.Point(0, 11);
            this.Dark_Series_Button.Name = "Dark_Series_Button";
            this.Dark_Series_Button.Size = new System.Drawing.Size(51, 16);
            this.Dark_Series_Button.TabIndex = 11;
            this.Dark_Series_Button.TabStop = true;
            this.Dark_Series_Button.Text = "Dark";
            this.Dark_Series_Button.UseVisualStyleBackColor = true;
            this.Dark_Series_Button.Click += new System.EventHandler(this.Dark_Series_Button_Click);
            // 
            // GroupBox1_Dark
            // 
            this.GroupBox1_Dark.Controls.Add(this.Dark_Series_Button);
            this.GroupBox1_Dark.Location = new System.Drawing.Point(394, 30);
            this.GroupBox1_Dark.Name = "GroupBox1_Dark";
            this.GroupBox1_Dark.Size = new System.Drawing.Size(54, 28);
            this.GroupBox1_Dark.TabIndex = 12;
            this.GroupBox1_Dark.TabStop = false;
            // 
            // GroupBox1_Light
            // 
            this.GroupBox1_Light.Controls.Add(this.Light_Series_Button);
            this.GroupBox1_Light.Location = new System.Drawing.Point(461, 30);
            this.GroupBox1_Light.Name = "GroupBox1_Light";
            this.GroupBox1_Light.Size = new System.Drawing.Size(54, 28);
            this.GroupBox1_Light.TabIndex = 12;
            this.GroupBox1_Light.TabStop = false;
            // 
            // Light_Series_Button
            // 
            this.Light_Series_Button.AutoSize = true;
            this.Light_Series_Button.Checked = true;
            this.Light_Series_Button.ForeColor = System.Drawing.Color.Red;
            this.Light_Series_Button.Location = new System.Drawing.Point(0, 11);
            this.Light_Series_Button.Name = "Light_Series_Button";
            this.Light_Series_Button.Size = new System.Drawing.Size(58, 16);
            this.Light_Series_Button.TabIndex = 11;
            this.Light_Series_Button.TabStop = true;
            this.Light_Series_Button.Text = "Light";
            this.Light_Series_Button.UseVisualStyleBackColor = true;
            this.Light_Series_Button.Click += new System.EventHandler(this.Light_Series_Button_Click);
            // 
            // GroupBox1_L_D
            // 
            this.GroupBox1_L_D.Controls.Add(this.L_D_Series_Button);
            this.GroupBox1_L_D.Location = new System.Drawing.Point(534, 30);
            this.GroupBox1_L_D.Name = "GroupBox1_L_D";
            this.GroupBox1_L_D.Size = new System.Drawing.Size(54, 28);
            this.GroupBox1_L_D.TabIndex = 12;
            this.GroupBox1_L_D.TabStop = false;
            // 
            // L_D_Series_Button
            // 
            this.L_D_Series_Button.AutoSize = true;
            this.L_D_Series_Button.Checked = true;
            this.L_D_Series_Button.ForeColor = System.Drawing.Color.Blue;
            this.L_D_Series_Button.Location = new System.Drawing.Point(0, 11);
            this.L_D_Series_Button.Name = "L_D_Series_Button";
            this.L_D_Series_Button.Size = new System.Drawing.Size(44, 16);
            this.L_D_Series_Button.TabIndex = 11;
            this.L_D_Series_Button.TabStop = true;
            this.L_D_Series_Button.Text = "L_D";
            this.L_D_Series_Button.UseVisualStyleBackColor = true;
            this.L_D_Series_Button.Click += new System.EventHandler(this.L_D_Series_Button_Click);
            // 
            // GroupBox1_Co
            // 
            this.GroupBox1_Co.Controls.Add(this.Co_Series_Button);
            this.GroupBox1_Co.Location = new System.Drawing.Point(598, 30);
            this.GroupBox1_Co.Name = "GroupBox1_Co";
            this.GroupBox1_Co.Size = new System.Drawing.Size(54, 28);
            this.GroupBox1_Co.TabIndex = 12;
            this.GroupBox1_Co.TabStop = false;
            // 
            // Co_Series_Button
            // 
            this.Co_Series_Button.AutoSize = true;
            this.Co_Series_Button.Checked = true;
            this.Co_Series_Button.ForeColor = System.Drawing.Color.Green;
            this.Co_Series_Button.Location = new System.Drawing.Point(0, 11);
            this.Co_Series_Button.Name = "Co_Series_Button";
            this.Co_Series_Button.Size = new System.Drawing.Size(37, 16);
            this.Co_Series_Button.TabIndex = 11;
            this.Co_Series_Button.TabStop = true;
            this.Co_Series_Button.Text = "Co";
            this.Co_Series_Button.UseVisualStyleBackColor = true;
            this.Co_Series_Button.Click += new System.EventHandler(this.Co_Series_Button_Click);
            // 
            // pictureBox1_On_Off
            // 
            this.pictureBox1_On_Off.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1_On_Off.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1_On_Off.ErrorImage")));
            this.pictureBox1_On_Off.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1_On_Off.Image")));
            this.pictureBox1_On_Off.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1_On_Off.InitialImage")));
            this.pictureBox1_On_Off.Location = new System.Drawing.Point(14, 32);
            this.pictureBox1_On_Off.Name = "pictureBox1_On_Off";
            this.pictureBox1_On_Off.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1_On_Off.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1_On_Off.TabIndex = 13;
            this.pictureBox1_On_Off.TabStop = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.button4.Location = new System.Drawing.Point(275, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(61, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "帮助";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(340, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(580, 540);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(932, 607);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox1_On_Off);
            this.Controls.Add(this.GroupBox1_Co);
            this.Controls.Add(this.GroupBox1_L_D);
            this.Controls.Add(this.GroupBox1_Light);
            this.Controls.Add(this.GroupBox1_Dark);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "小书包  V1.2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ClientSizeChanged += new System.EventHandler(this.Form1_ClientSizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.GroupBox1_Dark.ResumeLayout(false);
            this.GroupBox1_Dark.PerformLayout();
            this.GroupBox1_Light.ResumeLayout(false);
            this.GroupBox1_Light.PerformLayout();
            this.GroupBox1_L_D.ResumeLayout(false);
            this.GroupBox1_L_D.PerformLayout();
            this.GroupBox1_Co.ResumeLayout(false);
            this.GroupBox1_Co.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1_On_Off)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Co_Ppm;
        private System.Windows.Forms.TextBox textBox_Event;
        private System.Windows.Forms.TextBox textBox_CO_BAT;
        private System.Windows.Forms.TextBox textBox_MCU_BAT;
        private System.Windows.Forms.TextBox textBox_CO_PPM;
        private System.Windows.Forms.Label label_Event;
        private System.Windows.Forms.Label label_Co_Bat;
        private System.Windows.Forms.Label label_Mcu_Bat;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_Last_Co;
        private System.Windows.Forms.Label label_Count;
        private System.Windows.Forms.Label label_Average;
        private System.Windows.Forms.Label label_Max;
        private System.Windows.Forms.Label label_Min;
        private System.Windows.Forms.Label label_Temp_C;
        private System.Windows.Forms.Label label_L_D_Vol;
        private System.Windows.Forms.Label label_Light_Vol;
        private System.Windows.Forms.Label label_Dark_Vol;
        private System.Windows.Forms.Label label_Co_Vol;
        private System.Windows.Forms.Label label_Current;
        private System.Windows.Forms.TextBox textBox_Last_L_D;
        private System.Windows.Forms.TextBox textBox_Last_Light;
        private System.Windows.Forms.TextBox textBox_Last_Dark;
        private System.Windows.Forms.TextBox textBox_Last_Temp;
        private System.Windows.Forms.TextBox textBox_Min_Temp;
        private System.Windows.Forms.TextBox textBox_Min_L_D;
        private System.Windows.Forms.TextBox textBox_Min_Light;
        private System.Windows.Forms.TextBox textBox_Min_Dark;
        private System.Windows.Forms.TextBox textBox_Min_Co;
        private System.Windows.Forms.TextBox textBox_Total_Temp;
        private System.Windows.Forms.TextBox textBox_Total_L_D;
        private System.Windows.Forms.TextBox textBox_Total_Light;
        private System.Windows.Forms.TextBox textBox_Total_Dark;
        private System.Windows.Forms.TextBox textBox_Total_Co;
        private System.Windows.Forms.TextBox textBox_Average_Temp;
        private System.Windows.Forms.TextBox textBox_Average_L_D;
        private System.Windows.Forms.TextBox textBox_Average_Light;
        private System.Windows.Forms.TextBox textBox_Average_Dark;
        private System.Windows.Forms.TextBox textBox_Average_Co;
        private System.Windows.Forms.TextBox textBox_Max_Temp;
        private System.Windows.Forms.TextBox textBox_Max_L_D;
        private System.Windows.Forms.TextBox textBox_Max_Light;
        private System.Windows.Forms.TextBox textBox_Max_Dark;
        private System.Windows.Forms.TextBox textBox_Max_Co;
        private System.Windows.Forms.RadioButton Dark_Series_Button;
        private System.Windows.Forms.GroupBox GroupBox1_Dark;
        private System.Windows.Forms.GroupBox GroupBox1_Light;
        private System.Windows.Forms.RadioButton Light_Series_Button;
        private System.Windows.Forms.GroupBox GroupBox1_L_D;
        private System.Windows.Forms.RadioButton L_D_Series_Button;
        private System.Windows.Forms.GroupBox GroupBox1_Co;
        private System.Windows.Forms.RadioButton Co_Series_Button;
        private System.Windows.Forms.PictureBox pictureBox1_On_Off;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

