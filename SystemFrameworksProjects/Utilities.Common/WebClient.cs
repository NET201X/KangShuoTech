namespace KangShuoTech.Utilities.Common
{
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Net;
    using System.Net.Cache;
    using System.Net.Security;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading;

    public class WebClient
    {
        private int bufferSize = 0x3b88;
        private static System.Net.CookieContainer cc;
        private System.Text.Encoding encoding = System.Text.Encoding.Default;
        private WebProxy proxy;
        private WebHeaderCollection requestHeaders = new WebHeaderCollection();
        private string respHtml = "";
        private WebHeaderCollection responseHeaders = new WebHeaderCollection();

        public event EventHandler<DownloadEventArgs> DownloadProgressChanged;

        public event EventHandler<UploadEventArgs> UploadProgressChanged;

        static WebClient()
        {
            LoadCookiesFromDisk();
        }

        private bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        private HttpWebRequest CreateRequest(string url, string method)
        {
            Uri requestUri = new Uri(url);
            if (requestUri.Scheme == "https")
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(this.CheckValidationResult);
            }
            HttpWebRequest.DefaultCachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.Revalidate);
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(requestUri);
            request.AllowAutoRedirect = false;
            request.AllowWriteStreamBuffering = false;
            request.Method = method;
            if (this.proxy != null)
            {
                request.Proxy = this.proxy;
            }
            request.CookieContainer = cc;
            foreach (string str in this.requestHeaders.Keys)
            {
                request.Headers.Add(str, this.requestHeaders[str]);
            }
            this.requestHeaders.Clear();
            return request;
        }

        public void DownloadFile(string url, string filename)
        {
            FileStream stream = null;
            try
            {
                byte[] data = this.GetData(this.CreateRequest(url, "GET"));
                stream = new FileStream(filename, FileMode.Create, FileAccess.Write);
                stream.Write(data, 0, data.Length);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        private byte[] GetData(HttpWebRequest request)
        {
            int num;
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            this.responseHeaders = response.Headers;
            DownloadEventArgs e = new DownloadEventArgs();
            if (this.responseHeaders[HttpResponseHeader.ContentLength] != null)
            {
                e.TotalBytes = Convert.ToInt32(this.responseHeaders[HttpResponseHeader.ContentLength]);
            }
            MemoryStream stream = new MemoryStream();
            byte[] buffer = new byte[this.bufferSize];
            while ((num = responseStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                stream.Write(buffer, 0, num);
                if (this.DownloadProgressChanged != null)
                {
                    e.BytesReceived += num;
                    e.ReceivedData = new byte[num];
                    Array.Copy(buffer, e.ReceivedData, num);
                    this.DownloadProgressChanged(this, e);
                }
            }
            responseStream.Close();
            if (this.ResponseHeaders[HttpResponseHeader.ContentEncoding] != null)
            {
                MemoryStream stream3 = new MemoryStream();
                byte[] buffer2 = new byte[100];
                string str = this.ResponseHeaders[HttpResponseHeader.ContentEncoding].ToLower();
                if (str != null)
                {
                    if (!(str == "gzip"))
                    {
                        if (str == "deflate")
                        {
                            int num3;
                            DeflateStream stream5 = new DeflateStream(stream, CompressionMode.Decompress);
                            while ((num3 = stream5.Read(buffer2, 0, buffer2.Length)) > 0)
                            {
                                stream3.Write(buffer2, 0, num3);
                            }
                            return stream3.ToArray();
                        }
                    }
                    else
                    {
                        int num2;
                        GZipStream stream4 = new GZipStream(stream, CompressionMode.Decompress);
                        while ((num2 = stream4.Read(buffer2, 0, buffer2.Length)) > 0)
                        {
                            stream3.Write(buffer2, 0, num2);
                        }
                        return stream3.ToArray();
                    }
                }
            }
            return stream.ToArray();
        }

        public byte[] GetData(string url)
        {
            return this.GetData(this.CreateRequest(url, "GET"));
        }

        public string GetHtml(string url)
        {
            this.respHtml = this.encoding.GetString(this.GetData(this.CreateRequest(url, "GET")));
            return this.respHtml;
        }

        private static void LoadCookiesFromDisk()
        {
            cc = new System.Net.CookieContainer();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + @"\webclient.cookie";
            if (System.IO.File.Exists(path))
            {
                FileStream serializationStream = null;
                try
                {
                    serializationStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                    cc = (System.Net.CookieContainer) new BinaryFormatter().Deserialize(serializationStream);
                }
                finally
                {
                    if (serializationStream != null)
                    {
                        serializationStream.Close();
                    }
                }
            }
        }

        public string Post(string url, string postData)
        {
            byte[] bytes = this.encoding.GetBytes(postData);
            return this.Post(url, bytes);
        }

        public string Post(string url, byte[] postData)
        {
            HttpWebRequest request = this.CreateRequest(url, "POST");
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.KeepAlive = true;
            this.PostData(request, postData);
            this.respHtml = this.encoding.GetString(this.GetData(request));
            return this.respHtml;
        }

        public string Post(string url, MultipartForm mulitpartForm)
        {
            HttpWebRequest request = this.CreateRequest(url, "POST");
            request.ContentType = mulitpartForm.ContentType;
            request.ContentLength = mulitpartForm.FormData.Length;
            request.KeepAlive = true;
            this.PostData(request, mulitpartForm.FormData);
            this.respHtml = this.encoding.GetString(this.GetData(request));
            return this.respHtml;
        }

        private void PostData(HttpWebRequest request, byte[] postData)
        {
            int num3;
            int offset = 0;
            int bufferSize = this.bufferSize;
            Stream requestStream = request.GetRequestStream();
            UploadEventArgs e = new UploadEventArgs {
                TotalBytes = postData.Length
            };
            while ((num3 = postData.Length - offset) > 0)
            {
                if (bufferSize > num3)
                {
                    bufferSize = num3;
                }
                requestStream.Write(postData, offset, bufferSize);
                offset += bufferSize;
                if (this.UploadProgressChanged != null)
                {
                    e.BytesSent = offset;
                    this.UploadProgressChanged(this, e);
                }
            }
            requestStream.Close();
        }

        private static void SaveCookiesToDisk()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + @"\webclient.cookie";
            FileStream serializationStream = null;
            try
            {
                serializationStream = new FileStream(path, FileMode.Create);
                new BinaryFormatter().Serialize(serializationStream, cc);
            }
            finally
            {
                if (serializationStream != null)
                {
                    serializationStream.Close();
                }
            }
        }

        public int BufferSize
        {
            get
            {
                return this.bufferSize;
            }
            set
            {
                this.bufferSize = value;
            }
        }

        public System.Net.CookieContainer CookieContainer
        {
            get
            {
                return cc;
            }
            set
            {
                cc = value;
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return this.encoding;
            }
            set
            {
                this.encoding = value;
            }
        }

        public WebProxy Proxy
        {
            get
            {
                return this.proxy;
            }
            set
            {
                this.proxy = value;
            }
        }

        public WebHeaderCollection RequestHeaders
        {
            get
            {
                return this.requestHeaders;
            }
        }

        public string RespHtml
        {
            get
            {
                return this.respHtml;
            }
            set
            {
                this.respHtml = value;
            }
        }

        public WebHeaderCollection ResponseHeaders
        {
            get
            {
                return this.responseHeaders;
            }
        }
    }
}

