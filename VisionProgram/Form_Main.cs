using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;

namespace VisionProgram
{
    public partial class Form_Main : Form
    {

        //폼 생성 관련

        enum FormMenu { BTN_1, BTN_2, BTN_3, BTN_4, BTN_5, BTN_6, BTN_7, BTN_8, BTN_9, BTN_10 }

        static int frm_left = 0;
        static int frm_top = 0;
        static int frm_Width = 0;
        static int frm_Height = 0;

        // Vision부 
        static Vision vision;

        bool isVisionClick = false;
        Point pMarkStart;
        Size sMarkSize;
        Rectangle rMark;

        Form_Manual frm_manual = new Form_Manual(frm_left, frm_top, frm_Width, frm_Height);
        Form_SoftMotion frm_softmotion = new Form_SoftMotion(frm_left, frm_top, frm_Width, frm_Height);



        public Form_Main()
        {
            InitializeComponent();

        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_2);
 
            vision = new Vision(pb_Main, frm_manual.pb_Mark);


            frm_manual.edt_Align_TargetX.Text = (pb_Main.Width / 2).ToString();
            frm_manual.edt_Align_TargetY.Text = (pb_Main.Height / 2).ToString();
            frm_manual.edt_Align_TargetZ.Text = "0";

            frm_manual.edt_Align_OffsetX.Text = "0";
            frm_manual.edt_Align_OffsetY.Text = "0";
            frm_manual.edt_Align_OffsetZ.Text = "0";


            frm_manual.Sub_eLogSender += Main_eLogSender;
            frm_softmotion.Sub_eLogSender += Main_eLogSender;

            vision.Sub_eLogSender += Main_eLogSender;
        }

        public void Main_eLogSender(object oSender, string strLog)
        {
            Log(strLog);
        }
        public void Log(string LogDesc)
        {
             DateTime dTime = DateTime.Now;
             string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} {LogDesc}";
             listBox1.Items.Insert(0, LogInfo);
        }


        private void AllFormHide()
        {
            this.Invalidate();

            if (frm_manual != null)
            {
                frm_manual.Hide();
            }

            if (frm_softmotion != null)
            {
                frm_softmotion.Hide();
            }
            Invalidate();
        }

        private void AllFormClose()
        {
            this.Invalidate();
            if (frm_manual != null)
            {
                frm_manual.Close();
                frm_manual.Dispose();
                frm_manual = null;
            }

            if (frm_softmotion != null)
            {
                frm_softmotion.Close();
                frm_softmotion.Dispose();
                frm_softmotion = null;
            }
            Invalidate();
        }

        private void LoadMenu(FormMenu form)
        {
            Invalidate(true);

            switch (form)
            {
                case FormMenu.BTN_2:
                    {
                        AllFormHide();
                        frm_manual.TopLevel = false;
                        panel1.Controls.Add(frm_manual);
                        frm_manual.Show();
                    }
                    break;

                case FormMenu.BTN_6:
                    {
                        AllFormHide();
                        frm_softmotion.TopLevel = false;
                        panel1.Controls.Add(frm_softmotion);
                        frm_softmotion.Show();
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_1);
            Log("자동화면");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_2);
            Log("수동화면");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_3);
            Log("모델화면");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_4);
            Log("비전화면");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_5);
            Log("모터(Hexapod) 화면");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_6);
            Log("모터(Soft Motion) 화면");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_7);
            Log("캘리브레이션 화면");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_8);
            Log("환경설정 화면");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_9);
            Log("로그 화면");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            LoadMenu(FormMenu.BTN_10);
            Log("종료 버튼");
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            vision.Close();
            AllFormClose();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            vision.Live();
            Log("동영상");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            vision.Capture();
            Log("정지영상");
        }

        private void pb_Main_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                isVisionClick = true;
                pMarkStart = new Point(e.X, e.Y);
            }

        }

        private void pb_Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (isVisionClick)
            {
                isVisionClick = false;
                MarkSet();
                Log("마크 생성 완료");
            }
            int x = Convert.ToInt32(frm_manual.tb_ROI_X.Text);
            int y = Convert.ToInt32(frm_manual.tb_ROI_Y.Text);
            lb_mark.Text = "Mark Pos : x = " + x + " , y = " + y;


        }

        private void pb_Main_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {

                Point tmpP = new Point();
                if (e.X > pb_Main.Width)
                {
                    tmpP.X = pb_Main.Width - 1;
                }
                else if (e.X < 0)
                {
                    tmpP.X = 0;
                }
                else
                {
                    tmpP.X = e.X;
                }

                if (e.Y > pb_Main.Height)
                {
                    tmpP.Y = pb_Main.Height - 1;
                }
                else if (e.Y < 0)
                {
                    tmpP.Y = 0;
                }
                else
                {
                    tmpP.Y = e.Y;
                }

                int x = tmpP.X;
                int y = tmpP.Y;
                lb_pos.Text = "Mouse Pos : x = " + x + " , y = " + y;



                sMarkSize = new Size(tmpP.X - pMarkStart.X, tmpP.Y - pMarkStart.Y);
                rMark = new Rectangle(new Point(sMarkSize.Width > 0 ? pMarkStart.X : pMarkStart.X + sMarkSize.Width, sMarkSize.Height > 0 ? pMarkStart.Y : pMarkStart.Y + sMarkSize.Height),
                                      new Size(sMarkSize.Width > 0 ? sMarkSize.Width : -sMarkSize.Width, sMarkSize.Height > 0 ? sMarkSize.Height : -sMarkSize.Height));
                vision.RectUpdate(rMark);

            }
        }

        private void MarkSet()
        {

            if (vision.SetMark())
            {

                frm_manual.tb_ROI_X.Text = (rMark.X + rMark.Width / 2).ToString();  // tb_ROI_X
                frm_manual.tb_ROI_Y.Text = (rMark.Y + rMark.Height / 2).ToString(); // tb_ROI_Y

                if (vision.SaveMark())
                {
                    frm_manual.cb_ROI_Mark.Checked = true;
                }
            }

        }

        private void btn_Zoom_In_Click(object sender, EventArgs e)
        {
            vision.ZoomIn();

            Log("영상크게");
        }

        private void btn_Zoom_Out_Click(object sender, EventArgs e)
        {
            vision.ZoomOut();

            Log("영상작게");
        }

        private void btn_Zoom_Org_Click(object sender, EventArgs e)
        {
            vision.ZoomOrg();

            Log("영상1:1");
        }
    }
}
