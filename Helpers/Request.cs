using System;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace Helpers
{
    public static class Request
    {
        public static string Get(string url, string token = "")
        {
            string result = string.Empty;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());
                if (!string.IsNullOrEmpty(token))
                {
                    request.Headers.Add("token", token);
                }
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())              
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {                    
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return result;
        }

        public static string Post(string url, string postData, string token = "")
        {
            string result = string.Empty;

            try
            {
                
                var request = (HttpWebRequest)WebRequest.Create(url);

                var data = Encoding.UTF8.GetBytes(postData);

                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                request.ContentType = "application/json; charset=utf-8";
                request.Method = "POST";
                request.Accept = "application/json; charset=utf-8";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static string Put(string url, string postData)
        {
            string result = string.Empty;

            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                var data = Encoding.UTF8.GetBytes(postData);

                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                request.ContentType = "application/json; charset=utf-8";
                request.Method = "PUT";
                request.Accept = "application/json; charset=utf-8";
                request.ContentLength = data.Length;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)request.GetResponse();

                result = new StreamReader(response.GetResponseStream()).ReadToEnd();
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public static string Delete(string url)
        {
            string result = string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "DELETE";
                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                   
                }
            }
            catch
            {
            }
            return result;
        }

        public static string XmlHttpRequest(string Request, string xmlcontent, string ip = null, string port = null)
        {
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.Create(Request + "?InBoundHcp=" + xmlcontent) as HttpWebRequest;
                //HttpWebRequest httpWebRequest = WebRequest.Create("https://traderdma.denizyatirim.com/hcp/process.aspx?InBoundHcp=" + xmlcontent) as HttpWebRequest;

                if (httpWebRequest != null)
                {
                    httpWebRequest.ContentType = "text/xml; encoding='utf-8'";
                    httpWebRequest.Headers.Add("X_FORWARDED_TARGET", "195.85.255.150:443");
                }
                XmlDocument xmlDocument = new XmlDocument();
                                
                if (!string.IsNullOrEmpty(ip))
                {
                    httpWebRequest.Headers.Add("HTTP_FORWARDED_FOR", ip);
                    httpWebRequest.Headers.Add("HTTP_X_FORWARDED_FOR", ip);
                    httpWebRequest.Headers.Add("X_FORWARDED_FOR", ip);
                }

                if (!string.IsNullOrEmpty(port))
                {
                    httpWebRequest.Headers.Add("HTTP_FORWARDED_PORT", port);
                    httpWebRequest.Headers.Add("HTTP_X_FORWARDED_PORT", port);
                    httpWebRequest.Headers.Add("X_FORWARDED_PORT", port);
                }

                string str = "";

                using (HttpWebResponse response = httpWebRequest.GetResponse() as HttpWebResponse)
                {
                    try
                    {
                        if (response != null)
                        {
                            using (var sr = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1254)))
                            {
                                str = sr.ReadToEnd();
                            }
                        }
                        return str;
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public static Stream GetFile(string url)
        {
            Stream result;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Headers.Add("AcceptLanguage", System.Threading.Thread.CurrentThread.CurrentCulture.ToString());

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                     result = response.GetResponseStream();

                return result;
            }
            catch (Exception ex)
            {

            }

            return null;
        }

    }
}
