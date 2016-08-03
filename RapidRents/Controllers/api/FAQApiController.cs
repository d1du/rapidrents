using Sabio.Web.Models.Requests.FAQ;
using Sabio.Web.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sabio.Web.Services.FAQ;
using Sabio.Web.Services;
using Sabio.Web.Domain;

namespace Sabio.Web.Controllers.Api
{
    [RoutePrefix("api/faq")] 
    public class FAQApiController : ApiController
    {
        public IFAQService _service = null; //difference between this line and "public IFAQService service"? Also, explain "this" keyword in constructor from wiki example
        public IUserService _userService = null;

        public FAQApiController(IFAQService service, IUserService UserService)
        {
            _service = service;
            _userService = UserService;
        }

        [Route, HttpPost]
        public HttpResponseMessage Insert(FAQAddRequest model)
        {
            string userId = _userService.GetCurrentUserId(); //this is where the userId is.
            // if the Model does not pass validation, there will be an Error response returned with errors
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();
            
            response.Item = _service.Insert(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(FAQUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            SuccessResponse response = new SuccessResponse();
            _service.Update(model);
            
            return Request.CreateResponse(response);
        }

        [Route, HttpGet]
        public HttpResponseMessage GetList()
        {
            ItemsResponse<Faq> response = new ItemsResponse<Faq>();

            response.Items = _service.Get();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<Faq> response = new ItemResponse<Faq>();

            response.Item = _service.GetById(id);

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _service.Delete(id);

            SuccessResponse response = new SuccessResponse();

            return Request.CreateResponse(response);
        }

    }


}
