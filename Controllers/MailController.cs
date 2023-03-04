using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using WebApplication1.BL.Helper;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
   
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(MailVM Mail)
        {
            TempData["msg"]= MailHelper.sendMail(Mail.Title, Mail.Message);
            return RedirectToAction("Index");
        }
        public IActionResult MailBox ()
        {
            return View();
        }
    }
}
