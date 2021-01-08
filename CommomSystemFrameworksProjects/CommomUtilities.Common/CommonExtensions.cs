using NPinyin;
using KangShuoTech.CommomDataAccessProjects.CommonModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;

namespace CommomUtilities.Common
{
    public class CommonExtensions
    {
        /// <summary>
        /// 把DataTable转成List
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns>泛型集合</returns>
        public static IList<T> DataTableToList<T>(DataTable dt)
        {
            if (dt == null) return null;

            if (dt.Rows.Count < 0) return null;

            // 创建泛型集合
            IList<T> list = new List<T>();

            // 获取实体类和DataTable对应的属性清单
            Dictionary<PropertyInfo, string> pro = new Dictionary<PropertyInfo, string>();

            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), property =>
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (string.Compare(column.ColumnName, property.Name, true) == 0)
                    {
                        pro.Add(property, column.ColumnName);
                    }
                }
            });

            // 对清单中的实体类属性赋值
            foreach (DataRow row in dt.Rows)
            {
                // 创建泛型对象
                T t = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in pro.Keys)
                {
                    object value = row[pro[property]];
                    string fullName = property.PropertyType.ToString();
                    if (fullName.Contains("System.Nullable"))
                    {
                        value = string.IsNullOrEmpty(value.ToString()) ? null : value;

                        if (value == null)
                        {
                            property.SetValue(t, null, null);
                        }
                        else
                        {
                            if (fullName.Contains("System.Int32"))
                            {
                                property.SetValue(t, Convert.ToInt32(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Int64"))
                            {
                                property.SetValue(t, Convert.ToInt64(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.String"))
                            {
                                property.SetValue(t, value.ToString(), null);
                            }
                            else if (fullName.Contains("System.DateTime"))
                            {
                                property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Decimal"))
                            {
                                property.SetValue(t, Convert.ToDecimal(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Char"))
                            {
                                property.SetValue(t, Convert.ToChar(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Boolean"))
                            {
                                property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Guid"))
                            {
                                property.SetValue(t, new Guid(value.ToString()), null);
                            }
                            else
                            {
                                property.SetValue(t, Convert.ToString(value), null);
                            }
                        }
                    }
                    else
                    {
                        switch (fullName)
                        {
                            case "System.Int32":
                                property.SetValue(t, Convert.ToInt32(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                                break;
                            case "System.Int64":
                                property.SetValue(t, Convert.ToInt64(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                                break;
                            case "System.String":
                                if ((property.PropertyType).FullName.Contains("DateTime"))
                                {
                                    property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                                }
                                else
                                {
                                    property.SetValue(t, value == null ? "" : value.ToString(), null);
                                }

                                break;
                            case "System.DateTime":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? DateTime.MinValue : Convert.ToDateTime(value.ToString()), null);
                                break;
                            case "System.Decimal":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToDecimal(value.ToString()), null);
                                break;
                            case "System.Char":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? ' ' : Convert.ToChar(value.ToString()), null);
                                break;
                            case "System.Boolean":
                                property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                                break;
                            case "System.Guid":
                                property.SetValue(t, new Guid(value.ToString()), null);
                                break;
                            case "System.Byte[]":
                                property.SetValue(t, value, null);
                                break;
                            default:
                                property.SetValue(t, value == null ? "" : value.ToString(), null);
                                break;
                        }
                    }
                }

                list.Add(t);
            }

            return list;
        }

        /// <summary>
        /// 把DataRow转成T
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dr">数据源</param>
        /// <returns>Model</returns>
        public static T DataRowToModel<T>(DataRow row)
        {
            // 获取实体类和DataTable对应的属性清单
            Dictionary<PropertyInfo, string> pro = new Dictionary<PropertyInfo, string>();

            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), property =>
            {
                foreach (DataColumn column in row.Table.Columns)
                {
                    if (string.Compare(column.ColumnName, property.Name, true) == 0)
                    {
                        pro.Add(property, column.ColumnName);
                    }
                }
            });

            // 对清单中的实体类属性赋值
            // 创建泛型对象
            T t = Activator.CreateInstance<T>();

            foreach (PropertyInfo property in pro.Keys)
            {
                object value = row[pro[property]];
                string fullName = property.PropertyType.ToString();
                if (fullName.Contains("System.Nullable"))
                {
                    value = string.IsNullOrEmpty(value.ToString()) ? null : value;

                    if (value == null)
                    {
                        property.SetValue(t, null, null);
                    }
                    else
                    {
                        if (fullName.Contains("System.Int32"))
                        {
                            property.SetValue(t, Convert.ToInt32(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.Int64"))
                        {
                            property.SetValue(t, Convert.ToInt64(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.String"))
                        {
                            property.SetValue(t, value.ToString(), null);
                        }
                        else if (fullName.Contains("System.DateTime"))
                        {
                            property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.Decimal"))
                        {
                            property.SetValue(t, Convert.ToDecimal(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.Char"))
                        {
                            property.SetValue(t, Convert.ToChar(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.Boolean"))
                        {
                            property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                        }
                        else if (fullName.Contains("System.Guid"))
                        {
                            property.SetValue(t, new Guid(value.ToString()), null);
                        }
                        else
                        {
                            property.SetValue(t, Convert.ToString(value), null);
                        }
                    }
                }
                else
                {
                    switch (fullName)
                    {
                        case "System.Int32":
                            property.SetValue(t, Convert.ToInt32(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                            break;
                        case "System.Int64":
                            property.SetValue(t, Convert.ToInt64(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                            break;
                        case "System.String":
                            if ((property.PropertyType).FullName.Contains("DateTime"))
                            {
                                property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                            }
                            else
                            {
                                property.SetValue(t, value == null ? "" : value.ToString(), null);
                            }

                            break;
                        case "System.DateTime":
                            property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? DateTime.MinValue : Convert.ToDateTime(value.ToString()), null);
                            break;
                        case "System.Decimal":
                            property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToDecimal(value.ToString()), null);
                            break;
                        case "System.Char":
                            property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? ' ' : Convert.ToChar(value.ToString()), null);
                            break;
                        case "System.Boolean":
                            property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                            break;
                        case "System.Guid":
                            property.SetValue(t, new Guid(value.ToString()), null);
                            break;
                        case "System.Byte[]":
                            property.SetValue(t, value, null);
                            break;
                        default:
                            property.SetValue(t, value == null ? "" : value.ToString(), null);
                            break;
                    }
                }
            }

            return t;
        }

        /// <summary>
        /// 复制List中的元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="RealObject"></param>
        /// <returns></returns>
        public static T Clone<T>(T RealObject)
        {
            using (Stream objectStream = new MemoryStream())
            {
                //利用 System.Runtime.Serialization序列化与反序列化完成引用对象的复制
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(objectStream, RealObject);
                objectStream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(objectStream);
            }
        }

        /// <summary>
        /// 把DataTable转成List
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns>泛型集合</returns>
        public static List<T> ToList<T>(DataTable dt)
        {
            if (dt == null) return null;

            if (dt.Rows.Count < 0) return null;

            // 创建泛型集合
            List<T> list = new List<T>();

            // 获取实体类和DataTable对应的属性清单
            Dictionary<PropertyInfo, string> pro = new Dictionary<PropertyInfo, string>();

            Array.ForEach<PropertyInfo>(typeof(T).GetProperties(), property =>
            {
                foreach (DataColumn column in dt.Columns)
                {
                    if (string.Compare(column.ColumnName, property.Name, true) == 0)
                    {
                        pro.Add(property, column.ColumnName);
                    }
                }
            });

            // 对清单中的实体类属性赋值
            foreach (DataRow row in dt.Rows)
            {
                // 创建泛型对象
                T t = Activator.CreateInstance<T>();

                foreach (PropertyInfo property in pro.Keys)
                {
                    object value = row[pro[property]];
                    string fullName = property.PropertyType.ToString();
                    if (fullName.Contains("System.Nullable"))
                    {
                        value = string.IsNullOrEmpty(value.ToString()) ? null : value;

                        if (value == null)
                        {
                            property.SetValue(t, null, null);
                        }
                        else
                        {
                            if (fullName.Contains("System.Int32"))
                            {
                                property.SetValue(t, Convert.ToInt32(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Int64"))
                            {
                                property.SetValue(t, Convert.ToInt64(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.String"))
                            {
                                property.SetValue(t, value.ToString(), null);
                            }
                            else if (fullName.Contains("System.DateTime"))
                            {
                                property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Decimal"))
                            {
                                property.SetValue(t, Convert.ToDecimal(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Char"))
                            {
                                property.SetValue(t, Convert.ToChar(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Boolean"))
                            {
                                property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                            }
                            else if (fullName.Contains("System.Guid"))
                            {
                                property.SetValue(t, new Guid(value.ToString()), null);
                            }
                            else
                            {
                                property.SetValue(t, Convert.ToString(value), null);
                            }
                        }
                    }
                    else
                    {
                        switch (fullName)
                        {
                            case "System.Int32":
                                property.SetValue(t, Convert.ToInt32(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                                break;
                            case "System.Int64":
                                property.SetValue(t, Convert.ToInt64(string.IsNullOrEmpty(value.ToString()) ? "0" : value), null);
                                break;
                            case "System.String":
                                if ((property.PropertyType).FullName.Contains("DateTime"))
                                {
                                    property.SetValue(t, Convert.ToDateTime(value.ToString()), null);
                                }
                                else
                                {
                                    property.SetValue(t, value == null ? "" : value.ToString(), null);
                                }

                                break;
                            case "System.DateTime":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? DateTime.MinValue : Convert.ToDateTime(value.ToString()), null);
                                break;
                            case "System.Decimal":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? 0 : Convert.ToDecimal(value.ToString()), null);
                                break;
                            case "System.Char":
                                property.SetValue(t, string.IsNullOrEmpty(value.ToString()) ? ' ' : Convert.ToChar(value.ToString()), null);
                                break;
                            case "System.Boolean":
                                property.SetValue(t, Convert.ToBoolean(value.ToString()), null);
                                break;
                            case "System.Guid":
                                property.SetValue(t, new Guid(value.ToString()), null);
                                break;
                            case "System.Byte[]":
                                property.SetValue(t, value, null);
                                break;
                            default:
                                property.SetValue(t, value == null ? "" : value.ToString(), null);
                                break;
                        }
                    }
                }

                list.Add(t);
            }

            return list;
        }

        /// <summary>
        /// 获取汉语拼音码
        /// </summary>
        /// <param name="strVal"></param>
        /// <returns></returns>
        public static string GetPinym(string strVal)
        {
            if (string.IsNullOrEmpty(strVal)) return "";

            Encoding gb2312 = Encoding.GetEncoding("GB2312");

            return Pinyin.GetInitials(strVal, gb2312);
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpszOp, string lpszFile, string lpszParams, string lpszDir, int FsShowCmd);

        /// <summary>
        /// 读取XML配置文件 根据创建临时表的sql句 获取有哪些字段
        /// 目的：在模板修改时防止重复的字段添加
        /// </summary>
        /// <param name="path">模板地址</param>
        public static List<Model> GetXmlModel(string path)
        {
            List<Model> listModel = new List<Model>();

            if (File.Exists(path))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);

                XmlNodeList nodeList = doc.SelectNodes("//cursor");
                PropertyInfo[] propinfos = null;

                foreach (XmlNode node in nodeList)
                {
                    Model entity = new Model();

                    //初始化propertyinfo
                    if (propinfos == null)
                    {
                        Type objType = entity.GetType();
                        propinfos = objType.GetProperties();
                    }

                    //填充entity类的属性
                    foreach (PropertyInfo propinfo in propinfos)
                    {
                        XmlNode cNode = node.SelectSingleNode(propinfo.Name);

                        if (cNode == null) continue;

                        string v = cNode.InnerText;

                        if (v != null) propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                    }

                    listModel.Add(entity);
                }
            }

            return listModel;
        }

        /// <summary>
        /// 根据datatable获得列名
        /// </summary>
        /// <param name="dt">表对象</param>
        /// <returns>返回结果的数据列数组</returns>
        public static string[] GetColumnsByDataTable(DataTable dt)
        {
            string[] strColumns = null;

            if (dt.Columns.Count > 0)
            {
                int columnNum = 0;
                columnNum = dt.Columns.Count;
                strColumns = new string[columnNum];

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    strColumns[i] = dt.Columns[i].ColumnName;
                }
            }

            return strColumns;
        }
    }
}
