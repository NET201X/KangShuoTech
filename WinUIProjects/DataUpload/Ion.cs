using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.OleDb;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using QinCSoft.CommomDataAccessProjects.CommonBLL;
using QinCSoft.CommomDataAccessProjects.CommonModel;
using CommomUtilities.Common;

namespace DataUpload
{
    public partial class Ion : Form
    {
        CombinUploadData cud;
        Socket socketSend;
        int UploadCount = 0, index = 0;
        private static int dataNum = 1;
        bool endFlag = true;
        JsonHelper JsonH = new JsonHelper();
        RecordsxqBLL recordsXQBll = new RecordsxqBLL();
        RecordsAssistCheckBLL recordsAssistCheckBLL = new RecordsAssistCheckBLL();
        DeviceInfoBLL deviceInfoBLL = new DeviceInfoBLL();
        private string startDate = "", endDate = "", uploadType = "";
        DataTable dtUpload = new DataTable();
        private string[] postUrl = { };

        // 日期区间前推天数
        string addDay = ConfigHelper.GetSetNode("addDay");

        // 版本号
        string versionNo = ConfigHelper.GetSetNode("versionNo");

        // 区域
        string area = ConfigHelper.GetSetNode("area");

        // 获取体检数据，并插入身份证号码
        private static readonly object obj = new object();

        public Ion()
        {
            UploadTypeForm uf = new UploadTypeForm { Type = "3" };
            uf.ShowDialog();
            uploadType = uf.UploadType;

            addDay = addDay == "" ? "0" : addDay;

            InitializeComponent();

            if (File.Exists(Application.StartupPath + @"\DataUploadManger.xml"))
            {
                DataSet dsResult = new DataSet();

                dsResult.ReadXml(Application.StartupPath + @"\DataUploadManger.xml");

                dtUpload = dsResult.Tables[0];
                DataView dv = dtUpload.DefaultView;
                dv.RowFilter = "Category='Ion'";

                dtUpload = dv.ToTable();

                if (dtUpload.Rows.Count > 0)
                {
                    postUrl = dtUpload.Rows[0]["Website"].ToString().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                }
            }

            DateTime dtNow = DateTime.Now;

            this.dtpStart.Value = dtNow.AddDays(-Convert.ToInt32(addDay));
            this.dtpEnd.Value = dtNow;
        }

        /// <summary>
        /// 数据同步按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnDataUpload_Click(object sender, EventArgs e)
        {
            try
            {
                this.cud = new CombinUploadData();
                index = 0;
                dataNum = 1;
                AccessDBUtil.strCommon = "QClizi";//路径1

                if (ConfigurationManager.AppSettings.AllKeys.Contains("DJZUploadIsScoketProtocol"))
                {
                    string checkType = ConfigurationManager.AppSettings["DJZUploadIsScoketProtocol"].ToString();

                    if (checkType == "Y") GetDataBySocket();
                    else DataGet();
                }
                else DataGet();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                throw;
            }
        }
        
        /// <summary>
        /// 共享文件方式更新数据
        /// </summary>
        public void DataGet()
        {
            try
            {
                btnDataUpload.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";
                labUploadnum.Text = "0";
                Application.DoEvents();

                // 如果为共享的方式同步
                if (uploadType.Equals("Share"))
                {
                    //判断数据库是否连接
                    bool flag = TestConnection();

                    if (!flag)
                    {
                        MessageBox.Show("数据库连接失败！", "提示！", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        btnDataUpload.Enabled = true;
                        Application.DoEvents();
                        return;
                    }
                }

                lock (obj)
                {
                    btnDataUpload.Enabled = true;

                    string dTime = "", selectInfo = "";

                    if (this.ckbCheckDate.Checked)
                    {
                        startDate = this.dtpStart.Value.Date.ToString("yyyy-MM-dd 00:00:00");
                        endDate = this.dtpEnd.Value.Date.ToString("yyyy-MM-dd 23:59:59");

                        dTime = string.Format(" AND TestTime BETWEEN #{0}# AND #{1}# ", startDate, endDate);
                    }

                    selectInfo = "SELECT * FROM PersonInfoSH WHERE Mark='Y' " + dTime;

                    progressBar1.Visible = true;
                    progressBar1.Minimum = 0;
                    progressBar1.BackColor = Color.Green;

                    // 如果为共享的方式同步
                    if (uploadType.Equals("Share"))
                    {
                        DataSet personInfo = AccessDBUtil.ExecuteQuery(selectInfo);

                        if (personInfo != null)
                        {
                            DataTable dtInfo = personInfo.Tables[0];

                            progressBar1.Maximum = dtInfo.Rows.Count;
                            labCountnum.Text = dtInfo.Rows.Count.ToString();

                            int amount = DataUpload(dtInfo);

                            labUploadnum.Text = amount.ToString();
                            progressBar1.Value = amount;

                            MessageBox.Show("成功匹配：" + amount + "条数据！", "提示");
                            progressBar1.Visible = false;
                            Application.DoEvents();
                        }
                    }
                    else
                    {
                        DataUpload();
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.ToString());
                throw;
            }
        }

        private int DataUpload(DataTable dtInfo)
        {
            int amount = 0;

            Application.DoEvents();

            for (int i = 0; i < dtInfo.Rows.Count; i++)
            {
                try
                {
                    DataRow row = dtInfo.Rows[i];
                    DataModel model = new DataModel();

                    #region 项目赋值

                    model.IDCardNo = row["IDCardNo"].ToString();
                    model.HB = row["HB"].ToString();
                    model.WBC = row["WBC"].ToString();
                    model.PLT = row["PLT"].ToString();
                    model.PRO = row["PRO"].ToString();
                    model.GLU = row["GLU"].ToString();
                    model.KET = row["KET"].ToString();
                    model.BLD = row["BLD"].ToString();
                    model.FPGL = row["FPGL"].ToString();
                    model.ALBUMIN = row["ALBUMIN"].ToString();
                    model.HBALC = row["HBALC"].ToString();
                    model.SGPT = row["SGPT"].ToString();
                    model.GOT = row["GOT"].ToString();
                    model.BP = row["BP"].ToString();
                    model.TBIL = row["TBIL"].ToString();
                    model.CB = row["CB"].ToString();
                    model.SCR = row["SCR"].ToString();
                    model.BUN = row["BUN"].ToString();
                    model.PC = row["PC"].ToString();
                    model.HYPE = row["HYPE"].ToString();
                    model.TC = row["TC"].ToString();
                    model.TG = row["TG"].ToString();
                    model.HDL_C = row["HDL_C"].ToString();
                    model.LDL_C = row["LDL_C"].ToString();
                    model.GT = row["GT"].ToString();

                    model.TP = row.Table.Columns.Contains("TP") ? row["TP"].ToString() : "";
                    model.GLB = row.Table.Columns.Contains("GLB") ? row["GLB"].ToString() : "";
                    model.AG = row.Table.Columns.Contains("AG") ? row["AG"].ToString() : "";
                    model.IBIL = row.Table.Columns.Contains("IBIL") ? row["IBIL"].ToString() : "";
                    model.UA = row.Table.Columns.Contains("UA") ? row["UA"].ToString() : ""; //尿酸
                    model.HCY = row.Table.Columns.Contains("HCY") ? row["HCY"].ToString() : "";
                    model.HBSAG = row.Table.Columns.Contains("HBSAG") ? row["HBSAG"].ToString() : "";
                    model.LEU = row.Table.Columns.Contains("LEU") ? row["LEU"].ToString() : "";  // 尿白细胞

                    if (dtInfo.Columns.Contains("Bloodtype"))
                    {
                        string strBlood = row["Bloodtype"].ToString();

                        if (!string.IsNullOrEmpty(strBlood))
                        {
                            switch (strBlood)
                            {
                                case "A型":
                                    model.BloodType = "1";
                                    break;
                                case "B型":
                                    model.BloodType = "2";
                                    break;
                                case "O型":
                                    model.BloodType = "3";
                                    break;
                                case "AB型":
                                    model.BloodType = "4";
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    DateTime dt = new DateTime();

                    if (row.Table.Columns.Contains("TestTime"))
                    {
                        if (DateTime.TryParse(row["TestTime"].ToString(), out dt))
                        {
                            model.TestTime = dt;
                        }
                    }

                    decimal value = 0;
                    if (decimal.TryParse(model.FPGL, out value))
                    {
                        model.FPGDL = (value * 18).ToString();
                    }
                    else
                    {
                        model.FPGDL = "";
                    }

                    #endregion

                    #region 新增项目26个

                    model.NEU_B = row["NEU_B"].ToString();
                    model.LYMPH_B = row["LYMPH_B"].ToString();
                    model.MON_B = row["MON_B"].ToString();
                    model.EOS_B = row["EOS_B"].ToString();
                    model.BAS_B = row["BAS_B"].ToString();

                    model.NEU_N = row["NEU_N"].ToString();
                    model.LYMPH_N = row["LYMPH_N"].ToString();
                    model.EOS_N = row["EOS_N"].ToString();
                    model.MON_N = row["MON_N"].ToString();
                    model.BAS_N = row["BAS_N"].ToString();

                    model.RBC = row["RBC"].ToString();
                    model.HCT = row["HCT"].ToString();
                    model.MCV = row["MCV"].ToString();
                    model.MCH = row["MCH"].ToString();
                    model.MCHC = row["MCHC"].ToString();

                    model.RDW_CV = row["RDW_CV"].ToString();
                    model.RDW_SD = row["RDW_SD"].ToString();
                    model.MPV = row["MPV"].ToString();
                    model.PDW = row["PDW"].ToString();
                    model.PCT = row["PCT"].ToString();
                    model.MID_B = row["MID_B"].ToString();
                    model.MID_N = row["MID_N"].ToString();

                    model.P_LCR = row.Table.Columns.Contains("P_LCR") ? row["P_LCR"].ToString() : "";
                    model.P_LCC = row.Table.Columns.Contains("P_LCC") ? row["P_LCC"].ToString() : "";//大血小板数目
                    model.CL = row.Table.Columns.Contains("CL") ? row["CL"].ToString() : "";    //氯
                    model.CA = row.Table.Columns.Contains("CA") ? row["CA"].ToString() : "";    //钙
                    model.ASTALT = row.Table.Columns.Contains("ASTALT") ? row["ASTALT"].ToString() : ""; //草丙比

                    // 更新血球表，更新不到则新增
                    int result = recordsAssistCheckBLL.UpdateXQ(model);
                    if (result <= 0 && result != -2) recordsXQBll.AddRow(model);

                    #endregion

                    // 更新辅助检查
                    int successNum = recordsAssistCheckBLL.UpdateAssistCheck(model);

                    if (successNum > 0)
                    {
                        amount++;
                        Application.DoEvents();
                    }
                    else this.cud.ConbinData(model.IDCardNo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            return amount;
        }

        /// <summary>
        /// 执行网站同步
        /// </summary>
        private void DataUpload()
        {
            int strart = 0, end = 200, total = 0, amount = 0;

            total = GetPostHttpCount();

            progressBar1.Maximum = total;
            labCountnum.Text = total.ToString();

            BackgroundWorker dgWorker = new BackgroundWorker();

            dgWorker.DoWork += (senderdg, edg) =>
            {
                while (total > 0)
                {
                    List<DataModel> model = GetPostHttp(strart, end);
                    DataTable dtInfo = new DataTable();

                    if (model != null && model.Count > 0)
                        dtInfo = ModelConvertHelper<DataModel>.ToDataTable(model);

                    amount += DataUpload(dtInfo);

                    strart = end;
                    end += 200;
                    total -= 200;

                    dgWorker.ReportProgress(amount);
                }
            };

            dgWorker.ProgressChanged += (senderdg, edg) =>
            {
                progressBar1.Value = edg.ProgressPercentage;
            };

            dgWorker.RunWorkerCompleted += (senderdg, edg) =>
            {
                MessageBox.Show(String.Format("成功匹配：{0}条数据！", amount), "提示");

                progressBar1.Visible = false;
                btnDataUpload.Enabled = true;
                this.labUploadnum.Text = amount.ToString();

                if (this.cud.dtData.Rows.Count > 0)
                {
                    UploadData ud = new UploadData { dtData = cud.dtData };
                    ud.ShowDialog();
                }
            };

            dgWorker.WorkerReportsProgress = true;
            dgWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 测试数据库连接生化
        /// </summary>
        /// <returns></returns>
        public static bool TestConnection()
        {
            bool result = false;
            string connectionString = "";

            try
            {
                connectionString = ConfigurationManager.ConnectionStrings["QClizi"].ToString();

                AccessDBUtil.connectionString = connectionString;
                OleDbConnection conn = new OleDbConnection(connectionString);

                if (File.Exists(conn.DataSource))
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
                throw ex;
            }

            return result;
        }

        /// <summary>
        /// 日期范围勾选事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbCheckDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbCheckDate.Checked)
            {
                this.dtpStart.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpStart.Enabled = false;
                this.dtpEnd.Enabled = false;
                startDate = "";
                endDate = "";
            }
        }
  
        #region Socket通讯

        /// <summary>
        /// 通过网络通信获取数据
        /// </summary>
        public void GetDataBySocket()
        {
            try
            {
                this.cud = new CombinUploadData();
                btnDataUpload.Enabled = false;
                labCountnum.Text = "数据统计中，请稍后...";
                labUploadnum.Text = "0";
                UploadCount = 0;
                this.endFlag = true;
                Application.DoEvents();

                string IP = ConfigurationManager.AppSettings["DJZIPAddress"].ToString();
                string port = ConfigurationManager.AppSettings["DJZPort"].ToString();
                string starTime = "", endTime = "";

                btnDataUpload.Enabled = true;

                if (this.ckbCheckDate.Checked)
                {
                    starTime = dtpStart.Value.ToString("yyyy-MM-dd");
                    endTime = dtpEnd.Value.ToString("yyyy-MM-dd");
                }

                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse(IP);
                IPEndPoint point = new IPEndPoint(ip, int.Parse(port));
                socketSend.ReceiveTimeout = 5000;
                socketSend.Connect(point);

                string msg = "{\"Type\":\"0\",\"StartDate\":\"" + starTime + "\",\"EndDate\":\"" + endTime + "\"}"; //生化的type值为0
                byte[] buffer = new byte[1024 * 1024 * 3];

                buffer = Encoding.UTF8.GetBytes(msg);
                socketSend.Send(buffer);

                //开启新的线程，不停的接收服务器发来的消息
                Thread c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("IP或者端口号错误...");
            }
        }

        private void ControlTextRefresh(Control ctr, string text)
        {
            Action<Control, string> method = new Action<Control, string>(this.ControlTextRefresh);

            if (ctr.InvokeRequired)
            {
                ctr.Invoke(method, new object[] { ctr, text });
            }
            else
            {
                ctr.Text = text;
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 滚动条设置
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="value"></param>
        /// <param name="visibleflag"></param>
        private void ProcessBarRefresh(ProgressBar bar, int value, bool visibleflag)
        {
            Action<ProgressBar, int, bool> method = new Action<ProgressBar, int, bool>(this.ProcessBarRefresh);

            if (bar.InvokeRequired)
            {
                bar.Invoke(method, new object[] { bar, value, visibleflag });
            }
            else
            {
                if (visibleflag)
                {
                    bar.Visible = true;
                    bar.Minimum = 0;
                    bar.Maximum = value;
                    bar.BackColor = Color.Green;
                }
                else bar.Visible = false;
            }
        }

        /// <summary>
        /// 滚动条数据值设置
        /// </summary>
        /// <param name="bar"></param>
        /// <param name="value"></param>
        private void ProcessBarValueRefresh(ProgressBar bar, int value)
        {
            Action<ProgressBar, int> method = new Action<ProgressBar, int>(this.ProcessBarValueRefresh);

            if (bar.InvokeRequired)
            {
                bar.Invoke(method, new object[] { bar, value });
            }
            else
            {
                bar.Value = value;
                Application.DoEvents();
            }
        }

        public bool UpdateData(string date)
        {
            JsonClass jclass = JsonH.DeserializeJsonToObject<JsonClass>(date);
            DataModel model = jclass.Data;

            if (jclass.Message.ToUpper() == "CONNECTFAIL") //数据查询失败
            {
                MessageBox.Show("读取数据失败...");
                return false;
            }
            else if (jclass.Message.ToUpper() == "CONNECTOK") //数据查询成功
            {
                this.ControlTextRefresh(this.labCountnum, jclass.Status);
                this.ProcessBarRefresh(this.progressBar1, int.Parse(jclass.Status) + 5, true);
                return true;
            }
            else if (jclass.Message.ToUpper() == "OVER") //数据传送完毕
            {
                socketSend.Close();

                this.ProcessBarRefresh(this.progressBar1, int.Parse(jclass.Status), false);
                DialogResult dr = MessageBox.Show("成功匹配：" + UploadCount + "条数据！", "提示");

                if (dr == DialogResult.OK)
                {
                    if (this.cud.dtData.Rows.Count > 0)
                    {
                        UploadData ud = new UploadData { dtData = cud.dtData };
                        ud.ShowDialog();
                    }
                    return false;
                }
            }

            if (model == null) return true;

            if (recordsAssistCheckBLL.UpdateXQ(model) <= 0) recordsXQBll.AddRow(model);

            int successNum = recordsAssistCheckBLL.UpdateAssistCheck(model);

            if (successNum > 0)
            {
                UploadCount++;
                this.ControlTextRefresh(this.labUploadnum, UploadCount.ToString());
                this.ProcessBarValueRefresh(this.progressBar1, UploadCount);
                Application.DoEvents();
            }
            else
            {
                this.cud.ConbinData(model.IDCardNo);
            }

            return true;
        }

        /// <summary>
        /// 接收服务端返回的消息
        /// </summary>
        public void Received()
        {
            Application.DoEvents();
            byte[] newBuffer = new byte[] { };//大小可变的缓存器

            while (endFlag)
            {
                try
                {
                    int i = 1;
                    int receivedLength;
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    MessageProtocol msgXY = new MessageProtocol();

                    //实际接收到的有效字节数
                    receivedLength = socketSend.Receive(buffer);

                    string s = Encoding.UTF8.GetString(buffer);
                    newBuffer = MessageProtocol.ToArray(newBuffer, 0, newBuffer.Length, buffer, 0, receivedLength);

                    if (newBuffer.Length < 6) continue;
                    else
                    {
                        msgXY = MessageProtocol.FromBytes(newBuffer);

                        int firstFlag = msgXY.XieYiFirstFlag;
                        int secondFlag = msgXY.XieYiSecondFlag;
                        int msgContentLength = msgXY.MessageContentLength;

                        while ((newBuffer.Length - 6) >= msgContentLength)
                        {
                            msgXY = MessageProtocol.FromBytes(newBuffer);

                            string data = Encoding.UTF8.GetString(msgXY.MessageContent);

                            endFlag = UpdateData(data);
                            newBuffer = msgXY.DuoYvBytes;
                            msgContentLength = msgXY.MessageContentLength;

                            if (newBuffer == null)
                            {
                                newBuffer = new byte[] { };
                                break;
                            }

                            if (newBuffer.Length >= 6)
                            {
                                msgXY = MessageProtocol.FromBytes(newBuffer);
                                firstFlag = msgXY.XieYiFirstFlag;
                                secondFlag = msgXY.XieYiSecondFlag;
                                msgContentLength = msgXY.MessageContentLength;
                                continue;
                            }
                            else break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    break;
                }
            }
        }

        #endregion

        #region 网站方式同步

        private List<DataModel> GetPostHttp(int startIndex, int endIndex)
        {
            List<DataModel> listDevice = new List<DataModel>();
            string url = "", postDataStr = "";

            if (postUrl.Length > index)
            {
                url = postUrl[index] + "/Login/GetBiochemical";
                postDataStr = "startDate=" + startDate + "&endDate=" + endDate + "&startIndex=" + startIndex + "&endIndex=" + endIndex;

                string result = WebHelper.PostHttp(url, postDataStr);

                // 反序列化：json字符串 转 List
                listDevice = JsonConvert.DeserializeObject<List<DataModel>>(result);
            }
            return listDevice;
        }

        /// <summary>
        /// 取得资料笔数
        /// </summary>
        /// <returns></returns>
        private int GetPostHttpCount()
        {
            string url = "", postDataStr = "", result = "";

            if (postUrl.Length > index)
            {
                url = postUrl[index] + "/Login/GetBiochemicalCount";
                postDataStr = "startDate=" + startDate + "&endDate=" + endDate;

                result = WebHelper.PostHttp(url, postDataStr);
            }

            return Convert.ToInt32(result);
        }

        #endregion
    }
}
