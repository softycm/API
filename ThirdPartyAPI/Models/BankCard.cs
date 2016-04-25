// ***********************************************************************
// Project          : API
// File             : Information.cs
// Created          : 2016-04-21  16:14
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-21  16:15
// ***********************************************************************
// <copyright file="Information.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using Domain.Interface;
using Newtonsoft.Json;

namespace ThirdPartyAPI.Models
{
    public static class BankCardEx
    {
        public static BankCard ToResponse(this BankCardResponse result)
        {
            BankCard bankCard = new BankCard
            {
                BankCardNo = result.BankCardNo,
                BankName = result.BankName,
                CardName = result.CardName,
                CardType = result.CardType,
                Status = result.Status
            };
            return null;
        }
    }

    public class BankCard
    {
        /// <summary>
        ///     银行卡号
        /// </summary>
        /// <value>The bank card no.</value>
        [JsonProperty("bankCardNo")]
        public string BankCardNo { get; set; }

        /// <summary>
        ///     银行名称
        /// </summary>
        /// <value>The name of the bank.</value>
        [JsonProperty("bankName")]
        public string BankName { get; set; }

        /// <summary>
        ///     卡名称
        /// </summary>
        /// <value>The name of the card.</value>
        [JsonProperty("cardName")]
        public string CardName { get; set; }

        /// <summary>
        ///     卡类型
        /// </summary>
        /// <value>The type of the card.</value>
        [JsonProperty("cardType")]
        public string CardType { get; set; }

        /// <summary>
        ///     识别状态
        /// </summary>
        /// <value>The status.</value>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}