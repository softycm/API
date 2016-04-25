// ***********************************************************************
// Project          : API
// File             : YuMaiHelper.cs
// Created          : 2016-04-22  10:05
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-22  10:05
// ***********************************************************************
// <copyright file="YuMaiHelper.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class YunMaiHelper
    {
        //private readonly string boundary = "----WebKitFormBoundary8wBASHf6a6Pb4oCP";
        private readonly ArrayList bytesArray = new ArrayList();

        private readonly string url = "http://ocr.ccyunmai.com/UploadImg.action";

        /// <summary>
        ///     调用接口获取识别结果
        /// </summary>
        /// <param name="fileData">文件转成字符串后的数据</param>
        /// <param name="fileName">文件名</param>
        /// <param name="cardType">识别卡的类型</param>
        /// <param name="boundary">The boundary.</param>
        /// <param name="filedName">Name of the filed.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public async Task<string> Upload(string fileData, string fileName, string cardType, string boundary, string filedName = "img")
        {
            byte[] fileBytes = Convert.FromBase64String(fileData);
            this.SetFieldValue(boundary, filedName, fileName, "image/jpeg", fileBytes);
            this.SetFieldValue(boundary, "action", cardType);

            string responseText = "";
            WebClient webClient = new WebClient();

            //IP代理
            if (true)
            {
                //Tuple<string, int> tuple = this.MyProxy();
                WebProxy webProxy = new WebProxy("58.246.242.154", 8080);
                webClient.Proxy = webProxy;
            }

            webClient.Headers.Add("Content-Type", "multipart/form-data; boundary=" + boundary);

            byte[] responseBytes;
            byte[] bytes = this.MergeContent(boundary);

            try
            {
                //responseBytes = webClient.UploadData(requestUrl, bytes);
                responseBytes = await webClient.UploadDataTaskAsync(new Uri(this.url), bytes);
                responseText = Encoding.UTF8.GetString(responseBytes);
                return string.IsNullOrEmpty(responseText) ? "" : responseText;
            }
            catch (WebException ex)
            {
                Stream responseStream = ex.Response.GetResponseStream();
                responseBytes = new byte[ex.Response.ContentLength];
                responseStream.Read(responseBytes, 0, responseBytes.Length);
                responseText = Encoding.UTF8.GetString(responseBytes);
                return responseText;
            }
        }

        private byte[] MergeContent(string boundary)
        {
            int length = 0;
            int readLength = 0;
            string endBoundary = "--" + boundary + "--\r\n";
            byte[] endBoundaryBytes = Encoding.UTF8.GetBytes(endBoundary);

            this.bytesArray.Add(endBoundaryBytes);

            foreach (byte[] b in this.bytesArray)
            {
                length += b.Length;
            }

            byte[] bytes = new byte[length];

            foreach (byte[] b in this.bytesArray)
            {
                b.CopyTo(bytes, readLength);
                readLength += b.Length;
            }

            return bytes;
        }

        private Tuple<string, int> MyProxy()
        {
            string[] ip = { "58.246.242.154" };
            int[] port = { 8080 };
            Random random = new Random();
            int i = random.Next(0, 5);
            return new Tuple<string, int>(ip[i], port[i]);
        }

        private void SetFieldValue(string boundary, string fieldName, string fieldValue)
        {
            string httpRow = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"\r\n\r\n{1}\r\n";
            string httpRowData = string.Format(httpRow, fieldName, fieldValue);

            this.bytesArray.Add(Encoding.UTF8.GetBytes(httpRowData));
        }

        private void SetFieldValue(string boundary, string fieldName, string fileName, string contentType, byte[] fileBytes)
        {
            string end = "\r\n";
            string httpRow = "--" + boundary + "\r\nContent-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"\r\nContent-Type: {2}\r\n\r\n";
            string httpRowData = string.Format(httpRow, fieldName, fileName, contentType);

            byte[] headerBytes = Encoding.UTF8.GetBytes(httpRowData);
            byte[] endBytes = Encoding.UTF8.GetBytes(end);
            byte[] fileDataBytes = new byte[headerBytes.Length + fileBytes.Length + endBytes.Length];

            headerBytes.CopyTo(fileDataBytes, 0);
            fileBytes.CopyTo(fileDataBytes, headerBytes.Length);
            endBytes.CopyTo(fileDataBytes, headerBytes.Length + fileBytes.Length);

            this.bytesArray.Add(fileDataBytes);
        }
    }
}