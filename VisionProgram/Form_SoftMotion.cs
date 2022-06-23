using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VisionProgram
{
    public partial class Form_SoftMotion : Form
    {
        Rectangle RectSize = new Rectangle();

        static SoftMotion softmotion = new SoftMotion();

        static int[] g_cBit;
        static int[] g_cLED;
        static int[] g_cPos;
        static bool[] g_Limit;

        static Thread mythread = new Thread(() => softmotion.CurrentBit(out g_cBit));
        static Thread mythread1 = new Thread(() => softmotion.CurrentStatus(out g_cPos, out g_Limit));
        static Thread mythread2 = new Thread(() => softmotion.ButtonCombo(g_cBit));
        static Thread mythread3 = new Thread(() => softmotion.CurrentLED(out g_cLED));
        
        public delegate void delLogSender(object oSender, string strLog);
        public event delLogSender Sub_eLogSender;

        public Form_SoftMotion()
        {
            InitializeComponent();
        }

        //Form 배치를 위한 class
        public Form_SoftMotion(int nLeft, int nTop, int nWidth, int nHeight)
        {
            RectSize.X = nLeft;
            RectSize.Y = nTop;
            RectSize.Width = nWidth;
            RectSize.Height = nHeight;

            InitializeComponent();
        }


        //디바이스 생성 및 커뮤니케이션 시작
        private void btn_MotorConnect_Click(object sender, EventArgs e)
        {
            Sub_eLogSender(sender, "btnclick");
            if (!softmotion.IsCreated())
            {
                softmotion.Create();
            }
            if (!softmotion.IsConnected())
            {

                if (mythread.IsAlive == false)
                {
                    mythread.Start();

                    Sub_eLogSender(sender, "비트 스레드 시작");
                }
                if (mythread1.IsAlive == false)
                {
                    mythread1.Start();

                    Sub_eLogSender(sender, "현재위치 스레드 시작");
                }
                if (mythread2.IsAlive == false)
                {
                    mythread2.Start();

                    Sub_eLogSender(sender, "버튼 스레드 시작");
                }
                if (mythread3.IsAlive == false)
                {
                    mythread3.Start();

                    Sub_eLogSender(sender, "LED 스레드 시작");
                }

                StatusTimer.Start();

                softmotion.StartComm();

                Sub_eLogSender(sender, "통신연결");

            }
            else
            {

                if (mythread.IsAlive == true)
                {
                    mythread.Interrupt();
                    mythread.Join();

                    Sub_eLogSender(sender, "비트 스레드 종료");
                }
                if (mythread1.IsAlive == true)
                {
                    mythread1.Interrupt();
                    mythread1.Join();

                    Sub_eLogSender(sender, "현위치 스레드 종료");
                }
                if (mythread2.IsAlive == true)
                {
                    mythread2.Interrupt();
                    mythread2.Join();

                    Sub_eLogSender(sender, "버튼 스레드 종료");
                }
                if (mythread3.IsAlive == true)
                {
                    mythread3.Interrupt();
                    mythread3.Join();

                    Sub_eLogSender(sender, "LED 스레드 종료");
                }


                StatusTimer.Stop();

                softmotion.EndComm();
                softmotion.Close();

                Sub_eLogSender(sender, "통신연결해제");

            }

        }

        //서보 온, 오프, 원점복귀
        private void btn_ServoOn_Click(object sender, EventArgs e)
        {
            softmotion.ServoOn(cb_AxisNumber.SelectedIndex);

            Sub_eLogSender(sender, "서보온");
        }

        private void btn_ServoOff_Click(object sender, EventArgs e)
        {
            softmotion.ServoOff(cb_AxisNumber.SelectedIndex);
            Sub_eLogSender(sender, "서보오프");
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            softmotion.Home(cb_AxisNumber.SelectedIndex);

            Sub_eLogSender(sender, "원점복귀");
        }

        // 모터 이동 및 상태 - 조그, 상대, 절대 
        //
        // #0 번 축 역회전 버튼
        private void btn_Motor_0_CCW_MouseDown(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStart(0, -Convert.ToInt32(tb_Motor_0_Target_Spd.Text));

                Sub_eLogSender(sender, "조그 역회전 구동중");
            }
            if (rb_Inc.Checked)
            {
                softmotion.IncMove(0, Convert.ToInt32(tb_Motor_0_Target_Spd.Text), -Convert.ToInt32(tb_Motor_0_Target_Pos.Text));

                Sub_eLogSender(sender, "상대이동 역회전 구동중");
            }
            if (rb_Abs.Checked)
            {
                softmotion.AbsMove(0, Convert.ToInt32(tb_Motor_0_Target_Spd.Text), -Convert.ToInt32(tb_Motor_0_Target_Pos.Text));

                Sub_eLogSender(sender, "절대이동 역회전 구동중");
            }

        }
        private void btn_Motor_0_CCW_MouseUp(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStop(0);
            }

            Sub_eLogSender(sender, "역회전 구동완료");
        }

        // #0번 축 정회전 버튼 
        private void btn_Motor_0_CW_MouseDown(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStart(0, Convert.ToInt32(tb_Motor_0_Target_Spd.Text));
                Sub_eLogSender(sender, "조그 정회전 구동중");
            }
            if (rb_Inc.Checked)
            {
                softmotion.IncMove(0, Convert.ToInt32(tb_Motor_0_Target_Spd.Text), Convert.ToInt32(tb_Motor_0_Target_Pos.Text));

                Sub_eLogSender(sender, "상대이동 정회전 구동중");
            }
            if (rb_Abs.Checked)
            {
                softmotion.AbsMove(0, Convert.ToInt32(tb_Motor_0_Target_Spd.Text), Convert.ToInt32(tb_Motor_0_Target_Pos.Text));

                Sub_eLogSender(sender, "절대이동 정회전 구동중");
            }
        }
        private void btn_Motor_0_CW_MouseUp(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStop(0);
            }

            Sub_eLogSender(sender, "역회전 구동완료");
        }


        // #1번 축 역회전 버튼
        private void btn_Motor_1_CCW_MouseDown(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStart(1, -Convert.ToInt32(tb_Motor_1_Target_Spd.Text));

                Sub_eLogSender(sender, "조그 역회전 구동중");
            }
            if (rb_Inc.Checked)
            {
                softmotion.IncMove(1, Convert.ToInt32(tb_Motor_1_Target_Spd.Text), -Convert.ToInt32(tb_Motor_1_Target_Pos.Text));

                Sub_eLogSender(sender, "절대위치 역회전 구동중");
            }
            if (rb_Abs.Checked)
            {
                softmotion.AbsMove(1, Convert.ToInt32(tb_Motor_1_Target_Spd.Text), -Convert.ToInt32(tb_Motor_1_Target_Pos.Text));

                Sub_eLogSender(sender, "상대위치 역회전 구동중");
            }
        }
        private void btn_Motor_1_CCW_MouseUp(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStop(1);

                Sub_eLogSender(sender, "정회전 구동완료");
            }
        }

        // #1번 축 정회전 버튼 
        private void btn_Motor_1_CW_MouseDown(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStart(1, Convert.ToInt32(tb_Motor_1_Target_Spd.Text));

                Sub_eLogSender(sender, "조그 정회전 구동중");
            }
            if (rb_Inc.Checked)
            {
                softmotion.IncMove(1, Convert.ToInt32(tb_Motor_1_Target_Spd.Text), Convert.ToInt32(tb_Motor_1_Target_Pos.Text));

                Sub_eLogSender(sender, "절대위치 정회전 구동중");
            }
            if (rb_Abs.Checked)
            {
                softmotion.AbsMove(1, Convert.ToInt32(tb_Motor_1_Target_Spd.Text), Convert.ToInt32(tb_Motor_1_Target_Pos.Text));

                Sub_eLogSender(sender, "상대위치 정회전 구동중");
            }
        }
        private void btn_Motor_1_CW_MouseUp(object sender, MouseEventArgs e)
        {
            if (rd_Jog.Checked)
            {
                softmotion.JogStop(1);

                Sub_eLogSender(sender, "정회전 구동완료");
            }
        }

        // 1,2번 축 구동정지 
        private void btn_Motor_Stop_Click(object sender, EventArgs e)
        {
            if (rb_Inc.Checked | rb_Abs.Checked)
            {
                softmotion.StopMove(0);
                softmotion.StopMove(1);
            }

            Sub_eLogSender(sender, "모터 정지");
        }

        //ui thread - 타이머부분은 정기적으로 보여주기만 하는역할임
        //LED 출력부분 
        private void StatusTimer_Tick(object sender, EventArgs e)
        {

            tb_Motor_0_Current_Pos.Text = g_cPos[0].ToString();
            tb_Motor_1_Current_Pos.Text = g_cPos[1].ToString();

            tb_Motor_0_Limit_Pos.Text = g_Limit[0].ToString();
            tb_Motor_1_Limit_Pos.Text = g_Limit[1].ToString();

            cd_Motor_0.Checked = (g_cBit[0] == 1) ? true : false;
            cd_Motor_1.Checked = (g_cBit[1] == 1) ? true : false;

            cd_Speed_Low.Checked = (g_cBit[2] == 1) ? true : false;
            cd_Speed_High.Checked = (g_cBit[3] == 1) ? true : false;

            cd_CW.Checked = (g_cBit[4] == 1) ? true : false;
            cd_CCW.Checked = (g_cBit[5] == 1) ? true : false;

            cd_Home.Checked = (g_cBit[6] == 1) ? true : false;
            cd_Sequence.Checked = (g_cBit[7] == 1) ? true : false;

            cd_Comm.Checked = (g_cLED[0] == 1) ? true : false;
            cd_HomeComp.Checked = (g_cLED[1] == 1) ? true : false;
            cb_Moving.Checked = (g_cLED[2] == 1) ? true : false;
            cb_Idle.Checked = (g_cLED[3] == 1) ? true : false;
        }

        private void Form_SoftMotion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mythread.IsAlive == true)
            {
                mythread.Interrupt();
                mythread.Abort();
            }
            if (mythread1.IsAlive == true)
            {
                mythread1.Interrupt();
                mythread1.Abort();
            }
            if (mythread2.IsAlive == true)
            {
                mythread2.Interrupt();
                mythread2.Abort();
            }
            if (mythread3.IsAlive == true)
            {
                mythread3.Interrupt();
                mythread3.Abort();
            }
        }
    }
}
