namespace KangShuoTech.Utilities.CommunicationData
{
    using System;
    using System.Threading;

    internal class ClsQCTDEVICEBF : ClsQCTDevice
    {
        private byte bAge;
        private byte bHeight;
        private byte bSex;
        private byte[] CommandWrite;
        private int m_Bhour;
        private int m_Bminu;

        public ClsQCTDEVICEBF(ClsCommunication comm, string sex, string age, string height, int bfHour, int bfMinu)
        {
            base.m_Comm = comm;
            base.m_delay = 0xbb8;
            this.m_Bhour = bfHour;
            this.m_Bminu = bfMinu;
            this.bSex = Convert.ToByte(sex);
            this.bAge = Convert.ToByte(age);
            this.bHeight = Convert.ToByte(height);
            this.CommandWrite = new byte[11];
            DateTime now = DateTime.Now;
            byte num = (this.bSex != 1) ? ((byte) 0) : Convert.ToByte((sbyte) (-128));
            this.CommandWrite[0] = 170;
            this.CommandWrite[1] = 10;
            this.CommandWrite[2] = 0x53;
            this.CommandWrite[3] = 11;
            this.CommandWrite[4] = 0;
            this.CommandWrite[5] = (byte) (this.bAge + num);
            this.CommandWrite[6] = this.bHeight;
            this.CommandWrite[7] = 1;
            this.CommandWrite[8] = Convert.ToByte(now.Hour);
            this.CommandWrite[9] = Convert.ToByte(now.Minute);
            this.CommandWrite[10] = (byte) (((((0xf8 ^ this.CommandWrite[5]) ^ this.CommandWrite[6]) ^ 1) ^ this.CommandWrite[8]) ^ this.CommandWrite[9]);
        }

        public override bool ExecClose()
        {
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            Thread.Sleep(300);
            base.m_Comm.Send(this.CommandClose);
            return true;
        }

        public override bool ExecQuery()
        {
            try
            {
                byte[] resultData = null;
                int num = 0;
                base.ResultData = new byte[5];
                base.m_Comm.SetTimeOut(0x2710);
                ClsResult.DeviceMsg = "";
                ClsResult.DeviceName = "QCTBF";
                ClsResult.DeviceFriendName = "人体成分";
                ClsResult.DeviceAddress = "";
                base.m_Comm.Send(this.CommandQuery);
                Thread.Sleep(500);
                base.m_Comm.Recv(ref this.ResultData, 5);
                if (base.ResultData[3] != 0)
                {
                    Thread.Sleep(700);
                    base.m_Comm.Send(this.CommandWrite);
                    Thread.Sleep(500);
                    this.m_Bhour = this.CommandWrite[8];
                    this.m_Bminu = this.CommandWrite[9];
                    ClsTransInfo.m_BFHour = this.m_Bhour;
                    ClsTransInfo.m_BFMinu = this.m_Bminu;
                    ClsResult.DeviceMsg = "参数设置已经完成,请进行测量.";
                    return true;
                }
                ClsResult.DeviceMsg = "";
                base.ResultData = new byte[0x22];
                base.m_Comm.Send(this.CommandRead);
                Thread.Sleep(500);
                int num2 = base.m_Comm.Recv(ref this.ResultData, 0x22);
                if (num2 == 0x22)
                {
                    num = base.ResultData[2];
                    if ((num - num2) > 0)
                    {
                        byte[] data = new byte[num - num2];
                        int num3 = base.m_Comm.Recv(ref data, num - num2);
                        if (num3 == (num - num2))
                        {
                            resultData = new byte[num];
                            for (int i = 0; i < 0x22; i++)
                            {
                                resultData[i] = base.ResultData[i];
                            }
                            for (int j = 0; j < num3; j++)
                            {
                                resultData[j + 0x22] = data[j];
                            }
                        }
                    }
                    else
                    {
                        num = 0x22;
                        resultData = base.ResultData;
                    }
                }
                Thread.Sleep(200);
                base.m_Comm.Send(this.CommandClose);
                Thread.Sleep(500);
                base.m_Comm.Send(this.CommandClose);
                if (resultData != null)
                {
                    TimeSpan span = (TimeSpan) (new DateTime(1, 1, 1, resultData[11], resultData[12], 0) - new DateTime(1, 1, 1, this.m_Bhour, this.m_Bminu, 0));
                    double totalSeconds = span.TotalSeconds;
                    this.m_Bhour = 0;
                    this.m_Bminu = 0;
                    if ((span.TotalSeconds < 0.0) || (span.TotalSeconds > 180.0))
                    {
                        ClsResult.DeviceMsg = "测量结果的时间与下发参数时间不匹配,请重新测量。";
                        ClsResult.ResultFlag = false;
                        return true;
                    }
                    int num6 = num - 0x22;
                    double num7 = ((resultData[num6 + 0x11] * 0x100) + resultData[num6 + 0x12]) * 0.1;
                    byte num16 = resultData[num6 + 0x13];
                    byte num17 = resultData[num6 + 20];
                    double num8 = resultData[num6 + 0x15] * 0.1;
                    double num9 = ((resultData[num6 + 0x16] * 0x100) + resultData[num6 + 0x17]) * 0.1;
                    byte num10 = resultData[num6 + 0x18];
                    long num11 = (resultData[num6 + 0x19] * 0x100) + resultData[num6 + 0x1a];
                    double num12 = ((resultData[num6 + 0x1b] * 0x100) + resultData[num6 + 0x1c]) * 0.1;
                    double num13 = ((resultData[num6 + 0x1d] * 0x100) + resultData[num6 + 30]) * 0.1;
                    long num14 = (resultData[num6 + 0x1f] * 0x100) + resultData[num6 + 0x20];
                    double num15 = (1.0 - ((((((12.226 + ((9.058 * (Convert.ToDouble(this.bHeight) / 100.0)) * (Convert.ToDouble(this.bHeight) / 100.0))) + (0.32 * num7)) - (0.0068 * Convert.ToDouble(num11))) - (6.351 * ((this.bSex != 1) ? 0.75 : 0.55))) - (0.0542 * Convert.ToDouble(this.bAge))) / num7)) * 100.0;
                    if (num15 > 60.0)
                    {
                        num15 = 60.0;
                    }
                    else if (num15 < 5.0)
                    {
                        num15 = 5.0;
                    }
                    ClsResult.DeviceValue = new valueItem();
                    ClsResult.DeviceValue.QCTBF.TiZhong = num7.ToString();
                    ClsResult.DeviceValue.QCTBF.ZhiFang = num15.ToString("0.0");
                    ClsResult.DeviceValue.QCTBF.GuLiang = num8.ToString();
                    ClsResult.DeviceValue.QCTBF.JiRou = num9.ToString();
                    ClsResult.DeviceValue.QCTBF.NeiZhi = num10.ToString();
                    ClsResult.DeviceValue.QCTBF.ZuKang = num11.ToString();
                    ClsResult.DeviceValue.QCTBF.BMI = num12.ToString();
                    ClsResult.DeviceValue.QCTBF.ShuiFen = num13.ToString();
                    ClsResult.DeviceValue.QCTBF.JiChuDaiXie = num14.ToString();
                    ClsResult.ResultFlag = true;
                    return true;
                }
                this.m_Bhour = 0;
                this.m_Bminu = 0;
                ClsResult.ResultFlag = false;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public override byte[] CommandClose
        {
            get
            {
                return new byte[] { 170, 10, 0x31, 6, 0, 0x97 };
            }
        }

        public override byte[] CommandQuery
        {
            get
            {
                return new byte[] { 170, 10, 0x20, 6, 0, 0x86 };
            }
        }

        public override byte[] CommandRead
        {
            get
            {
                return new byte[] { 170, 10, 0x29, 6, 0, 0x8f };
            }
        }
    }
}

