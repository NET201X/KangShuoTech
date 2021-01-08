using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class BiochemicalAssessSetModel
    {
        #region Model
        private int _id;
        private string _type;
        private string _exceptioncol;
        private string _isshowdetail;
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
        public string IsShowDetail
        {
            set { _isshowdetail = value; }
            get { return _isshowdetail; }
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
        #endregion Model
    }
}
