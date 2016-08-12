using RapidRents.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapidRents.Web.Controllers
{
    [Authorize]
    [RoutePrefix("amenities")]
    public class AmenitiesController : BaseController
    {
        [Route("add")]
        public ActionResult Add()
        {
            return View();
        }

    }
}
