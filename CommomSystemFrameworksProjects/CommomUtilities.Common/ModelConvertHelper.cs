namespace CommomUtilities.Common
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data;
    using System.Reflection;
    using System.Collections;
    using System.Linq;

    /// <summary>    
    /// Table转为List
    /// </summary>    
    public class ModelConvertHelper<T> where T : new()
    {
        public static List<T> ToList(DataTable dt)
        {
            Type t = typeof(T);
            PropertyInfo[] propertys = t.GetProperties();
            List<T> lst = new List<T>();
            string typeName = string.Empty;

            foreach (DataRow dr in dt.Rows)
            {
                T entity = new T();

                foreach (PropertyInfo pi in propertys)
                {
                    typeName = pi.Name;

                    if (dt.Columns.Contains(typeName))
                    {
                        if (!pi.CanWrite) continue;

                        object value = dr[typeName];

                        if (value == DBNull.Value) continue;

                        if (pi.PropertyType == typeof(string))
                        {
                            pi.SetValue(entity, value.ToString(), null);
                        }
                        else if (pi.PropertyType == typeof(int) || pi.PropertyType == typeof(int?))
                        {
                            pi.SetValue(entity, int.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(DateTime?) || pi.PropertyType == typeof(DateTime))
                        {
                            pi.SetValue(entity, DateTime.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(float?) || pi.PropertyType == typeof(float))
                        {
                            pi.SetValue(entity, float.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(double?) || pi.PropertyType == typeof(double))
                        {
                            pi.SetValue(entity, double.Parse(value.ToString()), null);
                        }
                        else if (pi.PropertyType == typeof(decimal?) || pi.PropertyType == typeof(decimal))
                        {
                            pi.SetValue(entity, decimal.Parse(value.ToString()), null);
                        }
                        else
                        {
                            pi.SetValue(entity, value, null);
                        }
                    }
                }

                lst.Add(entity);
            }

            return lst;
        }

        public static DataTable ToDataTable<T>(IList<T> collection)
        {
            var dt = new DataTable();

            if (collection.Count() > 0)
            {
                PropertyInfo[] propertys = collection[0].GetType().GetProperties();

                foreach (PropertyInfo pi in propertys)
                {
                    Type colType = pi.PropertyType;

                    if (colType.IsGenericType && colType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        colType = colType.GetGenericArguments()[0];
                    }

                    dt.Columns.Add(pi.Name, colType);
                }

                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in propertys)
                    {
                        object obj = pi.GetValue(collection[i], null);
                        tempList.Add(obj);
                    }

                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }

            return dt;
        }
    }
}