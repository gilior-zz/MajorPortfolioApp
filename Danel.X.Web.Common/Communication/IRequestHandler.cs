using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Danel.Common.Api.Request;
using Danel.Common.Api.Response;

namespace Danel.X.Web.Common.Communication
{
    public interface IRequestHandler
    {
        LoginResponse Login(LoginRequest request);

        NewRegisterResponse NewRegister(NewRegisterRequest request);

        DanelDataResponse HandleRequest(DanelDataRequest request);
    }
}
