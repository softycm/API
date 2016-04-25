// ***********************************************************************
// Project          : API
// File             : IYuMaiService.cs
// Created          : 2016-04-22  10:01
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-22  10:01
// ***********************************************************************
// <copyright file="IYuMaiService.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IYunMaiService
    {
        Task<IdCardResponse> IdentifyIdCard(string fileName, string fileData);
    }
}