using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonControl;

namespace FocusGroup
{
    using CommonControl;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using System.Data;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using Femiani.Forms.UI.Input;
  
    public class DrugCondion
    {
        private List<InputRangeStr> inputrange_str;
        private List<InputRangeDec> inputRanges;
        private bool UState;
        public void InitEveryControl()
        {
            this.inputRanges = new List<InputRangeDec>();
            this.inputRanges.Add(new InputRangeDec("DailyTime", 100M, false));
            //this.inputRanges.Add(new InputRangeDec("EveryTimeMg", 100M));
            this.inputrange_str = new List<InputRangeStr>();
            this.inputrange_str.Add(new InputRangeStr("Name", 100));
            this.DrugbindingManager = new SimpleBindingManager<ChronicDrugConditionModel>(this.inputRanges, this.inputrange_str, this.Source);
            this.DrugbindingManager.SimpleBinding(this.TbDrugName, "Name", false);
            this.DrugbindingManager.SimpleBinding(this.TbUseCount, "DailyTime", true);
            this.DrugbindingManager.SimpleBinding(this.TbUseDose, "EveryTimeMg", false);
            this.TbDrugName.TextChanged += new EventHandler(this.TbDrugName_TextChanged);
            this.TbDrugName_TextChanged(this.TbDrugName, null);
        }

        private void SetEnabled(bool p_enabled)
        {
            if (this.UState != p_enabled)
            {
                this.TbUseCount.ReadOnly = !p_enabled;
                this.TbUseDose.ReadOnly = !p_enabled;
                if (!p_enabled)
                {
                    this.TbUseCount.Text = "";
                    this.TbUseDose.Text = "";
                }
                this.UState = p_enabled;
            }
        }

        private void TbDrugName_TextChanged(object sender, EventArgs e)
        {
            this.SetEnabled((sender as TextBox).Text != "");
        }
     
        public void UpdateSource()
        {
            if (this.TbDrugName.Text.Trim() == "")
            {
                if (this.Source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.Source.ModelState = RecordsStateModel.DeleteInDB;
                }
            }
            else
            {
                if (this.Source.ModelState == RecordsStateModel.Unchanged)
                {
                    this.Source.ModelState = RecordsStateModel.UpdateInDB;
                }
                if (this.Source.ModelState == RecordsStateModel.NoValue)
                {
                    this.Source.ModelState = RecordsStateModel.AddToDB;
                }
            }
        }

        private SimpleBindingManager<ChronicDrugConditionModel> DrugbindingManager { get; set; }

        public bool ErrorInput
        {
            get
            {
                return this.DrugbindingManager.ErrorInput;
            }
        }

        public ChronicDrugConditionModel Source { get; set; }

        public TextBox TbDrugName { get; set; }

        public TextBox TbUseCount { get; set; }

        public TextBox TbUseDose { get; set; }
    }
}

