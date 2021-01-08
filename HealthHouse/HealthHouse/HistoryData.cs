using KangShuoTech.DataAccessProjects.BLL;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using KangShuoTech.Utilities.Common;
using KangShuoTech.DataAccessProjects.Model;

namespace HealthHouse
{
    public partial class HistoryData : Form
    {
        DataTable dt = new DataTable();
        private HealthHouseBLL healthHouseBLL = new HealthHouseBLL();

        //public string IDCardNo { get; set; }
        public RecordsBaseInfoModel Model { get; set; }

        // 取得屏幕分辨率的宽高
        private int SW = Screen.PrimaryScreen.Bounds.Width;
        private int SH = Screen.PrimaryScreen.Bounds.Height;

        public HistoryData()
        {
            InitializeComponent();
        }

        public HistoryData(RecordsBaseInfoModel p_Model)
        {
            this.Model = p_Model;
            InitializeComponent();
            this.panel1.Height = SH - 20;

            GetData();
        }

        private void GetData()
        {
            dt = healthHouseBLL.GetDataInfo(this.Model.IDCardNo);

            if (dt != null && dt.Rows.Count > 0)
            {
                dt.DefaultView.Sort = "YM";
                dt = dt.DefaultView.ToTable();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistoryData_Load(object sender, EventArgs e)
        {
            // 体质指数
            BMIData();

            // 血压
            BloodData();

            // 心率
            HeartRateData();

            // 血氧
            BloodOxyData();

            #region 基本信息显示

            TimeParser timeParser = new TimeParser();

            if (dt != null && dt.Rows.Count > 0)
            {
                lblName.Text += dt.Rows[0]["CustomerName"].ToString();
                lblSex.Text += StringPlus.GetSex(dt.Rows[0]["Sex"].ToString());
                lblAge.Text += timeParser.GetAge(dt.Rows[0]["Birthday"]);
            }

            #endregion
        }

        /// <summary>
        /// 体质指数
        /// </summary>
        private void BMIData()
        {
            // 清除默认的series
            BMIChart.Series.Clear();
            BMIChart.Size = new Size((SW - 50) / 2, (SH - 100) / 2);

            BMIChart.ChartAreas[0].AxisY.Title = "体质指数";

            // 设Y轴间隔、最大、最小值
            BMIChart.ChartAreas[0].AxisY.Interval = 5;
            BMIChart.ChartAreas[0].AxisY.Minimum = 0;
            BMIChart.ChartAreas[0].AxisY.Maximum = 40;

            // 新建一个图形
            Series Strength = new Series("体质指数");

            // 设置chart的类型，这里为曲线图
            Strength.ChartType = SeriesChartType.Line;

            // 数据 给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Strength.Points.AddXY(dt.Rows[i]["YM"], dt.Rows[i]["BMI"]);
            }

            // 把series添加到chart上
            BMIChart.Series.Add(Strength);

            // 点线图上方显式数值
            BMIChart.Series[0].Label = "#VAL";
            BMIChart.Series[0].MarkerSize = 6;
            BMIChart.Series[0].MarkerStyle = MarkerStyle.Circle;
            BMIChart.Series[0].IsValueShownAsLabel = true;
        }

        /// <summary>
        /// 血压
        /// </summary>
        private void BloodData()
        {
            // 清除默认的series
            BloodChart.Series.Clear();
            BloodChart.Size = new Size((SW - 50) / 2, (SH - 100) / 2);

            BloodChart.ChartAreas[0].AxisY.Title = "血压";

            // 设Y轴间隔、最大、最小值
            BloodChart.ChartAreas[0].AxisY.Interval = 50;
            BloodChart.ChartAreas[0].AxisY.Minimum = 50;
            BloodChart.ChartAreas[0].AxisY.Maximum = 200;

            // 新建一个图形
            Series Strength = new Series("收缩压");
            Series Strength2 = new Series("舒张压");

            // 设置chart的类型，这里为曲线图
            Strength.ChartType = SeriesChartType.Line;
            Strength2.ChartType = SeriesChartType.Line;

            // 数据 给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Strength.Points.AddXY(dt.Rows[i]["YM"], dt.Rows[i]["LeftHeight"]);
                Strength2.Points.AddXY(dt.Rows[i]["YM"], dt.Rows[i]["LeftPre"]);
            }

            // 把series添加到chart上
            BloodChart.Series.Add(Strength);
            BloodChart.Series.Add(Strength2);

            // 点线图上方显式数值
            BloodChart.Series[0].Label = "#VAL";
            BloodChart.Series[0].MarkerSize = 6;
            BloodChart.Series[0].MarkerStyle = MarkerStyle.Circle;
            BloodChart.Series[0].IsValueShownAsLabel = true;

            // 点线图上方显式数值
            BloodChart.Series[1].Label = "#VAL";
            BloodChart.Series[1].MarkerSize = 6;
            BloodChart.Series[1].MarkerStyle = MarkerStyle.Circle;
            BloodChart.Series[1].IsValueShownAsLabel = true;
        }

        /// <summary>
        /// 心率
        /// </summary>
        private void HeartRateData()
        {
            // 清除默认的series
            HeartRateChart.Series.Clear();
            HeartRateChart.Size = new Size((SW - 50) / 2, (SH - 100) / 2);

            HeartRateChart.ChartAreas[0].AxisY.Title = "心率";

            // 设Y轴间隔、最大、最小值
            HeartRateChart.ChartAreas[0].AxisY.Interval = 20;
            HeartRateChart.ChartAreas[0].AxisY.Minimum = 0;
            HeartRateChart.ChartAreas[0].AxisY.Maximum = 120;

            // 新建一个图形
            Series Strength = new Series("心率");

            // 设置chart的类型，这里为曲线图
            Strength.ChartType = SeriesChartType.Line;

            // 数据 给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Strength.Points.AddXY(dt.Rows[i]["YM"], dt.Rows[i]["PulseRate"]);
            }

            // 把series添加到chart上
            HeartRateChart.Series.Add(Strength);

            // 点线图上方显式数值
            HeartRateChart.Series[0].Label = "#VAL";
            HeartRateChart.Series[0].MarkerSize = 6;
            HeartRateChart.Series[0].MarkerStyle = MarkerStyle.Circle;
            HeartRateChart.Series[0].IsValueShownAsLabel = true;
        }

        /// <summary>
        /// 血氧
        /// </summary>
        private void BloodOxyData()
        {
            // 清除默认的series
            BloodOxyChart.Series.Clear();
            BloodOxyChart.Size = new Size((SW - 50) / 2, (SH - 100) / 2);

            BloodOxyChart.ChartAreas[0].AxisY.Title = "血氧";

            // 设Y轴间隔、最大、最小值
            BloodOxyChart.ChartAreas[0].AxisY.Interval = 20;
            BloodOxyChart.ChartAreas[0].AxisY.Minimum = 0;
            BloodOxyChart.ChartAreas[0].AxisY.Maximum = 120;

            // 新建一个图形
            Series Strength = new Series("血氧");

            // 设置chart的类型，这里为曲线图
            Strength.ChartType = SeriesChartType.Line;

            // 数据 给系列上的点进行赋值，分别对应横坐标和纵坐标的值
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Strength.Points.AddXY(dt.Rows[i]["YM"], dt.Rows[i]["BloodOxygen"]);
            }

            // 把series添加到chart上
            BloodOxyChart.Series.Add(Strength);

            // 点线图上方显式数值
            BloodOxyChart.Series[0].Label = "#VAL";
            BloodOxyChart.Series[0].MarkerSize = 6;
            BloodOxyChart.Series[0].MarkerStyle = MarkerStyle.Circle;
            BloodOxyChart.Series[0].IsValueShownAsLabel = true;
        }
    }
}
