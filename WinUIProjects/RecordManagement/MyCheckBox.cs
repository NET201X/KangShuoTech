namespace ArchiveInfo
{
    using System.Windows.Forms;

    internal class MyCheckBox
    {
        public CheckBox ctr;
        public string displyStr;
        public string valueStr;

        public MyCheckBox(CheckBox box, string dis, string vl)
        {
            this.ctr = box;
            this.displyStr = dis;
            this.valueStr = vl;
        }

        public void SetChecked(bool status)
        {
            this.ctr.Checked = status;
        }
    }
}

