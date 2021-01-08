namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Runtime.CompilerServices;

    public class stru_result
    {
        public string datetime = "";
        public string type = "";
        public string value1 = "";
        public string value10 = "";
        public string value11 = "";
        public string value12 = "";
        public string value13 = "";
        public string value2 = "";
        public string value3 = "";
        public string value4 = "";
        public string value5 = "";
        public string value6 = "";
        public string value7 = "";
        public string value8 = "";
        public string value9 = "";

        public void Clear()
        {
            this.type = "";
            this.value1 = "";
            this.value2 = "";
            this.value3 = "";
            this.value4 = "";
            this.value5 = "";
            this.value6 = "";
            this.value7 = "";
            this.value8 = "";
            this.value9 = "";
            this.value10 = "";
            this.value11 = "";
            this.value12 = "";
            this.value13 = "";
            this.datetime = "";
            this.HasValue = true;
        }

        public bool HasValue { get; set; }
    }
}

