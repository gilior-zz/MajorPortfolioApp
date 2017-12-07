using System;
using System.Globalization;
using System.IO;
using System.Linq;
using ActiveUp.Net.Mail;
using System.Collections.Generic;



namespace DanelWebMail
{
    public class MailRetriever
    {
        public static bool SavePushExcelFiles(string destUrl)
        {
            var mailRepository = new MailRepository("imap.gmail.com", 993, true, @"trigger@spot-wise.com", "SpotWise57");
            string fileUrl;

            try
            {
                IEnumerable<Message> Messages = mailRepository.GetUnreadMails("Inbox");
                foreach (Message emailMessage in Messages)
                {
                    if (emailMessage.Attachments.Count > 0)
                    {
                        foreach (MimePart attachment in emailMessage.Attachments)
                        {
                            if (attachment.ContentType.MimeType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
                            {
                                fileUrl = destUrl + emailMessage.From.Email + "___" + (DateTime.UtcNow.ToString(CultureInfo.InvariantCulture).Replace(':', '.')).Replace('/', '-') + "_" + RandAlphanumericString(3) + ".xlsx";
                                var fileStream = new FileStream(fileUrl, FileMode.CreateNew);
                                fileStream.Write(attachment.BinaryContent, 0, attachment.Size);
                                fileStream.Close();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //Logger.Logger.Instance.Write("Exception" + "\n" + ex.ToString());
                return false;
            }

            return true;
        }

        private static string RandAlphanumericString(int charCount)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            var result = new string(Enumerable.Repeat(chars, charCount).Select(s => s[random.Next(s.Length)]).ToArray());

            return result;
        }


        //public static bool SavePushExcelFiles()
        //{
        //    var client = new ImapClient();
        //    var credentials = new NetworkCredential("bizspark@spot-wise.com", "ariegofer");
        //    var uri = new Uri("imaps://imap.gmail.com");

        //    var cancel = new CancellationTokenSource();
        //    client.Connect(uri, cancel.Token);

        //    // Note: since we don't have an OAuth2 token, disable
        //    // the XOAUTH2 authentication mechanism.
        //    client.AuthenticationMechanisms.Remove("XOAUTH");

        //    client.Authenticate(credentials, cancel.Token);

        //    // The Inbox folder is always available on all IMAP servers...
        //    var inbox = client.Inbox;
        //    inbox.Open(FolderAccess.ReadWrite, cancel.Token);

        //    //Console.WriteLine("Recent messages: {0}", inbox.Recent);

        //    while (inbox.FirstUnread != -1)
        //    {
        //        var mailMessage = inbox.GetMessage(inbox.FirstUnread, cancel.Token);

        //        inbox.Search(new SearchQuery(SearchTerm.New), cancel);

        //        foreach (MimePart part in mailMessage.Attachments)
        //        {
        //            if (part.IsAttachment &&
        //                part.ContentType.Name == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
        //            {
        //                var fileStream = new FileStream(@"C:\SpotWise\Access\Api\SpotWise.Api.Rest.Push.v1_0\Content\Reports\" + part.FileName, FileMode.CreateNew);
        //                part.WriteTo(new FormatOptions(), fileStream, cancel.Token);
        //                fileStream.Close();
        //            }
        //        }
        //    }

        //    client.Disconnect(true, cancel.Token);

        //    return true;
        //}

    }
}
