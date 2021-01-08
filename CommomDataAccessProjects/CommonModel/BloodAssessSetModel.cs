namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    using System;

    [Serializable]
    public class BloodAssessSetModel
    {
        #region Model
        private int _id;
        private string _bloodtype;
        private string _isshownum;
        private string _unit;
        private string _exceptioncol;
        private string _includeequal;
        private decimal? _generalhighmax;
        private decimal? _generallowmax;
        private string _generalhighcontent;
        private string _generalhighcontent2;
        private string _generalhighcontent3;
        private decimal? _generalhighmin;
        private decimal? _generallowmin;
        private string _generallowcontent;
        private string _generallowcontent2;
        private string _generallowcontent3;
        private string _distipoptype;
        private decimal? _hyphighmax;
        private decimal? _hyplowmax;
        private string _hyphighcontent;
        private string _hyphighcontent2;
        private string _hyphighcontent3;
        private decimal? _hyphighmin;
        private decimal? _hyplowmin;
        private string _hyplowcontent;
        private string _hyplowcontent2;
        private string _hyplowcontent3;
        private string _distiolder;
        private decimal? _oldhighmax;
        private decimal? _oldlowmax;
        private string _oldhighcontent;
        private string _oldhighcontent2;
        private string _oldhighcontent3;
        private decimal? _oldhighmin;
        private decimal? _oldlowmin;
        private string _oldlowcontent;
        private string _oldlowcontent2;
        private string _oldlowcontent3;
        private string _isreview;
        private decimal? _reviewhighmax;
        private decimal? _reviewlowmax;
        private decimal? _reviewhighmin;
        private decimal? _reviewlowmin;
        private string _isreferral;
        private decimal? _referralhighmax;
        private decimal? _referrallowmax;
        private decimal? _referralhighmin;
        private decimal? _referrallowmin;
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
        public string BloodType
        {
            set { _bloodtype = value; }
            get { return _bloodtype; }
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
        public decimal? GeneralHighMax
        {
            set { _generalhighmax = value; }
            get { return _generalhighmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GeneralLowMax
        {
            set { _generallowmax = value; }
            get { return _generallowmax; }
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
        public decimal? GeneralHighMin
        {
            set { _generalhighmin = value; }
            get { return _generalhighmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? GeneralLowMin
        {
            set { _generallowmin = value; }
            get { return _generallowmin; }
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
        public decimal? HypHighMax
        {
            set { _hyphighmax = value; }
            get { return _hyphighmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HypLowMax
        {
            set { _hyplowmax = value; }
            get { return _hyplowmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypHighContent
        {
            set { _hyphighcontent = value; }
            get { return _hyphighcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypHighContent2
        {
            set { _hyphighcontent2 = value; }
            get { return _hyphighcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypHighContent3
        {
            set { _hyphighcontent3 = value; }
            get { return _hyphighcontent3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HypHighMin
        {
            set { _hyphighmin = value; }
            get { return _hyphighmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? HypLowMin
        {
            set { _hyplowmin = value; }
            get { return _hyplowmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypLowContent
        {
            set { _hyplowcontent = value; }
            get { return _hyplowcontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypLowContent2
        {
            set { _hyplowcontent2 = value; }
            get { return _hyplowcontent2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HypLowContent3
        {
            set { _hyplowcontent3 = value; }
            get { return _hyplowcontent3; }
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
        public decimal? OldHighMax
        {
            set { _oldhighmax = value; }
            get { return _oldhighmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OldLowMax
        {
            set { _oldlowmax = value; }
            get { return _oldlowmax; }
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
        public decimal? OldHighMin
        {
            set { _oldhighmin = value; }
            get { return _oldhighmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? OldLowMin
        {
            set { _oldlowmin = value; }
            get { return _oldlowmin; }
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
        public decimal? ReviewHighMax
        {
            set { _reviewhighmax = value; }
            get { return _reviewhighmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReviewLowMax
        {
            set { _reviewlowmax = value; }
            get { return _reviewlowmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReviewHighMin
        {
            set { _reviewhighmin = value; }
            get { return _reviewhighmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReviewLowMin
        {
            set { _reviewlowmin = value; }
            get { return _reviewlowmin; }
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
        public decimal? ReferralHighMax
        {
            set { _referralhighmax = value; }
            get { return _referralhighmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferralLowMax
        {
            set { _referrallowmax = value; }
            get { return _referrallowmax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferralHighMin
        {
            set { _referralhighmin = value; }
            get { return _referralhighmin; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? ReferralLowMin
        {
            set { _referrallowmin = value; }
            get { return _referrallowmin; }
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
