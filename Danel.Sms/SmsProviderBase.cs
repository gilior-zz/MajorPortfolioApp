using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danel.Sms
{
    public abstract class SmsProviderBase : ISmsProvider
    {
       

        public abstract string SendSms(string msgText, string user, string password, string senderPhone, params string[] nums);
       

        public const string Ok = "Ok";
        public const string Error = "Error";
    }
}
