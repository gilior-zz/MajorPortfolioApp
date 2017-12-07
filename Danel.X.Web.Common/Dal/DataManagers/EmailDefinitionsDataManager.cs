using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Danel.Common.Api.Request;
using Danel.WebApp.Dal.Model;

namespace Danel.WebApp.Dal.DataManagers
{
    public class EmailDefinitionsDataManager : IEmailDefinitionsDataManager
    {
        public EmailDefinitionsRequest GetRequset(EmptyRequest req)
        {
            return new EmailDefinitionsRequest();
        }
    }
}