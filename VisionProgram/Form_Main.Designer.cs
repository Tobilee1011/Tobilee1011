namespace VisionProgram
{
    partial class Form_Main
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.btn_Zoom_In = new System.Windows.Forms.Button();
            this.btn_Zoom_Out = new System.Windows.Forms.Button();
            this.btn_Zoom_Org = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button20 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button21 = new System.Windows.Forms.Button();
            this.button22 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pb_Main = new System.Windows.Forms.Panel();
            this.lb_pos = new System.Windows.Forms.Label();
            this.lb_mark = new System.Windows.Forms.Label();
            this.pb_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1111, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "자동";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1111, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 65);
            this.button2.TabIndex = 1;
            this.button2.Text = "수동";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(1111, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "모델";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(1111, 251);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(118, 65);
            this.button4.TabIndex = 3;
            this.button4.Text = "비전";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Location = new System.Drawing.Point(1111, 322);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(118, 65);
            this.button5.TabIndex = 4;
            this.button5.Text = "모터 (Hexapod)";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(1111, 393);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(118, 65);
            this.button6.TabIndex = 5;
            this.button6.Text = "모터 (Soft Motion)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(1111, 464);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(118, 65);
            this.button7.TabIndex = 6;
            this.button7.Text = "캘리브레이션";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Location = new System.Drawing.Point(1111, 535);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(118, 65);
            this.button8.TabIndex = 7;
            this.button8.Text = "환경설정";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Location = new System.Drawing.Point(1111, 606);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(118, 65);
            this.button9.TabIndex = 8;
            this.button9.Text = "로그";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Location = new System.Drawing.Point(1111, 677);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(118, 65);
            this.button10.TabIndex = 9;
            this.button10.Text = "종료";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(12, 502);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(65, 53);
            this.button11.TabIndex = 11;
            this.button11.Text = "동영상";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(83, 502);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(65, 53);
            this.button12.TabIndex = 12;
            this.button12.Text = "정지영상";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // btn_Zoom_In
            // 
            this.btn_Zoom_In.Location = new System.Drawing.Point(154, 502);
            this.btn_Zoom_In.Name = "btn_Zoom_In";
            this.btn_Zoom_In.Size = new System.Drawing.Size(65, 53);
            this.btn_Zoom_In.TabIndex = 13;
            this.btn_Zoom_In.Text = "영상크게";
            this.btn_Zoom_In.UseVisualStyleBackColor = true;
            this.btn_Zoom_In.Click += new System.EventHandler(this.btn_Zoom_In_Click);
            // 
            // btn_Zoom_Out
            // 
            this.btn_Zoom_Out.Location = new System.Drawing.Point(225, 502);
            this.btn_Zoom_Out.Name = "btn_Zoom_Out";
            this.btn_Zoom_Out.Size = new System.Drawing.Size(65, 53);
            this.btn_Zoom_Out.TabIndex = 14;
            this.btn_Zoom_Out.Text = "영상작게";
            this.btn_Zoom_Out.UseVisualStyleBackColor = true;
            this.btn_Zoom_Out.Click += new System.EventHandler(this.btn_Zoom_Out_Click);
            // 
            // btn_Zoom_Org
            // 
            this.btn_Zoom_Org.Location = new System.Drawing.Point(296, 502);
            this.btn_Zoom_Org.Name = "btn_Zoom_Org";
            this.btn_Zoom_Org.Size = new System.Drawing.Size(65, 53);
            this.btn_Zoom_Org.TabIndex = 15;
            this.btn_Zoom_Org.Text = "영상 1:1";
            this.btn_Zoom_Org.UseVisualStyleBackColor = true;
            this.btn_Zoom_Org.Click += new System.EventHandler(this.btn_Zoom_Org_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(367, 502);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(65, 53);
            this.button16.TabIndex = 16;
            this.button16.Text = "화면맞춤";
            this.button16.UseVisualStyleBackColor = true;
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(438, 502);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(65, 53);
            this.button17.TabIndex = 17;
            this.button17.Text = "팬해제";
            this.button17.UseVisualStyleBackColor = true;
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(509, 502);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(65, 53);
            this.button18.TabIndex = 18;
            this.button18.Text = "오버레이지우기";
            this.button18.UseVisualStyleBackColor = true;
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(12, 561);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(65, 53);
            this.button19.TabIndex = 19;
            this.button19.Text = "시작";
            this.button19.UseVisualStyleBackColor = true;
            // 
            // button20
            // 
            this.button20.Location = new System.Drawing.Point(83, 561);
            this.button20.Name = "button20";
            this.button20.Size = new System.Drawing.Size(65, 53);
            this.button20.TabIndex = 20;
            this.button20.Text = "종료";
            this.button20.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 624);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(491, 196);
            this.listBox1.TabIndex = 21;
            // 
            // button21
            // 
            this.button21.Location = new System.Drawing.Point(509, 624);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(65, 53);
            this.button21.TabIndex = 22;
            this.button21.Text = "Clear";
            this.button21.UseVisualStyleBackColor = true;
            // 
            // button22
            // 
            this.button22.Location = new System.Drawing.Point(509, 683);
            this.button22.Name = "button22";
            this.button22.Size = new System.Drawing.Size(65, 53);
            this.button22.TabIndex = 23;
            this.button22.Text = "Save";
            this.button22.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(667, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(438, 811);
            this.panel1.TabIndex = 25;
            // 
            // pb_Main
            // 
            this.pb_Main.Controls.Add(this.lb_mark);
            this.pb_Main.Controls.Add(this.lb_pos);
            this.pb_Main.Location = new System.Drawing.Point(12, 16);
            this.pb_Main.Name = "pb_Main";
            this.pb_Main.Size = new System.Drawing.Size(640, 480);
            this.pb_Main.TabIndex = 26;
            this.pb_Main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pb_Main_MouseDown);
            this.pb_Main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pb_Main_MouseMove);
            this.pb_Main.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pb_Main_MouseUp);
            // 
            // lb_pos
            // 
            this.lb_pos.AutoSize = true;
            this.lb_pos.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_pos.ForeColor = System.Drawing.Color.Lime;
            this.lb_pos.Location = new System.Drawing.Point(18, 24);
            this.lb_pos.Name = "lb_pos";
            this.lb_pos.Size = new System.Drawing.Size(148, 12);
            this.lb_pos.TabIndex = 0;
            this.lb_pos.Text = "Mouse Pos : x = 0 , y = 0";
            // 
            // lb_mark
            // 
            this.lb_mark.AutoSize = true;
            this.lb_mark.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lb_mark.ForeColor = System.Drawing.Color.Lime;
            this.lb_mark.Location = new System.Drawing.Point(18, 36);
            this.lb_mark.Name = "lb_mark";
            this.lb_mark.Size = new System.Drawing.Size(137, 12);
            this.lb_mark.TabIndex = 1;
            this.lb_mark.Text = "Mark Pos : x = 0 , y = 0";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 842);
            this.Controls.Add(this.pb_Main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button22);
            this.Controls.Add(this.button21);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button20);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.btn_Zoom_Org);
            this.Controls.Add(this.btn_Zoom_Out);
            this.Controls.Add(this.btn_Zoom_In);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form_Main";
            this.Text = "사번 : 280380 / 팀명 : 레이저응용기술팀 / 이름 : 이명수";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Main_FormClosing);
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.pb_Main.ResumeLayout(false);
            this.pb_Main.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button btn_Zoom_In;
        private System.Windows.Forms.Button btn_Zoom_Out;
        private System.Windows.Forms.Button btn_Zoom_Org;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button20;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button button22;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pb_Main;
        private System.Windows.Forms.Label lb_pos;
        private System.Windows.Forms.Label lb_mark;
        public System.Windows.Forms.ListBox listBox1;
    }
}

