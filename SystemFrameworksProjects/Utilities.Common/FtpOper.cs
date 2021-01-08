namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Net;

    public class FtpOper
    {
        public static void CompressFile(string iFile, string oFile)
        {
            if (!System.IO.File.Exists(iFile))
            {
                throw new FileNotFoundException("文件未找到!");
            }
            FileStream stream = null;
            FileStream stream2 = null;
            GZipStream stream3 = null;
            try
            {
                stream = new FileStream(iFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] buffer = new byte[stream.Length];
                if (stream.Read(buffer, 0, buffer.Length) != buffer.Length)
                {
                    throw new ApplicationException("压缩文件异常!");
                }
                stream2 = new FileStream(oFile, FileMode.OpenOrCreate, FileAccess.Write);
                stream3 = new GZipStream(stream2, CompressionMode.Compress, true);
                stream3.Write(buffer, 0, buffer.Length);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (stream3 != null)
                {
                    stream3.Close();
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
            }
        }

        private void Connect(string path, string ftpUserID, string ftpPassword)
        {
        }

        public static bool makeDir(string ftpServerIP, string ftpUserID, string ftpPassword, string dirName)
        {
            bool flag = true;
            string requestUriString = "ftp://" + ftpServerIP + "/" + dirName;
            FtpWebRequest request = WebRequest.Create(requestUriString) as FtpWebRequest;
            request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
            request.Method = "NLST";
            try
            {
                request.GetResponse();
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine("目录不存在");
                LogHelper.LogError(exception);
            }
            try
            {
                FtpWebRequest request2 = (FtpWebRequest) WebRequest.Create(new Uri(requestUriString));
                request2.UseBinary = true;
                request2.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request2.Method = "MKD";
                request2.GetResponse().Close();
            }
            catch (Exception exception2)
            {
                LogHelper.LogError(exception2);
                flag = false;
            }
            return flag;
        }

        public static int up(string filePath, string ftpServerIP, string ftpUserID, string ftpPassword, string targetFile)
        {
            int num = 0;
            try
            {
                FtpWebRequest request = (FtpWebRequest) WebRequest.Create("ftp://" + ftpServerIP + "//" + targetFile);
                request.UseBinary = true;
                request.Method = "STOR";
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                System.IO.File.ReadAllBytes(filePath);
                using (Stream stream = request.GetRequestStream())
                {
                    using (FileStream stream2 = System.IO.File.OpenRead(filePath))
                    {
                        stream2.CopyTo(stream);
                    }
                }
                FtpWebResponse response = (FtpWebResponse) request.GetResponse();
                if (response != null)
                {
                    LogHelper.LogInfo(response.StatusDescription.ToString());
                }
            }
            catch (Exception exception)
            {
                LogHelper.LogError(exception);
                num = -2;
            }
            return num;
        }

        public static int UploadFtp(string filePath, string ftpServerIP, string ftpUserID, string ftpPassword)
        {
            FileInfo info = new FileInfo(filePath);
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + info.Name));
            try
            {
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request.KeepAlive = false;
                request.Method = "STOR";
                request.UseBinary = true;
                request.ContentLength = info.Length;
                int count = 0x800;
                byte[] buffer = new byte[count];
                FileStream stream = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                Stream requestStream = request.GetRequestStream();
                for (int i = stream.Read(buffer, 0, count); i != 0; i = stream.Read(buffer, 0, count))
                {
                    requestStream.Write(buffer, 0, i);
                }
                requestStream.Close();
                stream.Close();
                return 0;
            }
            catch (Exception exception)
            {
                request.Abort();
                LogHelper.LogError(exception);
                return -2;
            }
        }

        public static int UploadFtp(string filePath, string ftpServerIP, string ftpUserID, string ftpPassword, Action<int, string, bool> goWhere)
        {
            return UploadFtp(filePath, ftpServerIP, ftpUserID, ftpPassword, goWhere, filePath);
        }

        public static int UploadFtp(string filePath, string ftpServerIP, string ftpUserID, string ftpPassword, Action<int, string, bool> goWhere, string TagPath)
        {
            FileInfo info = new FileInfo(filePath);
            Uri uri = new Uri("ftp://" + ftpServerIP + "/" + TagPath);
            FtpWebRequest request = (FtpWebRequest) WebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + TagPath));
            try
            {
                request.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                request.KeepAlive = false;
                request.Method = "STOR";
                request.UseBinary = true;
                request.ContentLength = info.Length;
                int count = 0x800;
                byte[] buffer = new byte[count];
                FileStream stream = info.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                long num2 = stream.Length / ((long) count);
                if (goWhere != null)
                {
                    goWhere((int) num2, "", true);
                }
                int num3 = 1;
                Stream requestStream = request.GetRequestStream();
                int num4 = stream.Read(buffer, 0, count);
                if (goWhere != null)
                {
                    goWhere(num3, "", false);
                }
                decimal num5 = stream.Length / 1024.00M;
                Stopwatch stopwatch = new Stopwatch();
                int num6 = 50;
                int num7 = 1;
                stopwatch.Start();
                int tickCount = Environment.TickCount;
                while (num4 != 0)
                {
                    string str = "";
                    requestStream.Write(buffer, 0, num4);
                    num4 = stream.Read(buffer, 0, count);
                    if ((num7 % num6) == 0)
                    {
                        stopwatch.Stop();
                        decimal totalSeconds = (decimal) stopwatch.Elapsed.TotalSeconds;
                        decimal num10 = ((num6 * count) / 1024M) / totalSeconds;
                        decimal num11 = num3 / num2;
                        decimal num12 = ((((num2 - num3) / num2) * stream.Length) / 1024M) / num10;
                        str = string.Format("大小:{0}KB,上传速度:{1},已上传{2},预计剩余时间:{3}", new object[] { num5.ToString("0.00"), num10.ToString("0.00") + "KB/S", num11.ToString("P"), num12.ToString("0.00") + "秒" });
                        stopwatch.Reset();
                        stopwatch.Start();
                    }
                    if (goWhere != null)
                    {
                        goWhere(++num3, str, false);
                    }
                    num7++;
                }
                decimal num13 = (Environment.TickCount - tickCount) / 1000M;
                string str2 = string.Format("上传完成,大小:{0}KB,平均速度:{1}KB/S,用时:{2}秒", num5.ToString("0.00"), (num5 / num13).ToString("0.00"), num13.ToString("0.00"));
                goWhere(num3, str2, false);
                requestStream.Close();
                stream.Close();
                return 0;
            }
            catch (Exception exception)
            {
                request.Abort();
                ErrorLog.WriterLog(uri.ToString());
                LogHelper.LogError(exception);
                return -2;
            }
        }
    }
}

