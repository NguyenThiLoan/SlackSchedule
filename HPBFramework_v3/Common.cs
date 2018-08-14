using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Security;
using System.Reflection;
using System.Resources;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Configuration;

static public class Common
{
    /// <summary>
    /// Converts to unsign.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <returns></returns>
    public static string ConvertToUnsign(string str)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = str.Normalize(NormalizationForm.FormD);
        return regex.Replace(temp, String.Empty)
                    .Replace('\u0111', 'd').Replace('\u0110', 'D');
    }

    /// <summary>
    /// Gets the value from configuration.
    /// </summary>
    /// <param name="ConfigKey">The configuration key.</param>
    /// <returns></returns>
    public static string GetValueFromConfig(string ConfigKey)
    {
        return System.Web.Configuration.WebConfigurationManager.AppSettings[ConfigKey];
    }

    ///// <summary>
    ///// Gets the string from RESX.
    ///// </summary>
    ///// <param name="resourceKey">The resource key.</param>
    ///// <returns></returns>
    //public static string GetStringFromResx(string resourceKey)
    //{
    //    ResourceManager rm = null;
    //    rm = new ResourceManager("HPBFramework.Resources.Resource", Assembly.GetExecutingAssembly());
    //    return rm.GetString(resourceKey) ?? "";
    //}

    ///// <summary>
    ///// Gets the string from RESX.
    ///// </summary>
    ///// <param name="resourceName">Name of the resource.</param>
    ///// <param name="resourceKey">The resource key.</param>
    ///// <returns></returns>
    //public static string GetStringFromResx(string resourceName, string resourceKey)
    //{
    //    ResourceManager rm = null;
    //    rm = new ResourceManager("HPBFramework.Resources." + resourceName, Assembly.GetExecutingAssembly());
    //    return rm.GetString(resourceKey) ?? "";
    //}

    #region "DateTime Format"
    /// <summary>
    /// Formats the date time jp.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="weekday">if set to <c>true</c> [weekday].</param>
    /// <returns></returns>
    public static string FormatDateTimeJP(DateTime dateTime, bool weekday = false)
    {
        string dateTimeFormated = String.Format("{0:yyyy年MM月dd日}", dateTime);
        if (weekday)
        {
            dateTimeFormated += String.Format(" ({0})", GetWeekday(dateTime));
        }
        return dateTimeFormated;
    }
    /// <summary>
    /// Formats the date time jp.
    /// </summary>
    /// <param name="datetime">The datetime.</param>
    /// <param name="weekday">if set to <c>true</c> [weekday].</param>
    /// <returns></returns>
    public static string FormatDateTimeJP(string datetime, bool weekday = false)
    {
        return FormatDateTimeJP(DateTime.ParseExact(datetime, "yyyyMMdd", null), weekday);
    }
    /// <summary>
    /// Gets the weekday.
    /// </summary>
    /// <param name="datetime">The datetime.</param>
    /// <returns></returns>
    public static string GetWeekday(DateTime datetime)
    {
        switch (datetime.DayOfWeek)
        {
            case DayOfWeek.Sunday:
                return "日曜日";
            case DayOfWeek.Monday:
                return "月曜日";
            case DayOfWeek.Tuesday:
                return "火曜日";
            case DayOfWeek.Wednesday:
                return "水曜日";
            case DayOfWeek.Thursday:
                return "木曜日";
            case DayOfWeek.Friday:
                return "金曜日";
            case DayOfWeek.Saturday:
                return "土曜日";
            default:
                return "";
        }
    }
    /// <summary>
    /// Gets the weekday.
    /// </summary>
    /// <param name="datetime">The datetime.</param>
    /// <returns></returns>
    public static string GetWeekday(string datetime)
    {
        return GetWeekday(DateTime.ParseExact(datetime, "yyyyMMdd", null));
    }
    #endregion
    
    /// <summary>
    /// Gets the adress from post code.
    /// </summary>
    /// <param name="postcode">The postcode.</param>
    /// <returns></returns>
    public static string[] GetAdressFromPostCode(string postcode)
    {
        var listPostAddress = new List<PostAddress>();
        using (TextReader fileReader = File.OpenText(HttpContext.Current.Server.MapPath("~/App_Data/KEN_ALL.csv")))
        {
            var csv = new CsvReader(fileReader);
            csv.Configuration.HasHeaderRecord = false;
            csv.Configuration.RegisterClassMap<PostAddressMap>();
            while (csv.Read())
            {
                listPostAddress.Add(csv.GetRecord<PostAddress>());
            }
        }
        postcode = postcode.Replace("-", "");
        var postAddress = listPostAddress.FirstOrDefault(p => p.PostCode == postcode);
        if (postAddress == null)
        {
            return new string[2] { "", "" };
        }

        return new string[2] { 
            string.Format("{0}、{1}、{2}", postAddress.Province, postAddress.District, postAddress.Address),
            string.Format("{0}、{1}、{2}", postAddress.ProvinceKana, postAddress.DistrictKana, postAddress.AddressKana)};
    }
	
	   public static string GetFileUploadSize()
    {
        return GetValueFromConfig("FileUploadSize");
    }
    public static string MailAttachFileSize()
    {
        return GetValueFromConfig("MailAttachFileSize");
    }

    public static string ConvertBytesToMegabytes(long bytes)
    {
        return ((bytes / 1024f) / 1024f).ToString()+"MB ";
    }

    public static string GetLoginUserAttr(System.Security.Principal.IPrincipal User, string claimType)
    {
        return ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(u => u.Type == claimType).Select(c => c.Value).First();
    }

    //public static string GetLoginUserAttr(object sessionUser, string claimType)
    //{
    //    return ((System.Security.Claims.ClaimsIdentity)User.Identity).Claims.Where(u => u.Type == claimType).Select(c => c.Value).First();
    //}

    /// <summary>
    /// Sends the mail.
    /// </summary>
    /// <param name="bcc">The BCC.</param>
    /// <param name="cc">The cc.</param>
    /// <param name="emailto">The emailto.</param>
    /// <param name="subject">The subject.</param>
    /// <param name="body">The body.</param>
    /// <param name="AttachFilePath">The attach file path.</param>
    public static bool SendMail(string bcc, string cc, string emailto, string subject, string body, string AttachFilePath)
    {
        try
        {
            if (emailto == "") return false;
            System.Configuration.Configuration webConfig = WebConfigurationManager.OpenWebConfiguration("~/web.config");
            MailSettingsSectionGroup mailSettings = webConfig.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
            SmtpClient smtp = new SmtpClient
            {
                Host = mailSettings.Smtp.Network.Host,
                Port = mailSettings.Smtp.Network.Port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials =
                    new NetworkCredential(mailSettings.Smtp.Network.UserName,
                                          mailSettings.Smtp.Network.Password)
            };
            using (var message = new MailMessage(mailSettings.Smtp.From, emailto)
            {
                SubjectEncoding = Encoding.UTF8,
                BodyEncoding = Encoding.UTF8,
                Subject = subject,
                Body = body,
                IsBodyHtml = true,

            })
            {
                if (!string.IsNullOrEmpty(cc))
                {
                    message.CC.Add(cc);
                }
                if (!string.IsNullOrEmpty(bcc))
                {
                    message.Bcc.Add(bcc);
                }
                if (!string.IsNullOrEmpty(AttachFilePath))
                {
                    Attachment file = new Attachment(AttachFilePath, MediaTypeNames.Application.Octet);
                    message.Attachments.Add(file);
                }
                ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                { return true; };
                smtp.Send(message);

            }
            return true;
        }
        catch
        {
            return false;
        }

    }

}

public class PostAddress
{
    public string PostCode { get; set; }
    public string Province { get; set; }
    public string District { get; set; }
    public string DistrictKana { get; set; }
    public string ProvinceKana { get; set; }
    public string Address { get; set; }
    public string AddressKana { get; set; }
}

public sealed class PostAddressMap : ClassMap<PostAddress>
{
    public PostAddressMap()
    {
        AutoMap();
        Map(m => m.PostCode).Index(2);
        Map(m => m.ProvinceKana).Index(3);
        Map(m => m.DistrictKana).Index(4);
        Map(m => m.AddressKana).Index(5);
        Map(m => m.Province).Index(6);
        Map(m => m.District).Index(7);
        Map(m => m.Address).Index(8);
    }
}
