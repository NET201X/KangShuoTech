
using System.Collections.Generic;

namespace KangShuoTech.CommomDataAccessProjects.CommonModel
{
    public class PrintModel
    {
        public int? ID { get; set; }
        public string ButtonName { get; set; }
        public string ButtonID { get; set; }
        public string StyleName { get; set; }
        public int? Orders { get; set; }
        public string IsDisplay { get; set; }
        public string IsDouble { get; set; }
        public string PrintFile { get; set; }
        public string PrintType { get; set; }
        public string Col2 { get; set; }
        public string Col3 { get; set; }
        public string FileName { get; set; }
        public string IDCardNo { get; set; }
        public string Path { get; set; }
        public string CheckDate { get; set; }
    }

    public class Model
    {
        /// <summary>
        /// 键值 存放文本值
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// 文本类型
        /// </summary>
        public string TextType { get; set; }

        /// <summary>
        /// 日期格式
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// 数字格式
        /// </summary>
        public string NumFormat { get; set; }

        /// <summary>
        /// 内部信息
        /// </summary>
        public string InInfo { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 页签名
        /// </summary>
        public string TabName { get; set; }

        public string Content { get; set; }

        public string RemarksCut { get; set; }

        public string ImgPath { get; set; }

        public string Compare { get; set; }

        public string Format { get; set; }

        public string Alias { get; set; }

        public string Seq { get; set; }

        public string Text { get; set; }

        public string Separa { get; set; }

        public string Type { get; set; }

        public string Width { get; set; }
        public string Height { get; set; }

        /// <summary>
        /// 倒叙填充
        /// </summary>
        public string Fill { get; set; }

        /// <summary>
        /// 显示文字  0 否 1是
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// 显示文字  0 否 1是
        /// </summary>
        public string LastRecordId { get; set; }
    }
}