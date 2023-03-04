using Microsoft.AspNetCore.Mvc;
using System.Drawing.Text;
using WebApplication1.BL.Repository;
using WebApplication1.DAL.Database;
using WebApplication1.Models;
using System.Diagnostics;
using WebApplication1.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    
    public class DepartmentController : Controller
    {
        //private readonly DepartmentRep Department;
        private readonly IDepartmentRep Department;

        public DepartmentController(IDepartmentRep Department)
        {
           this.Department = Department;
        }

        public IActionResult Index()
        {

            var data = Department.Get();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentVM dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department.Add(dept);
                    return RedirectToAction("Index", "Department");
                }

                return View(dept);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(dept);
            }

        }

        public IActionResult Edit(int id)
        {
            var data=Department.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(DepartmentVM dept)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Department.Edit(dept);
                    return RedirectToAction("Index", "Department");
                }

                return View(dept);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(dept);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = Department.GetById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfermDelete(int id)
        {
            try
            {
                    Department.Delete(id);
                    return RedirectToAction("Index", "Department");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View();
            }
        }
    }
}
