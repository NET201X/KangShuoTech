using System;
using System.Drawing;
namespace ReportPrint
{
	public class ListValue
	{
		private string _strType;
		public string strVal
		{
			get;
			set;
		}
		public string strMark
		{
			get;
			set;
		}
        public Image image
        {
            get;
            set;
        }
		public string strType
		{
			get
			{
				return this._strType;
			}
			set
			{
				if (value == null)
				{
					this._strType = "0";
					return;
				}
				this._strType = value;
			}
		}
	}
}
