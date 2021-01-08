namespace KangShuoTech.CommomDataAccessProjects.CommonBLL
{
    using CommomUtilities.Common;
    using CommonDAL;
    using CommonModel;
    using System.Collections.Generic;
    using System.Data;

    public class CodeBaseBLL
    {
        private readonly CodeBaseDAL dal = new CodeBaseDAL();

        /// <summary>
        /// 获取代码类别
        /// </summary>
        /// <returns></returns>
        public DataSet GetCategory()
        {
            return this.dal.GetCategory();
        }

        /// <summary>
        /// 获取代码档-修改
        /// </summary>
        /// <returns></returns>
        public DataSet GetCodeBase(int ID)
        {
            return this.dal.GetCodeBase(ID);
        }

        public int GetRecordCount(string strWhere)
        {
            return this.dal.GetRecordCount(strWhere);
        }

        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return this.dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 判断代码类别、代码是否已存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists(CodeBaseModel model)
        {
            return this.dal.Exists(model);
        }

        public int Insert(CodeBaseModel model)
        {
            return this.dal.Insert(model);
        }

        public bool Update(CodeBaseModel model)
        {
            return this.dal.Update(model);
        }

        /// <summary>
        /// 删除选中代码
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        /// <summary>
        /// 删除选中代码下所有子类
        /// </summary>
        /// <param name="codeNo"></param>
        /// <returns></returns>
        public bool DeleteSub(string codeNo)
        {
            return this.dal.DeleteSub(codeNo);
        }

        /// <summary>
        /// 取得代码档选项资料
        /// </summary>
        /// <param name="pCategory">代码类别</param>
        /// <param name="bIncludeNo">是否包含选项</param>
        /// <returns></returns>
        public IList<CodeBaseModel> GetCodeBaseByCategory(string pCategory, bool bIncludeNo = false)
        {
            DataSet ds = this.dal.GetCodeBaseByCategory(pCategory, bIncludeNo);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // 将DataTable转为List
                IList<CodeBaseModel> list = CommonExtensions.DataTableToList<CodeBaseModel>(ds.Tables[0]);

                return list;
            }

            return null;
        }
    }
}

