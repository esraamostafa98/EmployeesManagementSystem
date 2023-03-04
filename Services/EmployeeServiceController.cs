using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Services
{
    public class EmployeeServiceController : Controller
    {
        [Route("/EmployeeService/GitCity")]
        public JsonResult GitCity()
        {

            return Json("");
        }
    }
}
