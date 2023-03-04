using AutoMapper;
using WebApplication1.DAL.Entities;
using WebApplication1.Models;

namespace WebApplication1.BL.Mapper
{
    public class DomainProfile:Profile
    {
      public  DomainProfile() {
            CreateMap<DepartmentVM, Department>();
            CreateMap<Department, DepartmentVM>();

            CreateMap<EmployeeVM, Employee>();
            CreateMap<Employee, EmployeeVM>();
        }
    }
}
