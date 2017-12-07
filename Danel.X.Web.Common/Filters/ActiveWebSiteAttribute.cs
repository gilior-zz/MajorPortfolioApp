using Danel.Common;
using Danel.X.WebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Danel.X.Web.Common.Communication
{
    public class ActiveWebSiteAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(HttpActionContext actionContext)
        {

            var isActiveWebsite = ParameterService.GetParametervalue(WebParameter.IsActiveWebSite, true);
                    if (!isActiveWebsite)
                        throw new DanelException(ErrorCode.InactiveWebSite, "אתר אינו זמין");
                

            
        }
    }
}