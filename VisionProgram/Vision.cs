using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrox.MatroxImagingLibrary;
using System.Drawing;

namespace VisionProgram
{
    class Vision
    {

        public static MIL_ID MilApplication = MIL.M_NULL;      //Lv1. 최상위 모듈
        public static MIL_ID MilSystem = MIL.M_NULL;           //Lv2. 그래버 보드 관리 모듈
        public static MIL_ID MilDigitizer = MIL.M_NULL;        //Lv3. 카메라 제어 모듈

        public static MIL_ID MilDisplayMain;      //Lv3. 이미지를 화면에 출력
        public static MIL_ID MilDisplayMark;      //Lv3. 이미지를 화면에 출력

        public static MIL_ID MilGraphicContext;   //Lv3. 이미지 위에 그림을 그리는 gra모듈
        public static MIL_ID MilOverlayMain;

        public static MIL_ID MilImageMain;        //Lv3. 이미지 버퍼로 그릴 그림의 데이터를 저장 
        public static MIL_ID MilImageMarkBuffer;
        public static MIL_ID MilImageMark;

        public static MIL_ID bufSizeX;
        public static MIL_ID bufSizeY;

        public static MIL_ID pmModel = MIL.M_NULL;
        public static MIL_ID pmResult = MIL.M_NULL;

        public static MIL_ID mfModel = MIL.M_NULL;
        public static MIL_ID mfResult = MIL.M_NULL;

        public static System.Windows.Forms.Panel Panel_Main;
        public static System.Windows.Forms.Panel Panel_Mark;

        public static String ipAddress = "192.168.10.2";

        public static int TargetX = 0;
        public static int TargetY = 0;

        public static double ZoomX = 1;
        public static double ZoomY = 1;

        public static Rectangle mainRect;


        public delegate void delLogSender(object oSender, string strLog);
        public event delLogSender Sub_eLogSender;

        //생성자 입니다. - 판넬을 인자로 받음 
        public Vision()
        {

        }


        public Vision(System.Windows.Forms.Panel pb_Main, System.Windows.Forms.Panel pb_Mark)
        {
            Panel_Main = pb_Main;
            Panel_Mark = pb_Mark;

            /*----------------*/

            // 1. 최상위 모듈 할당
            MIL.MappAlloc(MIL.M_DEFAULT, ref MilApplication);

            // 2. 프레임 그래버 할당
            MIL.MsysAlloc(MIL.M_SYSTEM_GIGE_VISION, MIL.M_DEFAULT, MIL.M_DEFAULT, ref MilSystem);

            // 3. 카메라 할당
            if (MIL.MsysInquire(MilSystem, MIL.M_DIGITIZER_NUM, MIL.M_NULL) > 0) // 카메라의 갯수 체크  
            {
                MIL.MdigAlloc(MilSystem, MIL.M_GC_CAMERA_ID(ipAddress), "M_DEFAULT", MIL.M_GC_DEVICE_IP_ADDRESS, ref MilDigitizer); //카메라 할당
            }
            else 
            { 
                return;
            }

            /*----------------*/

            // 4. 화면 출력을 위한 디스플레이를 할당 
            MIL.MdispAlloc(MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, ref MilDisplayMain);
            MIL.MdispAlloc(MilSystem, MIL.M_DEFAULT, "M_DEFAULT", MIL.M_WINDOWED, ref MilDisplayMark);

            /*----------------*/

            // 카메라 통해 들어올 이미지의 사이즈를 구하고
            MIL.MdigInquire(MilDigitizer, MIL.M_SIZE_X, ref bufSizeX);
            MIL.MdigInquire(MilDigitizer, MIL.M_SIZE_Y, ref bufSizeY);

            // 버퍼 할당 & 초기화 - 카메라를 통해 들어오는 이미지 사이즈의 크기만큼을 MilImageMain 버퍼에 할당
            MIL.MbufAlloc2d(MilSystem, bufSizeX, bufSizeY, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC, ref MilImageMain);
            MIL.MbufClear(MilImageMain, 0);

            // 버퍼 할당 & 초기화 - 마크 판넬에 들어갈 이미지의 크기만큼을 MilImageMarkBuffer 버퍼에 할당
            MIL.MbufAlloc2d(MilSystem, Panel_Mark.Width, Panel_Mark.Height, 8 + MIL.M_UNSIGNED, MIL.M_IMAGE + MIL.M_GRAB + MIL.M_DISP + MIL.M_PROC, ref MilImageMarkBuffer);
            MIL.MbufClear(MilImageMarkBuffer, 0);

            /*----------------*/

            // 판넬에 디스플레이를 해줄 핸들을 받아와 MilImageMain 버퍼를 MilDisplayMain에 띄움 
            MIL.MdispSelectWindow(MilDisplayMain, MilImageMain, Panel_Main.Handle);
            MIL.MdispSelectWindow(MilDisplayMark, MilImageMarkBuffer, Panel_Mark.Handle);

            /*----------------*/

            // 이미지 위에 오버레이할 수 있는 버퍼 메모리 할당
            MIL.MdispControl(MilDisplayMain, MIL.M_OVERLAY, MIL.M_ENABLE);
            MIL.MdispControl(MilDisplayMain, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT);

            // 디스플레이할 버퍼와 연결시킬 오버레이 버퍼 인자 작성
            MIL.MdispInquire(MilDisplayMain, MIL.M_OVERLAY_ID, ref MilOverlayMain);

            /*----------------*/

            // 그래피 컨텍스트를 사용하기 위한 메모리 할당 
            MIL.MgraAlloc(MilSystem, ref MilGraphicContext);

            // 그래픽 컨트롤 관련 세팅
            MIL.MgraControl(MilGraphicContext, MIL.M_SELECTABLE, MIL.M_DISABLE);            //그래픽 컨텍스트를 선택가능하도록 할것인가 -> 아니요
            MIL.MgraControl(MilGraphicContext, MIL.M_INPUT_UNITS, MIL.M_DISPLAY);           // ???
            MIL.MgraControl(MilGraphicContext, MIL.M_BACKGROUND_MODE, MIL.M_TRANSPARENT);   // 텍스트 배경색을 어떻게 만들것인가 -> 투명색

            /*----------------*/

            // 십자선 그리기 - 생성자의 인자로 받아 타겟 위치를 업데이트함 
            TargetUpdate(Panel_Main.Width / 2, Panel_Main.Height / 2);

        }

        //소멸자 입니다. 
        ~Vision()
        {

        }
        public bool TargetUpdate(int x, int y)
        {
            //판넬의 중앙을 타겟위치로함 
            TargetX = x;
            TargetY = y;
            MainPaint();
            return true;
        }

        public bool MainPaint()
        {
            // 메인 디스플레이의 모든 오버레이 지우기 
            MIL.MdispControl(MilDisplayMain, MIL.M_OVERLAY_CLEAR, MIL.M_DEFAULT);

            // Target 그리기 (십자선) - 메인에 오버레이로 그림
            MIL.MgraColor(MilGraphicContext, MIL.M_COLOR_GREEN);
            MIL.MgraLine(MilGraphicContext, MilOverlayMain, 0, TargetY, Panel_Main.Width, TargetY); //가로줄
            MIL.MgraLine(MilGraphicContext, MilOverlayMain, TargetX, 0, TargetX, Panel_Main.Height); //세로줄

            // Mark 영역 그리기 (붉은 사각형)  - 메인에 오버레이로 그림
            MIL.MgraColor(MilGraphicContext, MIL.M_COLOR_RED);
            MIL.MgraRect(MilGraphicContext, MilOverlayMain, mainRect.X, mainRect.Y, mainRect.X + mainRect.Width, mainRect.Y + mainRect.Height);

            return true;
        }

        public bool Live()
        {
            if (MilDigitizer != MIL.M_NULL)
            {
                // 카메라를 멈추고 카메라의 이미지를 연속적으로 MilImageMain 버퍼에 저장
                MIL.MdigHalt(MilDigitizer); // 카메라 초기화 
                MIL.MdigGrabContinuous(MilDigitizer, MilImageMain);// 디지타이저를 연속해서 살려서 카메라의 이미지를 MilImageMain 버퍼에 저장
            }
            else
            {
                return false;
            }
            //영상을 받아오고 그 위에 오버레이 그리기 
            MainPaint();

            return true;
        }


        public bool Capture()
        {
            if (MilDigitizer != MIL.M_NULL)
            {
                // 카메라를 멈추고 카메라의 이미지를 MilImageMain 버퍼에 저장 
                MIL.MdigHalt(MilDigitizer);//카메라 초기화
                MIL.MdigGrab(MilDigitizer, MilImageMain);//디지타이저를 1회만 살려서 카메라의 이미지를 MilImageMain 버퍼에 저장
            }
            else
            {
                return false;
            }
            //영상을 받아오고 그 위에 오버레이 그리기 
            MainPaint();

            return true;
        }

        public bool RectUpdate(Rectangle rect)
        {
            mainRect = rect;
            MainPaint();
            return true;
        }

        public bool SetMark()
        {
            if (MilImageMark != MIL.M_NULL)
            {
                MIL.MbufFree(MilImageMark);
            }

            MIL.MbufChild2d(MilImageMain, mainRect.X, mainRect.Y, mainRect.Width, mainRect.Height, ref MilImageMark);

            MIL.MimResize(MilImageMark, MilImageMarkBuffer, (double)Panel_Mark.Width / (double)mainRect.Width, (double)Panel_Mark.Height / (double)mainRect.Height, MIL.M_DEFAULT);


            return true;
        }


        public bool SaveMark()
        {
            IntPtr markSize = MIL.M_NULL;
            MIL.MfuncInquire(MilImageMark, MIL.M_BUFFER_INFO, ref markSize);
            MIL_INT w = MIL.MfuncBufSizeX(markSize);
            MIL_INT h = MIL.MfuncBufSizeY(markSize);

            if (pmModel != MIL.M_NULL)
            {
                MIL.MpatFree(pmModel);
            }
            MIL.MpatAlloc(MilSystem, MIL.M_NORMALIZED, MIL.M_DEFAULT, ref pmModel);

            MIL.MpatDefine(pmModel, MIL.M_REGULAR_MODEL, MilImageMark, 0, 0, w, h, MIL.M_DEFAULT);

            MIL.MpatControl(pmModel, MIL.M_DEFAULT, MIL.M_ACCURACY, MIL.M_HIGH);

            MIL.MpatControl(pmModel, MIL.M_DEFAULT, MIL.M_SPEED, MIL.M_HIGH);

            MIL.MpatPreprocess(pmModel, MIL.M_DEFAULT, MilImageMark);

            if (mfModel != MIL.M_NULL)
            {
                MIL.MmodFree(mfModel);
            }
            MIL.MmodAlloc(MilSystem, MIL.M_GEOMETRIC, MIL.M_DEFAULT, ref mfModel);

            MIL.MmodDefine(mfModel, MIL.M_IMAGE, MilImageMark, 0, 0, w, h);

            MIL.MmodControl(mfModel, MIL.M_CONTEXT, MIL.M_SPEED, MIL.M_VERY_HIGH);

            MIL.MmodPreprocess(mfModel, MIL.M_DEFAULT);

            return true;

        }

        public bool PatternMatching(out int offx, out int offy, out double score)
        {
            offx = 0;
            offy = 0;
            score = 0;
            double x = 0;
            double y = 0;
            int res = 0;
            int XOrg = 0;
            int YOrg = 0;
            if (pmResult != MIL.M_NULL)
            {
                MIL.MpatFree(pmResult);
            }

            MIL.MpatAllocResult(MilSystem, MIL.M_DEFAULT, ref pmResult);

            MIL.MpatFind(pmModel, MilImageMain, pmResult);

            MIL.MpatGetResult(pmResult, MIL.M_GENERAL, MIL.M_NUMBER + MIL.M_TYPE_MIL_INT, ref res);


            if (res == 1)
            {
                MIL.MpatGetResult(pmResult, MIL.M_DEFAULT, MIL.M_POSITION_X, ref x);
                MIL.MpatGetResult(pmResult, MIL.M_DEFAULT, MIL.M_POSITION_Y, ref y);
                MIL.MpatGetResult(pmResult, MIL.M_DEFAULT, MIL.M_SCORE, ref score);

                offx = (int)x - TargetX;
                offy = (int)y - TargetY;

                // Verify the results.
                if (score < 80)
                {
                    return false;
                }

                mainRect.X = (int)x - mainRect.Width / 2;
                mainRect.Y = (int)y - mainRect.Height / 2;

                IntPtr markSize = MIL.M_NULL;
                MIL.MfuncInquire(MilImageMark, MIL.M_BUFFER_INFO, ref markSize);
                mainRect.Width = (int)MIL.MfuncBufSizeX(markSize);
                mainRect.Height = (int)MIL.MfuncBufSizeY(markSize);

                MainPaint();

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool ModelFinder(out int offx, out int offy, out double offt, out double score)
        {
            offx = 0;
            offy = 0;
            offt = 0;
            score = 0;
            double[] x = new double[16];
            double[] y = new double[16];
            double[] t = new double[16];
            double[] sc = new double[16];
            int res = 0;
            if (mfResult != MIL.M_NULL)
            {
                MIL.MmodFree(mfResult);
            }

            MIL.MmodAllocResult(MilSystem, MIL.M_DEFAULT, ref mfResult);

            MIL.MmodFind(mfModel, MilImageMain, mfResult);

            MIL.MmodGetResult(mfResult, MIL.M_DEFAULT, MIL.M_NUMBER + MIL.M_TYPE_MIL_INT, ref res);

            if (res == 1)
            {
                MIL.MmodGetResult(mfResult, MIL.M_DEFAULT, MIL.M_POSITION_X, x);
                MIL.MmodGetResult(mfResult, MIL.M_DEFAULT, MIL.M_POSITION_Y, y);
                MIL.MmodGetResult(mfResult, MIL.M_DEFAULT, MIL.M_ANGLE, t);
                MIL.MmodGetResult(mfResult, MIL.M_DEFAULT, MIL.M_SCORE, sc);

                offx = (int)x[0] - TargetX;
                offy = (int)y[0] - TargetY;
                offt = t[0];
                score = sc[0];
                // Verify the results.
                if (score < 80)
                {
                    return false;
                }

                mainRect.X = (int)x[0] - mainRect.Width / 2;
                mainRect.Y = (int)y[0] - mainRect.Height / 2;

                IntPtr markSize = MIL.M_NULL;
                MIL.MfuncInquire(MilImageMark, MIL.M_BUFFER_INFO, ref markSize);
                mainRect.Width = (int)MIL.MfuncBufSizeX(markSize);
                mainRect.Height = (int)MIL.MfuncBufSizeY(markSize);

                MainPaint();

                return true;
            }
            else
            {
                return false;
            }
        }


        public bool MarkExport(String str = "Manual")
        {
            if (MilImageMark == MIL.M_NULL)
            {
                return false;
            }
            String path = "C:\\Image\\Mark\\" + str + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".mim";
            MIL.MbufSave(path, MilImageMark);

            return true;
        }

        public bool MarkImport(String path)
        {
            IntPtr markSize = MIL.M_NULL;
            MIL.MbufImport(path, MIL.M_MIL, MIL.M_RESTORE, MilSystem, ref MilImageMark);
            MIL.MfuncInquire(MilImageMark, MIL.M_BUFFER_INFO, ref markSize);
            MIL_INT x = MIL.MfuncBufSizeX(markSize);
            MIL_INT y = MIL.MfuncBufSizeY(markSize);
            MIL.MimResize(MilImageMark, MilImageMarkBuffer, (double)Panel_Mark.Width / (double)MIL.MfuncBufSizeX(markSize), (double)Panel_Mark.Height / (double)MIL.MfuncBufSizeY(markSize), MIL.M_DEFAULT);
            return true;
        }



        public bool Close()
        {
            // 패턴 매칭 메모리 해제
            if (pmModel != MIL.M_NULL)
            {
                MIL.MpatFree(pmModel);
            }
            if (pmResult != MIL.M_NULL)
            {
                MIL.MpatFree(pmResult);
            }

            // 모델 파인더 메모리 해제
            if (mfModel != MIL.M_NULL)
            {
                MIL.MmodFree(mfModel);
            }
            if (mfResult != MIL.M_NULL)
            {
                MIL.MmodFree(mfResult);
            }


            // 영상이 재생중이면 Digitizer가 살아있으므로 영상을 멈춤 
            MIL.MdigHalt(MilDigitizer);

            // 이미지 버퍼 메모리 해제 - 이미지 데이터를 저장하는 공간 
            if (MilImageMarkBuffer != MIL.M_NULL)
            {
                MIL.MbufFree(MilImageMarkBuffer);
            }
            if (MilImageMark != MIL.M_NULL)
            {
                MIL.MbufFree(MilImageMark);
            }
            if (MilImageMain != MIL.M_NULL)
            {
                MIL.MbufFree(MilImageMain);
            }


            // 그래픽 컨텍스트 해제 - 이미지 위에 그리는 일종의 그림판
            if (MilGraphicContext != MIL.M_NULL)
            {
                MIL.MgraFree(MilGraphicContext);
            }


            //메인, 마크 디스플레이 메모리 해제 - 버퍼 안에 있는 메모리를 표현하는 곳
            if (MilDisplayMain != MIL.M_NULL)
            {
                MIL.MdispFree(MilDisplayMain);
            }
            if (MilDisplayMark != MIL.M_NULL)
            {
                MIL.MdispFree(MilDisplayMark);
            }

            // 디지타이저(카메라), 시스템, 어플리케이션 메모리 해제
            if (MilDigitizer != MIL.M_NULL)
            {
                MIL.MdigFree(MilDigitizer);
            }
            if (MilSystem != MIL.M_NULL)
            {
                MIL.MsysFree(MilSystem);
            }
            if (MilApplication != MIL.M_NULL)
            {
                MIL.MappFree(MilApplication);
            }

            return true;
        }


        public bool ZoomIn()
        {
            ZoomX = ZoomX * 1.2;
            ZoomY = ZoomY * 1.2;

            MIL.MdispZoom(MilDisplayMain, ZoomX, ZoomY);
            return true;
        }

        public bool ZoomOut()
        {
            if (ZoomX > 1)
            {
                ZoomX = ZoomX / 1.2;
                ZoomY = ZoomY / 1.2;

                MIL.MdispZoom(MilDisplayMain, ZoomX, ZoomY);
            }
            else if (ZoomX<= 1)
            {
                ZoomX = 1;
                ZoomY = 1;

                MIL.MdispZoom(MilDisplayMain, ZoomX, ZoomY);

            }
                return true;
        }

        public bool ZoomOrg()
        {
            if (ZoomX != 1)
            {
                ZoomX = 1;
                ZoomY = 1;

                MIL.MdispZoom(MilDisplayMain, ZoomX, ZoomY);
            }
            return true;
        }







    }
}
