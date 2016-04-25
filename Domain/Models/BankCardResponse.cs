// ***********************************************************************
// Project          : API
// File             : BankCardResponse.cs
// Created          : 2016-04-22  9:53
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-22  9:53
// ***********************************************************************
// <copyright file="BankCardResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Domain.Interface
{
    /// <summary>
    ///     银行卡识别信息
    /// </summary>
    public class BankCardResponse
    {
        /// <summary>
        ///     银行卡号
        /// </summary>
        /// <value>The bank card no.</value>
        public string BankCardNo { get; set; }

        /// <summary>
        ///     银行名称
        /// </summary>
        /// <value>The name of the bank.</value>
        public string BankName { get; set; }

        /// <summary>
        ///     卡名称
        /// </summary>
        /// <value>The name of the card.</value>
        public string CardName { get; set; }

        /// <summary>
        ///     卡类型
        /// </summary>
        /// <value>The type of the card.</value>
        public string CardType { get; set; }

        /// <summary>
        ///     识别状态
        /// </summary>
        /// <value>The status.</value>
        public string Status { get; set; }
    }
}