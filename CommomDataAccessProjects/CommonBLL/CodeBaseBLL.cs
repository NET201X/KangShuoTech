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
        /// ��ȡ�������
        /// </summary>
        /// <returns></returns>
        public DataSet GetCategory()
        {
            return this.dal.GetCategory();
        }

        /// <summary>
        /// ��ȡ���뵵-�޸�
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
        /// �жϴ�����𡢴����Ƿ��Ѵ���
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
        /// ɾ��ѡ�д���
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public bool Delete(int ID)
        {
            return this.dal.Delete(ID);
        }

        /// <summary>
        /// ɾ��ѡ�д�������������
        /// </summary>
        /// <param name="codeNo"></param>
        /// <returns></returns>
        public bool DeleteSub(string codeNo)
        {
            return this.dal.DeleteSub(codeNo);
        }

        /// <summary>
        /// ȡ�ô��뵵ѡ������
        /// </summary>
        /// <param name="pCategory">�������</param>
        /// <param name="bIncludeNo">�Ƿ����ѡ��</param>
        /// <returns></returns>
        public IList<CodeBaseModel> GetCodeBaseByCategory(string pCategory, bool bIncludeNo = false)
        {
            DataSet ds = this.dal.GetCodeBaseByCategory(pCategory, bIncludeNo);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                // ��DataTableתΪList
                IList<CodeBaseModel> list = CommonExtensions.DataTableToList<CodeBaseModel>(ds.Tables[0]);

                return list;
            }

            return null;
        }
    }
}

