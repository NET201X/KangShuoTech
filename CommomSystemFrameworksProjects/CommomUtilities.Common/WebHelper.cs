using System.IO;
using System.Net;
using System;
using System.Drawing;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Net.Http;
using System.Web;

namespace CommomUtilities.Common
{
    public static class WebHelper
    {
        public static void SaveBase64StringToImage(string strBase64, string path, string name, ImageFormat fomat)
        {
            try
            {
                System.Drawing.Image img = Base64StringToImage(strBase64);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (Bitmap bitmap = new Bitmap(img))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        bitmap.Save(path + "\\" + name, fomat);
                    }
                }
                
                img.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string ImgToBase64String(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    FileStream fs = new FileStream(path, FileMode.Open);
                    byte[] arr = new byte[fs.Length];
                    fs.Position = 0;
                    fs.Read(arr, 0, (int)fs.Length);
                    fs.Close();
                    return Convert.ToBase64String(arr);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Image Base64StringToImage(string strBase64)
        {
            try
            {
                byte[] arr = Convert.FromBase64String(strBase64);
                MemoryStream ms = new MemoryStream(arr);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                ms.Dispose();

                return img;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 将List转换成DataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();

            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                dt.Columns.Add(property.Name, property.PropertyType);
            }

            object[] values = new object[properties.Count];

            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }

                dt.Rows.Add(values);
            }

            return dt;
        }

        /// <summary>
        /// 获得post请求后响应的数据
        /// </summary>
        /// <param name="postUrl">请求地址</param>
        /// <param name="postDataStr">请求带的数据</param>
        /// <returns>响应内容</returns>
        public static string PostHttp(string postUrl, string postDataStr)
        {
            string result = "";
            //postUrl = "http://Linda-PC/QCDataUploadWeb/Login/GetDeviceInfo";
            //postDataStr = "startDate=''&endDate=''&deviceType=20 ";

            try
            {
                string address = postUrl + (postDataStr == "" ? "" : "?");

                // 命名空间System.Net下的HttpWebRequest类
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);

                // 请求方式
                //request.Method = "GET";
                request.Method = "POST";
                request.ContentType = "application/json";

                // 浏览器类型，如果Servlet返回的内容与浏览器类型有关则该值非常有用
                request.Timeout = 200000;
                request.ReadWriteTimeout = 300000;
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 6.1; Trident/5.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; .NET4.0C; .NET4.0E)";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";

                // 是否保持常连接
                request.KeepAlive = false;
                request.Headers.Add("Accept-Encoding", "gzip, deflate");

                // 表示请求消息正文的长度
                //request.ContentLength = postDataStr.Length;
                request.ContentLength = Encoding.UTF8.GetByteCount(postDataStr);
                Stream postStream = request.GetRequestStream();
                byte[] postData = Encoding.UTF8.GetBytes(postDataStr);

                // 将传输的数据，请求正文写入请求流
                postStream.Write(postData, 0, postData.Length);
                postStream.Dispose();

                // 响应
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream myResponseStream = response.GetResponseStream();
                StreamReader myStreamReader = new StreamReader(myResponseStream);
                result = myStreamReader.ReadToEnd();
                myStreamReader.Close();
                myResponseStream.Close();


                //    byte[] postData = Encoding.UTF8.GetBytes(postDataStr);

                //    // 压缩后的byte数组
                //    byte[] compressedbuffer = null;

                //    // Compress buffer,压缩缓存
                //    MemoryStream ms = new MemoryStream();
                //    using (GZipStream zs = new GZipStream(ms, CompressionMode.Compress, true))
                //    {
                //        zs.Write(postData, 0, postData.Length);
                //    }

                //    // 只有GZipStream在Dispose后调应对应MemoryStream.ToArray()所得到的Buffer才是我们需要的结果
                //    compressedbuffer = ms.ToArray();

                //    // 将压缩后的byte数组basse64字符串
                //    string text64 = Convert.ToBase64String(compressedbuffer);
                //    var content = HttpUtility.UrlEncode(text64);
                //    HttpClient client = new HttpClient();
                //    string d = "content=" + System.Web.HttpUtility.UrlEncode(text64);

                //    var contenStr = new StringContent(d, Encoding.UTF8, "application/json");

                //    contenStr.Headers.Remove("Content-Type");//必须
                //    contenStr.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//1.根据需求设置

                //    result = client.PostAsync(postUrl, contenStr).Result.Content.ReadAsStringAsync().Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
}