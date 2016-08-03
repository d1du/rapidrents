using System.Web.Mvc;

namespace Sabio.Web.Controllers
{
    [Authorize]
    [RoutePrefix("listings/wizard")]
    public class PropertyListingWizardController : BaseController
    {
        [Route]
        public ActionResult Add()
        {
            return View();
        }
    }
}