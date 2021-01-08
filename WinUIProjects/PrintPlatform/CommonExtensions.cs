using NPinyin;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace KangShuoTech.Utilities.Common
{
    public static class CommonExtensions
    {
        /// <summary>
        /// 把DataTable转成List
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="dt">数据源</param>
        /// <returns>泛型集合</returns>
        public static IList<T> DataTableToList<T>(DataTable dt)
        {
            if (dt == null)
            {
                return null;
            }

            if (dt.Rows.Count < 0)
            {
                return null;
            }

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

        /// <summary>  
        /// 将给定的文件 拼接输出到指定的tif文件路径  
        /// </summary>  
        /// <param name="imageFiles">文件路径列表</param>  
        /// <param name="outFile">拼接后保存的 tif文件路径</param>  
        /// <param name="compressEncoder">压缩方式</param>  
        public static void JoinTiffImages(List<string> imageFiles, string outFile, EncoderValue compressEncoder)
        {
            if (File.Exists(outFile))
            {
                File.Delete(outFile);
            }

            //如果只有一个文件，直接复制到目标  
            if (imageFiles.Count == 1)
            {
                if (!File.Exists(imageFiles[0]))
                {
                    return;
                }

                File.Copy(imageFiles[0], outFile, true);
                return;
            }

            System.Drawing.Imaging.Encoder enc = System.Drawing.Imaging.Encoder.SaveFlag;

            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, (long)compressEncoder);

            Bitmap pages = null;
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");

            foreach (string strImageFile in imageFiles)
            {
                if (!File.Exists(strImageFile))
                {
                    continue;
                }

                if (frame == 0)
                {
                    pages = (Bitmap)Image.FromFile(strImageFile);
                    //保存第一个tif文件 到目标处  
                    pages.Save(outFile, info, ep);
                }
                else
                {
                    //保存好第一个tif文件后，其余 设置为添加一帧到 图像中  
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    Bitmap bm = (Bitmap)Image.FromFile(strImageFile);
                    pages.SaveAdd(bm, ep);
                    bm.Dispose();
                }

                if (frame == imageFiles.Count - 1)
                {
                    //flush and close.  
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame++;
            }
            pages.Dispose(); //释放资源  
            return;
        }

        /// <summary>  
        /// 获取支持的编码信息  
        /// </summary>  
        /// <param name="mimeType">协议描述</param>  
        /// <returns>图像编码信息</returns>  
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }

            return null;
        }

        [DllImport("shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpszOp, string lpszFile, string lpszParams, string lpszDir, int FsShowCmd);
    }
}
