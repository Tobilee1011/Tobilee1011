using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Matrox.MatroxImagingLibrary;
using System.IO;

namespace VisionProgram
{
    public partial class Form_Manual : Form
    {

        public MIL_ID ABCD;

        Rectangle RectSize = new Rectangle();

        int patOffsetX = 0;
        int patOffsetY = 0;
        int modOffsetX = 0;
        int modOffsetY = 0;
        double modOffsetT = 0;

        public delegate void delLogSender(object oSender,string strLog);
        public event delLogSender Sub_eLogSender;


        public Form_Manual()
        {
            InitializeComponent();
        }

        public Form_Manual(int nLeft, int nTop, int nWidth, int nHeight)
        {
            RectSize.X = nLeft;
            RectSize.Y = nTop;
            RectSize.Width = nWidth;
            RectSize.Height = nHeight;

            InitializeComponent();
        }


        private void edt_Align_Target_TextChanged(object sender, EventArgs e)
        {

            Vision vision = new Vision();

            try
            {
                tb_Correction_TargetX.Text = (Convert.ToInt32(edt_Align_TargetX.Text) + Convert.ToInt32(edt_Align_OffsetX.Text)).ToString();
                tb_Correction_TargetY.Text = (Convert.ToInt32(edt_Align_TargetY.Text) + Convert.ToInt32(edt_Align_OffsetY.Text)).ToString();
                vision.TargetUpdate(Convert.ToInt32(edt_Align_TargetX.Text) + Convert.ToInt32(edt_Align_OffsetX.Text), Convert.ToInt32(edt_Align_TargetY.Text) + Convert.ToInt32(edt_Align_OffsetY.Text));

            }
            catch
            {
                edt_Align_OffsetX.Text = "0";
                edt_Align_OffsetY.Text = "0";
                edt_Align_OffsetZ.Text = "0";
            }

        }

        private void btn_Data_Set_Click(object sender, EventArgs e)
        {

            Vision vision = new Vision();
            try
            {
                tb_Correction_TargetX.Text = (Convert.ToInt32(edt_Align_TargetX.Text) + Convert.ToInt32(edt_Align_OffsetX.Text)).ToString();
                tb_Correction_TargetY.Text = (Convert.ToInt32(edt_Align_TargetY.Text) + Convert.ToInt32(edt_Align_OffsetY.Text)).ToString();
                vision.TargetUpdate(Convert.ToInt32(edt_Align_TargetX.Text) + Convert.ToInt32(edt_Align_OffsetX.Text), Convert.ToInt32(edt_Align_TargetY.Text) + Convert.ToInt32(edt_Align_OffsetY.Text));

            }
            catch
            {
                edt_Align_OffsetX.Text = "0";
                edt_Align_OffsetY.Text = "0";
                edt_Align_OffsetZ.Text = "0";
            }
            Sub_eLogSender(sender, "타겟위치변경");
        }






        private void btn_Mark_Set_Click(object sender, EventArgs e)
        {

        }

        private void btn_Mark_Pattern_Click(object sender, EventArgs e)
        {
            Sub_eLogSender(sender, "패턴매칭버튼 클릭됨");
            Vision vision = new Vision();
            if (!cb_ROI_Mark.Checked)
            {
                Sub_eLogSender(sender, "마크 체크박스가 클릭되어있지 않습니다.");
                return;
            }
            if (vision.PatternMatching(out patOffsetX, out patOffsetY, out double score))
            {
                Sub_eLogSender(sender, "패턴매칭이 실행됨");
                tb_Correction_CurrentX.Text = (patOffsetX + Convert.ToInt32(tb_Correction_TargetX.Text)).ToString();
                tb_Correction_CurrentY.Text = (patOffsetY + Convert.ToInt32(tb_Correction_TargetY.Text)).ToString();
                tb_Correction_CurrentZ.Text = "0";

                tb_Correction_MoveX.Text = (patOffsetX).ToString();
                tb_Correction_MoveY.Text = (patOffsetY).ToString();
                tb_Correction_MoveZ.Text = "0";

                rb_Correction_Pattern.Checked = true;
            }
            else
            {
                Sub_eLogSender(sender, "패턴매칭이 실행되지 않았습니다.");
            }
        }

        private void btn_Mark_ModelFinder_Click(object sender, EventArgs e)
        {

            if (!cb_ROI_Mark.Checked)
            {
                Sub_eLogSender(sender, "마크 체크박스가 클릭되어있지 않습니다.");
                return;
            }

            Vision vision = new Vision();

            if (vision.ModelFinder(out modOffsetX, out modOffsetY, out modOffsetT, out double score))
            {
                Sub_eLogSender(sender, "모델파인더가 실행됨");
                tb_Correction_CurrentX.Text = (modOffsetX + Convert.ToInt32(tb_Correction_TargetX.Text)).ToString();
                tb_Correction_CurrentY.Text = (modOffsetY + Convert.ToInt32(tb_Correction_TargetY.Text)).ToString();
                tb_Correction_CurrentZ.Text = (modOffsetT/* + Convert.ToInt32(edt_Correction_TargetT.Text)*/).ToString();

                tb_Correction_MoveX.Text = (modOffsetX).ToString();
                tb_Correction_MoveY.Text = (modOffsetY).ToString();
                tb_Correction_MoveZ.Text = (modOffsetT).ToString();

                rb_Correction_Model.Checked = true;

            }
            else
            {
                Sub_eLogSender(sender, "모델파인더가 실행되지 않았습니다.");
            }
        }






        private void btn_Align_Move_Click(object sender, EventArgs e)
        {
            SoftMotion softmotion = new SoftMotion();
            softmotion.IncMove(0, 100000, Convert.ToInt32(tb_Correction_MoveX.Text) * 100);
            softmotion.IncMove(1, 10000, Convert.ToInt32(tb_Correction_MoveY.Text) * 100);
            Sub_eLogSender(sender, "순차보정 이동");
        }


        private void btn_Measure_Click(object sender, EventArgs e)
        {
            if (rb_Correction_Pattern.Checked == true)
            {
                Vision vision = new Vision();

                if (vision.PatternMatching(out patOffsetX, out patOffsetY, out double score))
                {
                    Sub_eLogSender(sender, "패턴매칭으로 측정됨");

                    tb_Correction_CurrentX.Text = (patOffsetX + Convert.ToInt32(tb_Correction_TargetX.Text)).ToString();
                    tb_Correction_CurrentY.Text = (patOffsetY + Convert.ToInt32(tb_Correction_TargetY.Text)).ToString();
                    tb_Correction_CurrentZ.Text = "0";

                    tb_Correction_MoveX.Text = (patOffsetX).ToString();
                    tb_Correction_MoveY.Text = (patOffsetY).ToString();
                    tb_Correction_MoveZ.Text = "0";

                    rb_Correction_Pattern.Checked = true;

                }
            }
            else if (rb_Correction_Model.Checked == true)
            {
                Vision vision = new Vision();

                if (vision.ModelFinder(out modOffsetX, out modOffsetY, out modOffsetT, out double score))
                {
                    Sub_eLogSender(sender, "모델파인더로 측정됨");

                    tb_Correction_CurrentX.Text = (modOffsetX + Convert.ToInt32(tb_Correction_TargetX.Text)).ToString();
                    tb_Correction_CurrentY.Text = (modOffsetY + Convert.ToInt32(tb_Correction_TargetY.Text)).ToString();
                    tb_Correction_CurrentZ.Text = (modOffsetT/* + Convert.ToInt32(edt_Correction_TargetT.Text)*/).ToString();

                    tb_Correction_MoveX.Text = (modOffsetX).ToString();
                    tb_Correction_MoveY.Text = (modOffsetY).ToString();
                    tb_Correction_MoveZ.Text = (modOffsetT).ToString();

                    rb_Correction_Model.Checked = true;
                }
            }
        }

        private void btn_Mark_Save_Click(object sender, EventArgs e)
        {
            Vision vision = new Vision();
            vision.MarkExport();

            Sub_eLogSender(sender, "마크 저장 - 경로 : C드라이브 이미지 폴더");
        }

        private void btn_Mark_Load_Click(object sender, EventArgs e)
        {
            Vision vision = new Vision();

            using (OpenFileDialog OD = new OpenFileDialog())
            {
                OD.InitialDirectory = "C:\\Image\\Mark";
                if (OD.ShowDialog() == DialogResult.OK)
                {
                    if (vision.MarkImport(OD.FileName))
                    {
                        if (vision.SaveMark())
                        {
                            cb_ROI_Mark.Checked = true;

                            Sub_eLogSender(sender, "마크 로드 됨 ");
                        }
                    }
                }
            }
        }

        private void btn_Align_Save_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String FilePath = saveFileDialog.FileName;
                    if (!Equals(FilePath.Substring(FilePath.Length - 4), ".txt"))
                    {
                        FilePath += ".txt";
                    }
                    StreamWriter SW = new StreamWriter(FilePath);

                    SW.WriteLine(edt_Align_TargetX.Text);
                    SW.WriteLine(edt_Align_TargetY.Text);
                    SW.WriteLine(edt_Align_TargetZ.Text);
                    SW.WriteLine(edt_Align_OffsetX.Text);
                    SW.WriteLine(edt_Align_OffsetY.Text);
                    SW.WriteLine(edt_Align_OffsetZ.Text);

                    SW.Close();

                    Sub_eLogSender(sender, "얼라인 타겟과 옵셋 저장  ");
                }
            }
        }

        private void btn_Align_Open_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "csv files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    String FilePath = openFileDialog.FileName;
                    StreamReader SR = new StreamReader(FilePath);
                    String[] tmpS = new string[6];
                    for (int i = 0; i < 6; i++)
                    {
                        tmpS[i] = SR.ReadLine();
                    }

                    edt_Align_TargetX.Text = tmpS[0];
                    edt_Align_TargetY.Text = tmpS[1];
                    edt_Align_TargetZ.Text = tmpS[2];
                    edt_Align_OffsetX.Text = tmpS[3];
                    edt_Align_OffsetY.Text = tmpS[4];
                    edt_Align_OffsetZ.Text = tmpS[5];

                    SR.Close();

                    Sub_eLogSender(sender, "얼라인 타겟과 옵셋 열기  ");
                }
            }
        }

    }
}
