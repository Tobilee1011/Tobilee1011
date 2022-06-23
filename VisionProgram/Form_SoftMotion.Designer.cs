namespace VisionProgram
{
    partial class Form_SoftMotion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Home = new System.Windows.Forms.Button();
            this.btn_ServoOff = new System.Windows.Forms.Button();
            this.btn_ServoOn = new System.Windows.Forms.Button();
            this.btn_MotorConnect = new System.Windows.Forms.Button();
            this.cb_AxisNumber = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_Motor_1_CCW = new System.Windows.Forms.Button();
            this.btn_Motor_0_CCW = new System.Windows.Forms.Button();
            this.tb_Motor_1_Target_Pos = new System.Windows.Forms.TextBox();
            this.tb_Motor_0_Target_Pos = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn_Motor_Stop = new System.Windows.Forms.Button();
            this.tb_Motor_1_Limit_Pos = new System.Windows.Forms.TextBox();
            this.tb_Motor_0_Limit_Pos = new System.Windows.Forms.TextBox();
            this.tb_Motor_1_Current_Pos = new System.Windows.Forms.TextBox();
            this.tb_Motor_0_Current_Pos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Motor_1_CW = new System.Windows.Forms.Button();
            this.btn_Motor_0_CW = new System.Windows.Forms.Button();
            this.tb_Motor_1_Target_Spd = new System.Windows.Forms.TextBox();
            this.tb_Motor_0_Target_Spd = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_Abs = new System.Windows.Forms.RadioButton();
            this.rb_Inc = new System.Windows.Forms.RadioButton();
            this.rd_Jog = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cd_Sequence = new System.Windows.Forms.CheckBox();
            this.cd_Home = new System.Windows.Forms.CheckBox();
            this.cd_CCW = new System.Windows.Forms.CheckBox();
            this.cd_CW = new System.Windows.Forms.CheckBox();
            this.cd_Speed_High = new System.Windows.Forms.CheckBox();
            this.cd_Speed_Low = new System.Windows.Forms.CheckBox();
            this.cd_Motor_1 = new System.Windows.Forms.CheckBox();
            this.cd_Motor_0 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn_Output = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.cb_Idle = new System.Windows.Forms.CheckBox();
            this.cb_Moving = new System.Windows.Forms.CheckBox();
            this.cd_HomeComp = new System.Windows.Forms.CheckBox();
            this.cd_Comm = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 120);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "자동 시퀀스";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(300, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 5;
            this.button2.Text = "비전 연동 얼라인";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "사용자 입력";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "- 비전 연동하여 축 구동 (X축 : #0,  Y축 : #1)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "2. 시퀀스 제어";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "- 모터 상태를 LED에 표시한다.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "1. 버턴 입력으로 모터를 제어한다.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Home);
            this.groupBox2.Controls.Add(this.btn_ServoOff);
            this.groupBox2.Controls.Add(this.btn_ServoOn);
            this.groupBox2.Controls.Add(this.btn_MotorConnect);
            this.groupBox2.Controls.Add(this.cb_AxisNumber);
            this.groupBox2.Location = new System.Drawing.Point(12, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 80);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "모터 선택 & 원점 복귀";
            // 
            // btn_Home
            // 
            this.btn_Home.Location = new System.Drawing.Point(300, 20);
            this.btn_Home.Name = "btn_Home";
            this.btn_Home.Size = new System.Drawing.Size(75, 52);
            this.btn_Home.TabIndex = 4;
            this.btn_Home.Text = "원점 복귀";
            this.btn_Home.UseVisualStyleBackColor = true;
            this.btn_Home.Click += new System.EventHandler(this.btn_Home_Click);
            // 
            // btn_ServoOff
            // 
            this.btn_ServoOff.Location = new System.Drawing.Point(186, 49);
            this.btn_ServoOff.Name = "btn_ServoOff";
            this.btn_ServoOff.Size = new System.Drawing.Size(75, 23);
            this.btn_ServoOff.TabIndex = 3;
            this.btn_ServoOff.Text = "서보 오프";
            this.btn_ServoOff.UseVisualStyleBackColor = true;
            this.btn_ServoOff.Click += new System.EventHandler(this.btn_ServoOff_Click);
            // 
            // btn_ServoOn
            // 
            this.btn_ServoOn.Location = new System.Drawing.Point(186, 20);
            this.btn_ServoOn.Name = "btn_ServoOn";
            this.btn_ServoOn.Size = new System.Drawing.Size(75, 23);
            this.btn_ServoOn.TabIndex = 2;
            this.btn_ServoOn.Text = "서보 온";
            this.btn_ServoOn.UseVisualStyleBackColor = true;
            this.btn_ServoOn.Click += new System.EventHandler(this.btn_ServoOn_Click);
            // 
            // btn_MotorConnect
            // 
            this.btn_MotorConnect.Location = new System.Drawing.Point(105, 20);
            this.btn_MotorConnect.Name = "btn_MotorConnect";
            this.btn_MotorConnect.Size = new System.Drawing.Size(75, 52);
            this.btn_MotorConnect.TabIndex = 1;
            this.btn_MotorConnect.Text = "통신연결";
            this.btn_MotorConnect.UseVisualStyleBackColor = true;
            this.btn_MotorConnect.Click += new System.EventHandler(this.btn_MotorConnect_Click);
            // 
            // cb_AxisNumber
            // 
            this.cb_AxisNumber.FormattingEnabled = true;
            this.cb_AxisNumber.Items.AddRange(new object[] {
            "Axis #0",
            "Axis #1"});
            this.cb_AxisNumber.Location = new System.Drawing.Point(8, 33);
            this.cb_AxisNumber.Name = "cb_AxisNumber";
            this.cb_AxisNumber.Size = new System.Drawing.Size(91, 20);
            this.cb_AxisNumber.TabIndex = 0;
            this.cb_AxisNumber.Tag = "";
            this.cb_AxisNumber.Text = "Axis #0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_Motor_1_CCW);
            this.groupBox3.Controls.Add(this.btn_Motor_0_CCW);
            this.groupBox3.Controls.Add(this.tb_Motor_1_Target_Pos);
            this.groupBox3.Controls.Add(this.tb_Motor_0_Target_Pos);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.btn_Motor_Stop);
            this.groupBox3.Controls.Add(this.tb_Motor_1_Limit_Pos);
            this.groupBox3.Controls.Add(this.tb_Motor_0_Limit_Pos);
            this.groupBox3.Controls.Add(this.tb_Motor_1_Current_Pos);
            this.groupBox3.Controls.Add(this.tb_Motor_0_Current_Pos);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.btn_Motor_1_CW);
            this.groupBox3.Controls.Add(this.btn_Motor_0_CW);
            this.groupBox3.Controls.Add(this.tb_Motor_1_Target_Spd);
            this.groupBox3.Controls.Add(this.tb_Motor_0_Target_Spd);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.rb_Abs);
            this.groupBox3.Controls.Add(this.rb_Inc);
            this.groupBox3.Controls.Add(this.rd_Jog);
            this.groupBox3.Location = new System.Drawing.Point(12, 224);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 211);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "모터 이동 및 상태";
            // 
            // btn_Motor_1_CCW
            // 
            this.btn_Motor_1_CCW.Location = new System.Drawing.Point(6, 150);
            this.btn_Motor_1_CCW.Name = "btn_Motor_1_CCW";
            this.btn_Motor_1_CCW.Size = new System.Drawing.Size(73, 20);
            this.btn_Motor_1_CCW.TabIndex = 21;
            this.btn_Motor_1_CCW.Text = "역회전 #1";
            this.btn_Motor_1_CCW.UseVisualStyleBackColor = true;
            this.btn_Motor_1_CCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_1_CCW_MouseDown);
            this.btn_Motor_1_CCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_1_CCW_MouseUp);
            // 
            // btn_Motor_0_CCW
            // 
            this.btn_Motor_0_CCW.Location = new System.Drawing.Point(6, 123);
            this.btn_Motor_0_CCW.Name = "btn_Motor_0_CCW";
            this.btn_Motor_0_CCW.Size = new System.Drawing.Size(73, 20);
            this.btn_Motor_0_CCW.TabIndex = 20;
            this.btn_Motor_0_CCW.Text = "역회전 #0";
            this.btn_Motor_0_CCW.UseVisualStyleBackColor = true;
            this.btn_Motor_0_CCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_0_CCW_MouseDown);
            this.btn_Motor_0_CCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_0_CCW_MouseUp);
            // 
            // tb_Motor_1_Target_Pos
            // 
            this.tb_Motor_1_Target_Pos.Location = new System.Drawing.Point(84, 150);
            this.tb_Motor_1_Target_Pos.Name = "tb_Motor_1_Target_Pos";
            this.tb_Motor_1_Target_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_1_Target_Pos.TabIndex = 19;
            this.tb_Motor_1_Target_Pos.Text = "50000";
            // 
            // tb_Motor_0_Target_Pos
            // 
            this.tb_Motor_0_Target_Pos.Location = new System.Drawing.Point(84, 122);
            this.tb_Motor_0_Target_Pos.Name = "tb_Motor_0_Target_Pos";
            this.tb_Motor_0_Target_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_0_Target_Pos.TabIndex = 18;
            this.tb_Motor_0_Target_Pos.Text = "500000";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(103, 107);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "이동량";
            // 
            // btn_Motor_Stop
            // 
            this.btn_Motor_Stop.Location = new System.Drawing.Point(6, 175);
            this.btn_Motor_Stop.Name = "btn_Motor_Stop";
            this.btn_Motor_Stop.Size = new System.Drawing.Size(236, 23);
            this.btn_Motor_Stop.TabIndex = 16;
            this.btn_Motor_Stop.Text = "정지";
            this.btn_Motor_Stop.UseVisualStyleBackColor = true;
            this.btn_Motor_Stop.Click += new System.EventHandler(this.btn_Motor_Stop_Click);
            // 
            // tb_Motor_1_Limit_Pos
            // 
            this.tb_Motor_1_Limit_Pos.Location = new System.Drawing.Point(327, 149);
            this.tb_Motor_1_Limit_Pos.Name = "tb_Motor_1_Limit_Pos";
            this.tb_Motor_1_Limit_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_1_Limit_Pos.TabIndex = 15;
            // 
            // tb_Motor_0_Limit_Pos
            // 
            this.tb_Motor_0_Limit_Pos.Location = new System.Drawing.Point(327, 123);
            this.tb_Motor_0_Limit_Pos.Name = "tb_Motor_0_Limit_Pos";
            this.tb_Motor_0_Limit_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_0_Limit_Pos.TabIndex = 14;
            // 
            // tb_Motor_1_Current_Pos
            // 
            this.tb_Motor_1_Current_Pos.Location = new System.Drawing.Point(247, 150);
            this.tb_Motor_1_Current_Pos.Name = "tb_Motor_1_Current_Pos";
            this.tb_Motor_1_Current_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_1_Current_Pos.TabIndex = 13;
            // 
            // tb_Motor_0_Current_Pos
            // 
            this.tb_Motor_0_Current_Pos.Location = new System.Drawing.Point(247, 122);
            this.tb_Motor_0_Current_Pos.Name = "tb_Motor_0_Current_Pos";
            this.tb_Motor_0_Current_Pos.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_0_Current_Pos.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(332, 107);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "리밋 (-)(+)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "현재위치";
            // 
            // btn_Motor_1_CW
            // 
            this.btn_Motor_1_CW.Location = new System.Drawing.Point(164, 149);
            this.btn_Motor_1_CW.Name = "btn_Motor_1_CW";
            this.btn_Motor_1_CW.Size = new System.Drawing.Size(78, 20);
            this.btn_Motor_1_CW.TabIndex = 9;
            this.btn_Motor_1_CW.Text = "정회전 #1";
            this.btn_Motor_1_CW.UseVisualStyleBackColor = true;
            this.btn_Motor_1_CW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_1_CW_MouseDown);
            this.btn_Motor_1_CW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_1_CW_MouseUp);
            // 
            // btn_Motor_0_CW
            // 
            this.btn_Motor_0_CW.Location = new System.Drawing.Point(164, 122);
            this.btn_Motor_0_CW.Name = "btn_Motor_0_CW";
            this.btn_Motor_0_CW.Size = new System.Drawing.Size(78, 20);
            this.btn_Motor_0_CW.TabIndex = 8;
            this.btn_Motor_0_CW.Text = "정회전 #0";
            this.btn_Motor_0_CW.UseVisualStyleBackColor = true;
            this.btn_Motor_0_CW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_0_CW_MouseDown);
            this.btn_Motor_0_CW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Motor_0_CW_MouseUp);
            // 
            // tb_Motor_1_Target_Spd
            // 
            this.tb_Motor_1_Target_Spd.Location = new System.Drawing.Point(84, 80);
            this.tb_Motor_1_Target_Spd.Name = "tb_Motor_1_Target_Spd";
            this.tb_Motor_1_Target_Spd.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_1_Target_Spd.TabIndex = 6;
            this.tb_Motor_1_Target_Spd.Text = "10000";
            // 
            // tb_Motor_0_Target_Spd
            // 
            this.tb_Motor_0_Target_Spd.Location = new System.Drawing.Point(84, 53);
            this.tb_Motor_0_Target_Spd.Name = "tb_Motor_0_Target_Spd";
            this.tb_Motor_0_Target_Spd.Size = new System.Drawing.Size(74, 21);
            this.tb_Motor_0_Target_Spd.TabIndex = 5;
            this.tb_Motor_0_Target_Spd.Text = "100000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "속도 #1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "속도 #0";
            // 
            // rb_Abs
            // 
            this.rb_Abs.AutoSize = true;
            this.rb_Abs.Location = new System.Drawing.Point(130, 20);
            this.rb_Abs.Name = "rb_Abs";
            this.rb_Abs.Size = new System.Drawing.Size(47, 16);
            this.rb_Abs.TabIndex = 2;
            this.rb_Abs.TabStop = true;
            this.rb_Abs.Text = "절대";
            this.rb_Abs.UseVisualStyleBackColor = true;
            // 
            // rb_Inc
            // 
            this.rb_Inc.AutoSize = true;
            this.rb_Inc.Location = new System.Drawing.Point(77, 20);
            this.rb_Inc.Name = "rb_Inc";
            this.rb_Inc.Size = new System.Drawing.Size(47, 16);
            this.rb_Inc.TabIndex = 1;
            this.rb_Inc.TabStop = true;
            this.rb_Inc.Text = "상대";
            this.rb_Inc.UseVisualStyleBackColor = true;
            // 
            // rd_Jog
            // 
            this.rd_Jog.AutoSize = true;
            this.rd_Jog.Location = new System.Drawing.Point(24, 20);
            this.rd_Jog.Name = "rd_Jog";
            this.rd_Jog.Size = new System.Drawing.Size(47, 16);
            this.rd_Jog.TabIndex = 0;
            this.rd_Jog.TabStop = true;
            this.rd_Jog.Text = "조그";
            this.rd_Jog.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cd_Sequence);
            this.groupBox4.Controls.Add(this.cd_Home);
            this.groupBox4.Controls.Add(this.cd_CCW);
            this.groupBox4.Controls.Add(this.cd_CW);
            this.groupBox4.Controls.Add(this.cd_Speed_High);
            this.groupBox4.Controls.Add(this.cd_Speed_Low);
            this.groupBox4.Controls.Add(this.cd_Motor_1);
            this.groupBox4.Controls.Add(this.cd_Motor_0);
            this.groupBox4.Location = new System.Drawing.Point(12, 441);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 116);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "버튼 입력";
            // 
            // cd_Sequence
            // 
            this.cd_Sequence.AutoSize = true;
            this.cd_Sequence.Location = new System.Drawing.Point(105, 86);
            this.cd_Sequence.Name = "cd_Sequence";
            this.cd_Sequence.Size = new System.Drawing.Size(78, 16);
            this.cd_Sequence.TabIndex = 23;
            this.cd_Sequence.Text = "07_시퀀스";
            this.cd_Sequence.UseVisualStyleBackColor = true;
            // 
            // cd_Home
            // 
            this.cd_Home.AutoSize = true;
            this.cd_Home.Location = new System.Drawing.Point(105, 65);
            this.cd_Home.Name = "cd_Home";
            this.cd_Home.Size = new System.Drawing.Size(90, 16);
            this.cd_Home.TabIndex = 22;
            this.cd_Home.Text = "06_원점복귀";
            this.cd_Home.UseVisualStyleBackColor = true;
            // 
            // cd_CCW
            // 
            this.cd_CCW.AutoSize = true;
            this.cd_CCW.Location = new System.Drawing.Point(105, 42);
            this.cd_CCW.Name = "cd_CCW";
            this.cd_CCW.Size = new System.Drawing.Size(78, 16);
            this.cd_CCW.TabIndex = 21;
            this.cd_CCW.Text = "05_역회전";
            this.cd_CCW.UseVisualStyleBackColor = true;
            // 
            // cd_CW
            // 
            this.cd_CW.AutoSize = true;
            this.cd_CW.Location = new System.Drawing.Point(105, 20);
            this.cd_CW.Name = "cd_CW";
            this.cd_CW.Size = new System.Drawing.Size(78, 16);
            this.cd_CW.TabIndex = 20;
            this.cd_CW.Text = "04_정회전";
            this.cd_CW.UseVisualStyleBackColor = true;
            // 
            // cd_Speed_High
            // 
            this.cd_Speed_High.AutoSize = true;
            this.cd_Speed_High.Location = new System.Drawing.Point(8, 86);
            this.cd_Speed_High.Name = "cd_Speed_High";
            this.cd_Speed_High.Size = new System.Drawing.Size(66, 16);
            this.cd_Speed_High.TabIndex = 19;
            this.cd_Speed_High.Text = "03_고속";
            this.cd_Speed_High.UseVisualStyleBackColor = true;
            // 
            // cd_Speed_Low
            // 
            this.cd_Speed_Low.AutoSize = true;
            this.cd_Speed_Low.Location = new System.Drawing.Point(8, 65);
            this.cd_Speed_Low.Name = "cd_Speed_Low";
            this.cd_Speed_Low.Size = new System.Drawing.Size(66, 16);
            this.cd_Speed_Low.TabIndex = 18;
            this.cd_Speed_Low.Text = "02_저속";
            this.cd_Speed_Low.UseVisualStyleBackColor = true;
            // 
            // cd_Motor_1
            // 
            this.cd_Motor_1.AutoSize = true;
            this.cd_Motor_1.Location = new System.Drawing.Point(8, 42);
            this.cd_Motor_1.Name = "cd_Motor_1";
            this.cd_Motor_1.Size = new System.Drawing.Size(82, 16);
            this.cd_Motor_1.TabIndex = 17;
            this.cd_Motor_1.Text = "01_#1 모터";
            this.cd_Motor_1.UseVisualStyleBackColor = true;
            // 
            // cd_Motor_0
            // 
            this.cd_Motor_0.AutoSize = true;
            this.cd_Motor_0.Location = new System.Drawing.Point(8, 20);
            this.cd_Motor_0.Name = "cd_Motor_0";
            this.cd_Motor_0.Size = new System.Drawing.Size(82, 16);
            this.cd_Motor_0.TabIndex = 16;
            this.cd_Motor_0.Text = "00_#0 모터";
            this.cd_Motor_0.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox1);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.checkBox4);
            this.groupBox5.Controls.Add(this.cb_Idle);
            this.groupBox5.Controls.Add(this.cb_Moving);
            this.groupBox5.Controls.Add(this.cd_HomeComp);
            this.groupBox5.Controls.Add(this.cd_Comm);
            this.groupBox5.Location = new System.Drawing.Point(230, 441);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(196, 116);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "LED 출력";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 565);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "입력값 =";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(75, 565);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "0.0000";
            // 
            // btn_Output
            // 
            this.btn_Output.Location = new System.Drawing.Point(230, 565);
            this.btn_Output.Name = "btn_Output";
            this.btn_Output.Size = new System.Drawing.Size(75, 23);
            this.btn_Output.TabIndex = 12;
            this.btn_Output.Text = "출력";
            this.btn_Output.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(312, 565);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "출력리셋";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 590);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "조작 및 동작 상태";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 620);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(413, 172);
            this.listBox1.TabIndex = 15;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(105, 86);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 31;
            this.checkBox1.Text = "07_기타3";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(105, 65);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 30;
            this.checkBox2.Text = "06_기타2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(105, 42);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(72, 16);
            this.checkBox3.TabIndex = 29;
            this.checkBox3.Text = "05_기타1";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(105, 20);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 16);
            this.checkBox4.TabIndex = 28;
            this.checkBox4.Text = "04_알람";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // cb_Idle
            // 
            this.cb_Idle.AutoSize = true;
            this.cb_Idle.Location = new System.Drawing.Point(8, 86);
            this.cb_Idle.Name = "cb_Idle";
            this.cb_Idle.Size = new System.Drawing.Size(78, 16);
            this.cb_Idle.TabIndex = 27;
            this.cb_Idle.Text = "03_정지중";
            this.cb_Idle.UseVisualStyleBackColor = true;
            // 
            // cb_Moving
            // 
            this.cb_Moving.AutoSize = true;
            this.cb_Moving.Location = new System.Drawing.Point(8, 65);
            this.cb_Moving.Name = "cb_Moving";
            this.cb_Moving.Size = new System.Drawing.Size(78, 16);
            this.cb_Moving.TabIndex = 26;
            this.cb_Moving.Text = "02_구동중";
            this.cb_Moving.UseVisualStyleBackColor = true;
            // 
            // cd_HomeComp
            // 
            this.cd_HomeComp.AutoSize = true;
            this.cd_HomeComp.Location = new System.Drawing.Point(8, 42);
            this.cd_HomeComp.Name = "cd_HomeComp";
            this.cd_HomeComp.Size = new System.Drawing.Size(90, 16);
            this.cd_HomeComp.TabIndex = 25;
            this.cd_HomeComp.Text = "01_원점완료";
            this.cd_HomeComp.UseVisualStyleBackColor = true;
            // 
            // cd_Comm
            // 
            this.cd_Comm.AutoSize = true;
            this.cd_Comm.Location = new System.Drawing.Point(8, 20);
            this.cd_Comm.Name = "cd_Comm";
            this.cd_Comm.Size = new System.Drawing.Size(90, 16);
            this.cd_Comm.TabIndex = 24;
            this.cd_Comm.Text = "00_통신연결";
            this.cd_Comm.UseVisualStyleBackColor = true;
            // 
            // Form_SoftMotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 811);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.btn_Output);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_SoftMotion";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_SoftMotion_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Home;
        private System.Windows.Forms.Button btn_ServoOff;
        private System.Windows.Forms.Button btn_ServoOn;
        private System.Windows.Forms.Button btn_MotorConnect;
        private System.Windows.Forms.ComboBox cb_AxisNumber;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_Motor_Stop;
        private System.Windows.Forms.TextBox tb_Motor_1_Limit_Pos;
        private System.Windows.Forms.TextBox tb_Motor_0_Limit_Pos;
        private System.Windows.Forms.TextBox tb_Motor_1_Current_Pos;
        private System.Windows.Forms.TextBox tb_Motor_0_Current_Pos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Motor_1_CW;
        private System.Windows.Forms.Button btn_Motor_0_CW;
        private System.Windows.Forms.TextBox tb_Motor_1_Target_Spd;
        private System.Windows.Forms.TextBox tb_Motor_0_Target_Spd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_Abs;
        private System.Windows.Forms.RadioButton rb_Inc;
        private System.Windows.Forms.RadioButton rd_Jog;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Output;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btn_Motor_1_CCW;
        private System.Windows.Forms.Button btn_Motor_0_CCW;
        private System.Windows.Forms.TextBox tb_Motor_1_Target_Pos;
        private System.Windows.Forms.TextBox tb_Motor_0_Target_Pos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.CheckBox cd_Motor_0;
        private System.Windows.Forms.CheckBox cd_Motor_1;
        private System.Windows.Forms.CheckBox cd_Sequence;
        private System.Windows.Forms.CheckBox cd_Home;
        private System.Windows.Forms.CheckBox cd_CCW;
        private System.Windows.Forms.CheckBox cd_CW;
        private System.Windows.Forms.CheckBox cd_Speed_High;
        private System.Windows.Forms.CheckBox cd_Speed_Low;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox cb_Idle;
        private System.Windows.Forms.CheckBox cb_Moving;
        private System.Windows.Forms.CheckBox cd_HomeComp;
        private System.Windows.Forms.CheckBox cd_Comm;
    }
}