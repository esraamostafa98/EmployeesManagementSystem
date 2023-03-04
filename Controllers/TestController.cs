using Microsoft.AspNetCore.Mvc;
using WebApplication1.BL.Interfaces;

namespace WebApplication1.Controllers
{
    public class TestController : Controller
    {
        private readonly IEmployeeRep employee;

        public TestController(IEmployeeRep Employee) {
            employee = Employee;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Display(string name)
        {
            var data = "Welcome "+ name;
            return Json(data);
        }
    }
}
