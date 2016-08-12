using RapidRents.Web.Models.Requests.Amenities;
using RapidRents.Web.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RapidRents.Web.Services.AmenitiesServices;
using RapidRents.Web.Services;
using RapidRents.Web.Domain;

namespace RapidRents.Web.Controllers.Api
{
    [RoutePrefix("api/amenities")]
    public class AmenitiesApiController : ApiController
    {
        public IAmenitiesService _service = null; //difference between this line and "public IFAQService service"? Also, explain "this" keyword in constructor from wiki example
        public IUserService _userService = null;

        public AmenitiesApiController(IAmenitiesService service, IUserService UserService)
        {
            _service = service;
            _userService = UserService;
        }

        [Route, HttpPost]
        public HttpResponseMessage Insert(AmenitiesAddRequest model)
        {
            string userId = _userService.GetCurrentUserId(); //this is where the userId is.

            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            ItemResponse<int> response = new ItemResponse<int>();

            response.Item = _service.Insert(model);
            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Update(AmenitiesUpdateRequest model)
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
            ItemsResponse<Amenity> response = new ItemsResponse<Amenity>();

            response.Items = _service.Get();

            return Request.CreateResponse(response);
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            ItemResponse<Amenity> response = new ItemResponse<Amenity>();

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
