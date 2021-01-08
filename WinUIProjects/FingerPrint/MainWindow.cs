using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Timers;

namespace FingerPrint
{
    public partial class MainWindow : Form
    {
        // USB
        public static USBComm m_clsUSB;

        public static SerialCom m_clsSerial;

        // Command
        public static CommandProc m_clsCmdProc;

        public string WindowType { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            fbll.DeleteFingerInfo();
        }

        public void DisplayCommandPacket()
        {
        }

        public void ProcessMessage(uint p_nMessage, int p_nWParam, int p_nLParam)
        {
            switch (p_nMessage)
            {
                case CommonDefine.WM_RECEIVE:
                    if (p_nWParam == 1)
                        ProcessRspPacket(true);
                    else
                        ProcessRspPacket(false);
                    break;
                case CommonDefine.WM_DISPLAY_PACKET:
                    DisplayCommandPacket();
                    break;
                case CommonDefine.WM_USER_UPDATE_0:
                    break;
                default:
                    break;
            }
        }

        public void ProcessRspPacket(bool p_bRet)
        {
            if (p_bRet == false)
            {
                //MessageBox.Show("接收错误! \n 请检查连接和目标", CommonDefine.MSG_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            //. Display response packet
            DisplayResponsePacket(CommandProc.GET_PACKET_COMMAND(false));
            return;
        }

        bool checkOK = false;
        bool goToAdd = false;
        string saveID = "";

        string loginID = "";
        public void DisplayResponsePacket(ushort p_nCode)
        {
            checkOK = false;
            goToAdd = false;
            saveID = "";

            int w_nRet;
            ushort w_nData = 0;
            ushort w_nData2 = 0;
            ushort w_nRcvCks = 0;
            ushort w_nSize = 0;

            //ClearResponseInfo();

            if (CommandProc.GET_PACKET_PREFIX(false) == CommonDefine.RCM_PREFIX_CODE)
                w_nRcvCks = (ushort)((CommandProc.m_pPacketBuffer[CommonDefine.ST_COM_PACKET_LEN + 1] << 8) + CommandProc.m_pPacketBuffer[CommonDefine.ST_COM_PACKET_LEN]);
            else if (CommandProc.GET_PACKET_PREFIX(false) == CommonDefine.RCM_DATA_PREFIX_CODE)
                w_nRcvCks = (ushort)((CommandProc.m_pPacketBuffer[CommandProc.GET_DATAPACKET_LEN(false) + 1] << 8) + CommandProc.m_pPacketBuffer[CommandProc.GET_DATAPACKET_LEN(false)]);

            w_nRet = (int)CommandProc.GET_PACKET_RETURN(false);
            w_nData = CommandProc.GET_PACKET_RCMDATA(0, false); // MAKEWORD(g_Packet[8], g_Packet[9]);
            w_nData2 = CommandProc.GET_PACKET_RCMDATA(2, false); //MAKEWORD(g_Packet[10], g_Packet[11]);
            w_nSize = CommandProc.GET_PACKET_LEN(false);

            string strMsg = "";

            switch (p_nCode)
            {
                case CommonDefine.CMD_CLEAR_TEMPLATE_CODE:
                    //指定删除
                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                    {
                        //strMsg = string.Format("结果 : 成功\r\n指纹编号 : {0}", w_nData);
                    }
                    else
                    {
                        // strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));
                    }
                    break;

                case CommonDefine.CMD_WRITE_TEMPLATE_CODE:
                    //指定录入
                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                    {
                        strMsg = string.Format("结果 : 成功\r\n指纹编号 : {0}", w_nData);
                    }
                    else
                    {
                        strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));

                        if (w_nData == CommonDefine.ERR_DUPLICATION_ID)
                            strMsg += string.Format(" {0}.", w_nData2);
                    }

                    break;

                case CommonDefine.CMD_GET_EMPTY_ID_CODE:
                    //获取最小ID
                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                    {
                        strMsg = string.Format("结果 : 成功\r\n可以编号 : {0}", w_nData);
                        strID = w_nData.ToString();
                    }
                    else
                    {
                        strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));
                        strID = "";
                    }
                    break;

                case CommonDefine.CMD_GET_ENROLL_COUNT_CODE:
                    //已经注册个数
                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                        strMsg = string.Format("结果 : 成功\r\n指纹数量 : {0}", w_nData);
                    else
                        strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));

                    break;

                case CommonDefine.CMD_VERIFY_WITH_DOWN_TMPL_CODE:
                case CommonDefine.CMD_IDENTIFY_WITH_DOWN_TMPL_CODE:
                case CommonDefine.CMD_VERIFY_CODE:
                case CommonDefine.CMD_IDENTIFY_CODE:
                case CommonDefine.CMD_IDENTIFY_FREE_CODE:
                case CommonDefine.CMD_ENROLL_CODE:
                case CommonDefine.CMD_ENROLL_ONETIME_CODE:
                case CommonDefine.CMD_CHANGE_TEMPLATE_CODE:
                case CommonDefine.CMD_IDENTIFY_WITH_IMAGE_CODE:
                case CommonDefine.CMD_VERIFY_WITH_IMAGE_CODE:
                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                    {
                        switch (w_nData)
                        {
                            case CommonDefine.GD_NEED_RELEASE_FINGER:
                                strMsg = "请离开手指";
                                break;
                            case CommonDefine.GD_NEED_FIRST_SWEEP:
                                strMsg = "请按手指";
                                break;
                            case CommonDefine.GD_NEED_SECOND_SWEEP:
                                strMsg = "请再按一次";
                                break;
                            case CommonDefine.GD_NEED_THIRD_SWEEP:
                                strMsg = "请再按一次";
                                break;
                            case CommonDefine.CMD_CLEAR_TEMPLATE_CODE:
                                strMsg = "请按手指";
                                break;
                            default:

                                strMsg = string.Format("结果 : 成功\r\n指纹编号 : {0}", w_nData);
                                strID = "";

                                checkOK = p_nCode == CommonDefine.CMD_IDENTIFY_FREE_CODE;
                                loginID = p_nCode == CommonDefine.CMD_IDENTIFY_FREE_CODE ? w_nData.ToString() : "";
                                saveID = p_nCode == CommonDefine.CMD_ENROLL_ONETIME_CODE ? w_nData.ToString() : "";

                                break;
                        }
                    }
                    else
                    {
                        strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));
                        if (CommandProc.LOBYTE(w_nData) == CommonDefine.ERR_BAD_QUALITY)
                        {
                            strMsg += "\r\nAgain... !";
                        }
                        else
                        {
                            goToAdd = p_nCode == CommonDefine.CMD_IDENTIFY_FREE_CODE;
                            if (w_nData == CommonDefine.ERR_DUPLICATION_ID)
                            {
                                strMsg += string.Format(" {0}.", w_nData2);
                            }
                        }
                    }

                    break;

                case CommonDefine.CMD_FINGER_DETECT_CODE:

                    if (w_nRet == CommonDefine.ERR_SUCCESS)
                    {
                        if (w_nData == CommonDefine.GD_DETECT_FINGER)
                            strMsg = string.Format("检测到指纹");
                        else if (w_nData == CommonDefine.GD_NO_DETECT_FINGER)
                            strMsg = string.Format("没有检测到指纹");
                        else
                            strMsg = string.Format("通讯错误.");
                    }
                    else
                    {
                        strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));
                    }

                    break;

                case CommonDefine.CMD_FP_CANCEL_CODE:

                    /* if (w_nRet == CommonDefine.ERR_SUCCESS)
                         strMsg = string.Format("结果 : 取消命令成功");
                     else
                         strMsg = string.Format("结果 : 错误\r\n{0}", GetErrorMsg(w_nData));
                     */
                    break;

                default:
                    break;
            }

            edtRC_Result.Text = strMsg;

            if ((p_nCode == CommonDefine.CMD_IDENTIFY_FREE_CODE))
            {
                if (w_nRet == CommonDefine.ERR_SUCCESS ||
                     CommandProc.LOBYTE(w_nData) != CommonDefine.ERR_NOT_AUTHORIZED &&
                     CommandProc.LOBYTE(w_nData) != CommonDefine.ERR_FP_CANCEL &&
                     CommandProc.LOBYTE(w_nData) != CommonDefine.ERR_INVALID_OPERATION_MODE &&
                     CommandProc.LOBYTE(w_nData) != CommonDefine.ERR_ALL_TMPL_EMPTY)
                {
                    Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);

                    if (checkOK)
                    {
                        Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                        m_clsCmdProc.m_bCmdDone = true;

                        Login(loginID);

                        return;
                    }

                    if (goToAdd)
                    {
                        if (MessageBox.Show("当前指纹未识别到身份证信息，是否手动登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                        {
                            Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                            m_clsCmdProc.m_bCmdDone = true;

                            AddLogin();
                        }
                    }

                    m_clsCmdProc.StartSendThread();
                    return;
                }

                if (goToAdd)
                {
                    if (MessageBox.Show("当前指纹未识别到身份证信息，是否手动登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                        m_clsCmdProc.m_bCmdDone = true;

                        AddLogin();
                    }
                }
            }

            if ((p_nCode == CommonDefine.CMD_ENROLL_CODE) ||
                (p_nCode == CommonDefine.CMD_CHANGE_TEMPLATE_CODE))
            {
                switch (w_nData)
                {
                    case CommonDefine.GD_NEED_RELEASE_FINGER:
                    case CommonDefine.GD_NEED_FIRST_SWEEP:
                    case CommonDefine.GD_NEED_SECOND_SWEEP:
                    case CommonDefine.GD_NEED_THIRD_SWEEP:
                    case CommonDefine.ERR_BAD_QUALITY:
                        Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                        m_clsCmdProc.StartSendThread();
                        return;
                    default:
                        break;
                }
            }
            if ((p_nCode == CommonDefine.CMD_ENROLL_ONETIME_CODE) ||
                (p_nCode == CommonDefine.CMD_VERIFY_CODE) ||
                (p_nCode == CommonDefine.CMD_IDENTIFY_CODE) ||
                (p_nCode == CommonDefine.CMD_IDENTIFY_FREE_CODE))
            {
                switch (w_nData)
                {
                    case CommonDefine.GD_NEED_RELEASE_FINGER:
                        Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                        m_clsCmdProc.StartSendThread();
                        return;
                    default:
                        break;
                }
            }

            Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
            m_clsCmdProc.m_bCmdDone = true;

            if (!string.IsNullOrEmpty(saveID))
            {
                SaveID(saveID);
            }

            if (p_nCode == CommonDefine.CMD_CLEAR_TEMPLATE_CODE)
            {
                if (MessageBox.Show("当前指纹未识别到身份证信息，是否手动登录？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    Array.Clear(CommandProc.m_pPacketBuffer, 0, CommonDefine.MAX_DATA_LEN + 10);
                    m_clsCmdProc.m_bCmdDone = true;

                    AddLogin();

                    return;
                }

                Run_IdentifyFree();
            }
        }

        FingerPrintBLL fbll = new FingerPrintBLL();

        public string IDCardNo { get; set; }

        public void Login(string strFignerID)
        {
            IDCardNo = fbll.GetIDCardNoByFinerID(strFignerID);

            if (string.IsNullOrEmpty(IDCardNo))
            {
                Run_ClearTemplate(strFignerID);
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void Run_ClearTemplate(string strFignerID)
        {
            bool w_bRet = false;
            uint w_nTemplateNo = 0;

            w_nTemplateNo = (uint)(Int32.Parse(strFignerID));
            w_bRet = m_clsCmdProc.Run_Command_1P(CommonDefine.CMD_CLEAR_TEMPLATE_CODE, (ushort)w_nTemplateNo);
        }

        public void SaveID(string strFignerID)
        {
            fbll.SaveFingerInfo(strFignerID, IDCardNo);

            MessageBox.Show("保存成功");

            this.Close();
        }

        public void AddLogin()
        {
            IDCardNo = "";

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run_Connect();
        }

        private void Run_Connect()
        {
            if (!m_clsCmdProc.Run_Connect(true, "", 0))
            {
                //MessageBox.Show("目标没响应", "通讯错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                edtRC_Result.Text = "通讯错误-目标没响应";

                btnReConc.Visible = true;
                return;
            }

            btnReConc.Visible = false;

            edtRC_Result.Text = string.Format("设备已连接{0}", btnSave.Visible ? "-按下录入开始保存指纹" : "");
        }

        string strID = "";

        private void Run_GetEmptyID()
        {
            m_clsCmdProc.Run_Command_NP(CommonDefine.CMD_GET_EMPTY_ID_CODE);
        }

        public string GetErrorMsg(ushort p_nErrorCode)
        {
            string w_ErrMsg;

            switch (CommandProc.LOBYTE(p_nErrorCode))
            {
                case CommonDefine.ERR_VERIFY:
                    w_ErrMsg = "1：1失败";
                    break;
                case CommonDefine.ERR_IDENTIFY:
                    //w_ErrMsg = "1:N失败";
                    w_ErrMsg = "验证失败";
                    break;
                case CommonDefine.ERR_EMPTY_ID_NOEXIST:
                    w_ErrMsg = "没有可用编号";
                    break;
                case CommonDefine.ERR_BROKEN_ID_NOEXIST:
                    w_ErrMsg = "没有损坏的模板";
                    break;
                case CommonDefine.ERR_TMPL_NOT_EMPTY:
                    w_ErrMsg = "指纹已经存在";
                    break;
                case CommonDefine.ERR_TMPL_EMPTY:
                    w_ErrMsg = "没有此指纹";
                    break;
                case CommonDefine.ERR_INVALID_TMPL_NO:
                    w_ErrMsg = "错误的指纹编号";
                    break;
                case CommonDefine.ERR_ALL_TMPL_EMPTY:
                    w_ErrMsg = "指纹为空";
                    break;
                case CommonDefine.ERR_INVALID_TMPL_DATA:
                    w_ErrMsg = "错误的指纹数据";
                    break;
                case CommonDefine.ERR_DUPLICATION_ID:
                    w_ErrMsg = "重复指纹 : ";
                    break;
                case CommonDefine.ERR_BAD_QUALITY:
                    w_ErrMsg = "图像质量差";
                    break;
                case CommonDefine.ERR_SMALL_LINES:
                    w_ErrMsg = "图像太小";
                    break;
                case CommonDefine.ERR_TOO_FAST:
                    w_ErrMsg = "手指离开太快";
                    break;
                case CommonDefine.ERR_TIME_OUT:
                    w_ErrMsg = "超时";
                    break;
                case CommonDefine.ERR_GENERALIZE:
                    w_ErrMsg = "创建失败";
                    break;
                case CommonDefine.ERR_NOT_AUTHORIZED:
                    w_ErrMsg = "通讯被加密";
                    break;
                case CommonDefine.ERR_EXCEPTION:
                    w_ErrMsg = "出现异常 ";
                    break;
                case CommonDefine.ERR_MEMORY:
                    w_ErrMsg = "内存出错 ";
                    break;
                case CommonDefine.ERR_INVALID_PARAM:
                    w_ErrMsg = "无效参数";
                    break;
                case CommonDefine.ERR_NO_RELEASE:
                    w_ErrMsg = "请离开手指";
                    break;
                case CommonDefine.ERR_INTERNAL:
                    w_ErrMsg = "内部错误";
                    break;
                case CommonDefine.ERR_FP_CANCEL:
                    w_ErrMsg = "已取消";
                    break;
                case CommonDefine.ERR_INVALID_OPERATION_MODE:
                    w_ErrMsg = "无效的工作模式";
                    break;
                case CommonDefine.ERR_NOT_SET_PWD:
                    w_ErrMsg = "没有设置通讯密码";
                    break;
                case CommonDefine.ERR_FP_NOT_DETECTED:
                    w_ErrMsg = "没有检测到指纹";
                    break;
                case CommonDefine.ERR_ADJUST_SENSOR:
                    w_ErrMsg = "校准传感器失败";
                    break;
                default:
                    w_ErrMsg = "错误";
                    break;
            }

            // Return
            return w_ErrMsg;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            m_clsUSB = new USBComm(this);
            m_clsCmdProc = new CommandProc(this);
            m_clsSerial = new SerialCom();

            if (!string.IsNullOrEmpty(WindowType) && WindowType == "SAVE")
            {
                btnSave.Visible = true;

                this.Text = "指纹录入";
            }
        }

        public bool CheckCanAdd()
        {
            return fbll.GetFinerIDByIDCardNo(IDCardNo) == "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!m_clsCmdProc.m_bIsConnected)
            {
                return;
            }
            Run_GetEmptyID();
            Run_EnrollOneTime();
        }

        private void Run_EnrollOneTime()
        {
            bool w_bRet = false;
            uint w_nTemplateNo = 0;

            //. Check inputed template no
            if (string.IsNullOrEmpty(strID))
            {
                edtRC_Result.Text = "获取指纹ID失败";
                return;
            }

            w_nTemplateNo = (uint)(Int32.Parse(strID));
            edtRC_Result.Text = "请按手指";
            w_bRet = m_clsCmdProc.Run_Command_1P(CommonDefine.CMD_ENROLL_ONETIME_CODE, (ushort)w_nTemplateNo);
        }

        private void Run_Enroll()
        {
            edtRC_Result.Text = "";
            bool w_bRet = false;
            uint w_nTempInd = 0;

            // Check Input
            if (string.IsNullOrEmpty(strID))
            {
                return;
            }

            w_nTempInd = (uint)(Int32.Parse(strID));

            // Run Command
            w_bRet = m_clsCmdProc.Run_Command_1P((ushort)(CommonDefine.CMD_ENROLL_CODE), (ushort)w_nTempInd);
        }

        private void Run_IdentifyFree()
        {
            if (!m_clsCmdProc.m_bIsConnected)
            {
                return;
            }

            edtRC_Result.Text = "请按手指";

            m_clsCmdProc.Run_Command_NP(CommonDefine.CMD_IDENTIFY_FREE_CODE);
        }

        /// <summary>
        /// 显示后，开启连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            Run_Connect();

            // 默认为登陆
            if (string.IsNullOrEmpty(WindowType))
            {
                Run_IdentifyFree();
            }
        }

        /// <summary>
        /// 关闭时退出连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Run_FpCancel();
            m_clsCmdProc.Run_Disconnect();
        }

        private void Run_FpCancel()
        {
            m_clsCmdProc.StartFpCancelThread();
        }

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            m_clsCmdProc.m_bIsConnected = true;
            this.Close();
        }

        private void btnReConc_Click(object sender, EventArgs e)
        {
            Run_Connect();

            Run_IdentifyFree();
        }
    }
}
