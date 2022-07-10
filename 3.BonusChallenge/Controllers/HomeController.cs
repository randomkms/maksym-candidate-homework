using _3.BonusChallenge;
using System.Web.Mvc;
using System.Web.UI;

namespace _3.BonusChallenge_1.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = Constants.OneDayInSeconds, Location = OutputCacheLocation.Client)]
        public ActionResult Index()
        {
            return View();
        }
    }
}