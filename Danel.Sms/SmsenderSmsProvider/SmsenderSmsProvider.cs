using System;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Web;


namespace Danel.Sms
{
    public class SmsenderSmsProvider : SmsProviderBase
    {






        public override string SendSms(string msgText, string user, string password, string senderPhone, params string[] nums)
        {
            foreach (string PhoneNumber in nums)
            {
                /*send msgText to the specific phoneNumer*/
                sendSmsPerPhone(msgText, user, password, senderPhone, PhoneNumber);
            }

            return Ok;
        }

        void sendSmsPerPhone(string msgText, string user, string password, string senderPhone, String PhoneNumber)
        {
            /*the order is : 1. smsPrefix ; 2. the smsContent; 
             * 3. the smsMidlePrefix ; 4 . the phoneNumber
             */
            const string smsPrefix = "http://www.smsender.co.il/sendsms.aspx?msg=";

            string smsMidlePrefix = string.Format("&name={0}&pass={1}&codepage=65001&from={2}&to={3}", user, password,senderPhone,PhoneNumber);
            //"&name=28656106&pass=FLJ56GFLT&codepage=65001&from=0737414443&to=";
            string errorMessage = string.Empty;

            string encodedText = HttpUtility.UrlEncode(msgText);

            var uri = smsPrefix + encodedText + smsMidlePrefix;

            var wr = WebRequest.Create(uri);
            try
            {
                var stream = wr.GetResponse().GetResponseStream();
                /*this part is optional - decide if we want to check the answer*/
                /*and if we don't want - we can omit the GetResponseStream() order*/
                var sr = new StreamReader(stream);
                var answer = sr.ReadToEnd();

                if (!answer.Contains("SMS Send OK"))
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