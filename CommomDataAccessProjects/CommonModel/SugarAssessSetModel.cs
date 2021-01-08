namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class SugarAssessSetModel
    {
        #region Model
        private int _id;
        private string _isshownum;
        private string _unit;
        private string _exceptioncol;
        private string _includeequal;
        private decimal? _generalhigh;
        private string _generalhighcontent;
        private string _generalhighcontent2;
        private string _generalhighcontent3;
        private decimal? _generallow;
        private string _generallowcontent;
        private string _generallowcontent2;
        private string _generallowcontent3;
        private string _distipoptype;
        private decimal? _diahigh;
        private string _diahighcontent;
        private string _diahighcontent2;
        private string _diahighcontent3;
        private decimal? _dialow;
        private string _dialowcontent;
        private string _dialowcontent2;
        private string _dialowcontent3;
        private string _distiolder;
        private decimal? _oldhigh;
        private string _oldhighcontent;
        private string _oldhighcontent2;
        private string _oldhighcontent3;
        private decimal? _oldlow;
        private string _oldlowcontent;
        private string _oldlowcontent2;
        private string _oldlowcontent3;
        private string _isreview;
        private decimal? _reviewhigh;
        private decimal? _reviewlow;
        private string _isreferral;
        private decimal? _referralhigh;
        private decimal? _referrallow;
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
        public decimal? GeneralHigh
        {
            set { _generalhigh = value; }
            get { return _generalhigh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralHighContent
        {
            set { _generalhighcontent = value; }
            get { return _generalhighcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralHighContent2
        {
            set { _generalhighcontent2 = value; }
            get { return _generalhighcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralHighContent3
        {
            set { _generalhighcontent3 = value; }
            get { return _generalhighcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GeneralLow
        {
            set { _generallow = value; }
            get { return _generallow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralLowContent
        {
            set { _generallowcontent = value; }
            get { return _generallowcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralLowContent2
        {
            set { _generallowcontent2 = value; }
            get { return _generallowcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string GeneralLowContent3
        {
            set { _generallowcontent3 = value; }
            get { return _generallowcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DistiPopType
        {
            set { _distipoptype = value; }
            get { return _distipoptype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DiaHigh
        {
            set { _diahigh = value; }
            get { return _diahigh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaHighContent
        {
            set { _diahighcontent = value; }
            get { return _diahighcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaHighContent2
        {
            set { _diahighcontent2 = value; }
            get { return _diahighcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaHighContent3
        {
            set { _diahighcontent3 = value; }
            get { return _diahighcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? DiaLow
        {
            set { _dialow = value; }
            get { return _dialow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaLowContent
        {
            set { _dialowcontent = value; }
            get { return _dialowcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaLowContent2
        {
            set { _dialowcontent2 = value; }
            get { return _dialowcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DiaLowContent3
        {
            set { _dialowcontent3 = value; }
            get { return _dialowcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string DistiOlder
        {
            set { _distiolder = value; }
            get { return _distiolder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OldHigh
        {
            set { _oldhigh = value; }
            get { return _oldhigh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldHighContent
        {
            set { _oldhighcontent = value; }
            get { return _oldhighcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldHighContent2
        {
            set { _oldhighcontent2 = value; }
            get { return _oldhighcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldHighContent3
        {
            set { _oldhighcontent3 = value; }
            get { return _oldhighcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OldLow
        {
            set { _oldlow = value; }
            get { return _oldlow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldLowContent
        {
            set { _oldlowcontent = value; }
            get { return _oldlowcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldLowContent2
        {
            set { _oldlowcontent2 = value; }
            get { return _oldlowcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldLowContent3
        {
            set { _oldlowcontent3 = value; }
            get { return _oldlowcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsReview
        {
            set { _isreview = value; }
            get { return _isreview; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReviewHigh
        {
            set { _reviewhigh = value; }
            get { return _reviewhigh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReviewLow
        {
            set { _reviewlow = value; }
            get { return _reviewlow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IsReferral
        {
            set { _isreferral = value; }
            get { return _isreferral; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferralHigh
        {
            set { _referralhigh = value; }
            get { return _referralhigh; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferralLow
        {
            set { _referrallow = value; }
            get { return _referrallow; }
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
