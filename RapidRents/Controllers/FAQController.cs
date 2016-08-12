using RapidRents.Web.Domain;
using RapidRents.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RapidRents.Web.Controllers
{
    [Authorize]
    [RoutePrefix("faqs")]
    public class FAQController : BaseController
    {
        [Route("add")]
        [Route("{id:int}/edit")]
        public ActionResult Add(int? id = null)
        {
            ItemViewModel<int?> model = new ItemViewModel<int?>();

            model.Item = id;

            return View(model);
        }

        [Route]
        public ActionResult List()
        {
            return View();
        }

        [Route("errorpage")]
        public ActionResult Error()
        {
            return View();
        }
    }
}
