using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using Danel.X.Web.Data.Utils;
using Danel.X.Web.Common.Utiles;

namespace Danel.X.Web.Common.SA
{
    public class BaseServiceAgentWeb
    {
        protected string GetRemotingServiceUri(string remotingServiceName)
        {
            string res = string.Format("{0}:{1}/{2}", WebConfigManager.Instance["Path"], WebConfigManager.Instance["Port"], remotingServiceName);
            return res;
        }

    }
}