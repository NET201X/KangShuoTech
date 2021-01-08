namespace KangShuoTech.Utilities.Common
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

        public static DataTable ToDataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();

            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());

            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();

                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
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