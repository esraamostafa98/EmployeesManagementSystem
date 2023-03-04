
using AutoMapper;
using WebApplication1.BL.Helper;
using WebApplication1.BL.Interfaces;
using WebApplication1.BL.Repository;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class EmployeeRep : IEmployeeRep
    {

        private readonly DbContainer db;
        private readonly IMapper mapper;

        //  private DbContainer db = new DbContainer();
        public EmployeeRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }
        public void Add(EmployeeVM emp)
        {
           
            var data = mapper.Map<Employee>(emp);
            data.PhotoName = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
            data.CVName = UploadFileHelper.SaveFile(emp.CVUrl, "Docs");

            db.Employee.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var DeletedObj = db.Employee.Find(id);
            db.Employee.Remove(DeletedObj);
            UploadFileHelper.RemoveFile("Photos", DeletedObj.PhotoName);
            UploadFileHelper.RemoveFile("Docs", DeletedObj.CVName);
            db.SaveChanges();
        }

        public void Edit(EmployeeVM emp)
        {
            var data = mapper.Map<Employee>(emp);
            data.PhotoName = UploadFileHelper.SaveFile(emp.PhotoUrl, "Photos");
            data.CVName = UploadFileHelper.SaveFile(emp.CVUrl, "Docs");

            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<EmployeeVM> Get()
        {
            var data = db.Employee.Select(c => new EmployeeVM { Id = c.Id, Name = c.Name,
                                          Salary = c.Salary, Address = c.Address, Email = c.Email, 
                                          IsActive = c.IsActive, Note = c.Note, HireDate = c.HireDate,
                                          DepartmentId=c.Department.Id,DepartmentName=c.Department.DepartmentName ,
                                          DistrictId = c.DistrictId, DistrictName =c.District.DistrictName,
                                          PhotoName = c.PhotoName,CVName = c.CVName
            });
            return data;
        }

        public EmployeeVM GetById(int id)
        {
            return db.Employee.Where(a => a.Id == id)
                              .Select(c => new EmployeeVM { Id = c.Id, Name = c.Name, Salary = c.Salary, 
                               Address = c.Address, Email = c.Email, IsActive = c.IsActive, Note = c.Note, 
                               HireDate = c.HireDate, DepartmentId = c.Department.Id, DepartmentName = c.Department.DepartmentName,
                                  DistrictId = c.DistrictId,
                                  DistrictName = c.District.DistrictName,
                                   PhotoName= c.PhotoName,CVName=c.CVName})
                              .FirstOrDefault();
        }
    }
}


                           