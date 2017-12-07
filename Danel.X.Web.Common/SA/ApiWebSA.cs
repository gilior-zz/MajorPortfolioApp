using System;
using Danel.Common.Api.Request;
using Danel.Common.Api.Response;
using Danel.Common.Interfaces;
using Danel.Common;

namespace Danel.X.Web.Common.SA
{
    internal class ApiWebSA : BaseServiceAgentWeb
    {

        public LoginResponse Login(LoginRequest request)
        {
            var url = GetRemotingServiceUri("ApiSF");

            IApiSF apiSF = (IApiSF)Activator.GetObject(typeof(IApiSF), url);
            return apiSF.Login(request);
        }

        public NewRegisterResponse NewRegister(NewRegisterRequest request)
        {
            var url = GetRemotingServiceUri("ApiSF");

            IApiSF apiSF = (IApiSF)Activator.GetObject(typeof(IApiSF), url);
            return apiSF.NewRegister(request);
        }

        public DanelDataResponse HandleRequest(DanelDataRequest requset)
        {
            var url = GetRemotingServiceUri("ApiSF");
            IApiSF apiSF = (IApiSF)Activator.GetObject(typeof(IApiSF), url);
            try
            {
                var res = apiSF.HandleRequest(requset);
                if (res.ResponseCode == ResponseCode.AuthorizationFaild)
                    throw new DanelException(ErrorCode.InternalServerError, "AuthorizationFaild");
                return res;
            }
            catch (Exception)
            {
                throw new DanelException(ErrorCode.InternalServerError, "InternalServerError");
            }
        }
    }
}