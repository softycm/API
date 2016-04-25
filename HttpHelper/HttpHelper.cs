using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HttpHelper
{
    public class HttpHelper
    {
        public HttpClient Client = client.Value;
        private static readonly Lazy<HttpClient> client;

        static HttpHelper()
        {
            client = new Lazy<HttpClient>(InitHttpClient);
        }

        public async Task<string> PostToYuMai(string imgPath)
        {
            FileStream fileStream = new FileStream("D:\\Work\\Test Solutions\\身份证电子照.jpg", FileMode.Open);
            byte[] data = new byte[1024 * 1024 * 4];
            await fileStream.ReadAsync(data, 0, data.Length);
            try
            {
                List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("callbackurl", "idcard"));
                values.Add(new KeyValuePair<string, string>("img", "D:\\Work\\Test Solutions\\身份证电子照.jpg"));
                FormUrlEncodedContent str = new FormUrlEncodedContent(values);
                //HttpContent content = new StringContent(JsonConvert.SerializeObject(json));

                HttpResponseMessage response = await this.Client.PostAsync("UploadImg.action", str);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        private static HttpClient InitHttpClient()
        {
            HttpClient httpClient = new HttpClient { BaseAddress = new Uri("http://ocr.ccyunmai.com/") };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
            httpClient.Timeout = new TimeSpan(0, 0, 10, 0);
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Accept-Charset", "UTF-8");
            httpClient.DefaultRequestHeaders.Host = "ocr.ccyunmai.com";

            return httpClient;
        }
    }
}