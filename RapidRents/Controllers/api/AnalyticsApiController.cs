using RapidRents.Web.Models.Requests.Analytics;
using RapidRents.Web.Models.Responses;
using RapidRents.Web.Services;
using RapidRents.Web.Services.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RapidRents.Web.Controllers.Api
{
    [RoutePrefix("api/analytics")]
    public class AnalyticsApiController : ApiController
    {
        public IAnalyticsService _analyticService = null;
        public IUserService _userService = null;
        public AnalyticsApiController(IAnalyticsService analyticService, IUserService userService)
        {
            _analyticService = analyticService;
            _userService = userService;
        }


        [Route, HttpGet]
        public HttpResponseMessage StoreAnalytics([FromUri] AnalyticsAddRequest model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _analyticService.Insert(model, userId);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

        [Route("V2"), HttpGet]
        public HttpResponseMessage StoreAnalyticsV2([FromUri] AnalyticsAddRequest model)
        {
            string userId = _userService.GetCurrentUserId();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            _analyticService.InsertV2(model, userId);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);

        }

    }
}
