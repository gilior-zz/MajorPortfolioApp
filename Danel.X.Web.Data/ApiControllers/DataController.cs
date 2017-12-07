using System;
using System.Collections.Generic;
using System.Web.Http;
using Danel.Common;
using Danel.Common.Api.Entity;
using Danel.Common.Api.Request;
using Danel.X.Web.Common.Communication;
using Danel.X.Web.Common.SA;
using Newtonsoft.Json;

namespace Danel.X.Web.Data.Controllers
{
    public class DataController : ApiController
    {
        //private IHttpActionResult LoginRequest(LoginRequest request)
        //{
        //    var loginResponse = new RpcRequestHandler().LoginRequest(request);

        //    if (loginResponse.LoginResult == LoginResults.OK)
        //        return Ok(loginResponse.UserInfo.TokenID);

        //    return Unauthorized();
        //}

        //public IHttpActionResult HandleRequest([FromBody]DanelDataRequest request)
        //{
        //    //DanelYieldRequest

        //    var loginRequest = new LoginRequest { RequestId = "17", UserName = "test@eli.com", UserPassword = "11" };

        //    var loginResponse = new RpcRequestHandler().LoginRequest(loginRequest);

        //    if (loginResponse.LoginResult != LoginResults.OK)
        //    {
        //        return Ok("Error Not Authorized");
        //    }

        //    request.UserToken = loginResponse.UserInfo.TokenID;

        //    var danelDataResponse = new RpcRequestHandler().HandleRequest(request);

        //    return Ok(danelDataResponse);
        //}

        //public IHttpActionResult GetJson()
        //{
        //    var req1 = new DanelYieldRequest { RequestId = "1234" };
        //    req1.DanelYieldDataRequestList = new List<DanelYieldDataRequest>();
        //    //req1.YieldPeriodDetailedLevelEnum
        //    var danelYieldDataRequest = new DanelYieldDataRequest
        //    {
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now,
        //        YieldPeriodDetailedLevelEnum = YieldPeriodDetailedLevelEnum.Monthly,
        //        YieldPeriodRequestType = YieldPeriodRequestType.YearlyTwelveMonth
        //    };

        //    var danelYieldDataRequest2 = new DanelYieldDataRequest
        //    {
        //        StartDate = DateTime.Now,
        //        EndDate = DateTime.Now,
        //        YieldPeriodDetailedLevelEnum = YieldPeriodDetailedLevelEnum.Quarterly,
        //        YieldPeriodRequestType = YieldPeriodRequestType.YearlyTwelveMonth
        //    };

        //    req1.DanelYieldDataRequestList.Add(danelYieldDataRequest);
        //    req1.DanelYieldDataRequestList.Add(danelYieldDataRequest2);
        //    req1.EntityList.Add(new DanelEntity { EntityType = ApiEntityType.WebUser, Id = "71" });

        //    var req = new CompoundRequest();
        //    req.Requests = new List<DanelDataRequest>();
        //    req.RequestId = "2222";
        //    req.Requests.Add(req1);

        //    return Ok(req);
        //}

        //public IHttpActionResult GetPortfolio(string entities)
        //{
        //    List<DanelEntity> l = new List<DanelEntity>();
        //    foreach (var item in entities.Split(','))
        //        l.Add(new DanelEntity() { Id = item });

        //    DanelPortfolioRequest d = new DanelPortfolioRequest() { EntityList = l };
        //    var danelDataResponse = new ApiWebSA().HandleRequest(d);
        //    string json = JsonConvert.SerializeObject(danelDataResponse);
        //    return Ok(danelDataResponse);
        //}

        //public IHttpActionResult GetTransacrions(string entities, DateTime from, DateTime to)
        //{
        //    List<DanelEntity> l = new List<DanelEntity>();
        //    foreach (var item in entities.Split(','))
        //        l.Add(new DanelEntity() { Id = item });

        //    DanelTransactionsRequest d = new DanelTransactionsRequest();
        //    d.Request.From = from;
        //    d.Request.To = to;
        //    d.EntityList = l;
        //    var danelDataResponse = new ApiWebSA().HandleRequest(d);
        //    string json = JsonConvert.SerializeObject(danelDataResponse);
        //    return Ok(danelDataResponse);

        //}

    }
}
