using Domain.Interface;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace Service
{
    public class YunMaiService
    {
        private readonly string BankCardBoundary = "----WebKitFormBoundaryitCVaBrzbNDdigEB";
        private readonly string DriverCardBoundary = "----WebKitFormBoundaryJxf5Ild3R6C9ZiC6";
        private readonly string IdCardBoundary = "----WebKitFormBoundary8wBASHf6a6Pb4oCP";
        private readonly YunMaiHelper yunMaiHelper = new YunMaiHelper();

        public async Task<BankCardResponse> IdentifyBankCard(string fileName, string fileData)
        {
            string response = await this.yunMaiHelper.Upload(fileData, fileName, "bankcard", this.IdCardBoundary);
            return this.GetBankCardDataFromString(response);
        }

        public async Task<DriverCardResponse> IdentifyDriverCard(string fileName, string fileData)
        {
            string response = await this.yunMaiHelper.Upload(fileData, fileName, "driver", this.DriverCardBoundary);
            return this.GetDriverDataFromString(response);
        }

        public async Task<IdCardResponse> IdentifyIdCard(string fileName, string fileData)
        {
            string response = await this.yunMaiHelper.Upload(fileData, fileName, "idcard", this.IdCardBoundary);
            return this.GetIdDataFromString(response);
        }

        private BankCardResponse GetBankCardDataFromString(string value)
        {
            try
            {
                Regex regex = new Regex("<fieldset>[\\s\\S]*?</fieldset>", RegexOptions.IgnoreCase);
                MatchCollection ms = regex.Matches(value);
                Match mm = ms[1];
                string temp = HttpUtility.HtmlDecode(mm.Value.Trim());

                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + temp;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode xn = doc.SelectSingleNode("fieldset");
                XmlNodeList xnl = xn.ChildNodes;
                BankCardResponse info = new BankCardResponse();

                info.Status = xnl[2].InnerText;
                info.BankCardNo = xnl[3].InnerText;
                info.BankName = xnl[4].InnerText;
                info.CardName = xnl[5].InnerText;
                info.CardType = xnl[6].InnerText;

                return info;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private DriverCardResponse GetDriverDataFromString(string value)
        {
            try
            {
                Regex regex = new Regex("<fieldset>[\\s\\S]*?</fieldset>", RegexOptions.IgnoreCase);
                MatchCollection ms = regex.Matches(value);
                Match mm = ms[1];
                string temp = HttpUtility.HtmlDecode(mm.Value.Trim());

                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>" + temp;
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode xn = doc.SelectSingleNode("fieldset");
                XmlNodeList xnl = xn.ChildNodes;
                DriverCardResponse info = new DriverCardResponse();

                info.Name = xnl[1].InnerText;
                info.CardNo = xnl[2].InnerText;
                info.Sex = xnl[3].InnerText;
                info.Birthday = xnl[4].InnerText;
                info.Address = xnl[5].InnerText;
                info.IssueDate = xnl[6].InnerText;
                info.Nation = xnl[7].InnerText;
                info.DrivingType = xnl[8].InnerText;
                info.RegisterDate = xnl[9].InnerText;
                info.ValidPeriod = Convert.ToInt32(xnl[10].InnerText.Replace("年", ""));

                return info;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private IdCardResponse GetIdDataFromString(string value)
        {
            try
            {
                Regex regex = new Regex("[^>]*(?=</fieldset>)", RegexOptions.IgnoreCase);
                MatchCollection ms = regex.Matches(value);
                Match mm = ms[2];
                string temp = HttpUtility.HtmlDecode(mm.Value.Trim());

                string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><root>" + temp + "</root>";
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode xn = doc.SelectSingleNode("root");
                XmlNodeList xnl = xn.ChildNodes;
                IdCardResponse info = new IdCardResponse();

                info.Name = xnl[0].InnerText;
                info.CardNo = xnl[1].InnerText;
                info.Sex = xnl[2].InnerText;
                info.Folk = xnl[3].InnerText;
                info.Birthday = xnl[4].InnerText;
                info.Address = xnl[5].InnerText;
                info.IssueAuthority = xnl[6].InnerText;
                info.ValidPeriod = xnl[7].InnerText;

                return info;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}