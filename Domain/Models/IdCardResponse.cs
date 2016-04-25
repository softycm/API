namespace Domain.Interface
{
    /// <summary>
    ///     身份证识别信息
    /// </summary>
    public class IdCardResponse
    {
        /// <summary>
        ///     住址
        /// </summary>
        /// <value>The address.</value>
        public string Address { get; set; }

        /// <summary>
        ///     出生
        /// </summary>
        /// <value>The birthday.</value>
        public string Birthday { get; set; }

        /// <summary>
        ///     公民身份证号码
        /// </summary>
        /// <value>The card no.</value>
        public string CardNo { get; set; }

        /// <summary>
        ///     民族
        /// </summary>
        /// <value>The folk.</value>
        public string Folk { get; set; }

        /// <summary>
        ///     签发机关
        /// </summary>
        /// <value>The issue authority.</value>
        public string IssueAuthority { get; set; }

        /// <summary>
        ///     姓名
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        ///     性别
        /// </summary>
        /// <value>The sex.</value>
        public string Sex { get; set; }

        /// <summary>
        ///     有效期限
        /// </summary>
        /// <value>The valid period.</value>
        public string ValidPeriod { get; set; }
    }
}