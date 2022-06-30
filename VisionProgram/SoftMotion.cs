using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMX3ApiCLR;
using System.Threading;

//vision관련 프로그램임 

namespace VisionProgram
{
    class SoftMotion
    {
        public static WMX3Api wmxlib = new WMX3Api();
        public static CoreMotion wmxlib_cm = new CoreMotion(wmxlib);
        public static Motion.JogCommand jog = new Motion.JogCommand();
        public static Motion.PosCommand pos = new Motion.PosCommand();
        public static Motion.LinearIntplCommand lin;
        public static Io io = new Io(wmxlib);
        public static CoreMotionStatus cmStatus = new CoreMotionStatus();
        public static CoreMotionAxisStatus[] axisstatus;

        public static AxisControl axiscontrol;

        public static bool isCreated = false;
        public static bool isConnected = false;
        public static bool[] isServoOn = new bool[2];
        public static bool[] isHomeComplete = new bool[2];

        public static byte inData = 0;
        public static int[] bitInput;

        //생성자 입니다.
        public SoftMotion()
        {
        }

        //디바이스 생성
        public bool Create()
        {
            if (isCreated)
            {
                return false;
            }
            wmxlib.CreateDevice("C:\\Program Files\\SoftServo\\WMX3", DeviceType.DeviceTypeNormal);
            isCreated = true;
            return true;
        }
        //디바이스 삭제
        public bool Close()
        {
            if (!isCreated)
            {
                return false;
            }
            wmxlib.CloseDevice();
            isCreated = false;
            return true;
        }

        //디바이스 상태 리턴
        public bool IsCreated()
        {
            if (isCreated)
            {
                isCreated = true;
                return true;
            }
            else
            {
                isCreated = false;
                return false;
            }
        }

        //커뮤니케이션 시작
        public bool StartComm()
        {
            if (isConnected)
            {
                return false;
            }
            wmxlib.StartCommunication(10000);
            isConnected = true;
            return true;
        }

        //커뮤니케이션 종료
        public bool EndComm()
        {
            if (!isConnected)
            {
                return false;
            }
            wmxlib.StopCommunication(10000);
            isConnected = false;
            return true;
        }

        //커뮤니케이션상태 리턴
        public bool IsConnected()
        {
            if (isConnected)
            {
                isConnected = true;
                return true;
            }
            else
            {
                isConnected = false;
                return false;
            }
        }
        //서보온
        public bool ServoOn(int Axis)
        {
            if (isServoOn[Axis])
            {
                return false;
            }
            wmxlib_cm.AxisControl.SetServoOn(Axis, 1);
            isServoOn[Axis] = true;
            isHomeComplete[Axis] = false;
            return true;
        }

        //서보오프
        public bool ServoOff(int Axis)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            wmxlib_cm.AxisControl.SetServoOn(Axis, 0);
            isServoOn[Axis] = false;
            return true;
        }

        //홈잉
        public bool Home(int Axis)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            wmxlib_cm.Home.StartHome(Axis); 
            isHomeComplete[Axis] = true;
            return true;
        }

        //조그시작
        public bool JogStart (int Axis, int Speed)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            if (!isHomeComplete[Axis])
            {
                return false;
            }

            jog.Axis = Axis;
            jog.Profile.Type = ProfileType.Trapezoidal;
            jog.Profile.Velocity = Speed;
            jog.Profile.Acc = Speed > 0 ? Speed * 10 : -Speed * 10;
            jog.Profile.Dec = Speed > 0 ? Speed * 10 : -Speed * 10;

            wmxlib_cm.Motion.StartJog(jog);

            return true;
        }

        //조그정지
        public bool JogStop(int Axis)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            if (!isHomeComplete[Axis])
            {
                return false;
            }
            wmxlib_cm.Motion.Stop(Axis);
            return true;
        }

        //상대위치이동
        public bool IncMove(int Axis, int Speed, int Target)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            if (!isHomeComplete[Axis])
            {
                return false;
            }

            pos.Axis = Axis;
            pos.Profile.Type = ProfileType.Trapezoidal;
            pos.Profile.Velocity = Speed;
            pos.Profile.Acc = Speed * 10;
            pos.Profile.Dec = Speed * 10;
            pos.Target = Target;

            wmxlib_cm.Motion.StartMov(pos);

            return true;
        }

        //절대위치이동
        public bool AbsMove(int Axis, int Speed, int Target)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            if (!isHomeComplete[Axis])
            {
                return false;
            }
            pos.Axis = Axis;
            pos.Profile.Type = ProfileType.Trapezoidal;
            pos.Profile.Velocity = Speed;
            pos.Profile.Acc = Speed * 10;
            pos.Profile.Dec = Speed * 10;
            pos.Target = Target;

            wmxlib_cm.Motion.StartPos(pos);

            return true;
        }

        //구동정지
        public bool StopMove(int Axis)
        {
            if (!isServoOn[Axis])
            {
                return false;
            }
            if (!isHomeComplete[Axis])
            {
                return false;
            }
            wmxlib_cm.Motion.Stop(Axis);

            return true;
        }

        //현재위치, Limit 센서 상태 Thread
        public void CurrentStatus(out int[] cPos, out bool []Limit)
        {
            cPos = new int[2];
            Limit = new bool[2];

            bool[] nLimit = new bool[2];
            bool[] pLimit = new bool[2];
            try
            {

                while (true)
                {
                    wmxlib_cm.GetStatus(ref cmStatus);

                    axisstatus = cmStatus.AxesStatus;

                    cPos[0] = (int)axisstatus[0].ActualPos;
                    cPos[1] = (int)axisstatus[1].ActualPos;

                    nLimit[0] = axisstatus[0].NegativeLS;
                    nLimit[1] = axisstatus[1].NegativeLS;

                    pLimit[0] = axisstatus[0].PositiveLS;
                    pLimit[1] = axisstatus[1].PositiveLS;

                    Limit[0] = nLimit[0] | pLimit[0];
                    Limit[1] = nLimit[1] | pLimit[1];

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException e)
            {
                return;
            }

        }

        // 현재 비트의 상태 (버튼) Thread
        public void CurrentBit(out int[] cBit)
        {
            cBit = new int[8];
            try
            {
                while (true)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        io.GetInBit(8, i, ref inData);
                        cBit[i] = inData;
                    }

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException e)
            {
                return;
            }
        }

        public void CurrentLED(out int[] cLED)
        {
            cLED = new int[8];

            try
            {
                while (true)
                {
                    wmxlib_cm.GetStatus(ref cmStatus);

                    axisstatus = cmStatus.AxesStatus;

                    if(isConnected == true)
                    {
                        cLED[0] = 1;
                    }
                    else
                    {
                        cLED[0] = 0;
                    }

                    if ((axisstatus[0].HomeDone == true) & (axisstatus[0].HomeDone == true))
                    {
                        cLED[1] = 1;
                    }
                    else
                    {
                        cLED[1] = 0;
                    }

                    if ((cmStatus.AxesStatus[0].OpState == 0)|| (cmStatus.AxesStatus[1].OpState == 0))
                    {
                        cLED[2] = 0;
                        cLED[3] = 1;
                    }

                    if ((cmStatus.AxesStatus[0].OpState != 0)|| (cmStatus.AxesStatus[1].OpState != 0))
                    {
                        cLED[2] = 1;
                        cLED[3] = 0;
                    }
                    
                    for (int i = 0; i < 8; i++)
                    {

                        io.SetOutBit(4, i, (byte) cLED[i]);

                    }

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException e)
            {
                return;
            }
        }





        // 스레드 슬립타임으로 인한 문제 - 버튼을 아무것도 안누르는 상황을 조그가 구동중인상태에서 발생시키면 Jog Stop이 먹지 않는다. 
        public void ButtonCombo(int[] g_cBit)
        {

            try
            {
                while (true)
                {
                    wmxlib_cm.GetStatus(ref cmStatus);
                    
                    if (g_cBit[0] == 1)
                    {

                        //0번 모터 조합 

                        if ((g_cBit[0] * g_cBit[6] == 1))
                        {
                            Home(0);
                        }

                        if ((g_cBit[0] * g_cBit[2] * g_cBit[4] == 1))
                        {
                            if (cmStatus.AxesStatus[0].OpState == 0)
                            {
                                JogStart(0, 10000);
                            }
                        }

                        if ((g_cBit[0] * g_cBit[2] * g_cBit[5] == 1))
                        {
                            if (cmStatus.AxesStatus[0].OpState == 0)
                            {
                                JogStart(0, -10000);
                            }
                        }


                        if ((g_cBit[0] * g_cBit[3] * g_cBit[4] == 1))
                        {
                            if (cmStatus.AxesStatus[0].OpState == 0)
                            {
                                JogStart(0, 30000);
                            }
                        }

                        if ((g_cBit[0] * g_cBit[3] * g_cBit[5] == 1))
                        {
                            if (cmStatus.AxesStatus[0].OpState == 0)
                            {
                                JogStart(0, -30000);
                            }
                        }

                        if ((g_cBit[0] * g_cBit[2] * g_cBit[4] != 1) & (g_cBit[0] * g_cBit[2] * g_cBit[5] != 1) & (g_cBit[0] * g_cBit[3] * g_cBit[4] != 1) & (g_cBit[0] * g_cBit[3] * g_cBit[5] != 1))
                        {
                            JogStop(0);
                        }
                    }

                    if (g_cBit[1] == 1)
                    {

                        //1번 모터 조합 

                        if ((g_cBit[1] * g_cBit[6] == 1))
                        {
                            Home(1);
                        }

                        if ((g_cBit[1] * g_cBit[2] * g_cBit[4] == 1) & (cmStatus.AxesStatus[0].OpState == 0))
                        {
                            if (cmStatus.AxesStatus[1].OpState == 0)
                            {
                                JogStart(1, 10000);
                            }
                        }
                        if ((g_cBit[1] * g_cBit[2] * g_cBit[5] == 1))
                        {
                            if (cmStatus.AxesStatus[1].OpState == 0)
                            {
                                JogStart(1, -10000);
                            }
                        }

                        if ((g_cBit[1] * g_cBit[3] * g_cBit[4] == 1))
                        {
                            if (cmStatus.AxesStatus[1].OpState == 0)
                            {
                                JogStart(1, 30000);
                            }
                        }

                        if ((g_cBit[1] * g_cBit[3] * g_cBit[5] == 1))
                        {
                            if (cmStatus.AxesStatus[1].OpState == 0)
                            {
                                JogStart(1, -30000);
                            }
                        }

                        if ((g_cBit[1] * g_cBit[2] * g_cBit[4] != 1) & (g_cBit[1] * g_cBit[2] * g_cBit[5] != 1) & (g_cBit[1] * g_cBit[3] * g_cBit[4] != 1) & (g_cBit[1] * g_cBit[3] * g_cBit[5] != 1))
                        {
                            JogStop(1);
                        }
                    }


                    if ((g_cBit[0] + g_cBit[1] + g_cBit[2] + g_cBit[3] + g_cBit[4] + g_cBit[5] + g_cBit[6] + g_cBit[7] == 0))
                    {

                    }
                    else if (g_cBit[0] != 1)
                    {
                        JogStop(0);
                    }


                    if (g_cBit[0] + g_cBit[1] + g_cBit[2] + g_cBit[3] + g_cBit[4] + g_cBit[5] + g_cBit[6] + g_cBit[7] == 0) //아무버튼을 안누르면
                    {

                    }
                    else if (g_cBit[1] != 1)
                    {
                        JogStop(1);
                    }

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException e)
            {
                return;
            }

        }

    }

}
