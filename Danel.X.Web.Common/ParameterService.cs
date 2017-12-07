using Danel.Common;
using Danel.Common.Expansion;
using Danel.X.Web.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Danel.X.WebApp.Common
{
    public static class ParameterService
    {
        public static T GetParametervalue<T>(WebParameter param, T replacmentValue)
        {
            var oldParameters = bool.Parse(ConfigurationManager.AppSettings["old-parameters"]);
            double paramValue = (long)param;
            if (oldParameters)
            {
                paramValue = Math.Pow(2, paramValue);
            }
            var generalParameters = WebCacheManager.Instance.GetValue<Dictionary<WebParameter, string>>("generalParameters", null);
            if (generalParameters == null) return replacmentValue;
            var matchingKVPs = generalParameters.Where(i => (long)i.Key == paramValue);
            if (!matchingKVPs.Any()) return replacmentValue;

            var kvp = matchingKVPs.FirstOrDefault();
            if (kvp.Equals(default(KeyValuePair<WebParameter, string>))) return replacmentValue;

            var kvpValue = kvp.Value;
            if (kvpValue == null) return replacmentValue;

            var obj = Convert.ChangeType(kvpValue, typeof(T));
            return (T)obj;
        }

        public static Dictionary<WebParameter, string> GetAllParameter()
        {
            var generalParameters = WebCacheManager.Instance.GetValue<Dictionary<WebParameter, string>>("generalParameters", null);
            if (generalParameters == null) return null;
            return generalParameters;
        }



        public static DateTime GetParsedDate()
        {

            DateTime parameterToDate = DateTime.Now;
            try
            {
                var val = GetParametervalue(WebParameter.WebsiteDataToDate, "");
                parameterToDate = val.GetValidDate();
            }
            catch (Exception) { }
            return parameterToDate;
        }
    }
}