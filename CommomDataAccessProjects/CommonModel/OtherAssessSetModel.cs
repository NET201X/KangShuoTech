namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class OtherAssessSetModel
    {
        private int _id;
        private string _type;
        private string _exceptioncol;
        private string _isshownum;
        private string _includeequal;
        private decimal? _maxvalue;
        private decimal? _minvalue;
        private string _content;
        private string _content2;
        private string _content3;
        private string _createdby;
        private DateTime? _createddate;
        private string _lastupdateby;
        private DateTime? _lastupdatedate;
        /// <summary>
        /// auto_increment
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ExceptionCol
        {
            set { _exceptioncol = value; }
            get { return _exceptioncol; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsShowNum
        {
            set { _isshownum = value; }
            get { return _isshownum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IncludeEqual
        {
            set { _includeequal = value; }
            get { return _includeequal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MaxVal
        {
            set { _maxvalue = value; }
            get { return _maxvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? MinVal
        {
            set { _minvalue = value; }
            get { return _minvalue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content2
        {
            set { _content2 = value; }
            get { return _content2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content3
        {
            set { _content3 = value; }
            get { return _content3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CreatedBy
        {
            set { _createdby = value; }
            get { return _createdby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreatedDate
        {
            set { _createddate = value; }
            get { return _createddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastUpDateBy
        {
            set { _lastupdateby = value; }
            get { return _lastupdateby; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastUpdateDate
        {
            set { _lastupdatedate = value; }
            get { return _lastupdatedate; }
        }
    }
}
