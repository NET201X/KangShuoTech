using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    public class OtherDisease
    {
        public bool? IsChecked;
        private string itsType;
        private int maxBytesCount;
        public RadioButton rd_w;
        public RadioButton rd_y;
        private RecordsIllnessHistoryInfoModel source;
        private bool UState;

        public OtherDisease(string it, TextBox t, DateTimePicker dtp)
        {
            this.itsType = it;
            this.tb1 = t;
            this.dtp1 = dtp;
            this.dtp1.MaxDate = DateTime.Today;
        }

        private void Other_TextChanged(object sender, EventArgs e)
        {
            if (Encoding.GetEncoding("GB2312").GetByteCount(this.tb1.Text) > this.MaxBytesCount)
            {
                this.ErrorInput = true;
                this.tb1.BackColor = Color.Salmon;
            }
            else
            {
                this.ErrorInput = false;
                this.tb1.BackColor = Color.WhiteSmoke;
            }
        }

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                this.Enabled = !p_enabled;
                this.UState = p_enabled;
            }
        }

        private void tb1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty((sender as TextBox).Text))
            {
                this.rd_y.Checked = true;
            }
        }

        public void UpdateSource()
        {
            if (this.source == null)
            {
                RecordsIllnessHistoryInfoModel recordsIllnessHistoryInfoModel = new RecordsIllnessHistoryInfoModel
                {
                    RecordState = RecordsStateModel.NoValue
                };
                this.source = recordsIllnessHistoryInfoModel;
                this.source.IDCardNo = this.IDCard;
                this.source.RecordID = this.RecordID;
                this.source.IllnessType = this.itsType;
            }

            if (this.rd_y.Checked)
            {
                if (this.source.RecordState == RecordsStateModel.NoValue)
                {
                    this.source.RecordState = RecordsStateModel.AddToDB;
                }
                if (this.source.RecordState == RecordsStateModel.Unchanged)
                {
                    this.source.RecordState = RecordsStateModel.UpdateInDB;
                }
                this.source.IllnessName = "2";
                this.source.IllnessNameOther = this.tb1.Text.Trim();
                this.source.DiagnoseTime = new DateTime?(this.dtp1.Value.Date);
            }
            else if (this.rd_w.Checked)
            {
                this.source.IllnessName = "1";
                this.source.IllnessNameOther = string.Empty;
                this.source.DiagnoseTime = null;
                RecordsStateModel modelState = this.source.RecordState;

                if (this.source.RecordState == RecordsStateModel.Unchanged)
                {
                    this.source.RecordState = RecordsStateModel.DeleteInDB;
                }
            }
        }

        public string RecordID { get; set; }

        public DateTimePicker dtp1 { get; set; }

        public bool Enabled
        {
            set
            {
                if (value)
                {
                    this.tb1.Enabled = value;
                    this.dtp1.Enabled = value;
                }
                else
                {
                    this.tb1.Text = "";
                    this.tb1.Enabled = false;
                    this.dtp1.Value = DateTime.Today;
                    this.dtp1.Enabled = false;
                }
            }
        }

        public bool ErrorInput { get; set; }

        public string IDCard { get; set; }

        public int MaxBytesCount
        {
            get
            {
                return this.maxBytesCount;
            }
            set
            {
                if (value > 0)
                {
                    this.maxBytesCount = value;
                    this.tb1.TextChanged += new EventHandler(this.Other_TextChanged);
                }
            }
        }

        public RecordsIllnessHistoryInfoModel Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
                this.tb1.Text = this.source.IllnessNameOther;
                if (this.source.DiagnoseTime.HasValue)
                {
                    this.dtp1.Value = this.source.DiagnoseTime.Value;
                }
                this.MaxBytesCount = 200;
            }
        }

        public TextBox tb1 { get; set; }
    }
}

