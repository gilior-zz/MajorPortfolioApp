using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Danel.Sms
{
    //i added the "public" before the interface
    public interface ISmsProvider
    {
        string SendSms(string msgText, string user, string password,string senderPhone, params string[] nums);
    }
}