using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Danel.X.Web.Common
{
    public enum ErrorCode
    {
        None = 0,
        InternalServerError = 1,
        ServerNotAvailable = 2,
        SecurityError = 3,
        InvalidAccountNumber = 4,
        CSRFValidationFailed = 5,
        TempPasswordExpired = 6,
        InvalidTempPassword = 7,
        AlreadyWebUser = 8,
        NoSuchAccountOwner = 9,
        UnRecongnisedEmail = 10,
        AlreadyAnotherWebUser = 11,
        AlreadyRegisteredIdentityNumber = 12,
        AlreadyRegisteredEmail = 13,
        Error = 14,
        NoSuchIdentityNumber = 15,
        NoSuchPhone = 16,
        AlreadyRegisteredPhone = 17,
        DuplicatedPassword = 18,
        PreviousPasswordIncncorrect = 19,
        PasswordAlreadyInHistory = 20,
        MailSendFailure = 21,
        invalidUserName = 22,
        Unknown = 23,
        InactiveWebSite = 24,
        NoValidSMSProvider = 25,
        EmptyProvider = 26
    }

    public enum UserState
    {
        New, Exists
    }
}


