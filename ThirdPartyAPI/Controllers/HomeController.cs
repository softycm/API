using Domain.Interface;
using Service;
using Swashbuckle.Swagger.Annotations;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using ThirdPartyAPI.Models;

namespace ThirdPartyAPI.Controllers
{
    public class HomeController : ApiController
    {
        private readonly YunMaiService yunMaiService = new YunMaiService();

        /// <summary>
        ///     文件转换成字符串
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>System.String.</returns>
        //public string GetFileDataString(string filePath)
        //{
        //    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        //    byte[] fileBytess = new byte[fs.Length];
        //    fs.Read(fileBytess, 0, fileBytess.Length);
        //    fs.Close();
        //    fs.Dispose();
        //    return Encoding.ASCII.GetString(fileBytess);
        //    return Convert.ToBase64String(fileBytess);
        //}

        /// <summary>
        ///     银行卡识别
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(BankCardResponse))]
        public async Task<IHttpActionResult> IdentifyBankCard(Request request)
        {
            BankCardResponse response = await this.yunMaiService.IdentifyBankCard(request.FileName, request.FileData);
            return this.Ok(response);
        }

        /// <summary>
        ///     驾驶证识别
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(DriverCardResponse))]
        public async Task<IHttpActionResult> IdentifyDriverCard(Request request)
        {
            DriverCardResponse response = await this.yunMaiService.IdentifyDriverCard(request.FileName, request.FileData);
            return this.Ok(response);
        }

        /// <summary>
        ///     身份证识别
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Task&lt;IHttpActionResult&gt;.</returns>
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IdCardResponse))]
        public async Task<IHttpActionResult> IdentifyIdCard(Request request)
        {
            IdCardResponse response = await this.yunMaiService.IdentifyIdCard(request.FileName, request.FileData);
            return this.Ok(response);
        }
    }
}