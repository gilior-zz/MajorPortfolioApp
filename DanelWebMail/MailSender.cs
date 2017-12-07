using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DanelWebMail
{
    public class MailSender
    {
        // Singleton Functions
        private MailSender() 
        {
            smtpClient = new SmtpClient {EnableSsl = true};
        }

        private static MailSender mailSender = null;
        public static MailSender Instance
        {
            get
            {
                if (mailSender == null)
                {
                    mailSender = new MailSender();
                }

                return mailSender;
            }
        }

        public void SendMail(string from, List<string> toList, string subject, string body, bool IsBodyHTML = false)
        {
            var mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(from);

            foreach (string to in toList)
            {
                mailMessage.To.Add(new MailAddress(to));
            }

            mailMessage.Subject = subject;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = IsBodyHTML;
          
            smtpClient.Send(mailMessage);
        }

        public void SendMail(string from, string to, string subject, string body, bool IsBodyHTML=false)
        {
            var toList = new List<string>();
            toList.Add(to);

            SendMail(from, toList, subject, body, IsBodyHTML);
        }

        public static bool IsEmailFormat(string email)
        {
            const string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                   + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                   + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private readonly SmtpClient smtpClient;

        public const int MailOk = 0;
        public const int MailFixed = 1;
        public const int MailCorrupted = 2;

    }
}

