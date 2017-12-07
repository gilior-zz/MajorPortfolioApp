using System;

namespace Danel.Sms
{
    // SmsProviderManager.Instance.GetProvider(SmsProvider).SendSms(message, phoneNumbersList);
    public class SmsProviderManager
    {

        private SmsProviderManager()
        {
        }

        private static SmsProviderManager _instacne;
        public static SmsProviderManager Instance
        {
            get { return _instacne ?? (_instacne = new SmsProviderManager()); }
        }

        public ISmsProvider GetProvider(string providerName)
        {
            if (providerName == "") // Does not send sms
                return new EmptySmsProvider();

            if (providerName == "SmsenderSmsProvider")
                return new SmsenderSmsProvider();

            if (providerName == "InfrouSmsProvider")
                return new InfrouSmsProvider();

            throw new Exception("The Sms Provider Name " + providerName + " Is not Supported By Danel.Sms Please Contact Danel");
        }
    }
}