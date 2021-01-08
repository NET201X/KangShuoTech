using NPinyin;
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

namespace KangShuoTech.Utilities.Common
{
    public  class CommonExtensions
    {
        /// <summary>
        /// 把DataTable转成List
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns>泛型集合</returns>
        public static IList<T> DataTableToList<T>(DataTable dt)
        {
            if (dt == null)  return null;

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
            if (string.IsNullOrEmpty(strVal))
            {
                return "";
            }

            Encoding gb2312 = Encoding.GetEncoding("GB2312");
            //string s = Pinyin.ConvertEncoding(strVal, Encoding.UTF8, gb2312);
            //Pinyin.GetInitials(s, gb2312);
            return Pinyin.GetInitials(strVal, gb2312);
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpszOp, string lpszFile, string lpszParams, string lpszDir, int FsShowCmd);

        public string toString(object value)
        {
            if (value == null) return "";
            else return value.ToString();
        }

        /// <summary>
        /// 根据默认项设置映射Mode实体取对应的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="oldModel"></param>
        /// <param name="newModel"></param>
        /// <param name="dtRequire"></param>
        /// <returns></returns>
        public static T EntityAssignment<T>(T oldModel, T newModel, DataTable dtRequire)
        {
            try
            {
                Type typeOld = oldModel.GetType();
                Type typeNew = newModel.GetType();

                foreach (DataRow item in dtRequire.Rows)
                {
                    PropertyInfo piOld = typeOld.GetProperty(item["OptionName"].ToString());
                    PropertyInfo piNew = typeNew.GetProperty(item["OptionName"].ToString());
                    string value = "";

                    if (item["IsSetValue"].ToString() == "是") value = item["ItemValue"].ToString();
                    else value = StringPlus.toString(piOld.GetValue(oldModel, null));

                    if (piOld != null && value != "")
                    {
                        if (piOld.PropertyType == typeof(string))
                        {
                            piNew.SetValue(newModel, value.ToString(), null);
                        }
                        else if (piOld.PropertyType == typeof(int) || piOld.PropertyType == typeof(int?))
                        {
                            piNew.SetValue(newModel, int.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(DateTime?) || piOld.PropertyType == typeof(DateTime))
                        {
                            piNew.SetValue(newModel, DateTime.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(float?) || piOld.PropertyType == typeof(float))
                        {
                            piNew.SetValue(newModel, float.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(double?) || piOld.PropertyType == typeof(double))
                        {
                            piNew.SetValue(newModel, double.Parse(value.ToString()), null);
                        }
                        else if (piOld.PropertyType == typeof(decimal?) || piOld.PropertyType == typeof(decimal))
                        {
                            piNew.SetValue(newModel, decimal.Parse(value.ToString()), null);
                        }
                        else
                        {
                            piNew.SetValue(newModel, value, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newModel;
        }
    }
}
