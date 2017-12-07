using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danel.Sms
{
    public class EmptySmsProvider : SmsProviderBase
    {




        public override string SendSms(string msgText, string user, string password, string senderPhone, params string[] nums)
        {
            return Ok;
        }
    }
}
