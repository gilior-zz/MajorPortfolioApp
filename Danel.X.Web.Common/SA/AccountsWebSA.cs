//using System;
//using Danel.Common.Api.Request;
//using Danel.Common.Api.Response;
//using Danel.Common.Interfaces;

//namespace Danel.X.Web.Common.SA
//{
//    internal class AccountsWebSA : BaseServiceAgentWeb
//    {
//        public LoginResponse LoginWebUser(LoginRequest loginRequset)
//        {
//            string url = GetRemotingServiceUri("UsersSF");
//            var usersSF = (IUserSF)Activator.GetObject(typeof(IUserSF), url);
            
//            return usersSF.LoginWebUser(loginRequset);
//        }
//    }
//}