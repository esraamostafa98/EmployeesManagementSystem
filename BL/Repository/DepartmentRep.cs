using AutoMapper;
using WebApplication1.BL.Interfaces;
using WebApplication1.DAL.Database;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly DbContainer db;
        private readonly IMapper mapper;

        //  private DbContainer db = new DbContainer();
        public DepartmentRep(DbContainer db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public void Add(DepartmentVM dept)
        {
            //Department d=new Department();
            //d.DepartmentName = dept.DepartmentName;
            //d.DepartmentCode = dept.DepartmentCode;
            var data = mapper.Map<Department>(dept);
            db.Department.Add(data);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
           var DeletedObj=db.Department.Find(id);
            db.Department.Remove(DeletedObj);
            db.SaveChanges();
        }

        public void Edit(DepartmentVM dept)
        {
            //var OldData = db.Department.Find(dept.ID);

            //OldData.DepartmentName=dept.DepartmentName;
            //OldData.DepartmentCode=dept.DepartmentCode;
            var data=mapper.Map<Department>(dept);
            db.Entry(data).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }

        public IQueryable<DepartmentVM> Get()
        {
            var data = db.Department.Select(c => new DepartmentVM { ID = c.Id, DepartmentName = c.DepartmentName, DepartmentCode = c.DepartmentCode });
            return data;
        }

        public DepartmentVM GetById(int id)
        {
            DepartmentVM? data = GetDeptById(id);
            return data;
        }

        private DepartmentVM? GetDeptById(int id)
        {
            return db.Department.Where(a => a.Id == id)
                                    .Select(c => new DepartmentVM { ID = c.Id, DepartmentName = c.DepartmentName, DepartmentCode = c.DepartmentCode })
                                    .FirstOrDefault();
        }
    }
}
