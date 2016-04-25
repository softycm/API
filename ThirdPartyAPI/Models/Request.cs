// ***********************************************************************
// Project          : API
// File             : Request.cs
// Created          : 2016-04-21  17:25
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-21  17:25
// ***********************************************************************
// <copyright file="Request.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using Newtonsoft.Json;

namespace ThirdPartyAPI.Models
{
    public class Request
    {
        /// <summary>
        ///     文件Base64后的字符串
        /// </summary>
        /// <value>The file data.</value>
        [JsonProperty("fileData")]
        public string FileData { get; set; }

        /// <summary>
        ///     文件名
        /// </summary>
        /// <value>The name of the file.</value>
        [JsonProperty("fileName")]
        public string FileName { get; set; }
    }
}