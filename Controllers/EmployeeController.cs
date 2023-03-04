using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using WebApplication1.BL.Interfaces;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Authorize(Roles ="User,Hr,Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRep Employee;
        private readonly IDepartmentRep Department;
        private readonly ICountryRep Country;
        private readonly ICityRep City;
        private readonly IDistrictRep District;


        public EmployeeController(IEmployeeRep Employee, IDepartmentRep Department, ICountryRep Country, ICityRep City, IDistrictRep District)
        {
            this.Employee = Employee;
            this.Department = Department;
            this.Country = Country;
            this.City = City;
            this.District = District;

        }

        public IActionResult Index()
        {

            var data = Employee.Get();
            return View(data);
        }

        public IActionResult Create()
        {
            var data = Department.Get();
            var Countrydata = Country.Get();
            ViewBag.DepartmentList = new SelectList(data, "ID", "DepartmentName");
            ViewBag.CountryList = new SelectList(Countrydata, "Id", "CountryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                
                    Employee.Add(emp);
                    return RedirectToAction("Index", "Employee");
                }
                var data = Department.Get();
                ViewBag.DpartmentList = new SelectList(data, "ID", "DepartmentName");
                return View(emp);
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(emp);
            }

        }
        public IActionResult Details(int id)
        {
            var data = Employee.GetById(id);
        var dataDept = Department.Get();
        var countrydata = Country.Get();
           

        ViewBag.DepartmentList = new SelectList(dataDept, "ID", "DepartmentName", data.DepartmentId);
        ViewBag.CountryList = new SelectList(countrydata, "Id", "CountryName", data.DistrictId);

            return View(data);

        
    }
        public IActionResult Edit(int id)
        {
            var data = Employee.GetById(id);
            var dataDept = Department.Get();
            var Countrydata = Country.Get();
          
            ViewBag.CountryList = new SelectList(Countrydata, "Id", "CountryName");
            ViewBag.DpartmentList = new SelectList(dataDept, "ID", "DepartmentName",data.DepartmentId);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee.Edit(emp);
                    return RedirectToAction("Index", "Employee");
                }
                else {
                    var dataDept = Department.Get();
                    ViewBag.DpartmentList = new SelectList(dataDept, "ID", "DepartmentName", emp.DepartmentId);
                    return View(emp);
                }

                
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                //EventLog log = new EventLog();
                //log.Source = "Admin Dashboard";
                //log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View(emp);
            }
        }

        public IActionResult Delete(int id)
        {
            var data = Employee.GetById(id);
            var dataDept = Department.Get();
            ViewBag.DpartmentList = new SelectList(dataDept, "ID", "DepartmentName", data.DepartmentId);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfermDelete(int id)
        {
            try
            {
                Employee.Delete(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                EventLog log = new EventLog();
                log.Source = "Admin Dashboard";
                log.WriteEntry(ex.Message, EventLogEntryType.Error);
                return View();
            }
        }
        [HttpPost]
        public JsonResult GitCityByCountryId(int countryId)
        {
            var data=City.Get().Where(a=>a.CountryId == countryId);
            return Json(data);
        }
        [HttpPost]
        public JsonResult GitDistrictByCityId(int cityId)
        {
            var data = District.Get().Where(a => a.CityId == cityId);
            return Json(data);
        }
    }
}
