using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Web;
using System.Xml.Linq;
using System.Linq;

namespace Danel.Sms
{
    public class InfrouSmsProvider : SmsProviderBase
    {

        public override string SendSms(string msgText, string user, string password, string senderPhone, params string[] nums)
        {
            /*send the msgText to all the phone number*/

            foreach (string PhoneNumber in nums)
            {
                /*send msgText to the specific phoneNumer*/
                sendSmsPerPhone(msgText, PhoneNumber, user, password, senderPhone);
            }

            return Ok;
        }

        void sendSmsPerPhone(string msgText, String PhoneNumber, string user, string password, string senderPhone)
        {

            string msg;

            var str = @"<Inforu><User><Username></Username><Password></Password></User><Content Type='sms'><Message>
             </Message></Content><Recipients><PhoneNumber>
          </PhoneNumber></Recipients><Settings><Sender>*6212</Sender></Settings></Inforu>";

            XDocument xdoc = XDocument.Parse(str);
            var element = xdoc.Descendants("Username").FirstOrDefault();
            element.Value = user;
            element = xdoc.Descendants("Password").FirstOrDefault();
            element.Value = password;
            element = xdoc.Descendants("PhoneNumber").FirstOrDefault();
            element.Value = PhoneNumber;
            element = xdoc.Descendants("Sender").FirstOrDefault();
            element.Value = senderPhone;
            element = xdoc.Descendants("Message").FirstOrDefault();
            element.Value = HttpUtility.UrlEncode(msgText);

            msg = xdoc.ToString();



            string errorMessage = string.Empty;
            const string smsPrefix = "http://api.inforu.co.il/SendMessageXml.ashx?InforuXML=";
            var uri = smsPrefix + msg;

            var wr = WebRequest.Create(uri);
            try
            {
                var stream = wr.GetResponse().GetResponseStream();
                /*this part is optional - decide if we want to check the answer*/
                /*and if we don't want - we can omit the GetResponseStream() order*/
                var sr = new StreamReader(stream);
                var answer = sr.ReadToEnd();

                if (!answer.Contains("Message accepted successfully"))
                {
                    //MailSender.Instance.SendMail("Bugs@spot-wise.com", "eli@Spot-wise.com", "Sms Transmission Error", "Error Response - \n" + answer);
                    //Logger.Logger.Instance.Write("Sms Transmission Error \n Error Response - \n" + answer);
                    errorMessage = "In SmsenderSmsProvider -> SendSms Error : " + answer;
                    throw new Exception(errorMessage);
                }
                /*end of optional part*/
            }
            catch (Exception ex)
            {
                errorMessage = "In SmsenderSmsProvider -> SendSms Error : " + ex.ToString();
                throw new Exception(errorMessage);
            }

        }
    }
}