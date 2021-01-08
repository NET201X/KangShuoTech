namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class BMIAssessSetModel
    {
        public BMIAssessSetModel()
        { }
        #region Model
        private int _id;
        private string _isshownum;
        private string _unit;
        private string _exceptioncol;
        private string _includeequal;
        private decimal? _thin;
        private string _thincontent;
        private string _thincontent2;
        private string _thincontent3;
        private decimal? _overweight;
        private string _overweightcontent;
        private string _overweightcontent2;
        private string _overweightcontent3;
        private decimal? _obesity;
        private string _obesitycontent;
        private string _obesitycontent2;
        private string _obesitycontent3;
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
        public string IsShowNum
        {
            set { _isshownum = value; }
            get { return _isshownum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Unit
        {
            set { _unit = value; }
            get { return _unit; }
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
        public string IncludeEqual
        {
            set { _includeequal = value; }
            get { return _includeequal; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Thin
        {
            set { _thin = value; }
            get { return _thin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThinContent
        {
            set { _thincontent = value; }
            get { return _thincontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThinContent2
        {
            set { _thincontent2 = value; }
            get { return _thincontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ThinContent3
        {
            set { _thincontent3 = value; }
            get { return _thincontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Overweight
        {
            set { _overweight = value; }
            get { return _overweight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OverweightContent
        {
            set { _overweightcontent = value; }
            get { return _overweightcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OverweightContent2
        {
            set { _overweightcontent2 = value; }
            get { return _overweightcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OverweightContent3
        {
            set { _overweightcontent3 = value; }
            get { return _overweightcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Obesity
        {
            set { _obesity = value; }
            get { return _obesity; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ObesityContent
        {
            set { _obesitycontent = value; }
            get { return _obesitycontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ObesityContent2
        {
            set { _obesitycontent2 = value; }
            get { return _obesitycontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ObesityContent3
        {
            set { _obesitycontent3 = value; }
            get { return _obesitycontent3; }
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
        #endregion Model
    }
}
