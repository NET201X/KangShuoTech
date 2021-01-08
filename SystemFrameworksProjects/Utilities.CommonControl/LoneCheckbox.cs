using KangShuoTech.Utilities.Common;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public class LoneCheckbox
    {
        private bool _couldit;
        private bool invalid;
        public Action UpdateSource;
        public Action<LoneCheckbox, bool> useOneVeto;

        public LoneCheckbox(CheckBox ck)
        {
            this._couldit = true;
            this.m_checkbox = ck;
            this.Vassal = null;
            this.OneVeto = false;
            this.Enemy = new List<LoneCheckbox>();
            this.m_checkbox.CheckedChanged += new EventHandler(this.m_checkbox_CheckedChanged);
        }

        public LoneCheckbox(CheckBox ck, bool veto)
        {
            this._couldit = true;
            this.m_checkbox = ck;
            this.Vassal = null;
            this.OneVeto = true;
            this.Enemy = new List<LoneCheckbox>();
            this.m_checkbox.CheckedChanged += new EventHandler(this.oneVeto_CheckedChanged);
        }

        public LoneCheckbox(CheckBox ck, TextBox va)
        {
            this._couldit = true;
            this.m_checkbox = ck;
            this.Vassal = va;
            this.OneVeto = false;
            this.Enemy = new List<LoneCheckbox>();
            this.m_checkbox.CheckedChanged += new EventHandler(this.m_checkbox_CheckedChanged);
        }

        public void AddEnemy(LoneCheckbox ck)
        {
            this.Enemy.Add(ck);
        }

        public void AddEnemyRange(LoneCheckbox[] enemys)
        {
            this.Enemy.AddRange((IEnumerable<LoneCheckbox>) enemys);
        }

        private void m_checkbox_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.invalid)
            {
                try
                {
                    for (int i = 0; i < this.Enemy.Count; i++)
                    {
                        this.Enemy[i].SetInvalid(this.m_checkbox.Checked);
                    }
                }
                catch (Exception exception)
                {
                    LogHelper.LogError(exception);
                    throw;
                }
                if (this.Vassal != null)
                {
                    if (this.m_checkbox.Checked)
                    {
                        this.Vassal.ReadOnly = false;
                    }
                    else
                    {
                        this.Vassal.ReadOnly = true;
                        this.Vassal.Text = "";
                    }
                }
                if (this.UpdateSource != null)
                {
                    this.UpdateSource();
                }
            }
        }

        private void oneVeto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.useOneVeto != null)
            {
                this.useOneVeto(this, this.m_checkbox.Checked);
            }
            if (this.UpdateSource != null)
            {
                this.UpdateSource();
            }
        }

        public void SetInvalid(bool p_invalid)
        {
            if (this.CouldIt)
            {
                if (p_invalid)
                {
                    this.m_checkbox.Enabled = false;
                    this.m_checkbox.Checked = false;
                }
                else
                {
                    this.m_checkbox.Enabled = true;
                }
                this.invalid = p_invalid;
            }
        }

        public bool CouldIt
        {
            get
            {
                return this._couldit;
            }
            set
            {
                this._couldit = value;
                if (this._couldit)
                {
                    this.m_checkbox.Enabled = true;
                }
                else
                {
                    this.m_checkbox.Enabled = false;
                    this.m_checkbox.Checked = false;
                }
            }
        }

        public List<LoneCheckbox> Enemy { get; set; }

        public CheckBox m_checkbox { get; set; }

        public string Mean { get; set; }

        public bool OneVeto { get; set; }

        public TextBox Vassal { get; set; }
    }
}

