namespace KangShuoTech.Utilities.CommonControl
{
    public class InputRangeStr
    {
        public InputRangeStr(string name, int count)
        {
            this.Name = name;
            this.BytesCount = count;
            this.ErrorInput = false;
        }

        public InputRangeStr(string name, string regex)
        {
            this.Name = name;
            this.StrRegex = regex;
            this.ErrorInput = false;
            this.BytesCount = 0x3e8;
        }

        public int BytesCount { get; set; }

        public bool ErrorInput { get; set; }

        public bool IsRequired { get; set; }

        public string Name { get; set; }

        public string StrRegex { get; set; }

        public string Whatsup { get; set; }
    }
}

