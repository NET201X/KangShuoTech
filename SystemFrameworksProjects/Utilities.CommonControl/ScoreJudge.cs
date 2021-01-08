using KangShuoTech.DataAccessProjects.Model;

namespace KangShuoTech.Utilities.CommonControl
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class ScoreJudge
    {
        private BindingFlags c_bf = (BindingFlags.Public | BindingFlags.Instance);
        public decimal m_score;
        //private RadioButton rdQY;
        //private RadioButton rdY;

        public ScoreJudge(OlderMedicineResultModel src, string pscore, string pjudge, RadioButton r_y, RadioButton r_qy)
        {
            this.DataSrc = src;
            this.ProScore = pscore;
            this.ProJudege = pjudge;
            //this.rdY = r_y;
            //this.rdQY = r_qy;
        }
        public ScoreJudge(OlderMedicineResultModel src, string pscore, string pjudge)
        {
            this.DataSrc = src;
            this.ProScore = pscore;
            this.ProJudege = pjudge;
            //this.rdY = r_y;
            //this.rdQY = r_qy;
        }
        public void UpdateResult()
        {
            //this.rdY.Checked = false;
            //this.rdQY.Checked = false;
            PropertyInfo property = this.DataSrc.GetType().GetProperty(this.ProScore, this.c_bf);
            PropertyInfo info2 = this.DataSrc.GetType().GetProperty(this.ProJudege, this.c_bf);
            if ((property != null) && (info2 != null))
            {
                decimal? nullable = (decimal?) property.GetValue(this.DataSrc, null);
                if (nullable.HasValue)
                {
                    this.m_score = nullable.Value;
                    if (nullable >= 11M)
                    {
                        info2.SetValue(this.DataSrc, "1", null);
                        //this.rdY.Checked = true;
                    }
                    else
                    {
                        if (nullable >= 9M && nullable<= 10M) 
                        {
                            info2.SetValue(this.DataSrc, "2", null);
                            //this.rdQY.Checked = true;
                            return;
                        }
                        //decimal? nullable5 = nullable;
                        //if (((nullable5.GetValueOrDefault() > 8M) ? 0 : 1) != 0)
                        //{
                            info2.SetValue(this.DataSrc, "", null);
                            //this.rdY.Checked = false;
                            //this.rdQY.Checked = false;
                        //}
                    }
                }
            }
        }

        public OlderMedicineResultModel DataSrc { get; set; }

        public string ProJudege { get; set; }

        public string ProScore { get; set; }
    }
}

