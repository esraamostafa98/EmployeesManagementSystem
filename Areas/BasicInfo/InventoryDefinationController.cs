using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Areas.BasicInfo
{
    public class InventoryDefinationController : Controller
    {
        [Area("BasicInfo")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
