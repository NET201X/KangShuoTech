using KangShuoTech.DataAccessProjects.Model;
using KangShuoTech.Utilities.CommonUI;

namespace RecordManagement
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class PEControler : Controler
    {
        public PEControler(PhysicalForm iparent, ChildFormFactory factory) : base(iparent, factory)
        {
        }

        public override bool DoSave()
        {
            BindingFlags bindingAttr = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            PhysicalForm iParentFrm = base.IParentFrm as PhysicalForm;
            bool flag = true;
            base.SaveDataInfo = "保存失败！\r\n";
            IEnumerable<IGrouping<string, RecordsRequiredModel>> enumerable = from a in iParentFrm.Archive_requireds group a by a.BTable;
            foreach (KeyValuePair<string, IChildForm> pair in base.IChildrens)
            {
                if (pair.Value.EveryThingIsOk)
                {
                    pair.Value.SaveDataInfo = "";
                    pair.Value.UpdataToModel();
                    foreach (PropertyInfo info in pair.Value.GetType().GetProperties(bindingAttr))
                    {
                        if (info.PropertyType.Name.Contains("Records"))
                        {
                            using (IEnumerator<IGrouping<string, RecordsRequiredModel>> enumerator = enumerable.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    Predicate<RecordsRequiredModel> match = null;
                                    IGrouping<string, RecordsRequiredModel> tmp_model = enumerator.Current;
                                    if ((info.PropertyType.Name == tmp_model.Key) && ((pair.Key != "一般情况") || (tmp_model.Key != "RecordsPhysicalExamModel")))
                                    {
                                        object obj2 = info.GetValue(pair.Value, null);                                              
                                        if (match == null)
                                        {
                                            match = req => req.BTable == tmp_model.Key;
                                        }
                                        foreach (RecordsRequiredModel archive_required in iParentFrm.Archive_requireds.FindAll(match))
                                        {
                                            decimal? nullable = archive_required.IsRequired;
                                            if (((nullable.GetValueOrDefault() != 0M) ? 0 : (nullable.HasValue ? 1 : 0)) == 0)
                                            {
                                                PropertyInfo property = obj2.GetType().GetProperty(archive_required.Name, bindingAttr);
                                                if (property != null)
                                                {
                                                    object obj3 = property.GetValue(obj2, null);
                                                    if (obj3 == null)
                                                    {
                                                        PEControler controler = this;
                                                        string str = controler.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                        controler.SaveDataInfo = str;
                                                        flag = false;
                                                    }
                                                    else if (string.IsNullOrEmpty(obj3.ToString()))
                                                    {
                                                        PEControler controler2 = this;
                                                        string str2 = controler2.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                        controler2.SaveDataInfo = str2;
                                                        flag = false;
                                                    }
                                                }
                                                else
                                                {
                                                    PEControler controler3 = this;
                                                    string str3 = controler3.SaveDataInfo + archive_required.Comment + " :必填\r\n";
                                                    controler3.SaveDataInfo = str3;
                                                    flag = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        return false;
                    }
                    if (pair.Value.CheckErrorInput() == ChildFormStatus.HasErrorInput)
                    {
                        flag = false;
                        base.IParentFrm.ChildStatus(pair.Key, ChildFormStatus.HasErrorInput);
                        PEControler controler4 = this;
                        string str4 = controler4.SaveDataInfo + pair.Value.SaveDataInfo;
                        controler4.SaveDataInfo = str4;
                    }
                }
            }
            if (!flag)
            {
                return false;
            }
            foreach (KeyValuePair<string, IChildForm> pair2 in base.IChildrens)
            {
                if (pair2.Value.EveryThingIsOk)
                {
                    flag = pair2.Value.SaveModelToDB();
                }
            }
            if (!flag)
            {
                return false;
            }
            IParentModel<RecordsBaseInfoModel> model = base.IParentFrm as IParentModel<RecordsBaseInfoModel>;
            if (model != null)
            {
                model.SaveModel();
            }
            return flag;
        }
    }
}

