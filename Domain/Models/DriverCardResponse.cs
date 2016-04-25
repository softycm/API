// ***********************************************************************
// Project          : API
// File             : DriverCardResponse.cs
// Created          : 2016-04-22  13:28
//
// Last Modified By : 袁成满(lu.siqi@outlook.com)
// Last Modified On : 2016-04-22  13:28
// ***********************************************************************
// <copyright file="DriverCardResponse.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Domain.Interface
{
    public class DriverCardResponse
    {
        public string Address { get; set; }
        public string Birthday { get; set; }
        public string CardNo { get; set; }
        public string DrivingType { get; set; }
        public string IssueDate { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public string RegisterDate { get; set; }
        public string Sex { get; set; }
        public int ValidPeriod { get; set; }
    }
}