using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AtkTennis
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
    }
}
