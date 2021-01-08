namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class JustSingleItem<T>
    {
        private T source;
        public Action<string> statusChanged;
        private string StrProContent;

        public JustSingleItem(T src)
        {
            this.source = src;
        }

        public void BindProperty(string content)
        {
            this.StrProContent = content;
            PropertyInfo property = this.source.GetType().GetProperty(this.StrProContent);
            this.R1.CheckedChanged += new EventHandler(this.R1_CheckedChanged);
            this.R2.CheckedChanged += new EventHandler(this.R2_CheckedChanged);
            if (property == null)
            {
                throw new Exception("异常！");
            }
            object obj2 = property.GetValue(this.source, null);
            if (obj2 != null)
            {
                if (obj2.ToString() == "1")
                {
                    this.R1.Checked = true;
                }
                if (obj2.ToString() == "2")
                {
                    this.R2.Checked = true;
                }
            }
        }

        private void R1_CheckedChanged(object sender, EventArgs e)
        {
            this.source.GetType().GetProperty(this.StrProContent).SetValue(this.source, "1", null);
            if (this.statusChanged != null)
            {
                this.statusChanged("1");
            }
        }

        private void R2_CheckedChanged(object sender, EventArgs e)
        {
            this.source.GetType().GetProperty(this.StrProContent).SetValue(this.source, "2", null);
            if (this.statusChanged != null)
            {
                this.statusChanged("2");
            }
        }
       
        public bool MVisiable
        {
            set
            {
                if (!value)
                {
                    this.R1.Checked = false;
                    this.R2.Checked = false;
                    this.R1.Visible = false;
                    this.R2.Visible = false;
                }
            }
        }

        public RadioButton R1 { get; set; }

        public RadioButton R2 { get; set; }

    }
}

