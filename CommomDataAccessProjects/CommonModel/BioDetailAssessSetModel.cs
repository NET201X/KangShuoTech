using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class BioDetailAssessSetModel
    {
        #region Model
        private int _id;
        private string _type;
        private int? _outkey;
        private string _codename;
        private string _code;
        private string _unit;
        private string _isshownum;
        private string _includeequal;
        private string _sex;
        private string _maxval;
        private string _minval;
        private string _content;
        private string _content2;
        private string _content3;
        private string _createdby;
        private DateTime? _createddate;
        private string _lastupdateby;
        private DateTime? _lastupdatedate;
        public int IfUsing { get; set; }
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
        public int? OutKey
        {
            set { _outkey = value; }
            get { return _outkey; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CodeName
        {
            set { _codename = value; }
            get { return _codename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
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
        public string Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MaxVal
        {
            set { _maxval = value; }
            get { return _maxval; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MinVal
        {
            set { _minval = value; }
            get { return _minval; }
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
        public int? Seq { get; set; }
        public string Value { get; set; }
        #endregion Model

    }
}
