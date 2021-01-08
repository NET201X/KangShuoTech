namespace KangShuoTech.Utilities.CommonControl
{
    public class InputRangeDec
    {
        private bool IncludeMin;

        public InputRangeDec(string name, decimal max)
        {
            this.Name = name;
            this.Max = max;
            this.Min = -0.1M;
            this.ErrorInput = false;
            this.IsFormate = true;
        }

        public InputRangeDec(string name, decimal max, bool isFormate)
        {
            this.Name = name;
            this.Max = max;
            this.Min = -0.1M;
            this.ErrorInput = false;
            this.IsFormate = isFormate;
        }

        public InputRangeDec(string name, decimal max, bool includeMin, bool isFormate)
        {
            this.Name = name;
            this.Max = max;
            this.Min = -0.1M;
            this.ErrorInput = false;
            this.IsFormate = isFormate;
            this.IncludeMin = includeMin;
        }

        public bool CheckIt(ref decimal p_v)
        {
            bool flag;
            if (!this.IncludeMin ? ((p_v > this.Min) && (p_v < this.Max)) : ((p_v >= this.Min) && (p_v < this.Max)))
            {
                if (this.IsFormate)
                {
                    p_v = decimal.Parse(((decimal) p_v).ToString("000.00"));
                }
                flag = true;
                this.ErrorInput = false;
                return flag;
            }
            flag = false;
            this.ErrorInput = true;
            return flag;
        }

        internal bool CheckIt(ref int p_v)
        {
            bool flag;
            if ((p_v >= this.Min) && (p_v <= this.Max))
            {
                if (this.IsFormate)
                {
                    p_v = int.Parse(((int) p_v).ToString());
                }
                flag = true;
                this.ErrorInput = false;
                return flag;
            }
            flag = false;
            this.ErrorInput = true;
            return flag;
        }

        public bool ErrorInput { get; set; }

        public bool IsFormate { get; set; }

        public decimal Max { get; set; }

        public decimal Min { get; set; }

        public string Name { get; set; }

        public string Whatsup { get; set; }
    }
}

