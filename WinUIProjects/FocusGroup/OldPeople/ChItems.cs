namespace FocusGroup.elderInfo
{
    using System;
    using System.Runtime.CompilerServices;

    public class ChItems
    {
        public ChItems(string dis, string val)
        {
            this.DisplayMem = dis;
            this.ValueMem = val;
        }

        public string DisplayMem { get; set; }

        public string ValueMem { get; set; }
    }
}

