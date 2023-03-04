using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.BasicInfo.Controllers
{
    [Area("BasicInfo")]
    public class BrachDefinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
