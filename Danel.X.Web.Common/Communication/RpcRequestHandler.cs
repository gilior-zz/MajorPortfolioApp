using Danel.Common;
using Danel.Common.Api.Request;
using Danel.Common.Api.Response;
using Danel.Common.Expansion;
using Danel.Common.Utils;
using Danel.X.Web.Common.SA;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Danel.X.Web.Common.Communication
{
   
    public class RpcRequestHandler : IRequestHandler
    {
        public LoginResponse Login(LoginRequest request)
        {
            return new ApiWebSA().Login(request);
        }

        public NewRegisterResponse NewRegister(NewRegisterRequest request)
        {
            return new ApiWebSA().NewRegister(request);
        }


        public DanelDataResponse HandleRequest(DanelDataRequest request)
        {          
            return new ApiWebSA().HandleRequest(request);
        }

    }
}
